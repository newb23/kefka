using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot.Helpers;
using ff14bot.Managers;
using Kefka.Models;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.General
{
    internal class Items
    {
        private static bool Use(Item item)
        {
            var useableItem = InventoryManager.FilledSlots.FirstOrDefault(a => a.Item == item);

            if (useableItem == null || !useableItem.IsValid || !useableItem.CanUse())
                return false;

            useableItem.UseItem();
            return true;
        }

        public static async Task<bool> UsePotion(Item item, bool reqs)
        {
            if (!reqs)
                return false;

            if (!Use(item))
                return false;

            Logging.Write(Colors.Firebrick, @"[Kefka] Attempting to use {0}", item.CurrentLocaleName);

            await Coroutine.Wait(Math.Min(MainSettingsModel.Instance.PotionDelayAdjust, 5000), () => Use(item) && Me.HasAura(Auras.Medicated));

            if (!Me.HasAura(Auras.Medicated) && Use(item))
                return false;

            Logging.Write(Colors.Firebrick, @"[Kefka] Used {0}", item.CurrentLocaleName);
            return true;
        }
    }
}