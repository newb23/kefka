using Kefka.ViewModels;

namespace Kefka.Models
{
    public class IgnoreTargetInfo : BaseViewModel
    {
        #region Fields

        private string ignoreTargetName;
        private uint ignoreTargetId;

        #endregion Fields

        #region Properties

        public string IgnoreTargetName
        {
            get { return ignoreTargetName; }
            set
            {
                ignoreTargetName = value;
                OnPropertyChanged();
            }
        }

        public uint IgnoreTargetId
        {
            get { return ignoreTargetId; }
            set
            {
                ignoreTargetId = value;
                OnPropertyChanged();
            }
        }

        #endregion Properties
    }
}