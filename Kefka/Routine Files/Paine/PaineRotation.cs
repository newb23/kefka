using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;
using System.Threading.Tasks;
using Kefka.Routine_Files.General;

namespace Kefka.Routine_Files.Paine
{
    public static partial class PaineRotation
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
                    Logger.PaineLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            await CountCheck();
            return await Stance();
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (PaineSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (!PaineSettingsModel.Instance.UseDeliverance)
            {
                ButchersCount = 0;
                OverpowerPullCount = 0;
            }

            if (Target.Distance(Me) >= 7)
            {
                if (await Onslaught()) return true;
                if (await Tomahawk()) return true;
            }

            if (await HeavySwing()) return true;

            return false;
        }

        public static async Task<bool> Heal()
        {
            return await Common_Utils.HpPotion();
        }

        public static async Task<bool> CombatBuff()
        {
            if (PaineSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await OverpowerSpam()) return true;
            if (await DpsPotion()) return true;
            if (await Stance()) return true;
            if (await Berserk()) return true;
            if (await InnerRelease()) return true;         
            if (await Unchained()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await Equilibrium()) return true;
            if (await Upheaval()) return true;
            if (await Onslaught()) return false;
            if (await Infuriate()) return true;
            return await Defensives();
        }

        public static async Task<bool> Combat()
        {
            if (ActionManager.LastSpell != Spells.FellCleave && CombatHelper.LastSpell != Spells.FellCleave)
                FellCleaveCount = 0;

            if (await Overpower()) return true;
            if (!PaineSettingsModel.Instance.UseDeliverance)
            {
                if (await SteelCyclone()) return true;
                if (await InnerBeast()) return true;
            }
            if (PaineSettingsModel.Instance.UseDeliverance)
            {
                if (await Decimate()) return true;
                if (await FellCleave()) return true;
            }
            if (await StormsEye()) return true;
            if (await StormsPath()) return true;
            if (await ButchersBlock()) return true;
            if (await Maim()) return true;
            if (await SkullSunder()) return true;
            if (await HeavySwing()) return true;
            return await Tomahawk();
        }

        public static async Task<bool> PVPRotation()

        {
            return false;
        }
    }
}