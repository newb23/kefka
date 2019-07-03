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

namespace Kefka.Routine_Files.Remiel
{
    internal partial class RemielRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct)
                {
                    if (Me.CurrentManaPercent < MainSettingsModel.Instance.RestMpPct)
                    {
                        if (MovementManager.IsMoving)
                        {
                            Navigator.PlayerMover.MoveStop();
                        }
                        Logger.RemielLog(@"Taking a quick breather...");
                        await Coroutine.Wait(5000, () => Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    }

                    await Heal();
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await SectSwitch()) return true;
            if (await Play()) return true;
            return await Protect();
        }

        public static async Task<bool> Pull()
        {
            return await Combat();
        }

        public static async Task<bool> Heal()
        {
            if (await Play()) return true;
            if (await Healbusters()) return true;
            if (await Largesse()) return true;
            if (await EarthlyStar()) return true;
            if (await EssentialDignity()) return true;
            if (await Synastry()) return true;
            if (await Lightspeed()) return true;
            if (await EyeForAnEye()) return true;
            if (await LucidDreaming()) return true;
            if (await Helios()) return true;
            if (await AspectedHelios()) return true;
            if (await CollectiveUnconscious()) return true;
            if (await BeneficII()) return true;
            if (await Ascend()) return true;
            if (await Benefic()) return true;
            if (await AspectedBenefic()) return true;
            if (await Protect()) return true;
            return await Esuna();
        }

        public static async Task<bool> CombatBuff()
        {
            if (await ClericStance()) return true;
            if (await CelestialOpposition()) return true;
            if (await TimeDilation()) return true;
            return await Play();
        }

        public static async Task<bool> Combat()
        {
            if (await Play()) return true;
            if (await Healbusters()) return true;

            if (!RemielSettingsModel.Instance.DoDamage || Target == null || !Target.CanAttack ||
                 (Me.CurrentManaPercent < RemielSettingsModel.Instance.DamageMinMpPct && PartyManager.IsInParty && !MainSettingsModel.Instance.DestroyTarget) ||
                 (GameObjectExtensions.HealManager.Any(hm => ((hm.CurrentHealthPercent <= HighestHealSetting && (!hm.HasAura(Auras.AspectedBenefic) && !hm.HasAura(Auras.AspectedHelios))) || hm.CurrentHealthPercent <= HighestFloorSetting) && hm.Distance(Me) <= 30) && Me.ClassLevel > 1)) return false;

            if (await Combust()) return true;
            if (await Gravity()) return true;
            return await Malefic();
        }

        public static async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}