using Kefka.ViewModels;

namespace Kefka.Models
{
    public class HealBuster : BaseViewModel
    {
        private string spellName;
        private uint spellId;

        private bool
            cureII,
            benediction,
            tetragrammaton,
            divineBenison,
            medica,
            medicaII,
            plenaryIndulgence,
            asylum,

            adloquium,
            excogitation,
            lustrate,
            aetherpact,
            succor,
            sacredSoil,
            rouse,

            beneficII,
            aspectedBenefic,
            essentialDignity,
            aspectedHelios,
            collectiveUnconscious;

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

        public bool CureII
        {
            get { return cureII; }
            set
            {
                cureII = value;
                OnPropertyChanged();
            }
        }

        public bool Benediction
        {
            get { return benediction; }
            set
            {
                benediction = value;
                OnPropertyChanged();
            }
        }

        public bool Tetragrammaton
        {
            get { return tetragrammaton; }
            set
            {
                tetragrammaton = value;
                OnPropertyChanged();
            }
        }

        public bool DivineBenison
        {
            get { return divineBenison; }
            set
            {
                divineBenison = value;
                OnPropertyChanged();
            }
        }

        public bool Medica
        {
            get { return medica; }
            set
            {
                medica = value;
                OnPropertyChanged();
            }
        }

        public bool MedicaII
        {
            get { return medicaII; }
            set
            {
                medicaII = value;
                OnPropertyChanged();
            }
        }

        public bool PlenaryIndulgence
        {
            get { return plenaryIndulgence; }
            set
            {
                plenaryIndulgence = value;
                OnPropertyChanged();
            }
        }

        public bool Asylum
        {
            get { return asylum; }
            set
            {
                asylum = value;
                OnPropertyChanged();
            }
        }

        public bool Adloquium
        {
            get { return adloquium; }
            set
            {
                adloquium = value;
                OnPropertyChanged();
            }
        }

        public bool Excogitation
        {
            get { return excogitation; }
            set
            {
                excogitation = value;
                OnPropertyChanged();
            }
        }

        public bool Aetherpact
        {
            get { return aetherpact; }
            set
            {
                aetherpact = value;
                OnPropertyChanged();
            }
        }

        public bool Succor
        {
            get { return succor; }
            set
            {
                succor = value;
                OnPropertyChanged();
            }
        }

        public bool SacredSoil
        {
            get { return sacredSoil; }
            set
            {
                sacredSoil = value;
                OnPropertyChanged();
            }
        }

        public bool Lustrate
        {
            get { return lustrate; }
            set
            {
                lustrate = value;
                OnPropertyChanged();
            }
        }

        public bool Rouse
        {
            get { return rouse; }
            set
            {
                rouse = value;
                OnPropertyChanged();
            }
        }

        public bool AspectedBenefic
        {
            get { return aspectedBenefic; }
            set
            {
                aspectedBenefic = value;
                OnPropertyChanged();
            }
        }

        public bool EssentialDignity
        {
            get { return essentialDignity; }
            set
            {
                essentialDignity = value;
                OnPropertyChanged();
            }
        }

        public bool AspectedHelios
        {
            get { return aspectedHelios; }
            set
            {
                aspectedHelios = value;
                OnPropertyChanged();
            }
        }

        public bool CollectiveUnconscious
        {
            get { return collectiveUnconscious; }
            set
            {
                collectiveUnconscious = value;
                OnPropertyChanged();
            }
        }

        public bool BeneficII
        {
            get { return beneficII; }
            set
            {
                beneficII = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{SpellName} : {SpellId}";
        }
    }
}