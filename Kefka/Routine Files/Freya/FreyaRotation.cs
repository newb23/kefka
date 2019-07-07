using System;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.Freya
{
    public static partial class FreyaRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent < MainSettingsModel.Instance.RestTpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.FreyaLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (FreyaSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await PiercingTalon()) return true;
            if (Me.ClassLevel <= 11)
                if (await Spells.TrueThrust.Use(Target, true)) return true;
            return await Spells.HeavyThrust.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await Bloodbath()) return true;
            return await SecondWind();
        }

        public static async Task<bool> CombatBuff()
        {
            if (FreyaSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await AoESpam()) return true;

            if (!CombatHelper.OnGcd) return false;

            if (await Nastrond()) return true;
            if (await Geirskogul()) return true;

            if (ActionManager.LastSpell == Spells.Jump
                || CombatHelper.LastSpell == Spells.Jump
                || ActionManager.LastSpell == Spells.SpineshatterDive
                || CombatHelper.LastSpell == Spells.SpineshatterDive
                || ActionManager.LastSpell == Spells.DragonfireDive
                || CombatHelper.LastSpell == Spells.DragonfireDive
                || ActionManager.LastSpell == Spells.MirageDive
                || CombatHelper.LastSpell == Spells.MirageDive
                || ActionManager.LastSpell == Spells.Geirskogul
                || CombatHelper.LastSpell == Spells.Geirskogul) return false;

            if (await LifeSurge()) return true;

            if (CombatHelper.GcdTimeRemaining > 1200)
                if (await Jumps()) return true;

            if (await Nastrond()) return true;
            if (await Geirskogul()) return true;
            if (await BloodOfTheDragon()) return true;

            if (await DpsPotion()) return true;

            if (!CombatHelper.OnGcd || CombatHelper.GcdTimeRemaining < 1200) return await OffGcd();

            if (await DragonSight()) return true;
            if (await Common_Utils.Goad()) return true;
            if (await Invigorate()) return true;
            if (await BloodForBlood()) return true;
            if (await InternalRelease()) return true;
            if (await TrueNorth()) return true;

            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await BloodOfTheDragon()) return true;

            if (!CombatHelper.OnGcd || CombatHelper.GcdTimeRemaining < 1000) return false;

            if (ActionManager.LastSpell == Spells.Jump
                || CombatHelper.LastSpell == Spells.Jump
                || ActionManager.LastSpell == Spells.SpineshatterDive
                || CombatHelper.LastSpell == Spells.SpineshatterDive
                || ActionManager.LastSpell == Spells.DragonfireDive
                || CombatHelper.LastSpell == Spells.DragonfireDive
                || ActionManager.LastSpell == Spells.MirageDive
                || CombatHelper.LastSpell == Spells.MirageDive
                || ActionManager.LastSpell == Spells.Geirskogul
                || CombatHelper.LastSpell == Spells.Geirskogul) return false;

            if (CombatHelper.GcdTimeRemaining > 1200)
                if (await Jumps()) return true;

            if (await BattleLitany()) return true;
            if (await Feint()) return true;
            return await LegSweep();
        }

        public static async Task<bool> Combat()
        {
            if (await WheelingThrust()) return true;
            if (await FangAndClaw()) return true;
            if (FreyaSettingsModel.Instance.UseAoE)
            {
                if (await HeavyThrust()) return true;
                if (await SonicThrust()) return true;
                if (await DoomSpike()) return true;
            }

            if (await LegSweep()) return true;
            if (await ChaosThrust()) return true;
            if (await Disembowel()) return true;
            if (await FullThrust()) return true;
            if (await VorpalThrust()) return true;
            if (await HeavyThrust()) return true;
            if (await ImpulseDrive()) return true;
            return await TrueThrust();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.Nastrond.Use(Target, true)) return true;
            if (await PvPSpells.Geirskogul.Use(Target, true)) return true;
            if (await PvPSpells.BloodoftheDragon.Use(Me, true)) return true;
            if (await PvPSpells.SpineshatterDive.Use(Target, CombatHelper.LastSpell != PvPSpells.Jump && ActionResourceManager.Dragoon.DragonGaze < 2 && ActionResourceManager.Dragoon.Timer > TimeSpan.Zero)) return true;
            if (await PvPSpells.Jump.Use(Target, CombatHelper.LastSpell != PvPSpells.SpineshatterDive && ActionResourceManager.Dragoon.DragonGaze < 2 && ActionResourceManager.Dragoon.Timer > TimeSpan.Zero)) return true;
            if (await PvPSpells.Skewer.Use(Target, CombatHelper.LastSpell != PvPSpells.SpineshatterDive && CombatHelper.LastSpell != PvPSpells.Jump)) return true;

            if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
            _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

            if ((!Target.HasAura(PvPAuras.ChaosThrust, true, 6000) && ActionManager.GetPvPComboCurrentAction(PvPCombos.FangandClawCombo) == PvPSpells.TrueThrust) || ActionManager.GetPvPComboCurrentAction(PvPCombos.WheelingThrustCombo) == PvPSpells.WheelingThrust)
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.WheelingThrustCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.WheelingThrustCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(1700);
                    return true;
                }
            }

            if (ActionManager.GetPvPComboCurrentAction(PvPCombos.WheelingThrustCombo) == PvPSpells.ImpulseDive)
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.FangandClawCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.FangandClawCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(1700);
                    return true;
                }
            }
            return false;
        }
    }
}