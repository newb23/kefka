using System;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using System.Threading.Tasks;

namespace Kefka.Routine_Files.Sabin
{
    public static partial class SabinRotation
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
                    Logger.SabinLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await OocFistsofWind()) return true;
            if ((!WorldManager.InSanctuary || Me.InCombat) && Me.ClassLevel >= 54)
                return await Meditation_Form_Dance();
            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (SabinSettingsModel.Instance.UseShoulderTackle)
                await Spells.ShoulderTackle.Use(Target, Target?.Distance() >= 15);

            if (SabinSettingsModel.Instance.UseOpener)
                return await Common_Utils.Opener();

            if (Me.HasAura(Auras.Opo_opoForm))
            {
                return await Spells.Bootshine.Use(Target, true);
            }

            if (Me.HasAura(Auras.RaptorForm))
            {
                if (Me.ClassLevel < 30)
                    return await Spells.TrueStrike.Use(Target, true);

                return await Spells.TwinSnakes.Use(Target, true);
            }

            if (!Me.HasAura(Auras.CoeurlForm) || Me.ClassLevel <= 5) return await Spells.Bootshine.Use(Target, true);

            if (Me.ClassLevel < 30)
                return await Spells.SnapPunch.Use(Target, true);

            return await Spells.Demolish.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            return await Bloodbath();
        }

        public static async Task<bool> CombatBuff()
        {
            if (await Fist()) return true;
            if (SabinSettingsModel.Instance.UseOpener)
                return await Common_Utils.Opener();

            if (await Meditation_Form_Dance()) return true;

            if (CombatHelper.GcdTimeRemaining < 300) return false;

            if (await DpsPotion()) return true;
            if (await Common_Utils.Goad()) return true;
            if (await InternalRelease()) return true;
            if (await Invigorate()) return true;
            if (await Mantra()) return true;
            if (await SecondWind()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await Meditation()) return true;

            if (CombatHelper.GcdTimeRemaining < 300) return false;

            if (await Brotherhood()) return true;
            if (await Feint()) return true;
            if (await PerfectBalance()) return true;
            if (await SteelPeak()) return true;
            if (await TornadoKick()) return true;
            if (await RiddleofEarth()) return true;
            if (await RiddleofFire()) return true;
            if (await ElixirField()) return true;
            if (await HowlingFist()) return true;
            return await Interrupt();
        }

        public static async Task<bool> Combat()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (await DpsPotion()) return true;
            if (await PerfectBalance()) return true;
            if (await ElixirField()) return true;
            if (await HowlingFist()) return true;
            if (await Meditation()) return true;
            if (await ShoulderTackle()) return true;
            if (await DragonKick()) return true;
            if (await TwinSnakes()) return true;
            if (await TrueStrike()) return true;
            if (await ArmOfTheDestroyer()) return true;
            if (await Rockbreaker()) return true;
            if (await Demolish()) return true;
            if (await SnapPunch()) return true;
            return await Bootshine();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.FormShift.Use(Me, ActionResourceManager.Monk.GreasedLightning < 3)) return true;
            if (await PvPSpells.Somersault.Use(Target, PvPSpells.RiddleofFire.Cooldown.TotalMilliseconds < 10000 && ActionResourceManager.Monk.FithChakra < 5 && ActionResourceManager.Monk.GreasedLightning == 3)) return true;
            if (await PvPSpells.RiddleofFire.Use(Me, ActionResourceManager.Monk.GreasedLightning == 3 && ActionResourceManager.Monk.FithChakra == 5)) return true;
            if (await PvPSpells.RiddleofWind.Use(Target, true)) return true;
            if (await PvPSpells.WindTackle.Use(Target, true)) return true;
            if (await PvPSpells.TheForbiddenChakra.Use(Target, Me.HasMyAura(PvPAuras.EarthsReply) || Me.HasMyAura(PvPAuras.RiddleofFire) || PvPSpells.RiddleofFire.Cooldown.TotalMilliseconds > 10000)) return true;
            if (await PvPSpells.TornadoKick.Use(Target, Me.HasMyAura(PvPAuras.EarthsReply) || Me.HasMyAura(PvPAuras.RiddleofFire) || PvPSpells.RiddleofFire.Cooldown.TotalMilliseconds > 10000)) return true;

            if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
            _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

            if (!Target.HasAura(PvPAuras.Demolish, true, 10000) && ActionManager.GetPvPComboCurrentAction(PvPCombos.SnapPunchCombo) == PvPSpells.Bootshine)
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.DemolishCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.DemolishCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(2000);
                    return true;
                }
            }

            if (ActionManager.GetPvPComboCurrentAction(PvPCombos.DemolishCombo) == PvPSpells.DragonKick)
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.SnapPunchCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.SnapPunchCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(2000);
                    return true;
                }
            }

            return false;
        }
    }
}