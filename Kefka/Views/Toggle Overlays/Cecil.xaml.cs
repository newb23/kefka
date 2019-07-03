using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Cecil.xaml
    /// </summary>
    public partial class Cecil : UserControl
    {
        public Cecil()
        {
            InitializeComponent();
        }

        private void GritButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)GritButton.Content == "Darkside Only")
            {
                GritButton.Content = "Grit";
                CecilSettingsModel.Instance.UseGrit = true;
            }

            else
            {
                GritButton.Content = "Darkside Only";
                CecilSettingsModel.Instance.UseGrit = false;
            }
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

        private void Swap_Click(object sender, RoutedEventArgs e)
        {
            CecilSettingsModel.Instance.Swap = true;
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            CecilSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            CecilSettingsModel.Instance.UseManualInterrupt = false;
        }
    }
}