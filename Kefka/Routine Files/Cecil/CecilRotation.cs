using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.Cecil
{
    public static partial class CecilRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent < MainSettingsModel.Instance.RestTpPct || Me.CurrentManaPercent < MainSettingsModel.Instance.RestMpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.CecilLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await Grit()) return true;

            UnleashCount = 0;

            return await Darkside();
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (CecilSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await Unmend()) return Me.InCombat;
            if (await HardSlash()) return Me.InCombat;
            return Me.InCombat;
        }

        public static async Task<bool> Heal()
        {
            return await Common_Utils.HpPotion();
        }

        public static async Task<bool> CombatBuff()
        {
            if (CecilSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await DpsPotion()) return true;

            if (CombatHelper.GcdTimeRemaining > 500)
            {
                if (await Darkside()) return true;
                if (await DarkArts()) return true;
                if (await Delirium()) return true;
                if (await BloodWeapon()) return true;
                if (await BloodPrice()) return true;
            }
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (CombatHelper.GcdTimeRemaining > 500)
            {
                if (await Defensives()) return true;
                if (await DarkArts()) return true;
                if (await SaltedEarth()) return true;
                if (await CarveAndSpit()) return true;
                if (await SoleSurvivor()) return true;
                if (await DarkPassenger()) return true;
                if (await Plunge()) return true;
                return await LowBlow();
            }
            return false;
        }

        public static async Task<bool> Combat()
        {
            if (CurrentEnemyCount != GameObjectManager.Attackers.Count(r => r.InCombat)) await UnleashCountReset();

            if (Target == null || !Target.CanAttack) return false;

            if (await Grit()) return true;
            if (await ExProvoke()) return true;
            if (await Quietus()) return true;
            if (await Bloodspiller()) return true;
            if (await AbyssalDrain()) return true;
            if (await Unleash()) return true;
            if (await PowerSlash()) return true;
            if (await Souleater()) return true;
            if (await SpinningSlash()) return true;
            if (await SyphonStrike()) return true;
            if (await HardSlash()) return true;
            return await Unmend();

        }

        public static async Task<bool> PVPRotation()

        {
            return false;
        }
    }
}