using System;
using Buddy.Overlay;
using Buddy.Overlay.Controls;
using ff14bot;
using Kefka.Models;
using Kefka.Utilities;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Application = System.Windows.Application;
using Control = System.Windows.Forms.Control;

namespace Kefka.Views
{
    public partial class KefkaBoundToggleOverlay
    {
        public KefkaBoundToggleOverlay()
        {
            InitializeComponent();
            SelectTheme();
        }

        #region Theme Switch

        private void SelectTheme()
        {
            switch (MainSettingsModel.Instance.Theme)
            {
                case SelectedTheme.Blue:
                    ChangeThemeColor("Blue");
                    break;

                case SelectedTheme.Pink:
                    ChangeThemeColor("Pink");
                    break;

                case SelectedTheme.Green:
                    ChangeThemeColor("Green");
                    break;

                case SelectedTheme.Red:
                    ChangeThemeColor("Red");
                    break;

                case SelectedTheme.Yellow:
                    ChangeThemeColor("Yellow");
                    break;

                case SelectedTheme.Purple:
                    ChangeThemeColor("Purple");
                    break;

                case SelectedTheme.Orange:
                    ChangeThemeColor("Orange");
                    break;

                case SelectedTheme.Lime:
                    ChangeThemeColor("Lime");
                    break;

                case SelectedTheme.Emerald:
                    ChangeThemeColor("Emerald");
                    break;

                case SelectedTheme.Teal:
                    ChangeThemeColor("Teal");
                    break;

                case SelectedTheme.Cyan:
                    ChangeThemeColor("Cyan");
                    break;

                case SelectedTheme.Cobalt:
                    ChangeThemeColor("Cobalt");
                    break;

                case SelectedTheme.Indigo:
                    ChangeThemeColor("Indigo");
                    break;

                case SelectedTheme.Violet:
                    ChangeThemeColor("Violet");
                    break;

                case SelectedTheme.Magenta:
                    ChangeThemeColor("Magenta");
                    break;

                case SelectedTheme.Crimson:
                    ChangeThemeColor("Crimson");
                    break;

                case SelectedTheme.Amber:
                    ChangeThemeColor("Amber");
                    break;

                case SelectedTheme.Brown:
                    ChangeThemeColor("Brown");
                    break;

                case SelectedTheme.Olive:
                    ChangeThemeColor("Olive");
                    break;

                case SelectedTheme.Steel:
                    ChangeThemeColor("Steel");
                    break;

                case SelectedTheme.Mauve:
                    ChangeThemeColor("Mauve");
                    break;

                case SelectedTheme.Taupe:
                    ChangeThemeColor("Taupe");
                    break;

                case SelectedTheme.Sienna:
                    ChangeThemeColor("Sienna");
                    break;

                default:
                    ChangeThemeColor("Steel");
                    break;
            }
        }

        private void ChangeThemeColor(string color)
        {
            try
            {
                if (Resources.MergedDictionaries.Count > 0)
                {
                    Resources.MergedDictionaries.Clear();
                }

                AddResourceDictionary("/KefkaUI.Metro;component/Styles/Controls.xaml");
                AddResourceDictionary("/KefkaUI.Metro;component/Styles/Fonts.xaml");
                AddResourceDictionary("/KefkaUI.Metro;component/Styles/Colors.xaml");
                AddResourceDictionary("/KefkaUI.Metro.IconPacks;component/Themes/IconPacks.xaml");
                AddResourceDictionary($"/KefkaUI.Metro;component/Styles/Accents/{color}.xaml");
                AddResourceDictionary("/KefkaUI.Metro;component/Styles/Accents/BaseDark.xaml");
            }
            catch (Exception e)
            {
                Logger.KefkaLog(e.ToString());
            }
        }

        private void AddResourceDictionary(string source)
        {
            var resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(resourceDictionary);
        }

        #endregion Theme Switch

        private void Close(object sender, RoutedEventArgs e)
        {
            BoundToggleOverlay.Stop();
        }

        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control && WindowCheck.ApplicationIsActivated())
            {
                var currentDeltaGrid = e.Delta;
                if (currentDeltaGrid == 120)
                    MainSettingsModel.Instance.GridRows++;
                else
                {
                    MainSettingsModel.Instance.GridRows--;
                }
            }

            if (Control.ModifierKeys == Keys.Shift && WindowCheck.ApplicationIsActivated())
            {
                var currentDeltaOpacity = e.Delta;
                if (currentDeltaOpacity == 120 && MainSettingsModel.Instance.ToggleOverlayOpacity < 1)
                    MainSettingsModel.Instance.ToggleOverlayOpacity = MainSettingsModel.Instance.ToggleOverlayOpacity + 0.05;
                else
                {
                    MainSettingsModel.Instance.ToggleOverlayOpacity = MainSettingsModel.Instance.ToggleOverlayOpacity - 0.05;
                }

                if (MainSettingsModel.Instance.ToggleOverlayOpacity <= 0)
                {
                    MainSettingsModel.Instance.ToggleOverlayOpacity = .1;
                }

                if (MainSettingsModel.Instance.ToggleOverlayOpacity >= 1)
                {
                    MainSettingsModel.Instance.ToggleOverlayOpacity = 1;
                }
            }
        }

        private void ChangeColors(object sender, RoutedEventArgs e)
        {
            SelectTheme();
        }
    }

    public static class BoundToggleOverlay
    {
        public static bool KefkaBoundToggleOverlayIsVisible;

        private static readonly KefkaToggleOverlayUiComponent KefkaOverlayComponent = new KefkaToggleOverlayUiComponent(true);

        public static void Start()
        {
            if (!Core.OverlayManager.IsActive)
            {
                Core.OverlayManager.Activate();
            }
            KefkaBoundToggleOverlayIsVisible = true;
            Core.OverlayManager.AddUIComponent(KefkaOverlayComponent);
        }

        public static void Stop()
        {
            if (!Core.OverlayManager.IsActive)
                return;

            Core.OverlayManager.RemoveUIComponent(KefkaOverlayComponent);
            InterruptManager.ResetInterrupts();
            TankBusterManager.ResetTankBusters();
            FormManager.SaveFormInstances();
            KefkaBoundToggleOverlayIsVisible = false;
        }
    }

    internal class KefkaToggleOverlayUiComponent : OverlayUIComponent
    {
        public KefkaToggleOverlayUiComponent(bool isHitTestable) : base(true)
        {
        }

        private OverlayControl _control;

        public override OverlayControl Control
        {
            get
            {
                if (_control != null)
                    return _control;

                var overlayUc = new KefkaBoundToggleOverlay();

                _control = new OverlayControl
                {
                    Name = "KefkaToggleOverlay",
                    Content = overlayUc,
                    X = MainSettingsModel.Instance.ToggleOverlayX,
                    Y = MainSettingsModel.Instance.ToggleOverlayY,
                    AllowMoving = true
                };

                _control.MouseLeave += (sender, args) =>
                {
                    MainSettingsModel.Instance.ToggleOverlayX = _control.X;
                    MainSettingsModel.Instance.ToggleOverlayY = _control.Y;
                    MainSettingsModel.Instance.Save();
                };

                return _control;
            }
        }
    }
}