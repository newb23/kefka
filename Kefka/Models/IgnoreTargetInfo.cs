using Kefka.ViewModels;

namespace Kefka.Models
{
    public class IgnoreTargetInfo : BaseViewModel
    {
        #region Fields

        private string _ignoreTargetName;
        private uint _ignoreTargetId;

        #endregion Fields

        #region Properties

        public string IgnoreTargetName
        {
            get => _ignoreTargetName;
            set
            {
                _ignoreTargetName = value;
                OnPropertyChanged();
            }
        }

        public uint IgnoreTargetId
        {
            get => _ignoreTargetId;
            set
            {
                _ignoreTargetId = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}