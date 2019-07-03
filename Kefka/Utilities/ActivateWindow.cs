using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ff14bot;

namespace Kefka.Utilities
{
    internal class ActivateWindow
    {
        public static int FFIXVPID = Core.OverlayManager.AttachedProcess.Id;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        internal static void ActivateFFXIV()
        {
            Process p = Process.GetProcessById(FFIXVPID);
            if (p != null)
            {
                SetForegroundWindow(p.MainWindowHandle);
            }
        }
    }
}