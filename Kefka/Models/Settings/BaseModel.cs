using System.ComponentModel;
using System.Runtime.CompilerServices;
using ff14bot.Helpers;

namespace Kefka.Models
{
    public abstract class BaseModel : JsonSettings, INotifyPropertyChanged
    {
        #region Constructor

        protected BaseModel(string path) : base(path)
        {
        }

        #endregion Constructor

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged
    }
}