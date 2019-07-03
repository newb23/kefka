using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Paine.xaml
    /// </summary>
    public partial class Paine : UserControl
    {
        public Paine()
        {
            InitializeComponent();
        }

        private void StanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (!PaineSettingsModel.Instance.UseDeliverance)
            {
                StanceButton.Content = "Deliverance";
                PaineSettingsModel.Instance.UseDeliverance = true;
            }

            else
            {
                StanceButton.Content = "Defiance";
                PaineSettingsModel.Instance.UseDeliverance = false;
            }
        }

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            PaineSettingsModel.Instance.Swap = true;
        }

        private void TankButton_Click(object sender, RoutedEventArgs e)
        {
            if (BeatrixSettingsModel.Instance.MainTank)
            {
                TankButton.Content = "Off Tanking";
                TankButton.ToolTip = "Uses abilities for damage ignoring set Enmity settings/abilities (Click to switch to Main Tank)";
                BeatrixSettingsModel.Instance.MainTank = false;
            }
            else
            {
                TankButton.Content = "Main Tanking";
                TankButton.ToolTip = "Uses Enmity abilities to reach set Minimum Enmity Lead settings (Click to switch to Off Tank)";
                BeatrixSettingsModel.Instance.MainTank = true;
            }
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            PaineSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            PaineSettingsModel.Instance.UseManualInterrupt = false;
        }
    }
}