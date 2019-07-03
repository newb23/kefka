using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using ff14bot;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
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

        private ShadowSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Shadow/Shadow_Settings.json")
        {
        }

        private bool _useBuffs, _useNinjutsu, _useAoE, _useDpsPotion, _useAssassinate, _useShukuchi, _useDots, _useOpener, _useDeathBlossom, _useTenChiJin,
            _useShadwalkerTarget, _useManualShadewalker, _useInterruptList, _useMudrasOoc, _useAbilitiesFromStealth, _useManualInterrupt, _useThrowingDagger, _useShadeShift, _useSmokeScreen,
            _useTrueNorth, _useFeint;

        private bool _showBuffs, _showNinjutsu, _showAoE, _showDpsPotion, _showAssassinate, _showShukuchi, _showDots, _showDynamicPositionals, _showOpener, _showDeathBlossom,
            _showTenChiJin, _showShadwalkerTarget, _showManualShadewalker, _showInterruptList, _showMudrasOoc, _showAbilitiesFromStealth, _showManualInterrupt, _showThrowingDagger,
            _showShadeShift, _showSmokeScreen, _showTrueNorth, _showFeint;

        private int _armorCrushRfsh, _shadowFangRfsh, _mutilateRfsh, _mobCount, _suitonHpInt, _suitonHpPct, _tpLimit, _mudraAdjust, _ninjutsuAdjust, _deathBlossomMobCount, _shadeShiftHpPct, _healingHpPct;

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
            {
                LoadFrom(path);
            }
        }

        public void UncheckUseInterruptList()
        { if (UseManualInterrupt) { UseInterruptList = false; } }

        public void UncheckUseManualInterrupt()
        { if (_useInterruptList) { UseManualInterrupt = false; } }

        public void UncheckUseShadewalkerTarget()
        { if (_useManualShadewalker) { UseShadewalkerTarget = false; } }

        public void UncheckUseManualShadewalker()
        { if (UseShadewalkerTarget) { UseManualShadewalker = false; } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseNinjutsu
        { get { return _useNinjutsu; } set { _useNinjutsu = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseAoE
        { get { return _useAoE; } set { _useAoE = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseDpsPotion
        { get { return _useDpsPotion; } set { _useDpsPotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAssassinate
        { get { return _useAssassinate; } set { _useAssassinate = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseShukuchi
        { get { return _useShukuchi; } set { _useShukuchi = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(30000)]
        public int ArmorCrushRfsh
        { get { return _armorCrushRfsh; } set { _armorCrushRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(7000)]
        public int ShadowFangRfsh
        { get { return _shadowFangRfsh; } set { _shadowFangRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4000)]
        public int MutilateRfsh
        { get { return _mutilateRfsh; } set { _mutilateRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDots
        { get { return _useDots; } set { _useDots = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTenChiJin
        { get { return _useTenChiJin; } set { _useTenChiJin = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        { get { return _mobCount; } set { _mobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(0)]
        public int SuitonHpInt
        { get { return _suitonHpInt; } set { _suitonHpInt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(0)]
        public int SuitonHpPct
        { get { return _suitonHpPct; } set { _suitonHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        { get { return _tpLimit; } set { _tpLimit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int MudraAdjust
        { get { return _mudraAdjust; } set { _mudraAdjust = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseDeathBlossom
        { get { return _useDeathBlossom; } set { _useDeathBlossom = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int NinjutsuAdjust
        { get { return _ninjutsuAdjust; } set { _ninjutsuAdjust = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseShadewalkerTarget
        { get { return _useShadwalkerTarget; } set { _useShadwalkerTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMudrasOoc
        { get { return _useMudrasOoc; } set { _useMudrasOoc = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseAbilitiesFromStealth
        { get { return _useAbilitiesFromStealth; } set { _useAbilitiesFromStealth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseManualShadewalker
        { get { return _useManualShadewalker; } set { _useManualShadewalker = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseShadeShift
        { get { return _useShadeShift; } set { _useShadeShift = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int ShadeShiftHpPct
        { get { return _shadeShiftHpPct; } set { _shadeShiftHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int DeathBlossomMobCount
        { get { return _deathBlossomMobCount; } set { _deathBlossomMobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseThrowingDagger
        { get { return _useThrowingDagger; } set { _useThrowingDagger = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowNinjutsu
        { get { return _showNinjutsu; } set { _showNinjutsu = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAoE
        { get { return _showAoE; } set { _showAoE = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDpsPotion
        { get { return _showDpsPotion; } set { _showDpsPotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAssassinate
        { get { return _showAssassinate; } set { _showAssassinate = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShukuchi
        { get { return _showShukuchi; } set { _showShukuchi = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDots
        { get { return _showDots; } set { _showDots = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTenChiJin
        { get { return _showTenChiJin; } set { _showTenChiJin = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDynamicPositionals
        { get { return _showDynamicPositionals; } set { _showDynamicPositionals = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDeathBlossom
        { get { return _showDeathBlossom; } set { _showDeathBlossom = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadewalkerTarget
        { get { return _showShadwalkerTarget; } set { _showShadwalkerTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        { get { return _showInterruptList; } set { _showInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMudrasOoc
        { get { return _showMudrasOoc; } set { _showMudrasOoc = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAbilitiesFromStealth
        { get { return _showAbilitiesFromStealth; } set { _showAbilitiesFromStealth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualShadewalker
        { get { return _showManualShadewalker; } set { _showManualShadewalker = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadeShift
        { get { return _showShadeShift; } set { _showShadeShift = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowThrowingDagger
        { get { return _showThrowingDagger; } set { _showThrowingDagger = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseSmokeScreen
        { get { return _useSmokeScreen; } set { _useSmokeScreen = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSmokeScreen
        { get { return _showSmokeScreen; } set { _showSmokeScreen = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTrueNorth
        { get { return _useTrueNorth; } set { _useTrueNorth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTrueNorth
        { get { return _showTrueNorth; } set { _showTrueNorth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeint
        { get { return _useFeint; } set { _useFeint = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFeint
        { get { return _showFeint; } set { _showFeint = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int HealingHpPct
        { get { return _healingHpPct; } set { _healingHpPct = value; OnPropertyChanged(); } }

        private volatile TCJMode _tcjMode;

        private volatile NinjutsuMode _ninjutsuMode;

        private volatile NinjutsuAoEModeSelection _ninjutsuAoEModeSelection;

        [Setting]
        public TCJMode TcjSelection
        { get { return _tcjMode; } set { _tcjMode = value; OnPropertyChanged(); } }

        [Setting]
        public NinjutsuMode Ninjutsu
        { get { return _ninjutsuMode; } set { _ninjutsuMode = value; OnPropertyChanged(); } }

        [Setting]
        public NinjutsuAoEModeSelection NinjutsuAoEMode
        { get { return _ninjutsuAoEModeSelection; } set { _ninjutsuAoEModeSelection = value; OnPropertyChanged(); } }

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