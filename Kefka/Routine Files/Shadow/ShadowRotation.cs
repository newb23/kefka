using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using static Kefka.Utilities.Constants;
using Kefka.Utilities;
using System.Threading.Tasks;

namespace Kefka.Routine_Files.Shadow
{
    public static partial class ShadowRotation
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
                    Logger.ShadowLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (await DeathBlossomSpam()) return true;

            if (!ShadowSettingsModel.Instance.UseAbilitiesFromStealth && Me.HasAura(Auras.Hidden))
                return false;

            if (ShadowSettingsModel.Instance.UseMudrasOoc && !WorldManager.InSanctuary)
            {
                await Ninjutsu();
            }

            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (!ShadowSettingsModel.Instance.UseAbilitiesFromStealth && Me.HasAura(Auras.Hidden))
                return false;

            if (ShadowSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await Ninjutsu()) return true;
            if (await TenChiJin()) return true;
            if (await ThrowingDagger()) return true;
            return await SpinningEdge();
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await SecondWind()) return true;
            return await Bloodbath();
        }

        public static async Task<bool> CombatBuff()
        {
            if (await DeathBlossomSpam()) return true;

            if (ShadowSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await Ninjutsu()) return true;
            if (await TenChiJin()) return true;
            if (await Jugulate()) return true;
            if (await Invigorate()) return true;
            if (await ShadeShift()) return true;
            if (await Feint()) return true;
            if (await Common_Utils.Goad()) return true;

            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await Interrupt()) return true;

            if (!CombatHelper.OnGcd || CombatHelper.GcdTimeRemaining < 1800) return false;
            if (Me.HasAura(Auras.Suiton))
            {
                if (await TrueNorth()) return true;
                return await TrickAttack();
            }

            if (await Ninjutsu()) return true;
            if (await TenChiJin()) return true;
            if (await DpsPotion()) return true;
            if (await Jugulate()) return true;
            if (await Bhavacakra()) return true;
            if (await HellfrogMedium()) return true;
            if (await DreamWithinADream()) return true;
            if (await Mug()) return true;
            if (await Shadewalker()) return true;
            if (await SmokeScreen()) return true;

            return await Common_Utils.Goad();
        }

        public static async Task<bool> Combat()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await Ninjutsu()) return true;
            if (await TenChiJin()) return true;
            if (await DeathBlossom()) return true;
            if (await ComboFinal()) return true;
            if (await GustSlash()) return true;
            if (await Assassinate()) return true;
            if (await Shukuchi()) return true;
            if (await SpinningEdge()) return true;
            if (await Ninjutsu()) return true;
            return await TenChiJin();
        }

        public static async Task<bool> PVPRotation()

        {
            return false;
        }
    }
}