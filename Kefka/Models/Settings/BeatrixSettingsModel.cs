using ff14bot;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Commands;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;

namespace Kefka.Models
{
    public class BeatrixSettingsModel : BaseModel
    {
        private static BeatrixSettingsModel _instance;
        public static BeatrixSettingsModel Instance => _instance ?? (_instance = new BeatrixSettingsModel());

        private BeatrixSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Beatrix/Beatrix_Settings.json")
        {
        }

        private bool _useOpener, _useDpsPotion, _swap, _mainTank, _overrideRage, _useSwordOath, 
            _useProvoke, _useFlash, _useTotalEclipse, _useShieldLob, _useFightorFlight, _useRequiescat,
            _useDefensives, _useBusterDefense, _useAwareness, _useSheltron, _useIntervention, _useManualClemency, _useClemencyTarget, _useClemencyOverReq, _useManualCover, _useCoverTarget, _useDivineVeil, _useHallowedGround, _useSentinel, _useBulwark, 
            _useRampart, _useAnticipation, _useConvalescence, _useReprisal, 
            _useInterruptList, _useManualInterrupt;

        private bool _showSwap, _showEnmityOverride, _showDamageOverride, _showAwareness, _showBuffs, _showFlash, _showDpsPotion, _showMercyStroke, _showDefensives, _showInterruptList, _showConvalescence, _showSentinel, _showBulwark, _showRampart, _showOpener, _showManualClemency, _showClemencyTarget, _showDivineVeil, _showSheltron, _showHallowedGround, _showForesight, 
            _showBusterDefense, _showShieldLob, _showSwordOath, _showProvoke, _showIntervention, _showManualCover, _showCoverTarget, _showManualInterrupt, _showrecoverMpOverride, _showAnticipation, _showReprisal;

        private int _flashCount, _rageofHaloneCount, _flashMinEnemies, _clemencyHpPct, _tankClemencyHpPct, _healerClemencyHpPct, _dpsClemencyHpPct, _divineVeilHpPct, _sheltronHpPct, _hallowedGroundHpPct, _convalescenceHpPct, _awarenessHpPct, _sentinelHpPct, _bulwarkHpPct, _rampartHpPct, _interventionHpPct, _riotBladeOverridePct, _totalEclipseTpPct, _totalEclipseMinEnemies, _anticipationHpPct, _reprisalHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public ICommand UncheckUseCoverTargetCommand => new DelegateCommand(UncheckUseCoverTarget);
        public ICommand UncheckUseManualCoverCommand => new DelegateCommand(UncheckUseManualCover);

        public ICommand UncheckUseClemencyTargetCommand => new DelegateCommand(UncheckUseClemencyTarget);
        public ICommand UncheckUseManualClemencyCommand => new DelegateCommand(UncheckUseManualClemency);

        public void UncheckUseInterruptList()
        { if (UseManualInterrupt) { UseInterruptList = false; } }

        public void UncheckUseManualInterrupt()
        { if (_useInterruptList) { UseManualInterrupt = false; } }

        public void UncheckUseCoverTarget()
        { if (_useManualCover) { UseCoverTarget = false; } }

        public void UncheckUseManualCover()
        { if (UseCoverTarget) { UseManualCover = false; } }

        public void UncheckUseClemencyTarget()
        { if (_useManualClemency) { UseClemencyTarget = false; } }

        public void UncheckUseManualClemency()
        { if (UseClemencyTarget) { UseManualClemency = false; } }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseDpsPotion
        { get { return _useDpsPotion; } set { _useDpsPotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool Swap
        { get { return _swap; } set { _swap = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool MainTank
        { get { return _mainTank; } set { _mainTank = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseShieldLob
        { get { return _useShieldLob; } set { _useShieldLob = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseProvoke
        { get { return _useProvoke; } set { _useProvoke = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseSwordOath
        { get { return _useSwordOath; } set { _useSwordOath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int RageofHaloneCount
        { get { return _rageofHaloneCount; } set { _rageofHaloneCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFlash
        { get { return _useFlash; } set { _useFlash = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int FlashMinEnemies
        { get { return _flashMinEnemies; } set { _flashMinEnemies = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int FlashCount
        { get { return _flashCount; } set { _flashCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTotalEclipse
        { get { return _useTotalEclipse; } set { _useTotalEclipse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int TotalEclipseMinEnemies
        { get { return _totalEclipseMinEnemies; } set { _totalEclipseMinEnemies = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(65)]
        public int TotalEclipseTpPct
        { get { return _totalEclipseTpPct; } set { _totalEclipseTpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFightorFlight
        { get { return _useFightorFlight; } set { _useFightorFlight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRequiescat
        { get { return _useRequiescat; } set { _useRequiescat = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int RiotBladeOverridePct
        { get { return _riotBladeOverridePct; } set { _riotBladeOverridePct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseClemencyTarget
        { get { return _useClemencyTarget; } set { _useClemencyTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualClemency
        { get { return _useManualClemency; } set { _useManualClemency = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseClemencyOverReq
        { get { return _useClemencyOverReq; } set { _useClemencyOverReq = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int ClemencyHpPct
        { get { return _clemencyHpPct; } set { _clemencyHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(15)]
        public int TankClemencyHpPct
        { get { return _tankClemencyHpPct; } set { _tankClemencyHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(35)]
        public int HealerClemencyHpPct
        { get { return _healerClemencyHpPct; } set { _healerClemencyHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int DpsClemencyHpPct
        { get { return _dpsClemencyHpPct; } set { _dpsClemencyHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDefensives
        { get { return _useDefensives; } set { _useDefensives = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseBusterDefense
        { get { return _useBusterDefense; } set { _useBusterDefense = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSheltron
        { get { return _useSheltron; } set { _useSheltron = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(100)]
        public int SheltronHpPct
        { get { return _sheltronHpPct; } set { _sheltronHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDivineVeil
        { get { return _useDivineVeil; } set { _useDivineVeil = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(100)]
        public int DivineVeilHpPct
        { get { return _divineVeilHpPct; } set { _divineVeilHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBulwark
        { get { return _useBulwark; } set { _useBulwark = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int BulwarkHpPct
        { get { return _bulwarkHpPct; } set { _bulwarkHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSentinel
        { get { return _useSentinel; } set { _useSentinel = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int SentinelHpPct
        { get { return _sentinelHpPct; } set { _sentinelHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseHallowedGround
        { get { return _useHallowedGround; } set { _useHallowedGround = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(10)]
        public int HallowedGroundHpPct
        { get { return _hallowedGroundHpPct; } set { _hallowedGroundHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseIntervention
        { get { return _useIntervention; } set { _useIntervention = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int InterventionHpPct
        { get { return _interventionHpPct; } set { _interventionHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRampart
        { get { return _useRampart; } set { _useRampart = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(65)]
        public int RampartHpPct
        { get { return _rampartHpPct; } set { _rampartHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAnticipation
        { get { return _useAnticipation; } set { _useAnticipation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int AnticipationHpPct
        { get { return _anticipationHpPct; } set { _anticipationHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAwareness
        { get { return _useAwareness; } set { _useAwareness = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int AwarenessHpPct
        { get { return _awarenessHpPct; } set { _awarenessHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseConvalescence
        { get { return _useConvalescence; } set { _useConvalescence = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int ConvalescenceHpPct
        { get { return _convalescenceHpPct; } set { _convalescenceHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseReprisal
        { get { return _useReprisal; } set { _useReprisal = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int ReprisalHpPct
        { get { return _reprisalHpPct; } set { _reprisalHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCoverTarget
        { get { return _useCoverTarget; } set { _useCoverTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualCover
        { get { return _useManualCover; } set { _useManualCover = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        #region Show
        [Setting]
        [DefaultValue(true)]
        public bool ShowSwap
        { get { return _showSwap; } set { _showSwap = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnmityOverride
        { get { return _showEnmityOverride; } set { _showEnmityOverride = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDamageOverride
        { get { return _showDamageOverride; } set { _showDamageOverride = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAwareness
        { get { return _showAwareness; } set { _showAwareness = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFlash
        { get { return _showFlash; } set { _showFlash = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDpsPotion
        { get { return _showDpsPotion; } set { _showDpsPotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowClemencyTarget
        { get { return _showClemencyTarget; } set { _showClemencyTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualClemency
        { get { return _showManualClemency; } set { _showManualClemency = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMercyStroke
        { get { return _showMercyStroke; } set { _showMercyStroke = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDefensives
        { get { return _showDefensives; } set { _showDefensives = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowInterruptList
        { get { return _showInterruptList; } set { _showInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowProvoke
        { get { return _showProvoke; } set { _showProvoke = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowConvalescence
        { get { return _showConvalescence; } set { _showConvalescence = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSentinel
        { get { return _showSentinel; } set { _showSentinel = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBulwark
        { get { return _showBulwark; } set { _showBulwark = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBusterDefense
        { get { return _showBusterDefense; } set { _showBusterDefense = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDivineVeil
        { get { return _showDivineVeil; } set { _showDivineVeil = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSheltron
        { get { return _showSheltron; } set { _showSheltron = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowHallowedGround
        { get { return _showHallowedGround; } set { _showHallowedGround = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowForesight
        { get { return _showForesight; } set { _showForesight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRampart
        { get { return _showRampart; } set { _showRampart = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShieldLob
        { get { return _showShieldLob; } set { _showShieldLob = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSwordOath
        { get { return _showSwordOath; } set { _showSwordOath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowIntervention
        { get { return _showIntervention; } set { _showIntervention = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCoverTarget
        { get { return _showCoverTarget; } set { _showCoverTarget = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualCover
        { get { return _showManualCover; } set { _showManualCover = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRecoverMpOverride
        { get { return _showrecoverMpOverride; } set { _showrecoverMpOverride = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAnticipation
        { get { return _showAnticipation; } set { _showAnticipation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowReprisal
        { get { return _showReprisal; } set { _showReprisal = value; OnPropertyChanged(); } }
        #endregion Show
    }
}