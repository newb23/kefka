using ff14bot;
using ff14bot.Enums;
using Kefka.Models;
using Kefka.Views;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Application = System.Windows.Application;

namespace Kefka.Utilities
{
    internal class FormManager
    {
        private static KefkaWindow form;
        private static bool infoOverlayJob;

        public static void SaveFormInstances()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                MainSettingsModel.Instance.Save();
                BarretSettingsModel.Instance.Save();
                BeatrixSettingsModel.Instance.Save();
                CecilSettingsModel.Instance.Save();
                CyanSettingsModel.Instance.Save();
                EdwardSettingsModel.Instance.Save();
                EikoSettingsModel.Instance.Save();
                ElayneSettingsModel.Instance.Save();
                FreyaSettingsModel.Instance.Save();
                MikotoSettingsModel.Instance.Save();
                PaineSettingsModel.Instance.Save();
                RemielSettingsModel.Instance.Save();
                SabinSettingsModel.Instance.Save();
                ShadowSettingsModel.Instance.Save();
                SuritoSettingsModel.Instance.Save();
                ViviSettingsModel.Instance.Save();

                BarretHotkeysModel.Instance.Save();
                BeatrixHotkeysModel.Instance.Save();
                CecilHotkeysModel.Instance.Save();
                CyanHotkeysModel.Instance.Save();
                EdwardHotkeysModel.Instance.Save();
                EikoHotkeysModel.Instance.Save();
                ElayneHotkeysModel.Instance.Save();
                FreyaHotkeysModel.Instance.Save();
                MikotoHotkeysModel.Instance.Save();
                PaineHotkeysModel.Instance.Save();
                RemielHotkeysModel.Instance.Save();
                SabinHotkeysModel.Instance.Save();
                ShadowHotkeysModel.Instance.Save();
                SuritoHotkeysModel.Instance.Save();
                ViviHotkeysModel.Instance.Save();
                MainHotkeysModel.Instance.Save();
            });
        }

        private static KefkaWindow Form
        {
            get
            {
                if (form != null) return form;
                form = new KefkaWindow();
                form.Closed += (sender, args) => form = null;
                return form;
            }
        }

        public static void OpenForms()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (Form.IsVisible)
                {
                    Form.Activate();
                    return;
                }

                Form.Show();
            });
        }

        public static void CloseOverlays()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (Kefka.windowInitialized)
                    if (Form.IsVisible)
                        Form.Hide();

                BoundInfoOverlay.Stop();
                BoundToggleOverlay.Stop();
                EnemyOverlay.Stop();
            });
        }

        public static void Window_Check()
        {
            if (WindowCheck.ApplicationIsActivated())
                Application.Current.Dispatcher.InvokeAsync(ClassChange);
        }

        public static void ClassChange()
        {
            if (TreeRoot.IsRunning)
                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    switch (Core.Me.CurrentJob)
                    {
                        case ClassJobType.Machinist:
                        case ClassJobType.Gladiator:
                        case ClassJobType.Paladin:
                        case ClassJobType.DarkKnight:
                        case ClassJobType.Archer:
                        case ClassJobType.Bard:
                        case ClassJobType.Marauder:
                        case ClassJobType.Warrior:
                        case ClassJobType.Thaumaturge:
                        case ClassJobType.BlackMage:
                        case ClassJobType.Conjurer:
                        case ClassJobType.WhiteMage:
                        case ClassJobType.Astrologian:
                        case ClassJobType.Scholar:
                        case ClassJobType.RedMage:

                            infoOverlayJob = false;
                            ClassChangeSubMethod();
                            break;

                        case ClassJobType.Pugilist:
                        case ClassJobType.Monk:
                        case ClassJobType.Lancer:
                        case ClassJobType.Dragoon:
                        case ClassJobType.Arcanist:
                        case ClassJobType.Summoner:
                        case ClassJobType.Rogue:
                        case ClassJobType.Ninja:
                        case ClassJobType.Samurai:
                            infoOverlayJob = true;
                            ClassChangeSubMethod();
                            break;

                        default:
                            BoundInfoOverlay.Stop();
                            BoundToggleOverlay.Stop();
                            EnemyOverlay.Stop();
                            break;
                    }
                });
        }

        private static void ClassChangeSubMethod()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (MainSettingsModel.Instance.UseToggleOverlay &&
                    !BoundToggleOverlay.KefkaBoundToggleOverlayIsVisible)
                {
                    BoundToggleOverlay.Start();
                }

                if (MainSettingsModel.Instance.UsePositionalOverlay &&
                    !BoundInfoOverlay.KefkaBoundInfoOverlayIsVisible &&
                    infoOverlayJob)
                {
                    BoundInfoOverlay.Start();
                }

                if (!MainSettingsModel.Instance.UseToggleOverlay && BoundToggleOverlay.KefkaBoundToggleOverlayIsVisible)
                    BoundToggleOverlay.Stop();

                if ((!MainSettingsModel.Instance.UsePositionalOverlay || !infoOverlayJob) && BoundInfoOverlay.KefkaBoundInfoOverlayIsVisible)
                    BoundInfoOverlay.Stop();

                if (MainSettingsModel.Instance.UseEnemyOverlay && !EnemyOverlay.KefkaEnemyOverlayIsVisible)
                    EnemyOverlay.Start();

                if (!MainSettingsModel.Instance.UseEnemyOverlay && EnemyOverlay.KefkaEnemyOverlayIsVisible)
                    EnemyOverlay.Stop();
            });
        }

        public static void DisableToggleOverlay()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                MainSettingsModel.Instance.UseToggleOverlay = false;
            });
        }

        public static void DisablePositionalOverlay()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                MainSettingsModel.Instance.UsePositionalOverlay = false;
            });
        }

        public static void DisableEnemyInfoOverlay()
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                MainSettingsModel.Instance.UseEnemyOverlay = false;
            });
        }

        public static void ResetOverlayPositions()
        {
            var messageBoxResult = MessageBox.Show("Center the settings window over your FFXIV window. \n This will close RB. Are you sure?", "Close and reset overlays", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CloseOverlays();

                MainSettingsModel.Instance.EnemyInfoX = MainSettingsModel.Instance.MainWindowX;
                MainSettingsModel.Instance.EnemyInfoY = MainSettingsModel.Instance.MainWindowY;

                MainSettingsModel.Instance.PositionOverlayX = MainSettingsModel.Instance.MainWindowX;
                MainSettingsModel.Instance.PositionOverlayY = MainSettingsModel.Instance.MainWindowY;

                MainSettingsModel.Instance.ToggleOverlayX = MainSettingsModel.Instance.MainWindowX;
                MainSettingsModel.Instance.ToggleOverlayY = MainSettingsModel.Instance.MainWindowY;

                MainSettingsModel.Instance.Save();

                Process.GetCurrentProcess().Kill();
            }
        }
    }
}