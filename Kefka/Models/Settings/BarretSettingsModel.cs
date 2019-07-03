using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Properties;
using Kefka.Utilities;

namespace Kefka.Models
{
    public class BarretSettingsModel : BaseModel
    {
        private static BarretSettingsModel _instance;
        public static BarretSettingsModel Instance => _instance ?? (_instance = new BarretSettingsModel());

        private BarretSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Barret/Barret_Settings.json")
        {
        }

        private bool _useBlank, _useBuffs, _useCooldowns, _useHeartBreak, _useAoE, _useDpsPotion, _useGaussBarrel, _useInterruptList,
            _useOpener, _useAutoAmmo, _useAutoTurret, _useHypercharge, _useManualInterrupt, _usePeloton, _useDismantleMind, _useWildfire,
            _useTactician, _useRefresh, _useWildfireWithOverheatOnly, _useFlamethrower;

        private bool _showBlank, _showBuffs, _showCooldowns, _showHeartBreak, _showAoE, _showDpsPotion, _showGaussBarrel, _showInterruptList,
            _showOpener, _showAutoAmmo, _showAutoTurret, _showHypercharge, _showManualInterrupt, _showPeloton, _showDismantleMind,
            _showWildfire, _showWildfireWithOverheatOnly, _showFlamethrower;

        private int _hotShotRfsh, _leadShotRfsh, _gcdTime, _mobCount, _tpLimit, _wfBuffDelay, _wfCdDelay, _wfProcDelay, _turretMobCount, _secondWindHpPct,
            _tacticianTpPct, _refreshMpPct, _tacticianMemberCount, _refreshMemberCount, _cooldownThreshold;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public void UncheckUseInterruptList()
        {
            if (UseManualInterrupt)
            {
                UseInterruptList = false;
            }
        }

        public void UncheckUseManualInterrupt()
        {
            if (_useInterruptList)
            {
                UseManualInterrupt = false;
            }
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
        public bool UseBlank
        { get { return _useBlank; } set { _useBlank = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseHeartBreak
        { get { return _useHeartBreak; } set { _useHeartBreak = value; OnPropertyChanged(); } }

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
        public bool UseGaussBarrel
        { get { return _useGaussBarrel; } set { _useGaussBarrel = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3500)]
        public int HotShotRfsh
        { get { return _hotShotRfsh; } set { _hotShotRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3500)]
        public int LeadShotRfsh
        { get { return _leadShotRfsh; } set { _leadShotRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(250)]
        public int GcdTime
        { get { return _gcdTime; } set { _gcdTime = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCooldowns
        { get { return _useCooldowns; } set { _useCooldowns = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        { get { return _mobCount; } set { _mobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(2)]
        public int TurretMobCount
        { get { return _turretMobCount; } set { _turretMobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        { get { return _tpLimit; } set { _tpLimit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(15000)]
        public int WfBuffDelay
        { get { return _wfBuffDelay; } set { _wfBuffDelay = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(15000)]
        public int WfcdDelay
        { get { return _wfCdDelay; } set { _wfCdDelay = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int WfProcDelay
        { get { return _wfProcDelay; } set { _wfProcDelay = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAutoAmmo
        { get { return _useAutoAmmo; } set { _useAutoAmmo = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAutoTurret
        { get { return _useAutoTurret; } set { _useAutoTurret = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseHypercharge
        { get { return _useHypercharge; } set { _useHypercharge = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePeloton
        { get { return _usePeloton; } set { _usePeloton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBlank
        { get { return _showBlank; } set { _showBlank = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHeartBreak
        { get { return _showHeartBreak; } set { _showHeartBreak = value; OnPropertyChanged(); } }

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
        public bool ShowGaussBarrel
        { get { return _showGaussBarrel; } set { _showGaussBarrel = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        { get { return _showInterruptList; } set { _showInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCooldowns
        { get { return _showCooldowns; } set { _showCooldowns = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAutoAmmo
        { get { return _showAutoAmmo; } set { _showAutoAmmo = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAutoTurret
        { get { return _showAutoTurret; } set { _showAutoTurret = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHypercharge
        { get { return _showHypercharge; } set { _showHypercharge = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPeloton
        { get { return _showPeloton; } set { _showPeloton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseDismantleMind
        { get { return _useDismantleMind; } set { _useDismantleMind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDismantleMind
        { get { return _showDismantleMind; } set { _showDismantleMind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseWildfire
        { get { return _useWildfire; } set { _useWildfire = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowWildfire
        { get { return _showWildfire; } set { _showWildfire = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        { get { return _secondWindHpPct; } set { _secondWindHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTactician
        { get { return _useTactician; } set { _useTactician = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRefresh
        { get { return _useRefresh; } set { _useRefresh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int TacticianTpPct
        { get { return _tacticianTpPct; } set { _tacticianTpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int RefreshMpPct
        { get { return _refreshMpPct; } set { _refreshMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int TacticianMemberCount
        { get { return _tacticianMemberCount; } set { _tacticianMemberCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int RefreshMemberCount
        { get { return _refreshMemberCount; } set { _refreshMemberCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseWildfireWithOverheatOnly
        { get { return _useWildfireWithOverheatOnly; } set { _useWildfireWithOverheatOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowWildfireWithOverheatOnly
        { get { return _showWildfireWithOverheatOnly; } set { _showWildfireWithOverheatOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFlamethrower
        { get { return _useFlamethrower; } set { _useFlamethrower = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFlamethrower
        { get { return _showFlamethrower; } set { _showFlamethrower = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int CooldownThreshold
        { get { return _cooldownThreshold; } set { _cooldownThreshold = value; OnPropertyChanged(); } }

        private TurretMode _turretMode;

        private BarretAoEModeSelection _barretAoEModeSelection;

        private BarretDismantleMindSelection _barretdismantleMindModeSelection;

        [Setting]
        public TurretMode Turret
        { get { return _turretMode; } set { _turretMode = value; OnPropertyChanged(); } }

        [Setting]
        public BarretAoEModeSelection AoEMode
        { get { return _barretAoEModeSelection; } set { _barretAoEModeSelection = value; OnPropertyChanged(); } }

        [Setting]
        public BarretDismantleMindSelection DismantleMindMode
        { get { return _barretdismantleMindModeSelection; } set { _barretdismantleMindModeSelection = value; OnPropertyChanged(); } }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TurretMode
    {
        [LocalizedDescription("Auto", typeof(Strings))]
        Auto,

        [LocalizedDescription("RookAutoturret", typeof(Strings))]
        RookAutoturret,

        [LocalizedDescription("BishopAutoturret", typeof(Strings))]
        BishopAutoturret,

        [LocalizedDescription("Manual", typeof(Strings))]
        Manual
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BarretAoEModeSelection
    {
        [LocalizedDescription("Auto", typeof(Strings))]
        Auto,

        [LocalizedDescription("GrenadoShot", typeof(Strings))]
        GrenadoShot,

        [LocalizedDescription("SpreadShot", typeof(Strings))]
        SpreadShot
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BarretDismantleMindSelection
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("Dismantle", typeof(Strings))]
        Dismantle,

        [LocalizedDescription("RendMind", typeof(Strings))]
        RendMind
    }
}