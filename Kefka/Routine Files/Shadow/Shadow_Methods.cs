using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Coroutines;
using Clio.Utilities;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Shadow
{
    public static partial class ShadowRotation
    {
        private static readonly Random _rnd = new Random();
        private static bool TCJMessage;
        private static DateTime TCJTimer;

        private static async Task<bool> DeathBlossomSpam()
        {
            if (Control.ModifierKeys != Keys.None && WindowCheck.ApplicationIsActivated())
                if (Keyboard.IsKeyDown(ShadowHotkeysModel.Instance.DbSpamKey))
                    await Spells.DeathBlossom.Use(Me, true);
            return false;
        }

        private static int AuraCount
        {
            get
            {
                var aura = ((BattleCharacter)Target)?.CharacterAuras?.ToArray();
                var value = aura?.Length ?? 0;
                return value;
            }
        }

        private static int GetMultiplier()
        {
            return _rnd.NextDouble() <= 0.5 ? 1 : -1;
        }

        private static async Task<bool> SpinningEdge()
        {
            return await Spells.SpinningEdge.Use(Target, true);
        }

        private static async Task<bool> ShadeShift()
        {
            return await Spells.ShadeShift.CastBuff(Me, ShadowSettingsModel.Instance.UseShadeShift && Me.CurrentHealthPercent <= ShadowSettingsModel.Instance.ShadeShiftHpPct, Auras.ShadeShift);
        }

        private static async Task<bool> GustSlash()
        {
            return await Spells.GustSlash.Use(Target, ActionManager.LastSpell == Spells.SpinningEdge);
        }

        private static async Task<bool> Assassinate()
        {
            return await
                    Spells.Assassinate.Use(Target,
                        ShadowSettingsModel.Instance.UseAssassinate && Target?.CurrentHealthPercent <= 20);
        }

        private static async Task<bool> ThrowingDagger()
        {
            if (BotManager.Current.IsAutonomous || ShadowSettingsModel.Instance.UseThrowingDagger)
            {
                return await Spells.ThrowingDagger.Use(Target, Target.Distance(Me) > 8);
            }
            return false;
        }

        public static async Task<bool> Mug()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseBuffs)
                return false;

            if (Target.HasAura(Auras.VulnerabilityUp))
                return await Spells.Mug.Use(Target, true);

            if ((Spells.TrickAttack.Cooldown.TotalMilliseconds >= 5000 || Target.HasAura(Auras.VulnerabilityUp)) &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Mug.Use(Target, true);
            }

            return false;
        }

        private static async Task<bool> Jugulate()
        {
            if (ShadowSettingsModel.Instance.UseManualInterrupt || Target == null || !Target.CanAttack) return false;

            if (ShadowSettingsModel.Instance.UseInterruptList && Target.CanSilence())
                return await Spells.Jugulate.Use(Target, true);

            return await Spells.Jugulate.Use(Target, true);
        }

        private static async Task<bool> DeathBlossom()
        {
            return await Spells.DeathBlossom.Use(Me,
            ShadowSettingsModel.Instance.UseAoE
            && ShadowSettingsModel.Instance.UseDeathBlossom
            && (ActionResourceManager.Ninja.HutonTimer.TotalMilliseconds >= ShadowSettingsModel.Instance.ArmorCrushRfsh || !ShadowSettingsModel.Instance.UseNinjutsu || Me.ClassLevel < 45)
            && Me.CurrentTP >= ShadowSettingsModel.Instance.TpLimit
            && Me.EnemiesInRange(8) >= ShadowSettingsModel.Instance.DeathBlossomMobCount);
        }

        private static async Task<bool> ComboFinal()
        {
            if (Target == null || !Target.CanAttack || (ActionManager.LastSpell != Spells.GustSlash && CombatHelper.LastSpell != Spells.GustSlash && CombatHelper.LastSpell != Spells.Duality))
                return false;

            if (ActionResourceManager.Ninja.HutonTimer.TotalSeconds > 0
                && (ActionResourceManager.Ninja.HutonTimer.TotalSeconds < CombatHelper.GCD * 3.5 || ActionResourceManager.Ninja.HutonTimer.TotalMilliseconds < ShadowSettingsModel.Instance.ArmorCrushRfsh))
            {
                return await Spells.ArmorCrush.Use(Target, true);
            }

            if (!Target.HasAura(Auras.ShadowFang, true, ShadowSettingsModel.Instance.ShadowFangRfsh)
                && (ActionResourceManager.Ninja.HutonTimer.TotalSeconds >= CombatHelper.GCD * 3.5 || !ShadowSettingsModel.Instance.UseNinjutsu || Me.ClassLevel < 45 || Me.CurrentJob == ClassJobType.Rogue)
                && !Me.HasAura(Auras.Duality)
                && CombatHelper.LastSpell != Spells.Duality
                && AuraCount <= 29)
            {
                return await Spells.ShadowFang.CastDot(Target, true, Auras.ShadowFang, 16000);
            }

            await Duality();

            if (Target.IsFlanking && Me.ClassLevel >= Spells.ArmorCrush.LevelAcquired)
            {
                return await Spells.ArmorCrush.Use(Target, true);
            }

            return await Spells.AeolianEdge.Use(Target, true);
        }

        private static async Task<bool> SmokeScreen()
        {
            if (ShadowSettingsModel.Instance.UseSmokeScreen) return false;

            var selectedSmokeScreenTarget = SmokeScreenTargetViewModel.Instance.SmokeScreenTarget;

            if (selectedSmokeScreenTarget.AllyIsValid() && ShadowSettingsModel.Instance.UseSmokeScreen && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.SmokeScreen.Use(selectedSmokeScreenTarget, true);
            }

            return false;
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, CombatHelper.OnGcd && Me.CurrentTP <= 550)
                && Target.HealthCheck(false);
        }

        private static async Task<bool> Bloodbath()
        {
            return await Spells.Bloodbath.CastBuff(Me, Me.CurrentHealthPercent <= ShadowSettingsModel.Instance.HealingHpPct, Auras.Bloodbath) && Target.HealthCheck(false);
        }

        private static async Task<bool> Feint()
        {
            return await Spells.Feint.CastDot(Target, ShadowSettingsModel.Instance.UseFeint
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.Feint);
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, Me.CurrentHealthPercent <= ShadowSettingsModel.Instance.HealingHpPct);
        }

        private static async Task<bool> Bhavacakra()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseBuffs || ActionResourceManager.Ninja.NinkiGauge < 80)
                return false;

            if (Target.HasAura(Auras.VulnerabilityUp))
                return await Spells.Bhavacakra.Use(Target, true);

            return await Spells.Bhavacakra.Use(Target, Spells.TrickAttack.Cooldown.TotalMilliseconds >= 5000
                                                       && Target.HealthCheck(false)
                                                       && Target.TimeToDeathCheck());
        }

        private static async Task<bool> HellfrogMedium()
        {
            if (ActionResourceManager.Ninja.NinkiGauge < 80) return false;

            if (ShadowSettingsModel.Instance.UseAoE && Target.EnemiesInRange(8) >= ShadowSettingsModel.Instance.MobCount)
                return await Spells.HellfrogMedium.Use(Target, true);

            return await Spells.HellfrogMedium.Use(Target,
                (Spells.Bhavacakra.Cooldown.TotalMilliseconds > 10000 || Me.ClassLevel < 68)
                && (Spells.TrickAttack.Cooldown.TotalMilliseconds > 10000 || Me.ClassLevel < 70));
        }

        private static async Task<bool> TrueNorth()
        {
            return await Spells.TrueNorth.Use(Me, ShadowSettingsModel.Instance.UseTrueNorth);
        }

        #region Ninjutsu

        private static bool TCJTimerGood()
        {
            if (DateTime.Now > TCJTimer)
            {
                return true;
            }
            return false;
        }

        private static async Task<bool> Ninjutsu()
        {
            if (ActionManager.CanCast(Spells.Ninjutsu, Target))
            {
                return await Spells.Ninjutsu.Use(Target, true);
            }

            if (ShadowSettingsModel.Instance.UseTenChiJin
                && ShadowSettingsModel.Instance.TcjSelection != TCJMode.None
                && Me.InCombat
                && ActionResourceManager.Ninja.NinkiGauge >= 74
                && Spells.TrickAttack.Cooldown.TotalMilliseconds < 3000
                && Spells.TenChiJin.Cooldown.TotalMilliseconds < 3000
                && TCJMessage == false
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck()
                && Me.ClassLevel == 70)
            {
                ToastManager.AddToast("Ten-Chi-Jin coming in ~3 seconds!", TimeSpan.FromMilliseconds(1500), MainSettingsModel.Instance.ToastColor(false), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                TCJMessage = true;
            }

            if (await Spells.TenChiJin.CastBuff(Me, Me.InCombat
                && ShadowSettingsModel.Instance.UseTenChiJin
                && ShadowSettingsModel.Instance.TcjSelection != TCJMode.None
                && ActionResourceManager.Ninja.NinkiGauge >= 80
                && Spells.TrickAttack.Cooldown.TotalMilliseconds == 0
                && Target.CanAttack
                && TCJTimerGood()
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.TenChiJin))
            {
                TCJMessage = false;
                return await TenChiJin();
            }

            if (!ActionManager.CanCast(Spells.Ten, Me) && !ActionManager.CanCast(Spells.Kassatsu, Me))
                return false;

            if (ShadowSettingsModel.Instance.UseNinjutsu
                && Me.ClassLevel >= 45
                && ActionManager.LastSpell != Spells.ArmorCrush
                && CombatHelper.LastSpell != Spells.ArmorCrush
                && (!WorldManager.InSanctuary || Me.InCombat)
                && (ActionResourceManager.Ninja.HutonTimer.TotalSeconds == 0 || ActionResourceManager.Ninja.HutonTimer.TotalSeconds < 7)
                && ShadowSettingsModel.Instance.ArmorCrushRfsh >= 10000)
            {
                return await Huton();
            }

            if (await Kassatsu()) return true;

            if (Target == null || !Target.CanAttack ||
                !ShadowSettingsModel.Instance.UseNinjutsu ||
                CombatHelper.GcdTimeRemaining < 1800 ||
                CombatHelper.LastSpell == Spells.Mug ||
                CombatHelper.LastSpell == Spells.Assassinate ||
                CombatHelper.LastSpell == Spells.Jugulate ||
                CombatHelper.LastSpell == Spells.Goad)
            {
                return false;
            }

            if (ActionResourceManager.Ninja.HutonTimer.TotalSeconds == 0 && Me.ClassLevel >= 45) return false;

            if (await Katon_Doton()) return true;
            if (await Katon()) return true;
            if (await Doton()) return true;
            if (await Suiton()) return true;
            if (await AutoMode()) return true;
            if (await Raiton()) return true;
            return await FumaShuriken();
        }

        private static async Task<bool> Kassatsu()
        {
            if (!ActionManager.CanCast(Spells.Ten, Me) &&
                ShadowSettingsModel.Instance.UseBuffs &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck() &&
                (Spells.TrickAttack.Cooldown.TotalMilliseconds >= 55000 || (ShadowSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(10) >= ShadowSettingsModel.Instance.MobCount && ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.None && ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.KatonDoton)) &&
                ActionResourceManager.Ninja.HutonTimer.TotalSeconds >= 20)
            {
                if (!ShadowSettingsModel.Instance.UseAoE)
                    return await Spells.Kassatsu.Use(Me, true);

                await Spells.Kassatsu.Use(Me, true);
                await Katon();
                return await Doton();
            }
            return false;
        }

        private static async Task<bool> TenChiJin()
        {
            if (ShadowSettingsModel.Instance.TcjSelection == TCJMode.None || !ShadowSettingsModel.Instance.UseTenChiJin || !Me.HasAura(Auras.TenChiJin) || ActionManager.LastSpell == Spells.Ninjutsu || CombatHelper.LastSpell == Spells.Ninjutsu || Me.ClassLevel < Spells.TenChiJin.LevelAcquired)
                return false;

            Logger.ShadowLog(@"Entering TenChiJin Method.");
            if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
            {
                Navigator.PlayerMover.MoveStop();
            }

            var timeOut = new Stopwatch();
            timeOut.Start();

            var ninjutsuQueue = new Queue<SpellData>();

            if (ShadowSettingsModel.Instance.TcjSelection == TCJMode.Suiton)
            {
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);
                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);
                ninjutsuQueue.Enqueue(Spells.Jin);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 10000 && (Me.HasAura(Auras.TenChiJin) || Me.HasAura(Auras.Mudra))))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }
            }

            if (ShadowSettingsModel.Instance.TcjSelection == TCJMode.Doton)
            {
                ninjutsuQueue.Enqueue(Spells.Jin);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);
                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 10000 && (Me.HasAura(Auras.TenChiJin) || Me.HasAura(Auras.Mudra))))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }
            }

            timeOut.Reset();

            ninjutsuQueue.Clear();
            TCJTimer = DateTime.Now + TimeSpan.FromSeconds(5);

            return false;
        }

        private static async Task<bool> Katon_Doton()
        {
            if (!ActionManager.CanCast(Spells.Kassatsu, Me))
                return await Katon();

            if (Me.ClassLevel < Spells.Chi.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me) &&
                ShadowSettingsModel.Instance.UseAoE &&
                ShadowSettingsModel.Instance.NinjutsuAoEMode == NinjutsuAoEModeSelection.KatonDoton &&
                Target?.EnemiesInRange(10) >= ShadowSettingsModel.Instance.MobCount &&
                Me.TargetDistance(15, false) &&
                Target.CanAttack &&
                Target.HealthCheck(false) &&
                Target.TimeToDeathCheck())
            {
                Logger.ShadowLog(@"Entering Katon_Doton Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                if (Target?.EnemiesInRange(10) >= ShadowSettingsModel.Instance.MobCount &&
                    Me.TargetDistance(15, false) &&
                    Target.CanAttack &&
                    Target.HealthCheck(false) &&
                    Target.TimeToDeathCheck())
                {
                    ninjutsuQueue.Enqueue(Spells.Kassatsu);
                    ninjutsuQueue.Enqueue(Spells.Jin);
                    ninjutsuQueue.Enqueue(Spells.Ten);
                    ninjutsuQueue.Enqueue(Spells.Chi);
                    ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                    while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 8000 || Me.HasAura(Auras.Mudra)))
                    {
                        var ninjutsuSpell = ninjutsuQueue.Peek();

                        var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                        Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                        if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                        {
                            ninjutsuQueue.Dequeue();
                            continue;
                        }

                        await Coroutine.Yield();
                    }
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }
            return false;
        }

        private static async Task<bool> Katon()
        {
            if (Me.ClassLevel < Spells.Chi.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me) &&
                ShadowSettingsModel.Instance.UseAoE &&
                ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.DotonOnly &&
                ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.None &&
                Target?.EnemiesInRange(10) >= ShadowSettingsModel.Instance.MobCount &&
                Me.TargetDistance(15, false) &&
                Target.CanAttack &&
                Target.HealthCheck(false) &&
                Target.TimeToDeathCheck())
            {
                Logger.ShadowLog(@"Entering Katon Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }

            return false;
        }

        private static async Task<bool> Doton()
        {
            if (!ActionManager.CanCast(Spells.Kassatsu, Me))
                return false;

            if (Me.ClassLevel < Spells.Jin.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me) &&
                ShadowSettingsModel.Instance.UseAoE &&
                ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.KatonOnly &&
                ShadowSettingsModel.Instance.NinjutsuAoEMode != NinjutsuAoEModeSelection.None &&
                Me.EnemiesInRange(5) >= ShadowSettingsModel.Instance.MobCount && Me.TargetDistance(15, false) &&
                Target.CanAttack &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck())
            {
                Logger.ShadowLog(@"Entering Doton Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Kassatsu);
                ninjutsuQueue.Enqueue(Spells.Jin);
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }

            return false;
        }

        private static async Task<bool> FumaShuriken()
        {
            if (Me.ClassLevel < Spells.Ten.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me) &&
                ((ShadowSettingsModel.Instance.Ninjutsu == NinjutsuMode.FumaShuriken) || Me.ClassLevel <= 35) &&
                Me.TargetDistance(15, false) &&
                Target.CanAttack &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                Logger.ShadowLog(@"Entering Shuriken Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }

            return false;
        }

        private static async Task<bool> AutoMode()
        {
            if (Me.ClassLevel < Spells.Ten.LevelAcquired) return false;

            if (Me.ClassLevel >= Spells.Chi.LevelAcquired
                && ActionManager.CanCast(Spells.Ten, Me)
                && (ShadowSettingsModel.Instance.Ninjutsu == NinjutsuMode.Auto)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck()
                && Me.TargetDistance(15, false)
                && Target.CanAttack)
            {
                if (Target.HasAura(Auras.FoeRequiemTargetDebuff) ||
                    (Me.HasAura(Auras.Kassatsu) &&
                    !Target.HasAura(Auras.FoeRequiemTargetDebuff) &&
                    !Target.HasAura(Auras.TheArrow) &&
                    Me.ClassLevel >= 35)
                    )
                {
                    Logger.ShadowLog(@"Entering Raiton Method.");
                    if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }

                    var timeOut = new Stopwatch();
                    timeOut.Start();

                    var ninjutsuQueue = new Queue<SpellData>();

                    ninjutsuQueue.Enqueue(Spells.Ten);
                    ninjutsuQueue.Enqueue(Spells.Chi);
                    ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                    while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                    {
                        var ninjutsuSpell = ninjutsuQueue.Peek();

                        var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                        Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                        if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                        {
                            ninjutsuQueue.Dequeue();
                            continue;
                        }

                        await Coroutine.Yield();
                    }

                    timeOut.Reset();

                    ninjutsuQueue.Clear();

                    return false;
                }
                else
                {
                    Logger.ShadowLog(@"Entering Shuriken Method.");
                    if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }

                    var timeOut = new Stopwatch();
                    timeOut.Start();

                    var ninjutsuQueue = new Queue<SpellData>();

                    ninjutsuQueue.Enqueue(Spells.Ten);
                    ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                    while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                    {
                        var ninjutsuSpell = ninjutsuQueue.Peek();

                        var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                        Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                        if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                        {
                            ninjutsuQueue.Dequeue();
                            continue;
                        }

                        await Coroutine.Yield();
                    }

                    timeOut.Reset();

                    ninjutsuQueue.Clear();

                    return false;
                }
            }

            return false;
        }

        private static async Task<bool> Raiton()
        {
            if (Me.ClassLevel < Spells.Chi.LevelAcquired) return await FumaShuriken();

            if (ActionManager.CanCast(Spells.Ten, Me) &&
                (ShadowSettingsModel.Instance.Ninjutsu == NinjutsuMode.Raiton) &&
                Me.TargetDistance(15, false) &&
                Target.CanAttack &&
                !Target.HasAura(Auras.MagicRes)
                && Me.ClassLevel >= 35)
            {
                Logger.ShadowLog(@"Entering Raiton Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }

            return false;
        }

        private static async Task<bool> Huton()
        {
            if (Me.ClassLevel < Spells.Jin.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me))
            {
                Logger.ShadowLog(@"Entering Huton Method.");
                if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                {
                    Navigator.PlayerMover.MoveStop();
                }

                var timeOut = new Stopwatch();
                timeOut.Start();

                var ninjutsuQueue = new Queue<SpellData>();

                ninjutsuQueue.Enqueue(Spells.Jin);
                ninjutsuQueue.Enqueue(Spells.Chi);
                ninjutsuQueue.Enqueue(Spells.Ten);
                ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                {
                    var ninjutsuSpell = ninjutsuQueue.Peek();

                    var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                    Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                    if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                    {
                        ninjutsuQueue.Dequeue();
                        continue;
                    }

                    await Coroutine.Yield();
                }

                timeOut.Reset();

                ninjutsuQueue.Clear();

                return false;
            }

            return false;
        }

        private static async Task<bool> Suiton()
        {
            if (Me.ClassLevel < Spells.Jin.LevelAcquired) return false;

            if (ActionManager.CanCast(Spells.Ten, Me)
                && Me.ClassLevel >= 18)
            {
                if (Math.Abs(Spells.TrickAttack.Cooldown.TotalMilliseconds) <= 7000 &&
                    Target?.CurrentHealth >= ShadowSettingsModel.Instance.SuitonHpInt &&
                    Target?.CurrentHealthPercent >= ShadowSettingsModel.Instance.SuitonHpPct &&
                    Target.TimeToDeathCheck() &&
                    Me.TargetDistance(15, false) &&
                    Target.CanAttack &&
                    !Target.HasAura(Auras.MagicRes) &&
                    (!ShadowSettingsModel.Instance.UseAoE ||
                     (ShadowSettingsModel.Instance.UseAoE &&
                      Me.EnemiesInRange(5) <= ShadowSettingsModel.Instance.MobCount)) &&
                    !Target.HasAura(Auras.VulnerabilityUp, false, 3000))
                {
                    Logger.ShadowLog(@"Entering Suiton Method.");
                    if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }

                    var timeOut = new Stopwatch();
                    timeOut.Start();

                    var ninjutsuQueue = new Queue<SpellData>();

                    ninjutsuQueue.Enqueue(Spells.Ten);
                    ninjutsuQueue.Enqueue(Spells.Chi);
                    ninjutsuQueue.Enqueue(Spells.Jin);
                    ninjutsuQueue.Enqueue(Spells.Ninjutsu);

                    while (ninjutsuQueue.Count > 0 && (timeOut.ElapsedMilliseconds < 5000 || Me.HasAura(Auras.Mudra)))
                    {
                        var ninjutsuSpell = ninjutsuQueue.Peek();

                        var ninjutsuTarget = (ActionManager.CanCast(ninjutsuSpell, Target) ? Target : Me) ?? Me;

                        Logger.ShadowLog($@"Next Ninjutsu Spell: {ninjutsuSpell} at : {ninjutsuTarget.SafeName()}");

                        if (await ninjutsuSpell.Use(ninjutsuTarget, true))
                        {
                            ninjutsuQueue.Dequeue();
                            continue;
                        }

                        await Coroutine.Yield();
                    }

                    timeOut.Reset();
                    ninjutsuQueue.Clear();

                    return await TrueNorth();
                }
            }

            return false;
        }

        private static async Task<bool> TrickAttack()
        {
            if (Target == null || !Target.CanAttack || !Target.HealthCheck(false) || !Target.TimeToDeathCheck())
            {
                return false;
            }

            return await Spells.TrickAttack.Use(Target, ((Target.IsBehind && !Target.IsFlanking) || Me.HasAura(Auras.TrueNorth) || !PartyManager.IsInParty));
        }

        #endregion Ninjutsu

        private static async Task<bool> Shukuchi()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseShukuchi)
                return false;

            var rndx = (Target.CombatReach * _rnd.NextDouble() * GetMultiplier());
            var rndz = (Target.CombatReach * _rnd.NextDouble() * GetMultiplier());
            var rndxz = new Vector3((float)rndx, 0f, (float)rndz);
            var tarloc = Target.Location;
            var rndloc = tarloc + rndxz;

            if (ActionManager.CanCast(Spells.Shukuchi, Target) && Target?.Distance() >= 10 &&
                !await Coroutine.Wait(1000, () => ActionManager.DoActionLocation(Spells.Shukuchi.Id, rndloc)))
            {
                return false;
            }
            return false;
        }

        private static async Task<bool> Shadewalker()
        {
            if (ShadowSettingsModel.Instance.UseManualShadewalker) return false;

            var autoShadeTarget = PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null &&
            x.Type == GameObjectType.Pc &&
            x.IsTank() &&
            x.InCombat &&
            x.IsAlive &&
            x.TargetGameObject != null &&
            x.TargetGameObject == Target);

            var selectedShadeTarget = ShadewalkerTargetViewModel.Instance.ShadewalkerTarget;

            if (selectedShadeTarget.AllyIsValid() && ShadowSettingsModel.Instance.UseShadewalkerTarget && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Shadewalker.Use(selectedShadeTarget, true);
            }

            if (!ShadowSettingsModel.Instance.UseShadewalkerTarget && autoShadeTarget.AllyIsValid() && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Shadewalker.Use(autoShadeTarget, true);
            }

            return await Spells.Shadewalker.Use(autoShadeTarget, ShadowSettingsModel.Instance.UseShadewalkerTarget && !selectedShadeTarget.AllyIsValid());
        }

        private static async Task<bool> Duality()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseBuffs)
                return false;

            if (Target.HasAura(Auras.VulnerabilityUp))
                return await Spells.Duality.CastBuff(Me, true, Auras.Duality);

            if (Spells.TrickAttack.Cooldown.TotalMilliseconds >= 5000 || Target.HasAura(Auras.VulnerabilityUp) &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Duality.CastBuff(Me, true, Auras.Duality);
            }

            return false;
        }

        private static async Task<bool> DreamWithinADream()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseBuffs)
                return false;

            if (Target.HasAura(Auras.VulnerabilityUp))
                return await Spells.DreamWithinaDream.Use(Target, true);

            if ((Spells.TrickAttack.Cooldown.TotalMilliseconds >= 5000 || Target.HasAura(Auras.VulnerabilityUp))
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                return await Spells.DreamWithinaDream.Use(Target, true);
            }

            return false;
        }

        #region Misc

        private static async Task<bool> Interrupt()
        {
            if (ShadowSettingsModel.Instance.UseManualInterrupt || Target == null || !Target.CanAttack) return false;

            if (ShadowSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LegSweep.Use(Target, true);

            return Target != null && await Spells.LegSweep.Use(Target, !ShadowSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !ShadowSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion?.Item == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        #endregion Misc
    }
}