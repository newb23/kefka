using Kefka.ViewModels;

namespace Kefka.Models
{
    public class OpenerSpellInfo : BaseViewModel
    {
        #region Fields

        private string spellName;
        private uint spellId;
        private bool isPet, isItem;

        #endregion Fields

        #region Properties

        public string SpellName
        {
            get { return spellName; }
            set
            {
                spellName = value;
                OnPropertyChanged();
            }
        }

        public uint SpellId
        {
            get { return spellId; }
            set
            {
                spellId = value;
                OnPropertyChanged();
            }
        }

        public bool IsPet
        {
            get { return isPet; }
            set
            {
                isPet = value;
                OnPropertyChanged();
            }
        }

        public bool IsItem
        {
            get { return isItem; }
            set
            {
                isItem = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}