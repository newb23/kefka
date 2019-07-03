using System;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using static Kefka.Utilities.Constants;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;

using System.Threading.Tasks;

namespace Kefka.Routine_Files.Barret
{
    public static partial class BarretRotation
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
                    Logger.BarretLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await Peloton()) return true;
            if (await GaussBarrel()) return true;
            if (BarretSettingsModel.Instance.UseAutoAmmo)
                if (AmmunitionLoadedStacks < 3 || !AmmunitionLoaded)
                {
                    return await Spells.QuickReload.Use(Me, true);
                }
            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (BarretSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (Me.ClassLevel >= 30 && !Me.HasAura(Auras.HotShot, true, BarretSettingsModel.Instance.HotShotRfsh))
                return await Spells.HotShot.Use(Target, true);

            return await Spells.SplitShot.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            return await SecondWind();
        }

        public static async Task<bool> CombatBuff()
        {
            if (BarretSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await ManualFlamethrower()) return true;
            if (await Overdrive()) return true;

            if (CombatHelper.GcdTimeRemaining < 750) return false;

            if (await DpsPotion()) return true;
            if (await GaussBarrel()) return true;
            if (await AutoTurret()) return true;
            if (await BarrelStabilizer()) return true;
            if (await Invigorate()) return true;
            if (await Reload()) return true;
            if (await QuickReload()) return true;
            if (await RapidFire()) return true;
            if (await Hypercharge()) return true;
            if (await Blank()) return true;
            if (await Refresh()) return true;
            if (await Tactician()) return true;
            if (await ReassembleUnderLevel35()) return true;
            if (await Flamethrower()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await Heartbreak()) return true;
            if (await HeadGraze()) return true;
            if (await Wildfire()) return true;
            if (await Ricochet()) return true;
            if (await RendMind()) return true;
            return await GaussRound();
        }

        public static async Task<bool> Combat()
        {
            if (await ManualFlamethrower()) return true;
            if (await GaussBarrel()) return true;
            if (await HeadGraze()) return true;
            if (await AoE()) return false;
            if (await Wildfire()) return true;
            if (await HotShot()) return true;
            if (await Cooldown()) return true;
            if (await CleanShot()) return true;
            if (await SlugShot()) return true;
            return await SplitShot();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.Wildfire.Use(Target, ActionResourceManager.Machinist.Timer != TimeSpan.Zero)) return true;

            if (await PvPSpells.HotShot.Use(Target, ActionResourceManager.Machinist.Heat < 50 && ActionResourceManager.Machinist.GaussBarrel)) return true;

            if (await PvPSpells.Cooldown.Use(Target, ActionResourceManager.Machinist.Heat > 50 && PvPSpells.Wildfire.Cooldown.TotalMilliseconds > 5000)) return true;

            if (await PvPSpells.GaussBarrel.Use(Me, !ActionResourceManager.Machinist.GaussBarrel)) return true;

            if (await PvPSpells.StunGun.Use(Me, ActionResourceManager.Machinist.Timer != TimeSpan.Zero)) return true;

            if (await PvPSpells.Blank.Use(Target, true)) return true;

            if (await PvPSpells.BetweentheEyes.Use(Target, true)) return true;

            if (await PvPSpells.QuickReload.Use(Me, ActionResourceManager.Machinist.Ammo < 3 && ActionResourceManager.Machinist.Heat >= 50 || ActionResourceManager.Machinist.Timer != TimeSpan.Zero)) return true;

            if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
            _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

            if (ActionResourceManager.Machinist.Heat < 50 && ActionResourceManager.Machinist.GaussBarrel)
                return await PvPSpells.HotShot.Use(Target, true);

            if (ActionManager.DoPvPCombo(PvPCombos.CleanShotCombo, Target))
            {
                _pvpComboTimer = DateTime.Now.AddMilliseconds(1700);
                return true;
            }
            return false;
        }
    }
}