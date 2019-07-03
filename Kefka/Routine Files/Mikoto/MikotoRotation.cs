using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.Mikoto
{
    internal partial class MikotoRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent < MainSettingsModel.Instance.RestMpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.MikotoLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            return await Protect();
        }

        public static async Task<bool> Pull()
        {
            if (await Aero()) return true;
            return await Stone();
        }

        public static async Task<bool> Heal()
        {
            if (await Healbusters()) return true;
            if (await PlenaryIndulgence()) return true;
            if (await Benediction()) return true;
            if (await Tetragrammaton()) return true;
            if (await DivineBenison()) return true;
            if (await Asylum()) return true;
            if (await LucidDreaming()) return true;
            if (await ThinAir()) return true;
            if (await PresenceOfMind()) return true;
            if (await Largesse()) return true;
            if (await EyeForAnEye()) return true;
            if (await Assize()) return true;
            if (await Medica()) return true;
            if (await MedicaII()) return true;
            if (await CureIII()) return true;
            if (await CureII()) return true;
            if (await Raise()) return true;
            if (await Protect()) return true;
            if (await Regen()) return true;
            if (await Cure()) return true;
            return await Esuna();
        }

        public static async Task<bool> CombatBuff()
        {
            if (await ClericStance()) return true;
            return await FluidAura();
        }

        public static async Task<bool> Combat()
        {
            if (await Healbusters()) return true;

            if (!MikotoSettingsModel.Instance.DoDamage || 
                Target == null || !Target.CanAttack || 
                (Me.CurrentManaPercent < MikotoSettingsModel.Instance.DamageMinMpPct && PartyManager.IsInParty && !MainSettingsModel.Instance.DestroyTarget) || 
                (GameObjectExtensions.HealManager.Any(hm => hm.CurrentHealthPercent < MikotoSettingsModel.Instance.CureHpPct) && (PartyManager.IsInParty || Me.ClassLevel > 3))) return false;

            //if (await Repose()) return true;

            if (await AeroIII()) return true;
            if (await Holy()) return true;
            if (await Aero()) return true;
            return await Stone();
        }

        public static async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}