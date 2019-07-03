using ff14bot;
using Kefka.Utilities;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static Kefka.Utilities.Constants;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class MainHotkeysModel : BaseModel
    {
        private static MainHotkeysModel _instance;
        public static MainHotkeysModel Instance => _instance ?? (_instance = new MainHotkeysModel());

        private MainHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Main_Hotkeys.json")
        {
        }

        private volatile Keys _destroy, _marker, _overlay, _goad;

        private volatile ModifierKeys _destroyModifier, _markerModifier, _overlayModifier, _goadModifier;

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DestroyKey
        {
            get => _destroy;
            set { _destroy = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DestroyModifier
        {
            get => _destroyModifier;
            set { _destroyModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OverlayKey
        {
            get => _overlay;
            set { _overlay = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OverlayModifier
        {
            get => _overlayModifier;
            set { _overlayModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MarkerKey
        {
            get => _marker;
            set { _marker = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MarkerModifier
        {
            get => _markerModifier;
            set { _markerModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys GoadKey
        {
            get => _goad;
            set { _goad = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GoadModifier
        {
            get => _goadModifier;
            set { _goadModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Kefka_Destroy", DestroyKey, DestroyModifier, hk =>
            {
                MainSettingsModel.Instance.DestroyTarget = !MainSettingsModel.Instance.DestroyTarget;
                {
                    ToastManager.AddToast(MainSettingsModel.Instance.DestroyTarget ? "Destroy Enabled!" : "Destroy Disabled!", TimeSpan.FromMilliseconds(750), Colors.Red, Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.KefkaLog(MainSettingsModel.Instance.DestroyTarget ? "Destroy Enabled!" : "Destroy Disabled!");
                }
            });

            HotkeyManager.Register("Kefka_Marker", MarkerKey, MarkerModifier, hk =>
            {
                ToastManager.AddToast("Marker Set!", TimeSpan.FromMilliseconds(750), Color.FromRgb(255, 77, 172), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.KefkaLog("Marker set at: {0}", DateTime.Now.ToString("h:mm:ss"));
            });

            HotkeyManager.Register("Kefka_UIToggle", OverlayKey, OverlayModifier, hk =>
            {
                MainSettingsModel.Instance.UseEnemyOverlay = !MainSettingsModel.Instance.UseEnemyOverlay;
                MainSettingsModel.Instance.UsePositionalOverlay = !MainSettingsModel.Instance.UsePositionalOverlay;
                MainSettingsModel.Instance.UseToggleOverlay = !MainSettingsModel.Instance.UseToggleOverlay;
                {
                    ToastManager.AddToast(MainSettingsModel.Instance.UseToggleOverlay ? "Overlays Enabled!" : "Overlays Disabled!", TimeSpan.FromMilliseconds(750), Colors.Red, Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.KefkaLog(MainSettingsModel.Instance.UseToggleOverlay ? "Overlays Enabled!" : "Overlays Disabled!");
                }
            });

            HotkeyManager.Register("Kefka_Goad", GoadKey, GoadModifier, hk =>
            {
                MainSettingsModel.Instance.UseManualGoad = !MainSettingsModel.Instance.UseManualGoad;
                {
                    ToastManager.AddToast(MainSettingsModel.Instance.UseManualGoad ? "Goad Enabled!" : "Goad Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(MainSettingsModel.Instance.UseManualGoad), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (MainSettingsModel.Instance.UseManualGoad)
                        if (MainSettingsModel.Instance.UseGoadTarget)
                            MainSettingsModel.Instance.UseGoadTarget = false;

                    Logger.KefkaLog(MainSettingsModel.Instance.UseManualGoad ? "Goad Enabled!" : "Goad Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Kefka_Destroy");
            HotkeyManager.Unregister("Kefka_Marker");
            HotkeyManager.Unregister("Kefka_UIToggle");
            HotkeyManager.Unregister("Kefka_Goad");
        }
    }
}