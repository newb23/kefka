using Kefka.ViewModels;

namespace Kefka.Models
{
    public class PotionInfo : BaseViewModel
    {
        private string _potionName;
        private uint _potionId;

        public string PotionName
        {
            get => _potionName;
            set
            {
                _potionName = value;
                OnPropertyChanged();
            }
        }

        public uint PotionId
        {
            get => _potionId;
            set
            {
                _potionId = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{_potionName}{_potionId}";
        }
    }
}