using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Advanced
{
    public partial class CombatSettings : UserControl
    {
        public CombatSettings()
        {
            InitializeComponent();
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