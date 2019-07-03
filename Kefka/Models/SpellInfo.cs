using Kefka.ViewModels;

namespace Kefka.Models
{
    public class SpellInfo : BaseViewModel
    {
        #region Fields

        private string npcName, spellName;
        private uint npcId, spellId;
        private bool canStun, canSilence;

        #endregion Fields

        #region Properties

        public string NpcName
        {
            get { return npcName; }
            set
            {
                npcName = value;
                OnPropertyChanged();
            }
        }

        public uint NpcId
        {
            get { return npcId; }
            set
            {
                npcId = value;
                OnPropertyChanged();
            }
        }

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

        public bool CanStun
        {
            get { return canStun; }
            set
            {
                canStun = value;
                OnPropertyChanged();
            }
        }

        public bool CanSilence
        {
            get { return canSilence; }
            set
            {
                canSilence = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}