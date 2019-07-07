using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace Kefka.Models
{
    public class ViviSettingsModel : BaseModel
    {
        private static ViviSettingsModel _instance;
        public static ViviSettingsModel Instance => _instance ?? (_instance = new ViviSettingsModel());

        private ViviSettingsModel() : base(CharacterSettingsDirectory +
                                           "/Kefka/Routine Settings/Vivi/Vivi_Settings.json")
        {
        }

        private bool _useEnochian,
            _useBuffs,
            _useSharpcast,
            _useAoE,
            _useDpsPotion,
            _useSwiftcast,
            _useDoTs,
            _useOpener,
            _useLeyLines,
            _useDiversion,
            _useDefensives,
            _useConvert,
            _useVirus,
            _useScathe,
            _useDrain,
            _useTriplecast;

        private bool _showEnochian,
            _showBuffs,
            _showSharpcast,
            _showAoE,
            _showDpsPotion,
            _showSwiftcast,
            _showDoTs,
            _showOpener,
            _showLeyLines,
            _showDiversion,
            _showDefensives,
            _showConvert,
            _showVirus,
            _showScathe,
            _showDrain,
            _showTriplecast;

        private int _enoRfshPct,
            _thunderRfsh,
            _astralRfsh,
            _mobCount,
            _mpLimit,
            _mpTickMaxDelay,
            _mpMinPct,
            _selfHealPct;

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEnochian
        {
            get => _useEnochian;
            set
            {
                _useEnochian = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        {
            get => _useBuffs;
            set
            {
                _useBuffs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSharpcast
        {
            get => _useSharpcast;
            set
            {
                _useSharpcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseAoE
        {
            get => _useAoE;
            set
            {
                _useAoE = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseDpsPotion
        {
            get => _useDpsPotion;
            set
            {
                _useDpsPotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDiversion
        {
            get => _useDiversion;
            set
            {
                _useDiversion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcast
        {
            get => _useSwiftcast;
            set
            {
                _useSwiftcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLeyLines
        {
            get => _useLeyLines;
            set
            {
                _useLeyLines = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        {
            get => _useOpener;
            set
            {
                _useOpener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int EnoRfshPct
        {
            get => _enoRfshPct;
            set
            {
                _enoRfshPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(6000)]
        public int ThunderRfsh
        {
            get => _thunderRfsh;
            set
            {
                _thunderRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int AstralRfsh
        {
            get => _astralRfsh;
            set
            {
                _astralRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDefensives
        {
            get => _useDefensives;
            set
            {
                _useDefensives = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDoTs
        {
            get => _useDoTs;
            set
            {
                _useDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseConvert
        {
            get => _useConvert;
            set
            {
                _useConvert = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        {
            get => _mobCount;
            set
            {
                _mobCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseVirus
        {
            get => _useVirus;
            set
            {
                _useVirus = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int MpLimit
        {
            get => _mpLimit;
            set
            {
                _mpLimit = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnochian
        {
            get => _showEnochian;
            set
            {
                _showEnochian = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        {
            get => _showBuffs;
            set
            {
                _showBuffs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSharpcast
        {
            get => _showSharpcast;
            set
            {
                _showSharpcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAoE
        {
            get => _showAoE;
            set
            {
                _showAoE = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDpsPotion
        {
            get => _showDpsPotion;
            set
            {
                _showDpsPotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDiversion
        {
            get => _showDiversion;
            set
            {
                _showDiversion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSwiftcast
        {
            get => _showSwiftcast;
            set
            {
                _showSwiftcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLeyLines
        {
            get => _showLeyLines;
            set
            {
                _showLeyLines = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        {
            get => _showOpener;
            set
            {
                _showOpener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDefensives
        {
            get => _showDefensives;
            set
            {
                _showDefensives = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoTs
        {
            get => _showDoTs;
            set
            {
                _showDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowConvert
        {
            get => _showConvert;
            set
            {
                _showConvert = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowVirus
        {
            get => _showVirus;
            set
            {
                _showVirus = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseScathe
        {
            get => _useScathe;
            set
            {
                _useScathe = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowScathe
        {
            get => _showScathe;
            set
            {
                _showScathe = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3000)]
        public int MpTickMaxDelay
        {
            get => _mpTickMaxDelay;
            set
            {
                _mpTickMaxDelay = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int MpMinPct
        {
            get => _mpMinPct;
            set
            {
                _mpMinPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int SelfHealPct
        {
            get => _selfHealPct;
            set
            {
                _selfHealPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDrain
        {
            get => _useDrain;
            set
            {
                _useDrain = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDrain
        {
            get => _showDrain;
            set
            {
                _showDrain = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTriplecast
        {
            get => _useTriplecast;
            set
            {
                _useTriplecast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTriplecast
        {
            get => _showTriplecast;
            set
            {
                _showTriplecast = value;
                OnPropertyChanged();
            }
        }
    }
}