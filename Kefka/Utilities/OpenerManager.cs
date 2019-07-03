using Kefka.Models;
using Kefka.ViewModels.Openers;

namespace Kefka.Utilities
{
    public class OpenerManager
    {
        public static void ResetOpeners()
        {
            BarretSettingsModel.Instance.UseOpener = false;
            BeatrixSettingsModel.Instance.UseOpener = false;
            CecilSettingsModel.Instance.UseOpener = false;
            CyanSettingsModel.Instance.UseOpener = false;
            EdwardSettingsModel.Instance.UseOpener = false;
            EikoSettingsModel.Instance.UseOpener = false;
            ElayneSettingsModel.Instance.UseOpener = false;
            FreyaSettingsModel.Instance.UseOpener = false;
            PaineSettingsModel.Instance.UseOpener = false;
            ShadowSettingsModel.Instance.UseOpener = false;
            SabinSettingsModel.Instance.UseOpener = false;
            ViviSettingsModel.Instance.UseOpener = false;
        }
    }
}