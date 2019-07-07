using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;
using Newtonsoft.Json;

namespace Kefka.Models
{
    public class CyanSettingsModel : BaseModel
    {
        private static CyanSettingsModel _instance;
        public static CyanSettingsModel Instance => _instance ?? (_instance = new CyanSettingsModel());

        private CyanSettingsModel() : base(CharacterSettingsDirectory +
                                           "/Kefka/Routine Settings/Cyan/Cyan_Settings.json")
        {
        }

        private volatile bool _useGoadTarget,
            _useBuffs,
            _useNinjutsu,
            _useAoE,
            _useDpsPotion,
            _useAgeha,
            _useShukuchi,
            _useDots,
            _useSeigan,
            _useOpener,
            _useGuren,
            _useMercifulEyes,
            _useShadwalkerTarget,
            _useManualShadewalker,
            _useInterruptList,
            _useIaijutsu,
            _useGyoten,
            _useManualInterrupt,
            _useManualGoad,
            _useEnpi,
            _useShadeShift,
            _useThirdEye;

        private volatile bool _showGoadTarget,
            _showBuffs,
            _showNinjutsu,
            _showAoE,
            _showDpsPotion,
            _showAgeha,
            _showShukuchi,
            _showDots,
            _showSeigan,
            _showOpener,
            _showGuren,
            _showMercifulEyes,
            _showShadwalkerTarget,
            _showManualShadewalker,
            _showInterruptList,
            _showIaijutsu,
            _showGyoten,
            _showManualInterrupt,
            _showManualGoad,
            _showEnpi,
            _showShadeShift,
            _showThirdEye;

        private volatile int _armorCrushRfsh,
            _higanbanaMinHpPct,
            _higanbanaRfsh,
            _mobCount,
            _suitonHpInt,
            _suitonHpPct,
            _tpLimit,
            _mudraAdjust,
            _ninjutsuAdjust,
            _goadTp,
            _higanbanaMinHpInt,
            _bloodbathHpPct,
            _mercifulEyesHpPct,
            _secondWindHpPct;

        [JsonIgnore] public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);

        [JsonIgnore] public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public void UncheckUseInterruptList()
        {
            if (UseManualInterrupt)
                UseInterruptList = false;
        }

        public void UncheckUseManualInterrupt()
        {
            if (_useInterruptList)
                UseManualInterrupt = false;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseGoadTarget
        {
            get => _useGoadTarget;
            set
            {
                _useGoadTarget = value;
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
        public bool UseNinjutsu
        {
            get => _useNinjutsu;
            set
            {
                _useNinjutsu = value;
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
        public bool UseAgeha
        {
            get => _useAgeha;
            set
            {
                _useAgeha = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseShukuchi
        {
            get => _useShukuchi;
            set
            {
                _useShukuchi = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30000)]
        public int ArmorCrushRfsh
        {
            get => _armorCrushRfsh;
            set
            {
                _armorCrushRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(10)]
        public int HiganbanaMinHpPct
        {
            get => _higanbanaMinHpPct;
            set
            {
                _higanbanaMinHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int HiganbanaRfsh
        {
            get => _higanbanaRfsh;
            set
            {
                _higanbanaRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDots
        {
            get => _useDots;
            set
            {
                _useDots = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMercifulEyes
        {
            get => _useMercifulEyes;
            set
            {
                _useMercifulEyes = value;
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
        [DefaultValue(0)]
        public int SuitonHpInt
        {
            get => _suitonHpInt;
            set
            {
                _suitonHpInt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(0)]
        public int SuitonHpPct
        {
            get => _suitonHpPct;
            set
            {
                _suitonHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        {
            get => _tpLimit;
            set
            {
                _tpLimit = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSeigan
        {
            get => _useSeigan;
            set
            {
                _useSeigan = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int MudraAdjust
        {
            get => _mudraAdjust;
            set
            {
                _mudraAdjust = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)] public bool UseOpener
        {
            get => _useOpener;
            set
            {
                _useOpener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseGuren
        {
            get => _useGuren;
            set
            {
                _useGuren = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int NinjutsuAdjust
        {
            get => _ninjutsuAdjust;
            set
            {
                _ninjutsuAdjust = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(400)]
        public int GoadTp
        {
            get => _goadTp;
            set
            {
                _goadTp = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)] public bool UseShadewalkerTarget
        {
            get => _useShadwalkerTarget;
            set
            {
                _useShadwalkerTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseInterruptList
        {
            get => _useInterruptList;
            set
            {
                _useInterruptList = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseIaijutsu
        {
            get => _useIaijutsu;
            set
            {
                _useIaijutsu = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)] public bool UseManualInterrupt
        {
            get => _useManualInterrupt;
            set
            {
                _useManualInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)] public bool UseGyoten
        {
            get => _useGyoten;
            set
            {
                _useGyoten = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)] public bool UseManualGoad
        {
            get => _useManualGoad;
            set
            {
                _useManualGoad = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseManualShadewalker
        {
            get => _useManualShadewalker;
            set
            {
                _useManualShadewalker = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseShadeShift
        {
            get => _useShadeShift;
            set
            {
                _useShadeShift = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int BloodbathHpPct
        {
            get => _bloodbathHpPct;
            set
            {
                _bloodbathHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseThirdEye
        {
            get => _useThirdEye;
            set
            {
                _useThirdEye = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int MercifulEyesHpPct
        {
            get => _mercifulEyesHpPct;
            set
            {
                _mercifulEyesHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int HiganbanaMinHpInt
        {
            get => _higanbanaMinHpInt;
            set
            {
                _higanbanaMinHpInt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseEnpi
        {
            get => _useEnpi;
            set
            {
                _useEnpi = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGoadTarget
        {
            get => _showGoadTarget;
            set
            {
                _showGoadTarget = value;
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
        public bool ShowNinjutsu
        {
            get => _showNinjutsu;
            set
            {
                _showNinjutsu = value;
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
        public bool ShowAgeha
        {
            get => _showAgeha;
            set
            {
                _showAgeha = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShukuchi
        {
            get => _showShukuchi;
            set
            {
                _showShukuchi = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDots
        {
            get => _showDots;
            set
            {
                _showDots = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMercifulEyes
        {
            get => _showMercifulEyes;
            set
            {
                _showMercifulEyes = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSeigan
        {
            get => _showSeigan;
            set
            {
                _showSeigan = value;
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
        public bool ShowGuren
        {
            get => _showGuren;
            set
            {
                _showGuren = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadewalkerTarget
        {
            get => _showShadwalkerTarget;
            set
            {
                _showShadwalkerTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        {
            get => _showInterruptList;
            set
            {
                _showInterruptList = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowIaijutsu
        {
            get => _showIaijutsu;
            set
            {
                _showIaijutsu = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        {
            get => _showManualInterrupt;
            set
            {
                _showManualInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGyoten
        {
            get => _showGyoten;
            set
            {
                _showGyoten = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualGoad
        {
            get => _showManualGoad;
            set
            {
                _showManualGoad = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualShadewalker
        {
            get => _showManualShadewalker;
            set
            {
                _showManualShadewalker = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadeShift
        {
            get => _showShadeShift;
            set
            {
                _showShadeShift = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowThirdEye
        {
            get => _showThirdEye;
            set
            {
                _showThirdEye = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnpi
        {
            get => _showEnpi;
            set
            {
                _showEnpi = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        {
            get => _secondWindHpPct;
            set
            {
                _secondWindHpPct = value;
                OnPropertyChanged();
            }
        }
    }
}