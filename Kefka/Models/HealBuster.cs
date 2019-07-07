using Kefka.ViewModels;

namespace Kefka.Models
{
    public class HealBuster : BaseViewModel
    {
        private string _spellName;
        private uint _spellId;

        private bool
            _cureII,
            _benediction,
            _tetragrammaton,
            _divineBenison,
            _medica,
            _medicaII,
            _plenaryIndulgence,
            _asylum,

            _adloquium,
            _excogitation,
            _lustrate,
            _aetherpact,
            _succor,
            _sacredSoil,
            _rouse,

            _beneficII,
            _aspectedBenefic,
            _essentialDignity,
            _aspectedHelios,
            _collectiveUnconscious;

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

        public bool CureII
        {
            get => _cureII;
            set
            {
                _cureII = value;
                OnPropertyChanged();
            }
        }

        public bool Benediction
        {
            get => _benediction;
            set
            {
                _benediction = value;
                OnPropertyChanged();
            }
        }

        public bool Tetragrammaton
        {
            get => _tetragrammaton;
            set
            {
                _tetragrammaton = value;
                OnPropertyChanged();
            }
        }

        public bool DivineBenison
        {
            get => _divineBenison;
            set
            {
                _divineBenison = value;
                OnPropertyChanged();
            }
        }

        public bool Medica
        {
            get => _medica;
            set
            {
                _medica = value;
                OnPropertyChanged();
            }
        }

        public bool MedicaII
        {
            get => _medicaII;
            set
            {
                _medicaII = value;
                OnPropertyChanged();
            }
        }

        public bool PlenaryIndulgence
        {
            get => _plenaryIndulgence;
            set
            {
                _plenaryIndulgence = value;
                OnPropertyChanged();
            }
        }

        public bool Asylum
        {
            get => _asylum;
            set
            {
                _asylum = value;
                OnPropertyChanged();
            }
        }

        public bool Adloquium
        {
            get => _adloquium;
            set
            {
                _adloquium = value;
                OnPropertyChanged();
            }
        }

        public bool Excogitation
        {
            get => _excogitation;
            set
            {
                _excogitation = value;
                OnPropertyChanged();
            }
        }

        public bool Aetherpact
        {
            get => _aetherpact;
            set
            {
                _aetherpact = value;
                OnPropertyChanged();
            }
        }

        public bool Succor
        {
            get => _succor;
            set
            {
                _succor = value;
                OnPropertyChanged();
            }
        }

        public bool SacredSoil
        {
            get => _sacredSoil;
            set
            {
                _sacredSoil = value;
                OnPropertyChanged();
            }
        }

        public bool Lustrate
        {
            get => _lustrate;
            set
            {
                _lustrate = value;
                OnPropertyChanged();
            }
        }

        public bool Rouse
        {
            get => _rouse;
            set
            {
                _rouse = value;
                OnPropertyChanged();
            }
        }

        public bool AspectedBenefic
        {
            get => _aspectedBenefic;
            set
            {
                _aspectedBenefic = value;
                OnPropertyChanged();
            }
        }

        public bool EssentialDignity
        {
            get => _essentialDignity;
            set
            {
                _essentialDignity = value;
                OnPropertyChanged();
            }
        }

        public bool AspectedHelios
        {
            get => _aspectedHelios;
            set
            {
                _aspectedHelios = value;
                OnPropertyChanged();
            }
        }

        public bool CollectiveUnconscious
        {
            get => _collectiveUnconscious;
            set
            {
                _collectiveUnconscious = value;
                OnPropertyChanged();
            }
        }

        public bool BeneficII
        {
            get => _beneficII;
            set
            {
                _beneficII = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{SpellName} : {SpellId}";
        }
    }
}