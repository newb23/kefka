using Kefka.Models;
using System.Windows;
using System.Windows.Controls;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Edward.xaml
    /// </summary>
    public partial class Edward : UserControl
    {
        public Edward()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseManualInterrupt = false;
        }

        private void UncheckTargetNaturesMinne(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseTargetNaturesMinne = false;
        }

        private void UncheckManualNaturesMinne(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseManualNaturesMinne = false;
        }

        private void UncheckTargetPalisade(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseTargetPalisade = false;
        }

        private void UncheckManualPalisade(object sender, RoutedEventArgs e)
        {
            EdwardSettingsModel.Instance.UseManualPalisade = false;
        }
    }
}