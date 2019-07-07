using Kefka.ViewModels;

namespace Kefka.Models
{
    public class SpellInfo : BaseViewModel
    {
        #region Fields

        private string _npcName, _spellName;
        private uint _npcId, _spellId;
        private bool _canStun, _canSilence;

        #endregion Fields

        #region Properties

        public string NpcName
        {
            get => _npcName;
            set
            {
                _npcName = value;
                OnPropertyChanged();
            }
        }

        public uint NpcId
        {
            get => _npcId;
            set
            {
                _npcId = value;
                OnPropertyChanged();
            }
        }

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

        public bool CanStun
        {
            get => _canStun;
            set
            {
                _canStun = value;
                OnPropertyChanged();
            }
        }

        public bool CanSilence
        {
            get => _canSilence;
            set
            {
                _canSilence = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}