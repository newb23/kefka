using ff14bot;
using Kefka.Models;
using Kefka.Utilities;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace Kefka.Views
{
    public partial class KefkaWindow
    {
        public KefkaWindow()
        {
            InitializeComponent();
            SelectTheme();

            Kefka.windowInitialized = true;
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
                throw;
            }
        }

        private void AddResourceDictionary(string source)
        {
            var resourceDictionary = Application.LoadComponent(new Uri(source, UriKind.Relative)) as ResourceDictionary;
            Resources.MergedDictionaries.Add(resourceDictionary);
        }

        #endregion Theme Switch

        private void HideWindow(object sender, RoutedEventArgs e)
        {
            InterruptManager.ResetInterrupts();
            TankBusterManager.ResetTankBusters();
            FormManager.SaveFormInstances();
            Hide();
        }

        private void CmbSwitchTheme(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            SelectTheme();
        }
    }
}