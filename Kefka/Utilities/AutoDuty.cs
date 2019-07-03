using System;
using System.Media;
using System.Runtime.InteropServices;
using ff14bot.Managers;
using ff14bot.RemoteWindows;
using Kefka.Models;
using Kefka.Properties;

namespace Kefka.Utilities
{
    internal class AutoDuty
    {
        public AutoDuty()
        {
            joinTimeSet = false;
            commenced = false;
        }

        private static DateTime joinTime, autoDutyPulseRejectTime;
        private static bool dutyReady, joinTimeSet, commenced;

        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);

        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);

        public static void AutoDutyRoot()
        {
            if (DutyManager.InInstance || (!MainSettingsModel.Instance.AutoDutyNotify && !MainSettingsModel.Instance.AutoCommenceDuty))
            {
                if (DateTime.Now < autoDutyPulseRejectTime) return;

                autoDutyPulseRejectTime = DateTime.Now.Add(TimeSpan.FromSeconds(30));

                return;
            }
            if (DutyManager.DutyReady)
            {
                if (!dutyReady)
                {
                    dutyReady = true;
                    if (MainSettingsModel.Instance.AutoDutyNotify)
                    {
                        // Calculate the volume that's being set
                        double newVolume = ushort.MaxValue * MainSettingsModel.Instance.AutoDutyVolume / 1000;

                        var v = ((uint)newVolume) & 0xffff;
                        var vAll = v | (v << 16);

                        // Set the volume
                        WaveOutSetVolume(IntPtr.Zero, vAll);

                        Play();
                    }
                    Logger.KefkaLog(@"Duty is ready!");
                    Reset();
                }

                if (MainSettingsModel.Instance.AutoCommenceDuty)
                    Commence();
            }
            else
                dutyReady = false;
        }

        public static void Commence()
        {
            if (!joinTimeSet)
            {
                joinTime = DateTime.Now.Add(TimeSpan.FromSeconds(MainSettingsModel.Instance.AutoCommenceDelay));
                joinTimeSet = true;
            }

            if (!commenced && DateTime.Now > joinTime && ContentsFinderConfirm.IsOpen)
            {
                DutyManager.Commence();
                commenced = true;
            }
        }

        public static void Reset()
        {
            commenced = false;
            joinTimeSet = false;
        }

        public static void Play()
        {
            SoundPlayer sndplayr = new SoundPlayer(Resources.DutyReady);
            sndplayr.Play();
        }
    }
}