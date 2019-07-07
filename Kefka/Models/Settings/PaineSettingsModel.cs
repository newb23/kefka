using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;

namespace Kefka.Models
{
    public class PaineSettingsModel : BaseModel
    {
        private static PaineSettingsModel _instance;
        public static PaineSettingsModel Instance => _instance ?? (_instance = new PaineSettingsModel());

        private PaineSettingsModel() : base(CharacterSettingsDirectory +
                                            "/Kefka/Routine Settings/Paine/Paine_Settings.json")
        {
        }

        private bool _useAwareness,
            _useBuffs,
            _useStormsPath,
            _useButchersBlock,
            _useTomahawk,
            _useDpsPotion,
            _useDefensives,
            _useInterruptList,
            _useConvalescence,
            _useThrillofBattle,
            _useVengeance,
            _useOpener,
            _useBerserk,
            _infuriateWithoutBerserk,
            _useInnerBeast,
            _useEquilibrium,
            _useHolmgang,
            _useBusterDefense,
            _useProvoke,
            _useDeliverance,
            _useManualInterrupt,
            _useRampart,
            _useAnticipation,
            _useRawIntuition,
            _useReprisal,
            _useOnslaught,
            _useUpheaval,
            _swap,
            _enmityOverride,
            _damageOverride;

        private bool _showSwap,
            _showEnmityOverride,
            _showOnslaught,
            _showAwareness,
            _showAnticipation,
            _showBuffs,
            _showTomahawk,
            _showDpsPotion,
            _showDefensives,
            _showRawIntuition,
            _showInterruptList,
            _showConvalescence,
            _showThrillofBattle,
            _showVengeance,
            _showOpener,
            _showBerserk,
            _showInnerBeast,
            _showEquilibrium,
            _showHolmgang,
            _showBusterDefense,
            _showAoE,
            _showProvoke,
            _showDeliverance,
            _showManualInterrupt,
            _showRampart,
            _showReprisal;

        private int _butchersBlockCount,
            _berserkHpPct,
            _innerBeastHpPct,
            _equilibriumHpPct,
            _holmgangHpPct,
            _convalescenceHpPct,
            _awarenessHpPct,
            _thrillofBattleHpPct,
            _vengeanceHpPct,
            _overpowerMinMobs,
            _fellCleaveBerserkMinCD,
            _stormsEyeRefresh,
            _stormsEyeRefreshBerserk,
            _overpowerRefreshTime,
            _overpowerPullCount,
            _stormsPathHpPct,
            _aoEMinEnemies,
            _rawIntuitionHpPct,
            _reprisalHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

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
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool MainTank
        {
            get => _enmityOverride;
            set
            {
                _enmityOverride = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(500)]
        public int ButchersBlockCount
        {
            get => _butchersBlockCount;
            set
            {
                _butchersBlockCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAwareness
        {
            get => _useAwareness;
            set
            {
                _useAwareness = value;
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
        [DefaultValue(false)]
        public bool UseStormsPath
        {
            get => _useStormsPath;
            set
            {
                _useStormsPath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTomahawk
        {
            get => _useTomahawk;
            set
            {
                _useTomahawk = value;
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
        public bool UseBerserk
        {
            get => _useBerserk;
            set
            {
                _useBerserk = value;
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
        [DefaultValue(100)]
        public int BerserkHpPct
        {
            get => _berserkHpPct;
            set
            {
                _berserkHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool InfuriateWithoutBerserk
        {
            get => _infuriateWithoutBerserk;
            set
            {
                _infuriateWithoutBerserk = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int InnerBeastHpPct
        {
            get => _innerBeastHpPct;
            set
            {
                _innerBeastHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
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
        [DefaultValue(70)]
        public int EquilibriumHpPct
        {
            get => _equilibriumHpPct;
            set
            {
                _equilibriumHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5)]
        public int HolmgangHpPct
        {
            get => _holmgangHpPct;
            set
            {
                _holmgangHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int ConvalescenceHpPct
        {
            get => _convalescenceHpPct;
            set
            {
                _convalescenceHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseDeliverance
        {
            get => _useDeliverance;
            set
            {
                _useDeliverance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseConvalescence
        {
            get => _useConvalescence;
            set
            {
                _useConvalescence = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseThrillofBattle
        {
            get => _useThrillofBattle;
            set
            {
                _useThrillofBattle = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int AwarenessHpPct
        {
            get => _awarenessHpPct;
            set
            {
                _awarenessHpPct = value;
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
        [DefaultValue(75)]
        public int ThrillofBattleHpPct
        {
            get => _thrillofBattleHpPct;
            set
            {
                _thrillofBattleHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseBusterDefense
        {
            get => _useBusterDefense;
            set
            {
                _useBusterDefense = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseInnerBeast
        {
            get => _useInnerBeast;
            set
            {
                _useInnerBeast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEquilibrium
        {
            get => _useEquilibrium;
            set
            {
                _useEquilibrium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHolmgang
        {
            get => _useHolmgang;
            set
            {
                _useHolmgang = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseVengeance
        {
            get => _useVengeance;
            set
            {
                _useVengeance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int VengeanceHpPct
        {
            get => _vengeanceHpPct;
            set
            {
                _vengeanceHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseProvoke
        {
            get => _useProvoke;
            set
            {
                _useProvoke = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2)]
        public int OverpowerMinMobs
        {
            get => _overpowerMinMobs;
            set
            {
                _overpowerMinMobs = value;
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
        [DefaultValue(15000)]
        public int FellCleaveBerserkMinCD
        {
            get => _fellCleaveBerserkMinCD;
            set
            {
                _fellCleaveBerserkMinCD = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(12500)]
        public int StormsEyeRefresh
        {
            get => _stormsEyeRefresh;
            set
            {
                _stormsEyeRefresh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(12500)]
        public int StormsEyeRefreshBerserk
        {
            get => _stormsEyeRefreshBerserk;
            set
            {
                _stormsEyeRefreshBerserk = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseButchersBlock
        {
            get => _useButchersBlock;
            set
            {
                _useButchersBlock = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30000)]
        public int OverpowerRefreshTime
        {
            get => _overpowerRefreshTime;
            set
            {
                _overpowerRefreshTime = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int OverpowerPullCount
        {
            get => _overpowerPullCount;
            set
            {
                _overpowerPullCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int AoEMinEnemies
        {
            get => _aoEMinEnemies;
            set
            {
                _aoEMinEnemies = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int StormsPathHpPct
        {
            get => _stormsPathHpPct;
            set
            {
                _stormsPathHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRampart
        {
            get => _useRampart;
            set
            {
                _useRampart = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int RampartHpPct
        {
            get => _stormsPathHpPct;
            set
            {
                _stormsPathHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAnticipation
        {
            get => _useAnticipation;
            set
            {
                _useAnticipation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int AnticipationHpPct
        {
            get => _stormsPathHpPct;
            set
            {
                _stormsPathHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRawIntuition
        {
            get => _useRawIntuition;
            set
            {
                _useRawIntuition = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int RawIntuitionHpPct
        {
            get => _rawIntuitionHpPct;
            set
            {
                _rawIntuitionHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseReprisal
        {
            get => _useReprisal;
            set
            {
                _useReprisal = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int ReprisalHpPct
        {
            get => _reprisalHpPct;
            set
            {
                _reprisalHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseOnslaught
        {
            get => _useOnslaught;
            set
            {
                _useOnslaught = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseUpheaval
        {
            get => _useUpheaval;
            set
            {
                _useUpheaval = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool Swap
        {
            get => _swap;
            set
            {
                _swap = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSwap
        {
            get => _showSwap;
            set
            {
                _showSwap = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnmityOverride
        {
            get => _showEnmityOverride;
            set
            {
                _showEnmityOverride = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOnslaught
        {
            get => _showOnslaught;
            set
            {
                _showOnslaught = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAwareness
        {
            get => _showAwareness;
            set
            {
                _showAwareness = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAnticipation
        {
            get => _showAnticipation;
            set
            {
                _showAnticipation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRampart
        {
            get => _showRampart;
            set
            {
                _showRampart = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowReprisal
        {
            get => _showReprisal;
            set
            {
                _showReprisal = value;
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
        public bool ShowTomahawk
        {
            get => _showTomahawk;
            set
            {
                _showTomahawk = value;
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
        public bool ShowBerserk
        {
            get => _showBerserk;
            set
            {
                _showBerserk = value;
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
        public bool ShowRawIntuition
        {
            get => _showRawIntuition;
            set
            {
                _showRawIntuition = value;
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
        public bool ShowDeliverance
        {
            get => _showDeliverance;
            set
            {
                _showDeliverance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowConvalescence
        {
            get => _showConvalescence;
            set
            {
                _showConvalescence = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowThrillofBattle
        {
            get => _showThrillofBattle;
            set
            {
                _showThrillofBattle = value;
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
        public bool ShowBusterDefense
        {
            get => _showBusterDefense;
            set
            {
                _showBusterDefense = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInnerBeast
        {
            get => _showInnerBeast;
            set
            {
                _showInnerBeast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEquilibrium
        {
            get => _showEquilibrium;
            set
            {
                _showEquilibrium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHolmgang
        {
            get => _showHolmgang;
            set
            {
                _showHolmgang = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowVengeance
        {
            get => _showVengeance;
            set
            {
                _showVengeance = value;
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
        public bool ShowProvoke
        {
            get => _showProvoke;
            set
            {
                _showProvoke = value;
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
    }
}