using Kefka.ViewModels;

namespace Kefka.Models
{
    public class Cleanse : BaseViewModel
    {
        private string _spellName;
        private uint _spellId;

        private bool
            _leeches,
            _esuna,
            _exaltedDetriment;

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

        public bool Leeches
        {
            get => _leeches;
            set
            {
                _leeches = value;
                OnPropertyChanged();
            }
        }

        public bool Esuna
        {
            get => _esuna;
            set
            {
                _esuna = value;
                OnPropertyChanged();
            }
        }

        public bool ExaltedDetriment
        {
            get => _exaltedDetriment;
            set
            {
                _exaltedDetriment = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{SpellName} : {SpellId}";
        }
    }
}