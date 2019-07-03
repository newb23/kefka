using System;
using ff14bot;
using GreyMagic;

namespace Kefka.Utilities
{
    internal class Memory
    {
        internal static IntPtr _instanceTimeRemainingPattern = new PatternFinder(Core.Memory).Find("Search 48 8D 0D ? ? ? ? E8 ? ? ? ? 44 8B 44 24 ? BA ? ? ? ? Add 3 TraceRelative");
    }
}