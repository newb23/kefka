using Kefka.ViewModels;

namespace Kefka.Models
{
    public class TankBuster : BaseViewModel
    {
        private string _spellName;
        private uint _spellId;

        private bool
            convalescence,
            awareness,
            divineVeil,
            sheltron,
            hallowedGround,
            sentinel,
            foresight,
            bulwark,
            rampart,
            thrillOfBattle,
            holmgang,
            vengeance,
            equilibrium,
            rawIntuition,
            anticipation,
            shadowWall,
            darkMind,
            blackestNight,
            livingDead,
            reprisal,
            palisade;

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

        public bool Convalescence
        {
            get => convalescence;
            set
            {
                convalescence = value;
                OnPropertyChanged();
            }
        }

        public bool Awareness
        {
            get => awareness;
            set
            {
                awareness = value;
                OnPropertyChanged();
            }
        }

        public bool DivineVeil
        {
            get => divineVeil;
            set
            {
                divineVeil = value;
                OnPropertyChanged();
            }
        }

        public bool Sheltron
        {
            get => sheltron;
            set
            {
                sheltron = value;
                OnPropertyChanged();
            }
        }

        public bool HallowedGround
        {
            get => hallowedGround;
            set
            {
                hallowedGround = value;
                OnPropertyChanged();
            }
        }

        public bool Sentinel
        {
            get => sentinel;
            set
            {
                sentinel = value;
                OnPropertyChanged();
            }
        }

        public bool Foresight
        {
            get => foresight;
            set
            {
                foresight = value;
                OnPropertyChanged();
            }
        }

        public bool Bulwark
        {
            get => bulwark;
            set
            {
                bulwark = value;
                OnPropertyChanged();
            }
        }

        public bool Rampart
        {
            get => rampart;
            set
            {
                rampart = value;
                OnPropertyChanged();
            }
        }

        public bool ThrillofBattle
        {
            get => thrillOfBattle;
            set
            {
                thrillOfBattle = value;
                OnPropertyChanged();
            }
        }

        public bool Holmgang
        {
            get => holmgang;
            set
            {
                holmgang = value;
                OnPropertyChanged();
            }
        }

        public bool Vengeance
        {
            get => vengeance;
            set
            {
                vengeance = value;
                OnPropertyChanged();
            }
        }

        public bool Equilibrium
        {
            get => equilibrium;
            set
            {
                equilibrium = value;
                OnPropertyChanged();
            }
        }

        public bool RawIntuition
        {
            get => rawIntuition;
            set
            {
                rawIntuition = value;
                OnPropertyChanged();
            }
        }

        public bool Anticipation
        {
            get => anticipation;
            set
            {
                anticipation = value;
                OnPropertyChanged();
            }
        }

        public bool ShadowWall
        {
            get => shadowWall;
            set
            {
                shadowWall = value;
                OnPropertyChanged();
            }
        }

        public bool DarkMind
        {
            get => darkMind;
            set
            {
                darkMind = value;
                OnPropertyChanged();
            }
        }

        public bool BlackestNight
        {
            get => blackestNight;
            set
            {
                blackestNight = value;
                OnPropertyChanged();
            }
        }

        public bool LivingDead
        {
            get => livingDead;
            set
            {
                livingDead = value;
                OnPropertyChanged();
            }
        }

        public bool Reprisal
        {
            get => reprisal;
            set
            {
                reprisal = value;
                OnPropertyChanged();
            }
        }

        public bool Palisade
        {
            get => palisade;
            set
            {
                palisade = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{SpellName} : {SpellId}";
        }
    }
}