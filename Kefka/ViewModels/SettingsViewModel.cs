using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using System.Windows.Input;
using Kefka.Routine_Files.Eiko;

namespace Kefka.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public static MainSettingsModel Settings => MainSettingsModel.Instance;
        public static BarretSettingsModel Barret => BarretSettingsModel.Instance;
        public static BeatrixSettingsModel Beatrix => BeatrixSettingsModel.Instance;
        public static CecilSettingsModel Cecil => CecilSettingsModel.Instance;
        public static CyanSettingsModel Cyan => CyanSettingsModel.Instance;
        public static EdwardSettingsModel Edward => EdwardSettingsModel.Instance;
        public static EikoSettingsModel Eiko => EikoSettingsModel.Instance;
        public static ElayneSettingsModel Elayne => ElayneSettingsModel.Instance;
        public static FreyaSettingsModel Freya => FreyaSettingsModel.Instance;
        public static MikotoSettingsModel Mikoto => MikotoSettingsModel.Instance;
        public static PaineSettingsModel Paine => PaineSettingsModel.Instance;
        public static RemielSettingsModel Remiel => RemielSettingsModel.Instance;
        public static SabinSettingsModel Sabin => SabinSettingsModel.Instance;
        public static ShadowSettingsModel Shadow => ShadowSettingsModel.Instance;
        public static SuritoSettingsModel Surito => SuritoSettingsModel.Instance;
        public static ViviSettingsModel Vivi => ViviSettingsModel.Instance;
        public static ICommand OpenSettingsForm => new DelegateCommand(Kefka.OnButtonPress);
        public static ICommand ActivateFFXIVCommand => new DelegateCommand(ActivateWindow.ActivateFFXIV);
        public static ICommand OverlayViewUpdate => new DelegateCommand(FormManager.ClassChange);
        public static ICommand DisableToggleOverlayCommand => new DelegateCommand(FormManager.DisableToggleOverlay);
        public static ICommand DisableEnemyInfoOverlayCommand => new DelegateCommand(FormManager.DisableEnemyInfoOverlay);
        public static ICommand SetMarkerCommand => new DelegateCommand(MainSettingsModel.SetMarker);
        public static ICommand OpenColorPickerToastCommand => new DelegateCommand(MainSettingsModel.OpenColorPickerToast);
        public static ICommand OpenColorPickerLogCommand => new DelegateCommand(MainSettingsModel.OpenColorPickerLog);
        public static ICommand OverlayResetCommand => new DelegateCommand(FormManager.ResetOverlayPositions);
    }
}