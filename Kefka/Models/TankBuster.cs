using Kefka.ViewModels;

namespace Kefka.Models
{
    public class TankBuster : BaseViewModel
    {
        private string spellName;
        private uint spellId;

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

        public bool Convalescence
        {
            get { return convalescence; }
            set
            {
                convalescence = value;
                OnPropertyChanged();
            }
        }

        public bool Awareness
        {
            get { return awareness; }
            set
            {
                awareness = value;
                OnPropertyChanged();
            }
        }

        public bool DivineVeil
        {
            get { return divineVeil; }
            set
            {
                divineVeil = value;
                OnPropertyChanged();
            }
        }

        public bool Sheltron
        {
            get { return sheltron; }
            set
            {
                sheltron = value;
                OnPropertyChanged();
            }
        }

        public bool HallowedGround
        {
            get { return hallowedGround; }
            set
            {
                hallowedGround = value;
                OnPropertyChanged();
            }
        }

        public bool Sentinel
        {
            get { return sentinel; }
            set
            {
                sentinel = value;
                OnPropertyChanged();
            }
        }

        public bool Foresight
        {
            get { return foresight; }
            set
            {
                foresight = value;
                OnPropertyChanged();
            }
        }

        public bool Bulwark
        {
            get { return bulwark; }
            set
            {
                bulwark = value;
                OnPropertyChanged();
            }
        }

        public bool Rampart
        {
            get { return rampart; }
            set
            {
                rampart = value;
                OnPropertyChanged();
            }
        }

        public bool ThrillofBattle
        {
            get { return thrillOfBattle; }
            set
            {
                thrillOfBattle = value;
                OnPropertyChanged();
            }
        }

        public bool Holmgang
        {
            get { return holmgang; }
            set
            {
                holmgang = value;
                OnPropertyChanged();
            }
        }

        public bool Vengeance
        {
            get { return vengeance; }
            set
            {
                vengeance = value;
                OnPropertyChanged();
            }
        }

        public bool Equilibrium
        {
            get { return equilibrium; }
            set
            {
                equilibrium = value;
                OnPropertyChanged();
            }
        }

        public bool RawIntuition
        {
            get { return rawIntuition; }
            set
            {
                rawIntuition = value;
                OnPropertyChanged();
            }
        }

        public bool Anticipation
        {
            get { return anticipation; }
            set
            {
                anticipation = value;
                OnPropertyChanged();
            }
        }

        public bool ShadowWall
        {
            get { return shadowWall; }
            set
            {
                shadowWall = value;
                OnPropertyChanged();
            }
        }

        public bool DarkMind
        {
            get { return darkMind; }
            set
            {
                darkMind = value;
                OnPropertyChanged();
            }
        }

        public bool BlackestNight
        {
            get { return blackestNight; }
            set
            {
                blackestNight = value;
                OnPropertyChanged();
            }
        }

        public bool LivingDead
        {
            get { return livingDead; }
            set
            {
                livingDead = value;
                OnPropertyChanged();
            }
        }

        public bool Reprisal
        {
            get { return reprisal; }
            set
            {
                reprisal = value;
                OnPropertyChanged();
            }
        }

        public bool Palisade
        {
            get { return palisade; }
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