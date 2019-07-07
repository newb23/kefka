using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;

namespace Kefka.Models
{
    public class FreyaSettingsModel : BaseModel
    {
        private static FreyaSettingsModel _instance;
        public static FreyaSettingsModel Instance => _instance ?? (_instance = new FreyaSettingsModel());

        private FreyaSettingsModel() : base(CharacterSettingsDirectory +
                                            "/Kefka/Routine Settings/Freya/Freya_Settings.json")
        {
        }

        private bool _useDragonfireDive,
            _useBuffs,
            _useInterruptList,
            _useAoE,
            _useDpsPotion,
            _useTrueNorth,
            _useDefensives,
            _useDoTs,
            _useJumps,
            _useOpener,
            _useBloodoftheDragon,
            _useBattleLitany,
            _useGeirskogul,
            _useManualInterrupt,
            _usePiercingTalon,
            _useSecondWind,
            _useBloodbath,
            _useManualDragonSight,
            _useTargetDragonSight,
            _useFeint,
            _useSpineshatterDive;

        private bool _showDragonfireDive,
            _showBuffs,
            _showInterruptList,
            _showAoE,
            _showDpsPotion,
            _showTrueNorth,
            _showDefensives,
            _showDoTs,
            _showJumps,
            _showOpener,
            _showBloodoftheDragon,
            _showBattleLitany,
            _showGeirskogul,
            _showManualInterrupt,
            _showPiercingTalon,
            _showManualDragonSight,
            _showTargetDragonSight,
            _showFeint,
            _showSpineshatterDive;

        private int _phlebotomizeRfsh,
            _heavyThrustRfsh,
            _disembowelRfsh,
            _chaosThrustRfsh,
            _mobCount,
            _tpLimit,
            _selfHealHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public ICommand UncheckUseDragonSightTargetCommand => new DelegateCommand(UncheckUseTargetDragonSight);
        public ICommand UncheckUseManualDragonSightCommand => new DelegateCommand(UncheckUseManualDragonSight);

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

        public void UncheckUseTargetDragonSight()
        {
            if (UseManualDragonSight)
                UseTargetDragonSight = false;
        }

        public void UncheckUseManualDragonSight()
        {
            if (_useTargetDragonSight)
                UseManualDragonSight = false;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDragonfireDive
        {
            get => _useDragonfireDive;
            set
            {
                _useDragonfireDive = value;
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
        [DefaultValue(6000)]
        public int PhlebotomizeRfsh
        {
            get => _phlebotomizeRfsh;
            set
            {
                _phlebotomizeRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(6000)]
        public int HeavyThrustRfsh
        {
            get => _heavyThrustRfsh;
            set
            {
                _heavyThrustRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
        public int DisembowelRfsh
        {
            get => _disembowelRfsh;
            set
            {
                _disembowelRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(15000)]
        public int ChaosThrustRfsh
        {
            get => _chaosThrustRfsh;
            set
            {
                _chaosThrustRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseGeirskogul
        {
            get => _useGeirskogul;
            set
            {
                _useGeirskogul = value;
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
        public bool UseBattleLitany
        {
            get => _useBattleLitany;
            set
            {
                _useBattleLitany = value;
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
        [DefaultValue(true)]
        public bool UseBloodoftheDragon
        {
            get => _useBloodoftheDragon;
            set
            {
                _useBloodoftheDragon = value;
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
        public bool UseJumps
        {
            get => _useJumps;
            set
            {
                _useJumps = value;
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
        public bool UsePiercingTalon
        {
            get => _usePiercingTalon;
            set
            {
                _usePiercingTalon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDragonfireDive
        {
            get => _showDragonfireDive;
            set
            {
                _showDragonfireDive = value;
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
        public bool ShowGeirskogul
        {
            get => _showGeirskogul;
            set
            {
                _showGeirskogul = value;
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
        public bool ShowBattleLitany
        {
            get => _showBattleLitany;
            set
            {
                _showBattleLitany = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBloodoftheDragon
        {
            get => _showBloodoftheDragon;
            set
            {
                _showBloodoftheDragon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowJumps
        {
            get => _showJumps;
            set
            {
                _showJumps = value;
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
        public bool ShowPiercingTalon
        {
            get => _showPiercingTalon;
            set
            {
                _showPiercingTalon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSecondWind
        {
            get => _useSecondWind;
            set
            {
                _useSecondWind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBloodbath
        {
            get => _useBloodbath;
            set
            {
                _useBloodbath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int SelfHealHpPct
        {
            get => _selfHealHpPct;
            set
            {
                _selfHealHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualDragonSight
        {
            get => _useManualDragonSight;
            set
            {
                _useManualDragonSight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualDragonSight
        {
            get => _showManualDragonSight;
            set
            {
                _showManualDragonSight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetDragonSight
        {
            get => _useTargetDragonSight;
            set
            {
                _useTargetDragonSight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetDragonSight
        {
            get => _showTargetDragonSight;
            set
            {
                _showTargetDragonSight = value;
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
        [DefaultValue(true)]
        public bool UseSpineshatterDive
        {
            get => _useSpineshatterDive;
            set
            {
                _useSpineshatterDive = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSpineshatterDive
        {
            get => _showSpineshatterDive;
            set
            {
                _showSpineshatterDive = value;
                OnPropertyChanged();
            }
        }
    }
}