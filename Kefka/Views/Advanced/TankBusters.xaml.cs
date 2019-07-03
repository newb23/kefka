using System.Windows;
using System.Windows.Controls;

namespace Kefka.Views.Advanced
{
    public partial class TankBusters : UserControl
    {
        public TankBusters()
        {
            InitializeComponent();
        }

        private void SearchAction_OnGotFocus(object sender, RoutedEventArgs e)
        {
            SearchAction.Text = "";
        }

        private void SearchAction_OnLostFocus(object sender, RoutedEventArgs e)
        {
            SearchAction.Text = "Enter Spell Name and Press Enter... ";
        }
    }
}