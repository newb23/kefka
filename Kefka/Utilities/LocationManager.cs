using System.Collections.Generic;
using ff14bot.Managers;

namespace Kefka.Utilities
{
    internal class LocationManager
    {
        public static bool OnPvpMap()
        {
            return PvPMapList.Contains(WorldManager.ZoneId);
        }

        internal static readonly HashSet<uint> PvPMapList = new HashSet<uint>
        {
            149, 175, 184, 186, 250, 336, 337, 352, 376, 422, 431, 518, 525, 526, 527, 528, 554, 618, 619
        };
    }
}