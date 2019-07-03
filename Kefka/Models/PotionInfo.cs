using Kefka.ViewModels;

namespace Kefka.Models
{
    public class PotionInfo : BaseViewModel
    {
        private string potionName;
        private uint potionId;

        public string PotionName
        {
            get { return potionName; }
            set
            {
                potionName = value;
                OnPropertyChanged();
            }
        }

        public uint PotionId
        {
            get { return potionId; }
            set
            {
                potionId = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{potionName}{potionId}";
        }
    }
}