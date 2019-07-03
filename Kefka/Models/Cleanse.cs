using Kefka.ViewModels;

namespace Kefka.Models
{
    public class Cleanse : BaseViewModel
    {
        private string spellName;
        private uint spellId;

        private bool
            leeches,
            esuna,
            exaltedDetriment;

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

        public bool Leeches
        {
            get { return leeches; }
            set
            {
                leeches = value;
                OnPropertyChanged();
            }
        }

        public bool Esuna
        {
            get { return esuna; }
            set
            {
                esuna = value;
                OnPropertyChanged();
            }
        }

        public bool ExaltedDetriment
        {
            get { return exaltedDetriment; }
            set
            {
                exaltedDetriment = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{SpellName} : {SpellId}";
        }
    }
}