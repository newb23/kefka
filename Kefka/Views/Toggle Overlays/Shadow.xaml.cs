using System.Windows;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Shadow.xaml
    /// </summary>
    public partial class Shadow
    {
        public Shadow()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            ShadowSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            ShadowSettingsModel.Instance.UseManualInterrupt = false;
        }

        private void UncheckManualGoad(object sender, RoutedEventArgs e)
        {
            MainSettingsModel.Instance.UseManualGoad = false;
        }

        private void UncheckGoadTarget(object sender, RoutedEventArgs e)
        {
            MainSettingsModel.Instance.UseGoadTarget = false;
        }

        private void UncheckManualShadewalker(object sender, RoutedEventArgs e)
        {
            ShadowSettingsModel.Instance.UseManualShadewalker = false;
        }

        private void UncheckShadewalkerTarget(object sender, RoutedEventArgs e)
        {
            ShadowSettingsModel.Instance.UseShadewalkerTarget = false;
        }
    }
}