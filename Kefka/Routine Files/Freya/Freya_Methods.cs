using System;
using System.Collections.Generic;
using ff14bot.Managers;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ff14bot.Enums;
using ff14bot.Objects;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Freya
{
    public static partial class FreyaRotation
    {
        private static bool BloodoftheDragon => ActionResourceManager.Dragoon.Timer > TimeSpan.Zero;
        private static double BloodoftheDragonTime => ActionResourceManager.Dragoon.Timer.TotalMilliseconds;
        private static int DragonGaze => ActionResourceManager.Dragoon.DragonGaze;
        private static bool BotDAuraGood => Me.ClassLevel < 54 || BloodoftheDragonTime >= CombatHelper.GCD * 4 || !BloodoftheDragon;

        private static async Task<bool> TrueThrust()
        {
            return await Spells.TrueThrust.Use(Target, ActionManager.LastSpell != Spells.ImpulseDrive
                && (ActionManager.LastSpell != Spells.TrueThrust || Me.ClassLevel < Spells.VorpalThrust.LevelAcquired)
                && (ActionManager.LastSpell != Spells.Disembowel || Me.ClassLevel < Spells.ChaosThrust.LevelAcquired)
                && (ActionManager.LastSpell != Spells.FullThrust || Me.ClassLevel < Spells.Disembowel.LevelAcquired)
                && (Target.HasAura(Auras.PiercingResistanceDown, true) || Me.ClassLevel < Spells.Disembowel.LevelAcquired));
        }

        private static async Task<bool> ImpulseDrive()
        {
            return await Spells.ImpulseDrive.Use(Target, FreyaSettingsModel.Instance.UseDoTs
                && Me.ClassLevel >= Spells.Disembowel.LevelAcquired
                && ActionManager.LastSpell != Spells.ImpulseDrive
                && ActionManager.LastSpell != Spells.TrueThrust
                && (!Target.HasAura(Auras.PiercingResistanceDown) || !Target.HasAura(Auras.PiercingResistanceDown, false, 15000)));
        }

        private static async Task<bool> VorpalThrust()
        {
            return await Spells.VorpalThrust.Use(Target, ActionManager.LastSpell == Spells.TrueThrust);
        }

        private static async Task<bool> ChaosThrust()
        {
            return await Spells.ChaosThrust.CastDot(Target, ActionManager.LastSpell == Spells.Disembowel, Auras.ChaosThrust, 5000);
        }

        private static async Task<bool> FullThrust()
        {
            return await Spells.FullThrust.Use(Target, (Me.HasAura(Auras.LifeSurge) && !Me.HasAura(Auras.EnhancedWheelingThrust) && !Me.HasAura(Auras.SharperFangandClaw)) || ActionManager.LastSpell == Spells.VorpalThrust);
        }

        private static async Task<bool> LegSweep()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (FreyaSettingsModel.Instance.UseManualInterrupt) return false;

            if (Target.CanStun() && FreyaSettingsModel.Instance.UseInterruptList)
                return await Spells.LegSweep.Use(Target, true);

            return await Spells.LegSweep.Use(Target, !FreyaSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> HeavyThrust()
        {
            return await Spells.HeavyThrust.CastBuff(Target, !Me.HasAura(Auras.HeavyThrust, true, FreyaSettingsModel.Instance.HeavyThrustRfsh) && BotDAuraGood, Auras.HeavyThrust);
        }

        private static async Task<bool> PiercingTalon()
        {
            if (BotManager.Current.IsAutonomous || FreyaSettingsModel.Instance.UsePiercingTalon)
            {
                return await Spells.PiercingTalon.Use(Target, Target?.Distance() >= Me.CombatReach + 2);
            }
            return false;
        }

        private static async Task<bool> LifeSurge()
        {
            if (await Spells.LifeSurge.CastBuff(Me, FreyaSettingsModel.Instance.UseBuffs
                && CombatHelper.LastSpell == Spells.VorpalThrust
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.LifeSurge))
                return await FullThrust();

            return false;
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, CombatHelper.OnGcd && Me.CurrentTPPercent <= 50 && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> BloodForBlood()
        {
            return await Spells.BloodforBlood.CastBuff(Me, FreyaSettingsModel.Instance.UseBuffs && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.BloodforBlood);
        }

        private static async Task<bool> Disembowel()
        {
            return await Spells.Disembowel.Use(Target, ActionManager.LastSpell == Spells.ImpulseDrive);
        }

        private static async Task<bool> DoomSpike()
        {
            return await Spells.DoomSpike.Use(Target, FreyaSettingsModel.Instance.UseAoE && Me.CurrentTP > FreyaSettingsModel.Instance.TpLimit && Me.EnemiesInRange(10) >= FreyaSettingsModel.Instance.MobCount);
        }

        private static async Task<bool> SonicThrust()
        {
            return await Spells.SonicThrust.Use(Target, FreyaSettingsModel.Instance.UseAoE && (ActionManager.LastSpell == Spells.DoomSpike || CombatHelper.LastSpell == Spells.DoomSpike) && Me.EnemiesInRange(10) >= FreyaSettingsModel.Instance.MobCount);
        }

        internal static async Task<bool> DragonSightOpener()
        {
            return await DragonSight();
        }

        private static async Task<bool> DragonSight()
        {
            if (FreyaSettingsModel.Instance.UseManualDragonSight) return false;

            if (!PartyManager.IsInParty)
            {
                if (ChocoboManager.Summoned)
                {
                    return await Spells.DragonSight.Use(ChocoboManager.Object, true);
                }
                return false;
            }

            var autoDragonSightTarget = DragonSightManager.FirstOrDefault();

            var selectedDragonSightTarget = DragonSightTargetViewModel.Instance.DragonSightTarget;

            if (selectedDragonSightTarget.AllyIsValid() && FreyaSettingsModel.Instance.UseTargetDragonSight && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.DragonSight.Use(selectedDragonSightTarget, true);
            }

            if (!FreyaSettingsModel.Instance.UseTargetDragonSight && autoDragonSightTarget.AllyIsValid() && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.DragonSight.Use(autoDragonSightTarget, true);
            }

            return await Spells.DragonSight.Use(autoDragonSightTarget, FreyaSettingsModel.Instance.UseTargetDragonSight && !selectedDragonSightTarget.AllyIsValid());
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, Me.CurrentHealthPercent <= FreyaSettingsModel.Instance.SelfHealHpPct);
        }

        private static async Task<bool> InternalRelease()
        {
            return await Spells.InternalRelease.CastBuff(Me, FreyaSettingsModel.Instance.UseBuffs && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.InternalRelease);
        }

        private static async Task<bool> BattleLitany()
        {
            return await Spells.BattleLitany.CastBuff(Me, FreyaSettingsModel.Instance.UseBattleLitany && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.BattleLitany);
        }

        private static async Task<bool> BloodOfTheDragon()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (!FreyaSettingsModel.Instance.UseBloodoftheDragon)
                return false;

            if (BloodoftheDragon)
                return false;

            return await Spells.BloodoftheDragon.Use(Me, ActionManager.LastSpell == Spells.ImpulseDrive || ActionManager.LastSpell == Spells.DoomSpike);
        }

        private static async Task<bool> FangAndClaw()
        {
            return await Spells.FangandClaw.Use(Target, Me.HasAura(Auras.SharperFangandClaw));
        }

        private static async Task<bool> WheelingThrust()
        {
            return await Spells.WheelingThrust.Use(Target, Me.HasAura(Auras.EnhancedWheelingThrust));
        }

        private static async Task<bool> Geirskogul()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (!FreyaSettingsModel.Instance.UseGeirskogul
                || DragonGaze == 2
                || (Spells.Geirskogul.Cooldown.TotalMilliseconds > Spells.SpineshatterDive.Cooldown.TotalMilliseconds && DragonGaze >= 2)
                || (Spells.Geirskogul.Cooldown.TotalMilliseconds > Spells.Jump.Cooldown.TotalMilliseconds && DragonGaze >= 2))
                return false;

            return await Spells.Geirskogul.Use(Target, true);
        }

        private static async Task<bool> Nastrond()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            return await Spells.Nastrond.Use(Target, true);
        }

        private static async Task<bool> TrueNorth()
        {
            return await Spells.TrueNorth.CastBuff(Me, FreyaSettingsModel.Instance.UseTrueNorth && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.TrueNorth);
        }

        private static async Task<bool> Feint()
        {
            return await Spells.Feint.CastDot(Target, FreyaSettingsModel.Instance.UseFeint
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.Feint);
        }

        private static async Task<bool> Bloodbath()
        {
            return await Spells.Bloodbath.Use(Me, Target != null && Target.CanAttack && Me.CurrentHealthPercent < FreyaSettingsModel.Instance.SelfHealHpPct);
        }

        #region Misc

        #region Dragon Sight Manager

        public static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return
                    PartyManager.VisibleMembers
                        .Select(pm => pm.GameObject as BattleCharacter)
                        .Where(pm => pm.IsTargetable);
            }
        }

        public static IEnumerable<BattleCharacter> DragonSightManager
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                        .Where(
                            gm =>
                                PartyMembers.Contains(gm) && gm.Type == GameObjectType.Pc
                                && gm.InCombat
                                && gm.Distance(Me) <= 12
                                && gm.IsAlive).OrderByDescending(ClassScore);
            }
        }

        private static int ClassScore(BattleCharacter c)
        {
            var score = 1;

            if (c.IsDps())
                score += 100;

            if (c.IsMeleeDps())
                score += 100;

            if (c.CurrentJob == ClassJobType.Samurai)
                score += 100;

            if (c.CurrentJob == ClassJobType.Monk)
                score += 90;

            if (c.CurrentJob == ClassJobType.Ninja)
                score += 80;

            if (c.CurrentJob == ClassJobType.Dragoon)
                score += 70;

            if (c.IsRangedDps())
                score += 60;

            if (c.IsTank())
                score += 50;

            if (c.IsHealer())
                score += 40;

            return score;
        }

        #endregion Dragon Sight Manager

        private static async Task<bool> Jumps()
        {
            if (Target == null || !Target.CanAttack || !BotDAuraGood)
                return false;

            if (CombatHelper.LastSpell == Spells.FullThrust || CombatHelper.LastSpell == Spells.ChaosThrust)
                return false;

            if (CombatHelper.LastSpell == Spells.VorpalThrust && FreyaSettingsModel.Instance.UseBuffs && Spells.LifeSurge.Cooldown.TotalMilliseconds == 0)
                return false;

            if (DragonGaze == 3) return false;

            if (CombatHelper.LastSpell == Spells.Jump || CombatHelper.LastSpell == Spells.SpineshatterDive || Me.HasAura(Auras.DiveReady))
                return await Spells.MirageDive.Use(Target, true);

            if (CombatHelper.LastSpell == Spells.Jump || CombatHelper.LastSpell == Spells.SpineshatterDive || CombatHelper.LastSpell == Spells.DragonfireDive || CombatHelper.LastSpell == Spells.MirageDive)
                return false;

            if (Me.HasAura(Auras.EnhancedWheelingThrust) || Me.HasAura(Auras.SharperFangandClaw))
                return false;

            if (Me.ClassLevel == 60 && CombatHelper.CombatTime.ElapsedMilliseconds < 20000 && !BloodoftheDragon && Spells.BloodoftheDragon.Cooldown.TotalMilliseconds < 4000)
                return false;

            if (await Spells.Jump.Use(Target, FreyaSettingsModel.Instance.UseJumps && !Me.HasAura(Auras.DiveReady) && (Target.HasAura(Auras.PiercingResistanceDown) || Me.ClassLevel < Spells.Disembowel.LevelAcquired) && (BloodoftheDragon || Me.ClassLevel < Spells.BloodoftheDragon.LevelAcquired))) return true;

            if (await Spells.SpineshatterDive.Use(Target, FreyaSettingsModel.Instance.UseJumps && FreyaSettingsModel.Instance.UseSpineshatterDive && !Me.HasAura(Auras.DiveReady) && Target.HasAura(Auras.PiercingResistanceDown) && (BloodoftheDragon || Me.ClassLevel < Spells.BloodoftheDragon.LevelAcquired))) return true;
            return await Spells.DragonfireDive.Use(Target, FreyaSettingsModel.Instance.UseDragonfireDive && FreyaSettingsModel.Instance.UseJumps && Target.HasAura(Auras.PiercingResistanceDown));
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !FreyaSettingsModel.Instance.UseDpsPotion || !Me.HasAura(Auras.BloodforBlood, true, 10000) || CombatHelper.LastSpell != Spells.ImpulseDrive || CombatHelper.LastSpell != Spells.VorpalThrust)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, Me.HasAura(Auras.BloodforBlood));
        }

        private static async Task<bool> AoESpam()
        {
            if (Control.ModifierKeys == Keys.None || !WindowCheck.ApplicationIsActivated()) return false;

            if (Keyboard.IsKeyDown(FreyaHotkeysModel.Instance.AoeSpamKey))
            {
                if (!Me.HasAura(Auras.HeavyThrust, true, FreyaSettingsModel.Instance.HeavyThrustRfsh))
                {
                    await HeavyThrust();
                }
                if (ActionManager.LastSpell == Spells.DoomSpike && Me.ClassLevel >= Spells.SonicThrust.LevelAcquired)
                    return await Spells.SonicThrust.Use(Target, true);

                return await Spells.DoomSpike.Use(Target, true);
            }
            return false;
        }

        #endregion Misc
    }
}