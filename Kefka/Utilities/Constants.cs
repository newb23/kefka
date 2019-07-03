using ff14bot;
using ff14bot.Objects;

namespace Kefka.Utilities
{
    internal static class Constants
    {
        public static bool InGcInstance;

        internal static LocalPlayer Me => Core.Player;
        internal static GameObject Target => Core.Player.CurrentTarget;
    }
}