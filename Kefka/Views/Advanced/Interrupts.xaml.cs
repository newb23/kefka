using System.Windows;
using System.Windows.Controls;
using Kefka.ViewModels;

namespace Kefka.Views.Advanced
{
    public partial class Interrupts : UserControl
    {
        public Interrupts()
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

        private void LstInterrupts_OnLostFocus(object sender, RoutedEventArgs e)
        {
            InterruptViewModel.Instance.Save();
        }
    }
}