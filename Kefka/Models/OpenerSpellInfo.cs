using Kefka.ViewModels;

namespace Kefka.Models
{
    public class OpenerSpellInfo : BaseViewModel
    {
        #region Fields

        private string _spellName;
        private uint _spellId;
        private bool _isPet, _isItem;

        #endregion Fields

        #region Properties

        public string SpellName
        {
            get => _spellName;
            set
            {
                _spellName = value;
                OnPropertyChanged();
            }
        }

        public uint SpellId
        {
            get => _spellId;
            set
            {
                _spellId = value;
                OnPropertyChanged();
            }
        }

        public bool IsPet
        {
            get => _isPet;
            set
            {
                _isPet = value;
                OnPropertyChanged();
            }
        }

        public bool IsItem
        {
            get => _isItem;
            set
            {
                _isItem = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}