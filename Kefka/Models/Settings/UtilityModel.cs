using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kefka.Models.Settings
{
    public class Utility
    {
        public Utility(string name, uint id, bool stun, bool silence)
        {
            Name = name;
            Id = id;
            Stun = stun;
            Silence = silence;
        }

        public override string ToString()
        {
            return $"Name: {Name}  Id: {Id}  Stun: {Stun}  Silence: {Silence}";
        }

        private string _name;
        private uint _id;
        private bool _stun, _silence;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public uint Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public bool Stun
        {
            get { return _stun; }
            set
            {
                _stun = value;
                OnPropertyChanged();
            }
        }

        public bool Silence
        {
            get { return _silence; }
            set
            {
                _silence = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}