using System.Windows;
using System.Windows.Controls;
using Kefka.Models;

namespace Kefka.Views.Toggle_Overlays
{
    /// <summary>
    /// Interaction logic for Barret.xaml
    /// </summary>
    public partial class Barret : UserControl
    {
        public Barret()
        {
            InitializeComponent();
        }

        private void UncheckInterruptList(object sender, RoutedEventArgs e)
        {
            BarretSettingsModel.Instance.UseInterruptList = false;
        }

        private void UncheckManualInterrupt(object sender, RoutedEventArgs e)
        {
            BarretSettingsModel.Instance.UseManualInterrupt = false;
        }
    }
}