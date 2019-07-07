using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using static Kefka.Utilities.Constants;
using static Kefka.Utilities.Extensions.GameObjectExtensions;

namespace Kefka.Routine_Files.Surito
{
    internal partial class SuritoRotation
    {
        private static SuritoSummonMode previousSuritoSummon;

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
                    Logger.SuritoLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await Summon()) return true;
            if (await Protect()) return true;
            return await Aetherflow();
        }

        public static async Task<bool> Pull()
        {
            if (await Bio()) return true;
            if (await Ruin()) return true;
            return Me.InCombat;
        }

        public static async Task<bool> Heal()
        {
            if (await Resurrection()) return true;
            if (Me.HasAura(Auras.Swiftcast) && HealManager.Any(hm => hm.IsDead && !hm.HasAura(Auras.Raise) && !hm.HasAura(Auras.Raise2))) return false;

            if (await Healbusters()) return true;
            if (await Indomitability()) return true;
            if (await Largesse()) return true;
            if (await Lustrate()) return true;
            if (await Aetherpact()) return true;
            if (await Excogitation()) return true;
            if (await SacredSoil()) return true;
            if (await Rouse()) return true;
            if (await Dissipation()) return true;
            if (await EyeForAnEye()) return true;
            if (await DeploymentTactics()) return true;
            if (await EmergencyTactics()) return true;
            if (await LucidDreaming()) return true;
            if (await Succor()) return true;
            if (await Adloquium()) return true;
            if (await Physick()) return true;
            if (await Esuna()) return true;
            if (await Protect()) return true;
            if (Me.ClassLevel <= 2) return await Common_Utils.HpPotion();
            return await PetAction();
        }

        public static async Task<bool> CombatBuff()
        {
            if (await Summon()) return true;
            if (await Bane()) return true;
            if (await ChainStratagem()) return true;
            if (await ClericStance()) return true;
            if (await PetAction()) return true;
            return await Aetherflow();
        }

        public static async Task<bool> Combat()
        {
            if (await Healbusters()) return true;

            if (!SuritoSettingsModel.Instance.DoDamage ||
                Target == null || !Target.CanAttack || Target.Distance(Me) > 25 ||
                (Me.CurrentManaPercent < SuritoSettingsModel.Instance.DamageMinMpPct && PartyManager.IsInParty && !MainSettingsModel.Instance.DestroyTarget) ||
                (HealManager.Any(hm => hm.CurrentHealthPercent < SuritoSettingsModel.Instance.PhysickHpPct) && (PartyManager.IsInParty || Me.ClassLevel > 3))) return false;

            if (await ClericStance()) return true;
            if (await Summon()) return true;
            if (await EnergyDrain()) return true;
            if (await ShadowFlare()) return true;
            if (await MiasmaII()) return true;
            if (await Miasma()) return true;
            if (await Bio()) return true;
            if (await Broil()) return true;
            if (await PetAction()) return true;
            return await Ruin();
        }

        public static async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}