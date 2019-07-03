using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Freya.xaml
    /// </summary>
    public partial class Freya : UserControl
    {
        public Freya()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            FreyaSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            FreyaSettingsModel.Instance.UseManualInterrupt = false;
        }

        private void UncheckTargetDragonSight(object sender, RoutedEventArgs e)
        {
            FreyaSettingsModel.Instance.UseTargetDragonSight = false;
        }

        private void UncheckManualDragonSight(object sender, RoutedEventArgs e)
        {
            FreyaSettingsModel.Instance.UseManualDragonSight = false;
        }
    }
}