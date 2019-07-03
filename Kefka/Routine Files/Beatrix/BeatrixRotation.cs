using System;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using static Kefka.Utilities.Constants;
using System.Linq;
using System.Threading.Tasks;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Beatrix
{
    public static partial class BeatrixRotation
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
                    Logger.BeatrixLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            await AutoStance();
            FlashCount = 0;
            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (BeatrixSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await ShieldLob()) return Me.InCombat;
            if (await FastBlade()) return Me.InCombat;
            return Me.InCombat;
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await Clemency()) return true;
            return await Cover();
        }

        public static async Task<bool> CombatBuff()
        {
            if (BarretSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await DpsPotion()) return true;
            if (await Requiescat()) return true;
            if (await FightOrFlight()) return true;
            return await OffGcd();
        }

        public static async Task<bool> OffGcd()
        {
            if (await Swap()) return true;
            if (CombatHelper.GcdTimeRemaining > 1000)
            {
                if (await ShieldBash()) return true;
                if (await SpiritsWithin()) return true;
                if (await Defensives()) return true;
                if (await CircleOfScorn()) return true;
                if (await ShieldSwipe()) return true;
            }
            return false;
        }

        public static async Task<bool> Combat()
        {
            if (CurrentEnemyCount != GameObjectManager.Attackers.Count(r => r.InCombat)) await FlashCountReset();

            if (await AutoStance()) return true;
            if (await Swap()) return true;
            if (await ExProvoke()) return true;

            if (await HolySpirit()) return true;
            if (await TotalEclipse()) return true;
            if (await Flash()) return true;
            if (await RageOfHalone()) return true;
            if (await GoringBlade()) return true;
            if (await RoyalAuthority()) return true;
            if (await RiotBlade()) return true;
            if (await SavageBlade()) return true;
            if (await ShieldLob()) return true;
            return await FastBlade();
        }

        public static async Task<bool> PVPRotation()

        {
            return false;
        }
    }
}