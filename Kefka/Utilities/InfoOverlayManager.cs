using System;
using System.Windows.Media;
using ff14bot;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;

namespace Kefka.Utilities
{
    internal class InfoOverlayManager
    {
        public static event EventHandler InfoTextChanged;

        public static event EventHandler PetSelectionChanged;

        public static event EventHandler InfoTextColorChanged;

        private static string combatMode;

        public static string CombatMode
        {
            get { return combatMode; }
            set
            {
                if (value != combatMode)
                {
                    combatMode = value;

                    InfoTextChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        private static string petSelection;

        public static string PetSelection
        {
            get { return petSelection; }
            set
            {
                if (value != petSelection)
                {
                    petSelection = value;

                    PetSelectionChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        private static SolidColorBrush infoTextColor = Brushes.LawnGreen;

        public static SolidColorBrush InfoTextColor
        {
            get { return infoTextColor; }
            set
            {
                if (value != infoTextColor)
                {
                    infoTextColor = value;

                    InfoTextColorChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }

        public static void SelectedPet()
        {
            switch (EikoSettingsModel.Instance.SelectedEikoSummon)
            {
                case EikoSummonMode.Garuda:
                    PetSelection = "Garuda";
                    break;

                case EikoSummonMode.Titan:
                    PetSelection = "Titan";
                    break;

                case EikoSummonMode.Ifrit:
                    PetSelection = "Ifrit";
                    break;

                case EikoSummonMode.None:
                    PetSelection = "None";
                    return;
            }
        }

        public static void CombatModeText()
        {
            if (EikoSettingsModel.Instance.UseAoE)
            {
                CombatMode = "AoE";
                InfoTextChanged?.Invoke(null, EventArgs.Empty);
            }
            else
            {
                CombatMode = "Single"; InfoTextChanged?.Invoke(null, EventArgs.Empty);
            }
        }
    }
}