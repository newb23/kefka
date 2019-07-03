using System;
using System.Windows.Media;

namespace Kefka.ViewModels
{
    public class OverlayViewModel : BaseViewModel
    {
        private static OverlayViewModel _instance;
        public static OverlayViewModel Instance => _instance ?? (_instance = new OverlayViewModel());

        public static event EventHandler PropertyUpdate;

        private string currentPositional, combatMode, petSelection, upcomingPositional;
        private SolidColorBrush _positionalColor;
        private int _fontSize;
        private static SolidColorBrush infoTextColor = Brushes.LawnGreen;

        public string CurrentPositional
        { get { return currentPositional; } set { currentPositional = value; OnPropertyChanged(); } }

        public SolidColorBrush PositionalColor
        { get { return _positionalColor; } set { _positionalColor = value; OnPropertyChanged(); } }

        public string CombatMode
        { get { return combatMode; } set { combatMode = value; OnPropertyChanged(); } }

        public string PetSelection
        { get { return petSelection; } set { petSelection = value; OnPropertyChanged(); } }

        public int FontSize
        { get { return _fontSize; } set { _fontSize = value; OnPropertyChanged(); } }

        public SolidColorBrush InfoTextColor
        { get { return infoTextColor; } set { infoTextColor = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); } }

        public string UpcomingPositional
        { get { return upcomingPositional; } set { upcomingPositional = value; OnPropertyChanged(); } }
    }
}