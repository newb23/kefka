using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using ff14bot;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Commands;

namespace Kefka.Models
{
    public class FreyaSettingsModel : BaseModel
    {
        private static FreyaSettingsModel _instance;
        public static FreyaSettingsModel Instance => _instance ?? (_instance = new FreyaSettingsModel());

        private FreyaSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Freya/Freya_Settings.json")
        {
        }

        private bool _useDragonfireDive, _useBuffs, _useInterruptList, _useAoE, _useDpsPotion, _useTrueNorth, _useDefensives, _useDoTs,
            _useJumps, _useOpener, _useBloodoftheDragon, _useBattleLitany, _useGeirskogul, _useManualInterrupt, _usePiercingTalon,
            _useSecondWind, _useBloodbath, _useManualDragonSight, _useTargetDragonSight, _useFeint, _useSpineshatterDive;

        private bool _showDragonfireDive, _showBuffs, _showInterruptList, _showAoE, _showDpsPotion, _showTrueNorth, _showDefensives,
            _showDoTs, _showJumps, _showOpener, _showBloodoftheDragon, _showBattleLitany, _showGeirskogul, _showManualInterrupt, _showPiercingTalon,
            _showManualDragonSight, _showTargetDragonSight, _showFeint, _showSpineshatterDive;

        private int _phlebotomizeRfsh, _heavyThrustRfsh, _disembowelRfsh, _chaosThrustRfsh, _mobCount, _tpLimit, _selfHealHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public ICommand UncheckUseDragonSightTargetCommand => new DelegateCommand(UncheckUseTargetDragonSight);
        public ICommand UncheckUseManualDragonSightCommand => new DelegateCommand(UncheckUseManualDragonSight);

        public void UncheckUseInterruptList()
        { if (UseManualInterrupt) { UseInterruptList = false; } }

        public void UncheckUseManualInterrupt()
        { if (_useInterruptList) { UseManualInterrupt = false; } }

        public void UncheckUseTargetDragonSight()
        { if (UseManualDragonSight) { UseTargetDragonSight = false; } }

        public void UncheckUseManualDragonSight()
        { if (_useTargetDragonSight) { UseManualDragonSight = false; } }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDragonfireDive
        { get { return _useDragonfireDive; } set { _useDragonfireDive = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

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
        public bool UseTrueNorth
        { get { return _useTrueNorth; } set { _useTrueNorth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDefensives
        { get { return _useDefensives; } set { _useDefensives = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(6000)]
        public int PhlebotomizeRfsh
        { get { return _phlebotomizeRfsh; } set { _phlebotomizeRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(6000)]
        public int HeavyThrustRfsh
        { get { return _heavyThrustRfsh; } set { _heavyThrustRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int DisembowelRfsh
        { get { return _disembowelRfsh; } set { _disembowelRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(15000)]
        public int ChaosThrustRfsh
        { get { return _chaosThrustRfsh; } set { _chaosThrustRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseGeirskogul
        { get { return _useGeirskogul; } set { _useGeirskogul = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDoTs
        { get { return _useDoTs; } set { _useDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBattleLitany
        { get { return _useBattleLitany; } set { _useBattleLitany = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        { get { return _mobCount; } set { _mobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBloodoftheDragon
        { get { return _useBloodoftheDragon; } set { _useBloodoftheDragon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        { get { return _tpLimit; } set { _tpLimit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseJumps
        { get { return _useJumps; } set { _useJumps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UsePiercingTalon
        { get { return _usePiercingTalon; } set { _usePiercingTalon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDragonfireDive
        { get { return _showDragonfireDive; } set { _showDragonfireDive = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        { get { return _showInterruptList; } set { _showInterruptList = value; OnPropertyChanged(); } }

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
        public bool ShowTrueNorth
        { get { return _showTrueNorth; } set { _showTrueNorth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDefensives
        { get { return _showDefensives; } set { _showDefensives = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGeirskogul
        { get { return _showGeirskogul; } set { _showGeirskogul = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoTs
        { get { return _showDoTs; } set { _showDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBattleLitany
        { get { return _showBattleLitany; } set { _showBattleLitany = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBloodoftheDragon
        { get { return _showBloodoftheDragon; } set { _showBloodoftheDragon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowJumps
        { get { return _showJumps; } set { _showJumps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPiercingTalon
        { get { return _showPiercingTalon; } set { _showPiercingTalon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSecondWind
        { get { return _useSecondWind; } set { _useSecondWind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBloodbath
        { get { return _useBloodbath; } set { _useBloodbath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int SelfHealHpPct
        { get { return _selfHealHpPct; } set { _selfHealHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualDragonSight
        { get { return _useManualDragonSight; } set { _useManualDragonSight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualDragonSight
        { get { return _showManualDragonSight; } set { _showManualDragonSight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetDragonSight
        { get { return _useTargetDragonSight; } set { _useTargetDragonSight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetDragonSight
        { get { return _showTargetDragonSight; } set { _showTargetDragonSight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeint
        { get { return _useFeint; } set { _useFeint = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFeint
        { get { return _showFeint; } set { _showFeint = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSpineshatterDive
        { get { return _useSpineshatterDive; } set { _useSpineshatterDive = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSpineshatterDive
        { get { return _showSpineshatterDive; } set { _showSpineshatterDive = value; OnPropertyChanged(); } }
    }
}