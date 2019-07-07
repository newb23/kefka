using System.Linq;
using System.Threading.Tasks;
using ff14bot.Managers;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.Sabin
{
    public static partial class SabinRotation
    {
        private static async Task<bool> Bootshine()
        {
            return await Spells.Bootshine.CastBuff(Target, !Me.HasAura(Auras.PerfectBalance)
                && ((!Me.HasAura(Auras.RaptorForm) && !Me.HasAura(Auras.CoeurlForm)) || Me.ClassLevel < 6)
                && (Target.HasAura(Auras.BluntResistanceDown, false, SabinSettingsModel.Instance.DragonKickRfsh) || Target.HasAura(Auras.Delirium, false, SabinSettingsModel.Instance.DragonKickRfsh) || Me.ClassLevel < 50 || !Me.HasAura(Auras.Opo_opoForm))
                && ((SabinSettingsModel.Instance.UseHoldPositionals && Target.IsBehind && !Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.RaptorForm);
        }

        private static async Task<bool> TrueStrike()
        {
            return await Spells.TrueStrike.CastBuff(Target, Me.HasAura(Auras.RaptorForm) && (Me.HasAura(Auras.TwinSnakes, true, SabinSettingsModel.Instance.TwinSnakesRfsh) || Me.ClassLevel < 18) && !Me.HasAura(Auras.PerfectBalance) && ((SabinSettingsModel.Instance.UseHoldPositionals && Target.IsBehind && !Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.CoeurlForm);
        }

        private static async Task<bool> SnapPunch()
        {
            return await Spells.SnapPunch.Use(Target, (Me.HasAura(Auras.PerfectBalance) || Me.HasAura(Auras.CoeurlForm))
                && (Target.HasAura(Auras.Demolish, true, SabinSettingsModel.Instance.DemolishRfsh) || !Target.HasAura(Auras.Demolish, true))
                && ((SabinSettingsModel.Instance.UseHoldPositionals && !Target.IsBehind && Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals));
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, SabinSettingsModel.Instance.UseSecondWind && Me.CurrentHealthPercent <= SabinSettingsModel.Instance.SecondWindHpPct);
        }

        private static async Task<bool> InternalRelease()
        {
            return await Spells.InternalRelease.CastBuff(Me, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0)) && SabinSettingsModel.Instance.UseBuffs && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.InternalRelease);
        }

        private static async Task<bool> TwinSnakes()
        {
            return await Spells.TwinSnakes.CastBuff(Target, Me.HasAura(Auras.RaptorForm) && !Me.HasAura(Auras.TwinSnakes, true, SabinSettingsModel.Instance.TwinSnakesRfsh) && !Me.HasAura(Auras.PerfectBalance) && ((SabinSettingsModel.Instance.UseHoldPositionals && !Target.IsBehind && Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.TwinSnakes, 13000);
        }

        private static async Task<bool> ArmOfTheDestroyer()
        {
            return await Spells.ArmoftheDestroyer.CastBuff(Me, SabinSettingsModel.Instance.UseAoE && SabinSettingsModel.Instance.UseArmoftheDestroyer && Me.EnemiesInRange(5) >= SabinSettingsModel.Instance.MobCount && Me.CurrentTP >= SabinSettingsModel.Instance.TpLimit, Auras.RaptorForm);
        }

        private static async Task<bool> Demolish()
        {
            return await Spells.Demolish.CastBuff(Target, !Target.HasAura(Auras.Demolish, true, SabinSettingsModel.Instance.DemolishRfsh) && SabinSettingsModel.Instance.UseDoTs && !Me.HasAura(Auras.PerfectBalance) && Target.AuraCount() < 29 && Target.HealthCheck(true) && Target.TimeToDeathCheck() && Target.TimeToDeathCheck() && ((SabinSettingsModel.Instance.UseHoldPositionals && Target.IsBehind && !Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.Opo_opoForm);
        }

        private static async Task<bool> FistsofWind()
        {
            if (!Me.HasAura(Auras.FistsofWind))
            {
                return await Spells.FistsofWind.CastBuff(Me, true, Auras.FistsofWind);
            }
            return false;
        }

        private static async Task<bool> SteelPeak()
        {
            return await Spells.SteelPeak.Use(Target, Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Mantra()
        {
            return await Spells.Mantra.CastBuff(Me, SabinSettingsModel.Instance.UseMantra && Me.CurrentHealthPercent <= 70, Auras.Mantra);
        }

        private static async Task<bool> HowlingFist()
        {
            return await Spells.HowlingFist.Use(Target, SabinSettingsModel.Instance.UseHowlingFist && (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0)) && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> PerfectBalance()
        {
            return await Spells.PerfectBalance.CastBuff(Me, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0)) && SabinSettingsModel.Instance.UsePerfectBalance && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.PerfectBalance);
        }

        private static async Task<bool> Feint()
        {
            return await Spells.Feint.CastDot(Target, SabinSettingsModel.Instance.UseFeint
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.Feint);
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, CombatHelper.OnGcd && Me.CurrentTPPercent <= 50 && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Bloodbath()
        {
            return await Spells.Bloodbath.CastBuff(Me, SabinSettingsModel.Instance.UseBloodbath && Me.CurrentHealthPercent <= SabinSettingsModel.Instance.BloodbathHpPct);
        }

        private static async Task<bool> Rockbreaker()
        {
            return await Spells.Rockbreaker.CastBuff(Target, SabinSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(8) >= SabinSettingsModel.Instance.MobCount && ((SabinSettingsModel.Instance.UseHoldPositionals && Target.IsBehind && !Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.Opo_opoForm);
        }

        private static async Task<bool> ShoulderTackle()
        {
            return await Spells.ShoulderTackle.Use(Target, (SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0))
                && SabinSettingsModel.Instance.UseShoulderTackle
                && Target.Distance(Me) >= SabinSettingsModel.Instance.ShoulderTackleMinDistance
                && (Me.HasAura(Auras.RiddleofFire) || Me.HasAura(Auras.RiddleofEarth) || Me.ClassLevel < Spells.RiddleofEarth.LevelAcquired)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> DragonKick()
        {
            return await Spells.DragonKick.CastBuff(Target,
                !Target.HasAura(Auras.BluntResistanceDown, false, SabinSettingsModel.Instance.DragonKickRfsh)
                && !Me.HasAura(Auras.PerfectBalance)
                && Target.AuraCount() < 29
                && Me.HasAura(Auras.Opo_opoForm, true)
                && ((SabinSettingsModel.Instance.UseHoldPositionals && !Target.IsBehind && Target.IsFlanking) || !SabinSettingsModel.Instance.UseHoldPositionals), Auras.RaptorForm);
        }

        private static async Task<bool> Meditation()
        {
            return await Spells.Meditation.Use(Target, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0))
                && SabinSettingsModel.Instance.UseBuffs
                && ActionResourceManager.Monk.FithChakra == 5
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> ElixirField()
        {
            return await Spells.ElixirField.Use(Me, SabinSettingsModel.Instance.UseElixirField && (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0)) && Target?.Distance() <= 5 && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> TornadoKick()
        {
            return await Spells.TornadoKick.Use(Target, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0)) && SabinSettingsModel.Instance.UseTornadoKick && (Me.HasAura(Auras.PerfectBalance) || Spells.PerfectBalance.Cooldown.TotalSeconds <= 5) && SabinSettingsModel.Instance.UseBuffs && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> RiddleofEarth()
        {
            return await Spells.RiddleofEarth.Use(Me, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0))
                && SabinSettingsModel.Instance.UseBuffs
                && SabinSettingsModel.Instance.UseRiddleofEarth
                && !Me.HasAura(Auras.RiddleofFire)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> RiddleofFire()
        {
            return await Spells.RiddleofFire.Use(Me, (!SabinSettingsModel.Instance.UseHoldoGcDs || (SabinSettingsModel.Instance.UseHoldoGcDs && ActionResourceManager.Monk.GreasedLightning != 0))
                && SabinSettingsModel.Instance.UseBuffs
                && (!Me.HasAura(Auras.RiddleofEarth) || (!SabinSettingsModel.Instance.UseRiddleofEarth && Me.HasAura(Auras.RiddleofEarth)))
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Brotherhood()
        {
            if (!PartyManager.IsInParty || PartyManager.NumMembers < 4) return false;

            return await Spells.RiddleofFire.Use(Me, SabinSettingsModel.Instance.UseBuffs
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        #region Misc

        private static async Task<bool> Interrupt()
        {
            if (SabinSettingsModel.Instance.UseManualInterrupt || Target == null || !Target.CanAttack) return false;

            if (SabinSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LegSweep.Use(Target, true);

            return Target != null && await Spells.LegSweep.Use(Target, !SabinSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> Fist()
        {
            if ((Me.HasAura(Auras.RiddleofEarth) && SabinSettingsModel.Instance.UseRiddleofEarth) || Me.HasAura(Auras.RiddleofFire)) return false;

            switch (SabinSettingsModel.Instance.Fist)
            {
                case FistMode.None:
                    return false;

                case FistMode.Fire:
                    if (!Me.HasAura(Auras.FistsofFire))
                        return await Spells.FistsofFire.CastBuff(Me, true, Auras.FistsofFire);
                    break;

                case FistMode.Earth:
                    if (!Me.HasAura(Auras.FistsofEarth))
                        return await Spells.FistsofEarth.CastBuff(Me, true, Auras.FistsofEarth);
                    break;

                case FistMode.Wind:
                    if (!Me.HasAura(Auras.FistsofWind))
                        return await Spells.FistsofWind.CastBuff(Me, true, Auras.FistsofWind);
                    break;

                default:
                    return false;
            }
            return false;
        }

        private static async Task<bool> OocFistsofWind()
        {
            if (Me.HasTarget && Target.IsValid && Target.CanAttack)
                return await Fist();

            return await Spells.FistsofWind.CastBuff(Me, SabinSettingsModel.Instance.UseOocFistsofWind && !Me.HasAura(Auras.FistsofWind) && Me.EnemiesInRange(30) == 0 && !Me.HasTarget, Auras.FistsofWind);
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !SabinSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        private static async Task<bool> Meditation_Form_Dance()
        {
            if ((Target == null || !Target.CanAttack) && ActionResourceManager.Monk.FithChakra != 5)
            {
                return await Spells.Meditation.Use(Me, ActionResourceManager.Monk.FithChakra != 5);
            }

            if ((Target == null || !Target.CanAttack) && !Me.HasAura(Auras.CoeurlForm, true))
            {
                return await Spells.FormShift.Use(Me, SabinSettingsModel.Instance.UseFormShift && !Me.HasAura(Auras.CoeurlForm));
            }

            return false;
        }

        #endregion Misc
    }
}