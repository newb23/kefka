using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Routines
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
            if (!BeatrixSettingsModel.Instance.UseSwordOath)
            {
                OathButton.Content = "Sword Oath";
                OathButton.ToolTip = "Uses Sword Oath (Click to switch to Shield Oath)";
                BeatrixSettingsModel.Instance.UseSwordOath = true;
            }
            else
            {
                OathButton.Content = "Shield Oath";
                OathButton.ToolTip = "Uses Shield Oath (Click to switch to Sword Oath)";
                BeatrixSettingsModel.Instance.UseSwordOath = false;
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
    }
}