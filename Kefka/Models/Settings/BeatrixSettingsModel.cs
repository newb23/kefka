using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;
using static Kefka.Utilities.Constants;

namespace Kefka.Models
{
    public class BeatrixSettingsModel : BaseModel
    {
        private static BeatrixSettingsModel _instance;
        public static BeatrixSettingsModel Instance => _instance ?? (_instance = new BeatrixSettingsModel());

        private BeatrixSettingsModel() : base(CharacterSettingsDirectory +
                                              "/Kefka/Routine Settings/Beatrix/Beatrix_Settings.json")
        {
        }

        private bool _useOpener,
            _useDpsPotion,
            _swap,
            _mainTank,
            _overrideRage,
            _useSwordOath,
            _useProvoke,
            _useFlash,
            _useTotalEclipse,
            _useShieldLob,
            _useFightorFlight,
            _useRequiescat,
            _useDefensives,
            _useBusterDefense,
            _useAwareness,
            _useSheltron,
            _useIntervention,
            _useManualClemency,
            _useClemencyTarget,
            _useClemencyOverReq,
            _useManualCover,
            _useCoverTarget,
            _useDivineVeil,
            _useHallowedGround,
            _useSentinel,
            _useBulwark,
            _useRampart,
            _useAnticipation,
            _useConvalescence,
            _useReprisal,
            _useInterruptList,
            _useManualInterrupt;

        private bool _showSwap,
            _showEnmityOverride,
            _showDamageOverride,
            _showAwareness,
            _showBuffs,
            _showFlash,
            _showDpsPotion,
            _showMercyStroke,
            _showDefensives,
            _showInterruptList,
            _showConvalescence,
            _showSentinel,
            _showBulwark,
            _showRampart,
            _showOpener,
            _showManualClemency,
            _showClemencyTarget,
            _showDivineVeil,
            _showSheltron,
            _showHallowedGround,
            _showForesight,
            _showBusterDefense,
            _showShieldLob,
            _showSwordOath,
            _showProvoke,
            _showIntervention,
            _showManualCover,
            _showCoverTarget,
            _showManualInterrupt,
            _showrecoverMpOverride,
            _showAnticipation,
            _showReprisal;

        private int _flashCount,
            _rageofHaloneCount,
            _flashMinEnemies,
            _clemencyHpPct,
            _tankClemencyHpPct,
            _healerClemencyHpPct,
            _dpsClemencyHpPct,
            _divineVeilHpPct,
            _sheltronHpPct,
            _hallowedGroundHpPct,
            _convalescenceHpPct,
            _awarenessHpPct,
            _sentinelHpPct,
            _bulwarkHpPct,
            _rampartHpPct,
            _interventionHpPct,
            _riotBladeOverridePct,
            _totalEclipseTpPct,
            _totalEclipseMinEnemies,
            _anticipationHpPct,
            _reprisalHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public ICommand UncheckUseCoverTargetCommand => new DelegateCommand(UncheckUseCoverTarget);
        public ICommand UncheckUseManualCoverCommand => new DelegateCommand(UncheckUseManualCover);

        public ICommand UncheckUseClemencyTargetCommand => new DelegateCommand(UncheckUseClemencyTarget);
        public ICommand UncheckUseManualClemencyCommand => new DelegateCommand(UncheckUseManualClemency);

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

        public void UncheckUseCoverTarget()
        {
            if (_useManualCover)
                UseCoverTarget = false;
        }

        public void UncheckUseManualCover()
        {
            if (UseCoverTarget)
                UseManualCover = false;
        }

        public void UncheckUseClemencyTarget()
        {
            if (_useManualClemency)
            {
                UseClemencyTarget = false;
            }
        }

        public void UncheckUseManualClemency()
        {
            if (UseClemencyTarget)
            {
                UseManualClemency = false;
            }
        }

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
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
        [DefaultValue(false)]
        public bool MainTank
        {
            get => _mainTank;
            set
            {
                _mainTank = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseShieldLob
        {
            get => _useShieldLob;
            set
            {
                _useShieldLob = value;
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
        [DefaultValue(false)]
        public bool UseSwordOath
        {
            get => _useSwordOath;
            set
            {
                _useSwordOath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(500)]
        public int RageofHaloneCount
        {
            get => _rageofHaloneCount;
            set
            {
                _rageofHaloneCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFlash
        {
            get => _useFlash;
            set
            {
                _useFlash = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int FlashMinEnemies
        {
            get => _flashMinEnemies;
            set
            {
                _flashMinEnemies = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(500)]
        public int FlashCount
        {
            get => _flashCount;
            set
            {
                _flashCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTotalEclipse
        {
            get => _useTotalEclipse;
            set
            {
                _useTotalEclipse = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int TotalEclipseMinEnemies
        {
            get => _totalEclipseMinEnemies;
            set
            {
                _totalEclipseMinEnemies = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(65)]
        public int TotalEclipseTpPct
        {
            get => _totalEclipseTpPct;
            set
            {
                _totalEclipseTpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFightorFlight
        {
            get => _useFightorFlight;
            set
            {
                _useFightorFlight = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRequiescat
        {
            get => _useRequiescat;
            set
            {
                _useRequiescat = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int RiotBladeOverridePct
        {
            get => _riotBladeOverridePct;
            set
            {
                _riotBladeOverridePct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseClemencyTarget
        {
            get => _useClemencyTarget;
            set
            {
                _useClemencyTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualClemency
        {
            get => _useManualClemency;
            set
            {
                _useManualClemency = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseClemencyOverReq
        {
            get => _useClemencyOverReq;
            set
            {
                _useClemencyOverReq = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int ClemencyHpPct
        {
            get => _clemencyHpPct;
            set
            {
                _clemencyHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(15)]
        public int TankClemencyHpPct
        {
            get => _tankClemencyHpPct;
            set
            {
                _tankClemencyHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(35)]
        public int HealerClemencyHpPct
        {
            get => _healerClemencyHpPct;
            set
            {
                _healerClemencyHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int DpsClemencyHpPct
        {
            get => _dpsClemencyHpPct;
            set
            {
                _dpsClemencyHpPct = value;
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
        public bool UseSheltron
        {
            get => _useSheltron;
            set
            {
                _useSheltron = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(100)]
        public int SheltronHpPct
        {
            get => _sheltronHpPct;
            set
            {
                _sheltronHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDivineVeil
        {
            get => _useDivineVeil;
            set
            {
                _useDivineVeil = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(100)]
        public int DivineVeilHpPct
        {
            get => _divineVeilHpPct;
            set
            {
                _divineVeilHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBulwark
        {
            get => _useBulwark;
            set
            {
                _useBulwark = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int BulwarkHpPct
        {
            get => _bulwarkHpPct;
            set
            {
                _bulwarkHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSentinel
        {
            get => _useSentinel;
            set
            {
                _useSentinel = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int SentinelHpPct
        {
            get => _sentinelHpPct;
            set
            {
                _sentinelHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHallowedGround
        {
            get => _useHallowedGround;
            set
            {
                _useHallowedGround = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(10)]
        public int HallowedGroundHpPct
        {
            get => _hallowedGroundHpPct;
            set
            {
                _hallowedGroundHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseIntervention
        {
            get => _useIntervention;
            set
            {
                _useIntervention = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int InterventionHpPct
        {
            get => _interventionHpPct;
            set
            {
                _interventionHpPct = value;
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
        [DefaultValue(65)]
        public int RampartHpPct
        {
            get => _rampartHpPct;
            set
            {
                _rampartHpPct = value;
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
        [DefaultValue(60)]
        public int AnticipationHpPct
        {
            get => _anticipationHpPct;
            set
            {
                _anticipationHpPct = value;
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
        [DefaultValue(60)]
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
        public bool UseCoverTarget
        {
            get => _useCoverTarget;
            set
            {
                _useCoverTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualCover
        {
            get => _useManualCover;
            set
            {
                _useManualCover = value;
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

        #region Show

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
        public bool ShowDamageOverride
        {
            get => _showDamageOverride;
            set
            {
                _showDamageOverride = value;
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
        public bool ShowFlash
        {
            get => _showFlash;
            set
            {
                _showFlash = value;
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
        public bool ShowClemencyTarget
        {
            get => _showClemencyTarget;
            set
            {
                _showClemencyTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualClemency
        {
            get => _showManualClemency;
            set
            {
                _showManualClemency = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMercyStroke
        {
            get => _showMercyStroke;
            set
            {
                _showMercyStroke = value;
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
        public bool ShowSentinel
        {
            get => _showSentinel;
            set
            {
                _showSentinel = value;
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
        public bool ShowBulwark
        {
            get => _showBulwark;
            set
            {
                _showBulwark = value;
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
        public bool ShowDivineVeil
        {
            get => _showDivineVeil;
            set
            {
                _showDivineVeil = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSheltron
        {
            get => _showSheltron;
            set
            {
                _showSheltron = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHallowedGround
        {
            get => _showHallowedGround;
            set
            {
                _showHallowedGround = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowForesight
        {
            get => _showForesight;
            set
            {
                _showForesight = value;
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
        public bool ShowShieldLob
        {
            get => _showShieldLob;
            set
            {
                _showShieldLob = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSwordOath
        {
            get => _showSwordOath;
            set
            {
                _showSwordOath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowIntervention
        {
            get => _showIntervention;
            set
            {
                _showIntervention = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCoverTarget
        {
            get => _showCoverTarget;
            set
            {
                _showCoverTarget = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualCover
        {
            get => _showManualCover;
            set
            {
                _showManualCover = value;
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
        public bool ShowRecoverMpOverride
        {
            get => _showrecoverMpOverride;
            set
            {
                _showrecoverMpOverride = value;
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
        public bool ShowReprisal
        {
            get => _showReprisal;
            set
            {
                _showReprisal = value;
                OnPropertyChanged();
            }
        }

        #endregion Show
    }
}