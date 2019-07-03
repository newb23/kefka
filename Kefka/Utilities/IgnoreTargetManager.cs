using System.Collections.Generic;
using Kefka.ViewModels;

namespace Kefka.Utilities
{
    public static class IgnoreTargetManager
    {
        public static HashSet<uint> IgnoreTargets = new HashSet<uint>();

        public static void ResetIgnoreTargets()
        {
            var ignoreTargets = new HashSet<uint>();

            foreach (var ignore in IgnoreTargetsViewModel.Instance.GuiIgnoreTargetsList)
            {
                ignoreTargets.Add(ignore.IgnoreTargetId);
            }

            IgnoreTargets = ignoreTargets;
        }
    }
}