using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using static ff14bot.Managers.ActionResourceManager.Samurai;
using static ff14bot.Managers.ActionResourceManager.Samurai.Iaijutsu;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Cyan
{
    public static partial class CyanRotation
    {
        private static bool HasKaiten => Me.HasAura(Auras.Kaiten) || ActionManager.LastSpell == Spells.HissatsuKaiten || CombatHelper.LastSpell == Spells.HissatsuKaiten;

        private static Aura jinpuAura => Me.CharacterAuras.FirstOrDefault(aura => aura != null && aura.Name.Contains("Jinpu"));
        private static Aura shifuAura => Me.CharacterAuras.FirstOrDefault(aura => aura != null && aura.Name.Contains("Shifu"));

        private static int SenCount()
        {
            var count = 0;

            if (Sen.HasFlag(Ka))
                count++;

            if (Sen.HasFlag(Setsu))
                count++;

            if (Sen.HasFlag(Getsu))
                count++;

            return count;
        }

        private static async Task<bool> ManualMeditation()
        {
            if (Spells.Meditate.Cooldown != TimeSpan.Zero) return false;

            if (Control.ModifierKeys != Keys.None && WindowCheck.ApplicationIsActivated())
                if (Keyboard.IsKeyDown(CyanHotkeysModel.Instance.MeditiationKey))
                {
                    await Spells.Meditate.Use(Me, true);

                    while (Kenki < 100 && !MovementManager.IsMoving)
                    {
                        await Coroutine.Wait(250, () => Kenki < 100);
                        await Coroutine.Yield();
                    }
                }
            return false;
        }

        private static async Task<bool> Hakaze()
        {
            return await Spells.Hakaze.Use(Target, !HasKaiten);
        }

        private static async Task<bool> ComboSkill()
        {
            if (HasKaiten) return false;

            if (CombatHelper.LastSpell == Spells.Hakaze || ActionManager.LastSpell == Spells.Hakaze)
            {
                if (Me.ClassLevel < 18)
                    return await Spells.Jinpu.Use(Target, true);

                if (Sen.HasFlag(Getsu) && !Sen.HasFlag(Ka))
                    return await Spells.Shifu.Use(Target, true);

                if (Sen.HasFlag(Ka) && !Sen.HasFlag(Getsu))
                    return await Spells.Jinpu.Use(Target, true);

                if (Me.ClassLevel >= 50 && Sen.HasFlag(Ka) && Sen.HasFlag(Getsu) && !Sen.HasFlag(Setsu))
                    return await Spells.Yukikaze.Use(Target, true);

                if (shifuAura == null || shifuAura.TimespanLeft == TimeSpan.Zero)
                    return await Spells.Shifu.Use(Target, true);

                if (jinpuAura == null || jinpuAura.TimespanLeft == TimeSpan.Zero)
                    return await Spells.Jinpu.Use(Target, true);

                if (Me.ClassLevel >= 50 && (!Target.HasAura(Auras.SlashingResistanceDown, false, 5000) || !Sen.HasFlag(Setsu)))
                    return await Spells.Yukikaze.Use(Target, true);

                if (jinpuAura?.TimespanLeft < shifuAura?.TimespanLeft)
                    return await Spells.Jinpu.Use(Target, true);

                return await Spells.Shifu.Use(Target, true);
            }

            return false;
        }

        private static async Task<bool> ComboFinisher()
        {
            if (HasKaiten) return false;

            if (CombatHelper.LastSpell == Spells.Jinpu || ActionManager.LastSpell == Spells.Jinpu || Me.HasAura(Auras.MeikyoShisui) && (jinpuAura?.TimespanLeft < shifuAura?.TimespanLeft || !Sen.HasFlag(Getsu) || Me.ClassLevel < 62))
                return await Spells.Gekko.Use(Target, true);

            if (CombatHelper.LastSpell == Spells.Shifu || ActionManager.LastSpell == Spells.Shifu || Me.HasAura(Auras.MeikyoShisui) && (shifuAura?.TimespanLeft < jinpuAura?.TimespanLeft || !Sen.HasFlag(Ka) || Me.ClassLevel < 62))
                return await Spells.Kasha.Use(Target, true);

            return false;
        }

        private static async Task<bool> Higanbana()
        {
            if (!CyanSettingsModel.Instance.UseDots
                || !CyanSettingsModel.Instance.UseIaijutsu
                || Target.HasAura(Auras.Higanbana, true, CyanSettingsModel.Instance.HiganbanaRfsh)
                || Me.HasAura(Auras.MeikyoShisui)
                || Spells.MeikyoShisui.Cooldown.TotalMilliseconds == 0
                || ActionManager.LastSpell == Spells.Hagakure
                || CombatHelper.LastSpell == Spells.Hagakure) return false;

            if (SenCount() != 1
                || (Kenki < 20 && Me.ClassLevel > 51)
                || Me.HasAura(Auras.MeikyoShisui)
                || Target.CurrentHealthPercent < CyanSettingsModel.Instance.HiganbanaMinHpPct && !Target.IsBoss() && !MainSettingsModel.Instance.DestroyTarget
                || Target.CurrentHealth < CyanSettingsModel.Instance.HiganbanaMinHpInt && !Target.IsBoss() && !MainSettingsModel.Instance.DestroyTarget) return false;

            Logger.CyanLog(@"Entering Higanbana Method.");
            if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
            {
                Navigator.PlayerMover.MoveStop();
            }

            var timeOut = new Stopwatch();
            timeOut.Start();

            var queue = new Queue<SpellData>();

            if (CyanSettingsModel.Instance.UseBuffs && Me.ClassLevel >= 52)
                queue.Enqueue(Spells.HissatsuKaiten);

            while (queue.Count > 0 && timeOut.ElapsedMilliseconds < 5000 && ((Me.HasAura(Auras.Kaiten) || CombatHelper.LastSpell != Spells.Iaijutsu)))
            {
                var action = queue.Peek();

                Logger.CyanLog(@"Next Attack: {0}", action);
                await Coroutine.Wait(3000, () => ActionManager.CanCast(action, Target) || ActionManager.CanCast(action, Me));

                if (await action.Use(Target, true) || await action.Use(Me, true))
                {
                    queue.Dequeue();
                    continue;
                }

                await Coroutine.Yield();
            }

            timeOut.Reset();
            await Coroutine.Wait(3000, () => ActionManager.CanCast(Spells.Hakaze, Target));
            queue.Clear();
            return false;
        }

        private static async Task<bool> HissatsuSeigan()
        {
            if (!CyanSettingsModel.Instance.UseSeigan) return false;

            if (CyanSettingsModel.Instance.UseThirdEye && Kenki >= 35 && Target.HealthCheck(false) && Target.TimeToDeathCheck())
                await Spells.ThirdEye.Use(Me, true);

            return await Spells.HissatsuSeigan.Use(Target, Me.HasAura(Auras.EyesOpen));
        }

        private static async Task<bool> MercifulEyes()
        {
            if (Target == null || !Target.CanAttack || !CyanSettingsModel.Instance.UseMercifulEyes) return false;

            if (CyanSettingsModel.Instance.UseThirdEye
                && Kenki >= 35
                && Me.CurrentHealthPercent < CyanSettingsModel.Instance.MercifulEyesHpPct
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                await Spells.ThirdEye.Use(Me, true);
                return await Spells.MercifulEyes.Use(Target, true);
            }

            return await Spells.MercifulEyes.Use(Me, Me.HasAura(Auras.EyesOpen) && Me.CurrentHealthPercent < CyanSettingsModel.Instance.MercifulEyesHpPct);
        }

        private static async Task<bool> Ageha()
        {
            return await Spells.Ageha.Use(Target, CyanSettingsModel.Instance.UseAgeha);
        }

        private static async Task<bool> Enpi()
        {
            if (BotManager.Current.IsAutonomous || CyanSettingsModel.Instance.UseEnpi)
            {
                return await Spells.Enpi.Use(Target, Target.Distance(Me) > 8);
            }
            return false;
        }

        private static async Task<bool> Fuga()
        {
            if (Me.HasAura(Auras.Kaiten)) return false;

            return await Spells.Fuga.Use(Target, Target.EnemiesInRange(8) >= CyanSettingsModel.Instance.MobCount
                && Me.CurrentTP > CyanSettingsModel.Instance.TpLimit
                && Me.HasAura(Auras.Jinpu));
        }

        private static async Task<bool> Mangetsu()
        {
            return await Spells.Mangetsu.Use(Me, (CombatHelper.LastSpell == Spells.Fuga || ActionManager.LastSpell == Spells.Fuga)
                && Me.EnemiesInRange(6) >= 1
                && (!Sen.HasFlag(Getsu) || Sen.HasFlag(Ka) && Sen.HasFlag(Getsu)));
        }

        private static async Task<bool> Oka()
        {
            return await Spells.Oka.Use(Me, (CombatHelper.LastSpell == Spells.Fuga || ActionManager.LastSpell == Spells.Fuga)
                && Me.EnemiesInRange(6) >= 1
                && (!Sen.HasFlag(Ka) || Sen.HasFlag(Ka) && Sen.HasFlag(Getsu)));
        }

        private static async Task<bool> HissatsuKyuten()
        {
            return await Spells.HissatsuKyuten.Use(Me, Me.EnemiesInRange(6) >= CyanSettingsModel.Instance.MobCount && Kenki >= 45);
        }

        private static async Task<bool> HissatsuGuren()
        {
            return await Spells.HissatsuGuren.Use(Target, CyanSettingsModel.Instance.UseGuren && Kenki >= 50);
        }

        private static async Task<bool> TenkaGoken()
        {
            if ((SenCount() == 2 && Me.ClassLevel >= 50) || !CyanSettingsModel.Instance.UseIaijutsu) return false;

            return await Spells.Iaijutsu.Use(Target, Target.EnemiesInRange(8) >= CyanSettingsModel.Instance.MobCount || (Me.ClassLevel < 50 && SenCount() == 2));
        }

        private static async Task<bool> MeikyoShisui()
        {
            if ((SenCount() == 3 && ActionManager.CanCast(Spells.Hagakure, Me) && Me.ClassLevel >= 68) || !CyanSettingsModel.Instance.UseIaijutsu || ActionManager.LastSpell == Spells.Hagakure || CombatHelper.LastSpell == Spells.Hagakure) return false;

            if (Target == null || !Target.CanAttack || (CyanSettingsModel.Instance.UseAoE && Me.EnemiesInRange(6) >= CyanSettingsModel.Instance.MobCount && Me.CurrentTP > CyanSettingsModel.Instance.TpLimit)) return false;

            if (!CyanSettingsModel.Instance.UseBuffs
                || !ActionManager.CanCast(Spells.MeikyoShisui, Me)
                || SenCount() == 3
                || CombatHelper.LastSpell != Spells.Hakaze
                || !Target.HealthCheck(false)
                || !Target.TimeToDeathCheck()) return false;

            Logger.CyanLog(@"Entering Meikyo Shisui Method.");
            if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
            {
                Navigator.PlayerMover.MoveStop();
            }

            var timeOut = new Stopwatch();
            timeOut.Start();

            var queue = new Queue<SpellData>();

            queue.Enqueue(Spells.MeikyoShisui);

            if (!Sen.HasFlag(Setsu))
                queue.Enqueue(Spells.Yukikaze);

            if (!Sen.HasFlag(Ka))
                queue.Enqueue(Spells.Kasha);

            if (!Sen.HasFlag(Getsu))
                queue.Enqueue(Spells.Gekko);

            if (Spells.Hagakure.Cooldown.TotalSeconds > 5 || Me.ClassLevel < Spells.Hagakure.LevelAcquired || Kenki > 40)
            {
                if (CyanSettingsModel.Instance.UseBuffs && Me.ClassLevel >= Spells.HissatsuKaiten.LevelAcquired && (Kenki >= 20 || ((Kenki + (5 * (queue.Count - 1))) >= 20)))
                    queue.Enqueue(Spells.HissatsuKaiten);
            }
            else if (Me.ClassLevel >= Spells.Hagakure.LevelAcquired && (Kenki + (5 * (queue.Count - 1))) <= 40)
                queue.Enqueue(Spells.Hagakure);

            while (queue.Count > 0 && timeOut.ElapsedMilliseconds < 12000 && ((Me.HasAura(Auras.Kaiten) || CombatHelper.LastSpell != Spells.Iaijutsu)))
            {
                var action = queue.Peek();

                await Coroutine.Wait(3000, () => ActionManager.CanCast(action, Target) || ActionManager.CanCast(action, Me));

                if (await action.Use(Target, true) || await action.Use(Me, true))
                {
                    queue.Dequeue();
                    continue;
                }

                await Coroutine.Yield();
            }

            timeOut.Reset();
            await Coroutine.Wait(3000, () => ActionManager.CanCast(Spells.Hakaze, Target));
            queue.Clear();
            return false;
        }

        private static async Task<bool> HissatsuGyoten()
        {
            return await Spells.HissatsuGyoten.Use(Target, CyanSettingsModel.Instance.UseGyoten && Target.Distance(Me) > 10 && Kenki >= 45);
        }

        private static async Task<bool> HissatsuShinten()
        {
            if (CyanSettingsModel.Instance.UseAoE
                && Me.EnemiesInRange(6) >= CyanSettingsModel.Instance.MobCount && SenCount() < 3
                && Me.CurrentTP > CyanSettingsModel.Instance.TpLimit) return false;

            return await Spells.HissatsuShinten.Use(Target,
                Kenki >= 45
                && (Spells.HissatsuGuren.Cooldown.TotalMilliseconds > 5000 || Me.ClassLevel < 70)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Hagakure()
        {
            return await Spells.Hagakure.Use(Me, SenCount() == 3 && Kenki <= 30 && ActionManager.LastSpell != Spells.HissatsuKaiten && CombatHelper.LastSpell != Spells.HissatsuKaiten && !Me.HasAura(Auras.Kaiten));
        }

        private static async Task<bool> MidareSetsugekka()
        {
            if ((SenCount() == 3 && Spells.Hagakure.Cooldown.TotalMilliseconds < 5000 && Me.ClassLevel >= 68) || !CyanSettingsModel.Instance.UseIaijutsu
                || ActionManager.LastSpell == Spells.Iaijutsu || CombatHelper.LastSpell == Spells.Iaijutsu
                || ActionManager.LastSpell == Spells.Hagakure || CombatHelper.LastSpell == Spells.Hagakure
                || ActionManager.LastSpell == Spells.ThirdEye || CombatHelper.LastSpell == Spells.ThirdEye) return false;

            if (!Me.HasAura(Auras.Shifu)
                || SenCount() < 3
                || (Kenki < 20 && Me.ClassLevel > 51)
                || !Target.HealthCheck(false)
                || !Target.TimeToDeathCheck())
                return false;

            Logger.CyanLog(@"Entering Midare Setsugekka Method.");
            if (BotManager.Current.IsAutonomous && MovementManager.IsMoving)
            {
                Navigator.PlayerMover.MoveStop();
            }

            var timeOut = new Stopwatch();
            timeOut.Start();

            var queue = new Queue<SpellData>();

            if (CyanSettingsModel.Instance.UseBuffs && Me.ClassLevel >= 52)
                queue.Enqueue(Spells.HissatsuKaiten);

            while (queue.Count > 0 && timeOut.ElapsedMilliseconds < 3500 && ((Me.HasAura(Auras.Kaiten) || CombatHelper.LastSpell != Spells.Iaijutsu)))
            {
                var action = queue.Peek();

                Logger.CyanLog(@"Next Attack: {0}", action);
                await Coroutine.Wait(3000, () => ActionManager.CanCast(action, Target) || ActionManager.CanCast(action, Me));

                if (await action.Use(Target, true) || await action.Use(Me, true))
                {
                    queue.Dequeue();
                    continue;
                }

                await Coroutine.Yield();
            }

            timeOut.Reset();
            await Coroutine.Wait(3000, () => ActionManager.CanCast(Spells.Hakaze, Target));
            queue.Clear();
            return false;
        }

        #region Misc

        private static async Task<bool> Interrupt()
        {
            if (CyanSettingsModel.Instance.UseManualInterrupt || Target == null || !Target.CanAttack) return false;

            if (CyanSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LegSweep.Use(Target, true);

            return Target != null && await Spells.LegSweep.Use(Target, !CyanSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, Me.CurrentHealthPercent < CyanSettingsModel.Instance.SecondWindHpPct);
        }

        private static async Task<bool> Bloodbath()
        {
            return await Spells.Bloodbath.Use(Me, Target != null && Target.CanAttack && Me.CurrentHealthPercent < CyanSettingsModel.Instance.BloodbathHpPct);
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, Me.CurrentTP < CyanSettingsModel.Instance.TpLimit);
        }

        private static async Task<bool> Feint()
        {
            return await Spells.Feint.Use(Target, Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !CyanSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion?.Item == null) return false;

            return await Items.UsePotion(dpsPotion.Item, Target.HealthCheck(false)
                                                         && Target.TimeToDeathCheck());
        }

        #endregion Misc
    }
}