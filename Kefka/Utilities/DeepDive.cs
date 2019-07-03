using ff14bot.Managers;
using Kefka.Models;

namespace Kefka.Utilities
{
    internal class DeepDive
    {
        internal static void DeepDiveInterruptOverride()
        {
            if (!BotManager.Current.Name.Contains("DeepDive")) return;

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    BarretSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Beatrix":
                    BeatrixSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Cecil":
                    CecilSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Cyan":
                    CyanSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Edward":
                    EdwardSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Elayne":
                    break;

                case "Freya":
                    FreyaSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Paine":
                    PaineSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Sabin":
                    SabinSettingsModel.Instance.UseManualInterrupt = true;
                    break;

                case "Shadow":
                    ShadowSettingsModel.Instance.UseManualInterrupt = true;
                    break;
            }
        }
    }
}