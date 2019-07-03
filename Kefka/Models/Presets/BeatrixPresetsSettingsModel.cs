using System.ComponentModel;
using System.Configuration;
using Newtonsoft.Json;
using static Kefka.Utilities.Constants;

namespace Kefka.Models
{
    public class BeatrixPresetsSettingsModel : BaseModel
    {
        private static BeatrixPresetsSettingsModel _instance;
        public static BeatrixPresetsSettingsModel Instance => _instance ?? (_instance = new BeatrixPresetsSettingsModel());

        private BeatrixPresetsSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Beatrix/Beatrix_Preset_Settings.json")
        {
        }

        private string _preset1Path, _preset2Path, _preset3Path, _preset4Path, _preset5Path;

        private string _preset1Name, _preset2Name, _preset3Name, _preset4Name, _preset5Name;

        private bool _showPreset1, _showPreset2, _showPreset3, _showPreset4, _showPreset5;

        [Setting]
        [DefaultValue("Preset 1")]
        public string Preset1Name
        {
            get => _preset1Name;
            set
            {
                _preset1Name = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public string Preset1Path
        {
            get => _preset1Path;
            set
            {
                _preset1Path = value;
                ShowPreset1 = Preset1Path != null;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool ShowPreset1
        {
            get => _showPreset1;
            set
            {
                _showPreset1 = Preset1Path != null;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue("Preset 2")]
        public string Preset2Name
        {
            get => _preset2Name;
            set
            {
                _preset2Name = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public string Preset2Path
        {
            get => _preset2Path;
            set
            {
                _preset2Path = value;
                ShowPreset2 = Preset2Path != null;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool ShowPreset2
        {
            get => _showPreset2;
            set
            {
                _showPreset2 = Preset2Path != null;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue("Preset 3")]
        public string Preset3Name
        {
            get => _preset3Name;
            set
            {
                _preset3Name = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public string Preset3Path
        {
            get => _preset3Path;
            set
            {
                _preset3Path = value;
                ShowPreset3 = Preset3Path != null;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool ShowPreset3
        {
            get => _showPreset3;
            set
            {
                _showPreset3 = Preset3Path != null;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue("Preset 4")]
        public string Preset4Name
        {
            get => _preset4Name;
            set
            {
                _preset4Name = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public string Preset4Path
        {
            get => _preset4Path;
            set
            {
                _preset4Path = value;
                ShowPreset4 = Preset4Path != null;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool ShowPreset4
        {
            get => _showPreset4;
            set
            {
                _showPreset4 = Preset4Path != null;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue("Preset 5")]
        public string Preset5Name
        {
            get => _preset5Name;
            set
            {
                _preset5Name = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public string Preset5Path
        {
            get => _preset5Path;
            set
            {
                _preset5Path = value;
                ShowPreset5 = Preset5Path != null;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool ShowPreset5
        {
            get => _showPreset5;
            set
            {
                _showPreset5 = Preset5Path != null;
                OnPropertyChanged();
            }
        }
    }
}