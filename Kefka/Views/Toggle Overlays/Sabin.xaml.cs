using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Sabin.xaml
    /// </summary>
    public partial class Sabin
    {
        public Sabin()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            SabinSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            SabinSettingsModel.Instance.UseManualInterrupt = false;
        }
    }
}