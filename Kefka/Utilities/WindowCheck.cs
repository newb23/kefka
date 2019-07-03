using ff14bot;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Kefka.Utilities
{
    internal class WindowCheck
    {
        public static int FFIXVPID = Core.OverlayManager.AttachedProcess.Id;

        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }

            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);
            int nProcessID = Process.GetCurrentProcess().Id;

            return activeProcId == FFIXVPID || activeProcId == nProcessID;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
    }
}