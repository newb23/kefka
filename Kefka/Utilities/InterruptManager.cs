using System.Collections.Generic;
using Kefka.ViewModels;

namespace Kefka.Utilities
{
    public static class InterruptManager
    {
        public static HashSet<uint> SilenceInterrupts = new HashSet<uint>();
        public static HashSet<uint> StunInterrupts = new HashSet<uint>();

        public static void ResetInterrupts()
        {
            var silences = new HashSet<uint>();
            var stuns = new HashSet<uint>();

            foreach (var interrupt in InterruptViewModel.Instance.GuiInterruptsList)
            {
                if (interrupt.CanSilence)
                {
                    silences.Add(interrupt.SpellId);
                }

                if (interrupt.CanStun)
                {
                    stuns.Add(interrupt.SpellId);
                }

                SilenceInterrupts = silences;
                StunInterrupts = stuns;
            }
        }
    }
}