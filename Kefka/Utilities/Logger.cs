using System;
using System.Windows.Media;
using ff14bot.Helpers;
using Kefka.Models;

namespace Kefka.Utilities
{
    internal class Logger
    {
        private static Random random = new Random();

        internal static void KefkaLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Kefka] {text}", args);

            Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(255, 77, 172), $@"[Kefka] {text}", args);
        }

        internal static void BarretLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Barret] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Barret - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(110, 225, 214), $@"[Barret] {text}", args);
        }

        internal static void BeatrixLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Beatrix] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Beatrix - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(168, 210, 230), $@"[Beatrix] {text}", args);
        }

        internal static void CecilLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Cecil] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Cecil - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(246, 85, 241), $@"[Cecil] {text}", args);
        }

        internal static void CyanLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Cyan] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Cyan - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(65, 100, 205), $@"[Cyan] {text}", args);
        }

        internal static void EdwardLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Edward] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Edward - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(144, 178, 102), $@"[Edward] {text}", args);
        }

        internal static void EikoLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Eiko] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Eiko - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(45, 155, 120), $@"[Eiko] {text}", args);
        }

        internal static void ElayneLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Elayne] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Elayne - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(207, 38, 33), $@"[Elayne] {text}", args);
        }

        internal static void FreyaLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Freya] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Freya - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(65, 100, 205), $@"[Freya] {text}", args);
        }

        internal static void MikotoLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Mikoto] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Mikoto - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(189, 189, 174), $@"[Mikoto] {text}", args);
        }

        internal static void PaineLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Paine] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Paine - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(207, 38, 33), $@"[Paine] {text}", args);
        }

        internal static void RemielLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Remiel] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Remiel - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(188, 181, 68), $@"[Remiel] {text}", args);
        }

        internal static void SabinLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Sabin] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Sabin - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(214, 156, 0), $@"[Sabin] {text}", args);
        }

        internal static void ShadowLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Shadow] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Shadow - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(217, 102, 255), $@"[Shadow] {text}", args);
        }

        internal static void SuritoLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Surito] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Surito - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(80, 78, 171), $@"[Surito] {text}", args);
        }

        internal static void ViviLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.RandomizeLogColor && !MainSettingsModel.Instance.DestroyTargetLog)
                Logging.Write(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)), $@"[Vivi] {text}", args);

            if (MainSettingsModel.Instance.DestroyTargetLog && !MainSettingsModel.Instance.OverrideLogColor)
                Logging.Write(Colors.Red, $@"[Vivi - Destroy] {text}", args);
            else Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(165, 121, 214), $@"[Vivi] {text}", args);
        }

        internal static void DebugLog(string text, params object[] args)
        {
            if (MainSettingsModel.Instance.UseDebugLogging)
                Logging.Write(MainSettingsModel.Instance.OverrideLogColor ? MainSettingsModel.Instance.LogColor() : Color.FromRgb(255, 77, 172), $@"[Kefka] {text}", args);
        }

        internal static void CastMessage(string ability, string SafeName)
        {
            var castMessage = $@"====> {ability} on {SafeName}";

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    BarretLog(castMessage);
                    break;

                case "Beatrix":
                    BeatrixLog(castMessage);
                    break;

                case "Cecil":
                    CecilLog(castMessage);
                    break;

                case "Cyan":
                    CyanLog(castMessage);
                    break;

                case "Edward":
                    EdwardLog(castMessage);
                    break;

                case "Eiko":
                    EikoLog(castMessage);
                    break;

                case "Elayne":
                    ElayneLog(castMessage);
                    break;

                case "Freya":
                    FreyaLog(castMessage);
                    break;

                case "Mikoto":
                    MikotoLog(castMessage);
                    break;

                case "Paine":
                    PaineLog(castMessage);
                    break;

                case "Remiel":
                    RemielLog(castMessage);
                    break;

                case "Sabin":
                    SabinLog(castMessage);
                    break;

                case "Shadow":
                    ShadowLog(castMessage);
                    break;

                case "Surito":
                    SuritoLog(castMessage);
                    break;

                case "Vivi":
                    ViviLog(castMessage);
                    break;
            }
        }
    }
}