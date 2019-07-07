using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;
using Kefka.Properties;
using Kefka.Utilities;
using Newtonsoft.Json;

namespace Kefka.Models
{
    public class ShadowSettingsModel : BaseModel
    {
        private static ShadowSettingsModel _instance;
        public static ShadowSettingsModel Instance => _instance ?? (_instance = new ShadowSettingsModel());

        private ShadowSettingsModel() : base(CharacterSettingsDirectory +
                                             "/Kefka/Routine Settings/Shadow/Shadow_Settings.json")
        {
        }

        private bool
            _useBuffs,
            _useNinjutsu,
            _useAoE,
            _useDpsPotion,
            _useAssassinate,
            _useShukuchi,
            _useDots,
            _useOpener,
            _useDeathBlossom,
            _useTenChiJin,
            _useShadwalkerTarget,
            _useManualShadewalker,
            _useInterruptList,
            _useMudrasOoc,
            _useAbilitiesFromStealth,
            _useManualInterrupt,
            _useThrowingDagger,
            _useShadeShift,
            _useSmokeScreen,
            _useTrueNorth,
            _useFeint;

        private bool
            _showBuffs,
            _showNinjutsu,
            _showAoE,
            _showDpsPotion,
            _showAssassinate,
            _showShukuchi,
            _showDots,
            _showDynamicPositionals,
            _showOpener,
            _showDeathBlossom,
            _showTenChiJin,
            _showShadwalkerTarget,
            _showManualShadewalker,
            _showInterruptList,
            _showMudrasOoc,
            _showAbilitiesFromStealth,
            _showManualInterrupt,
            _showThrowingDagger,
            _showShadeShift,
            _showSmokeScreen,
            _showTrueNorth,
            _showFeint;

        private int
            _armorCrushRfsh,
            _shadowFangRfsh,
            _mutilateRfsh,
            _mobCount,
            _suitonHpInt,
            _suitonHpPct,
            _tpLimit,
            _mudraAdjust,
            _ninjutsuAdjust,
            _deathBlossomMobCount,
            _shadeShiftHpPct,
            _healingHpPct;

        [JsonIgnore]
        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);

        [JsonIgnore]
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        [JsonIgnore]
        public ICommand UncheckUseShadewalkerTargetCommand => new DelegateCommand(UncheckUseShadewalkerTarget);

        [JsonIgnore]
        public ICommand UncheckUseManualShadewalkerCommand => new DelegateCommand(UncheckUseManualShadewalker);

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

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

        public void UncheckUseShadewalkerTarget()
        {
            if (_useManualShadewalker)
                UseShadewalkerTarget = false;
        }

        public void UncheckUseManualShadewalker()
        {
            if (UseShadewalkerTarget)
                UseManualShadewalker = false;
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
        public bool UseAssassinate
        {
            get => _useAssassinate;
            set
            {
                _useAssassinate = value;
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
        [DefaultValue(7000)]
        public int ShadowFangRfsh
        {
            get => _shadowFangRfsh;
            set
            {
                _shadowFangRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int MutilateRfsh
        {
            get => _mutilateRfsh;
            set
            {
                _mutilateRfsh = value;
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
        public bool UseTenChiJin
        {
            get => _useTenChiJin;
            set
            {
                _useTenChiJin = value;
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
        [DefaultValue(false)]
        public bool UseDeathBlossom
        {
            get => _useDeathBlossom;
            set
            {
                _useDeathBlossom = value;
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
        [DefaultValue(false)]
        public bool UseShadewalkerTarget
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
        public bool UseMudrasOoc
        {
            get => _useMudrasOoc;
            set
            {
                _useMudrasOoc = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        {
            get => _useManualInterrupt;
            set
            {
                _useManualInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseAbilitiesFromStealth
        {
            get => _useAbilitiesFromStealth;
            set
            {
                _useAbilitiesFromStealth = value;
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
        public int ShadeShiftHpPct
        {
            get => _shadeShiftHpPct;
            set
            {
                _shadeShiftHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int DeathBlossomMobCount
        {
            get => _deathBlossomMobCount;
            set
            {
                _deathBlossomMobCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseThrowingDagger
        {
            get => _useThrowingDagger;
            set
            {
                _useThrowingDagger = value;
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
        public bool ShowAssassinate
        {
            get => _showAssassinate;
            set
            {
                _showAssassinate = value;
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
        public bool ShowTenChiJin
        {
            get => _showTenChiJin;
            set
            {
                _showTenChiJin = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDynamicPositionals
        {
            get => _showDynamicPositionals;
            set
            {
                _showDynamicPositionals = value;
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
        public bool ShowDeathBlossom
        {
            get => _showDeathBlossom;
            set
            {
                _showDeathBlossom = value;
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
        public bool ShowMudrasOoc
        {
            get => _showMudrasOoc;
            set
            {
                _showMudrasOoc = value;
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
        public bool ShowAbilitiesFromStealth
        {
            get => _showAbilitiesFromStealth;
            set
            {
                _showAbilitiesFromStealth = value;
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
        public bool ShowThrowingDagger
        {
            get => _showThrowingDagger;
            set
            {
                _showThrowingDagger = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseSmokeScreen
        {
            get => _useSmokeScreen;
            set
            {
                _useSmokeScreen = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSmokeScreen
        {
            get => _showSmokeScreen;
            set
            {
                _showSmokeScreen = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTrueNorth
        {
            get => _useTrueNorth;
            set
            {
                _useTrueNorth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTrueNorth
        {
            get => _showTrueNorth;
            set
            {
                _showTrueNorth = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeint
        {
            get => _useFeint;
            set
            {
                _useFeint = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFeint
        {
            get => _showFeint;
            set
            {
                _showFeint = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int HealingHpPct
        {
            get => _healingHpPct;
            set
            {
                _healingHpPct = value;
                OnPropertyChanged();
            }
        }

        private volatile TCJMode _tcjMode;

        private volatile NinjutsuMode _ninjutsuMode;

        private volatile NinjutsuAoEModeSelection _ninjutsuAoEModeSelection;

        [Setting]
        public TCJMode TcjSelection
        {
            get => _tcjMode;
            set
            {
                _tcjMode = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public NinjutsuMode Ninjutsu
        {
            get => _ninjutsuMode;
            set
            {
                _ninjutsuMode = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        public NinjutsuAoEModeSelection NinjutsuAoEMode
        {
            get => _ninjutsuAoEModeSelection;
            set
            {
                _ninjutsuAoEModeSelection = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public ICommand ChangeTenChiJinSelectionCommand => new DelegateCommand(ChangeTenChiJinSelection);

        private void ChangeTenChiJinSelection()
        {
            switch (TcjSelection)
            {
                case TCJMode.Suiton:
                    TcjSelection = TCJMode.Doton;
                    break;

                case TCJMode.Doton:
                    TcjSelection = TCJMode.None;
                    break;

                case TCJMode.None:
                    TcjSelection = TCJMode.Suiton;
                    break;
            }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TCJMode
    {
        [LocalizedDescription("Suiton", typeof(Strings))]
        Suiton,

        [LocalizedDescription("Doton", typeof(Strings))]
        Doton,

        [LocalizedDescription("None", typeof(Strings))]
        None
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum NinjutsuMode
    {
        [LocalizedDescription("Auto", typeof(Strings))]
        Auto,

        [LocalizedDescription("Raiton", typeof(Strings))]
        Raiton,

        [LocalizedDescription("FumaShuriken", typeof(Strings))]
        FumaShuriken
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum NinjutsuAoEModeSelection
    {
        [LocalizedDescription("KatonDoton", typeof(Strings))]
        KatonDoton,

        [LocalizedDescription("KatonOnly", typeof(Strings))]
        KatonOnly,

        [LocalizedDescription("DotonOnly", typeof(Strings))]
        DotonOnly,

        [LocalizedDescription("None", typeof(Strings))]
        None
    }
}