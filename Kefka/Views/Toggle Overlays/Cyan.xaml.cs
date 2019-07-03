using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Cyan.xaml
    /// </summary>
    public partial class Cyan : UserControl
    {
        public Cyan()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            CyanSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            CyanSettingsModel.Instance.UseManualInterrupt = false;
        }

        private void UncheckManualGoad(object sender, RoutedEventArgs e)
        {
            MainSettingsModel.Instance.UseManualGoad = false;
        }

        private void UncheckGoadTarget(object sender, RoutedEventArgs e)
        {
            MainSettingsModel.Instance.UseGoadTarget = false;
        }
    }
}