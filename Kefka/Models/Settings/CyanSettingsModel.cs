using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Newtonsoft.Json;

namespace Kefka.Models
{
    public class CyanSettingsModel : BaseModel
    {
        private static CyanSettingsModel _instance;
        public static CyanSettingsModel Instance => _instance ?? (_instance = new CyanSettingsModel());

        private CyanSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Cyan/Cyan_Settings.json")
        {
        }

        private volatile bool _useGoadTarget, _useBuffs, _useNinjutsu, _useAoE, _useDpsPotion, _useAgeha, _useShukuchi, _useDots, _useSeigan, _useOpener, _useGuren, _useMercifulEyes, _useShadwalkerTarget, _useManualShadewalker, _useInterruptList, _useIaijutsu, _useGyoten, _useManualInterrupt, _useManualGoad, _useEnpi, _useShadeShift, _useThirdEye;

        private volatile bool _showGoadTarget, _showBuffs, _showNinjutsu, _showAoE, _showDpsPotion, _showAgeha, _showShukuchi, _showDots, _showSeigan, _showOpener, _showGuren, _showMercifulEyes, _showShadwalkerTarget, _showManualShadewalker, _showInterruptList, _showIaijutsu, _showGyoten, _showManualInterrupt, _showManualGoad, _showEnpi, _showShadeShift, _showThirdEye;

        private volatile int _armorCrushRfsh, _higanbanaMinHpPct, _higanbanaRfsh, _mobCount, _suitonHpInt, _suitonHpPct, _tpLimit, _mudraAdjust, _ninjutsuAdjust, _goadTp, _higanbanaMinHpInt, _bloodbathHpPct, _mercifulEyesHpPct, _secondWindHpPct;

        [JsonIgnore]
        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);

        [JsonIgnore]
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public void UncheckUseInterruptList()
        { if (UseManualInterrupt) { UseInterruptList = false; } }

        public void UncheckUseManualInterrupt()
        { if (_useInterruptList) { UseManualInterrupt = false; } }

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
        { get { return _useGoadTarget; } set { _useGoadTarget = value; OnPropertyChanged(); } }

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
        public bool UseAgeha
        { get { return _useAgeha; } set { _useAgeha = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseShukuchi
        { get { return _useShukuchi; } set { _useShukuchi = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(30000)]
        public int ArmorCrushRfsh
        { get { return _armorCrushRfsh; } set { _armorCrushRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(10)]
        public int HiganbanaMinHpPct
        { get { return _higanbanaMinHpPct; } set { _higanbanaMinHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4000)]
        public int HiganbanaRfsh
        { get { return _higanbanaRfsh; } set { _higanbanaRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDots
        { get { return _useDots; } set { _useDots = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMercifulEyes
        { get { return _useMercifulEyes; } set { _useMercifulEyes = value; OnPropertyChanged(); } }

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
        [DefaultValue(true)]
        public bool UseSeigan
        { get { return _useSeigan; } set { _useSeigan = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int MudraAdjust
        { get { return _mudraAdjust; } set { _mudraAdjust = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseGuren
        { get { return _useGuren; } set { _useGuren = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int NinjutsuAdjust
        { get { return _ninjutsuAdjust; } set { _ninjutsuAdjust = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(400)]
        public int GoadTp
        { get { return _goadTp; } set { _goadTp = value; OnPropertyChanged(); } }

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
        public bool UseIaijutsu
        { get { return _useIaijutsu; } set { _useIaijutsu = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseGyoten
        { get { return _useGyoten; } set { _useGyoten = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualGoad
        { get { return _useManualGoad; } set { _useManualGoad = value; OnPropertyChanged(); } }

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
        public int BloodbathHpPct
        { get { return _bloodbathHpPct; } set { _bloodbathHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseThirdEye
        { get { return _useThirdEye; } set { _useThirdEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int MercifulEyesHpPct
        { get { return _mercifulEyesHpPct; } set { _mercifulEyesHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int HiganbanaMinHpInt
        { get { return _higanbanaMinHpInt; } set { _higanbanaMinHpInt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseEnpi
        { get { return _useEnpi; } set { _useEnpi = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGoadTarget
        { get { return _showGoadTarget; } set { _showGoadTarget = value; OnPropertyChanged(); } }

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
        public bool ShowAgeha
        { get { return _showAgeha; } set { _showAgeha = value; OnPropertyChanged(); } }

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
        public bool ShowMercifulEyes
        { get { return _showMercifulEyes; } set { _showMercifulEyes = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSeigan
        { get { return _showSeigan; } set { _showSeigan = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGuren
        { get { return _showGuren; } set { _showGuren = value; OnPropertyChanged(); } }

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
        public bool ShowIaijutsu
        { get { return _showIaijutsu; } set { _showIaijutsu = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGyoten
        { get { return _showGyoten; } set { _showGyoten = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualGoad
        { get { return _showManualGoad; } set { _showManualGoad = value; OnPropertyChanged(); } }

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
        public bool ShowThirdEye
        { get { return _showThirdEye; } set { _showThirdEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnpi
        { get { return _showEnpi; } set { _showEnpi = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        { get { return _secondWindHpPct; } set { _secondWindHpPct = value; OnPropertyChanged(); } }
    }
}