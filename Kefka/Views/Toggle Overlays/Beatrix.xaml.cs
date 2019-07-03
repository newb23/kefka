using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Beatrix.xaml
    /// </summary>
    public partial class Beatrix : UserControl
    {
        public Beatrix()
        {
            InitializeComponent();
        }

        private void OathButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)OathButton.Content == "Shield Oath")
            {
                OathButton.Content = "Sword Oath";
                BeatrixSettingsModel.Instance.UseSwordOath = true;
            }

            else
            {
                OathButton.Content = "Shield Oath";
                BeatrixSettingsModel.Instance.UseSwordOath = false;
            }
        }

        private void TankButton_Click(object sender, RoutedEventArgs r)
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
            BeatrixSettingsModel.Instance.Swap = true;
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseManualInterrupt = false;
        }

        private void UncheckManualClemency(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseManualClemency = false;
        }

        private void UncheckClemencyTarget(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseClemencyTarget = false;
        }

        private void UncheckManualCover(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseManualCover = false;
        }

        private void UncheckCoverTarget(object sender, RoutedEventArgs e)
        {
            BeatrixSettingsModel.Instance.UseCoverTarget = false;
        }
    }
}