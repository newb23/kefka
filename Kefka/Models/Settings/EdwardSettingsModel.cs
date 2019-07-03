using static Kefka.Utilities.Constants;
using Kefka.Commands;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;

namespace Kefka.Models
{
    public class EdwardSettingsModel : BaseModel
    {
        private static EdwardSettingsModel _instance;
        public static EdwardSettingsModel Instance => _instance ?? (_instance = new EdwardSettingsModel());

        private EdwardSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Edward/Edward_Settings.json")
        {
        }

        private bool _useRepellingShot, _useBuffs, _useMiserysEnd, _useAoE, _useDpsPotion, _useFeint, _useInterruptList, _useDots, _useOpener, _useBattleVoice, _useSongs, _useFlamingArrow,
            _useQuellingStrikes, _useRainofDeath, _usePeloton, _useTroubadour, _usePaean, _useSidewinder, _useFoeRequiem, _useManualInterrupt, _useAoEBeforeDoTs,
            _useMultiDoT, _useMinuetDance, _useTactician, _useRefresh, _useManualNaturesMinne, _useTargetNaturesMinne, _useManualPalisade, _useTargetPalisade, _useBusterPalisade;

        private bool _showRepellingShot, _showBuffs, _showMiserysEnd, _showAoE, _showDpsPotion, _showMinuet, _showFeint, _showInterruptList, _showDots, _showOpener, _showBattleVoice, _showSongs, _showFlamingArrow,
            _showQuellingStrikes, _showRainofDeath, _showAdvancedRainofDeath, _showPeloton, _showBloodoforBlood, _showPaean, _showSidewinder, _showCure, _showFoeRequiem, _showManualInterrupt, _showAoEBeforeDoTs,
            _showMultiDoT, _showMinuetDance, _showManualNaturesMinne, _showTargetNaturesMinne, _showManualPalisade, _showTargetPalisade, _showBusterPalisade, _showTactician, _showRefresh;

        private int _windBiteRfsh, _venomBiteRfsh, _mobCount, _tpLimit, _foesMp, _roDMobCount, _restHPct, _restMpPct, _battleVoiceMinMpPct, _multiDoTTargetMax, _secondWindHpPct, _naturesMinneHpPct,
            _tacticianTpPct, _refreshMpPct, _tacticianMemberCount, _refreshMemberCount, _repertoireCount, _palisadeHpPct;

        private bool _pvPManualBluntArrow;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);
        public ICommand UncheckUseTargetNaturesMinneCommand => new DelegateCommand(UncheckUseTargetNaturesMinne);
        public ICommand UncheckUseManualNaturesMinneCommand => new DelegateCommand(UncheckUseManualNaturesMinne);
        public ICommand UncheckUsePalisadeTargetCommand => new DelegateCommand(UncheckUseTargetPalisade);
        public ICommand UncheckUseManualPalisadeCommand => new DelegateCommand(UncheckUseManualPalisade);

        public void UncheckUseInterruptList()
        { if (UseManualInterrupt) { UseInterruptList = false; } }

        public void UncheckUseManualInterrupt()
        { if (_useInterruptList) { UseManualInterrupt = false; } }

        public void UncheckUseTargetNaturesMinne()
        { if (UseManualNaturesMinne) { UseTargetNaturesMinne = false; } }

        public void UncheckUseManualNaturesMinne()
        { if (_useTargetNaturesMinne) { UseManualNaturesMinne = false; } }

        public void UncheckUseTargetPalisade()
        { if (UseManualPalisade) { UseTargetPalisade = false; } }

        public void UncheckUseManualPalisade()
        { if (_useTargetPalisade) { UseManualPalisade = false; } }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseRepellingShot
        { get { return _useRepellingShot; } set { _useRepellingShot = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMiserysEnd
        { get { return _useMiserysEnd; } set { _useMiserysEnd = value; OnPropertyChanged(); } }

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
        public bool UseFoeRequiem
        { get { return _useFoeRequiem; } set { _useFoeRequiem = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeint
        { get { return _useFeint; } set { _useFeint = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4500)]
        public int WindBiteRfsh
        { get { return _windBiteRfsh; } set { _windBiteRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4500)]
        public int VenomBiteRfsh
        { get { return _venomBiteRfsh; } set { _venomBiteRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDots
        { get { return _useDots; } set { _useDots = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5)]
        public int MobCount
        { get { return _mobCount; } set { _mobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int TpLimit
        { get { return _tpLimit; } set { _tpLimit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBattleVoice
        { get { return _useBattleVoice; } set { _useBattleVoice = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSongs
        { get { return _useSongs; } set { _useSongs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int FoesMpRfsh
        { get { return _foesMp; } set { _foesMp = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFlamingArrow
        { get { return _useFlamingArrow; } set { _useFlamingArrow = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseQuellingStrikes
        { get { return _useQuellingStrikes; } set { _useQuellingStrikes = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRainofDeath
        { get { return _useRainofDeath; } set { _useRainofDeath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int RoDMobCount
        { get { return _roDMobCount; } set { _roDMobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(2500)]
        public int IronJawsRsRefresh
        { get { return _restHPct; } set { _restHPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int RestMpPct
        { get { return _restMpPct; } set { _restMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UsePeloton
        { get { return _usePeloton; } set { _usePeloton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTroubadour
        { get { return _useTroubadour; } set { _useTroubadour = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePaean
        { get { return _usePaean; } set { _usePaean = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSidewinder
        { get { return _useSidewinder; } set { _useSidewinder = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int BattleVoiceMinMpPct
        { get { return _battleVoiceMinMpPct; } set { _battleVoiceMinMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseAoEBeforeDoTs
        { get { return _useAoEBeforeDoTs; } set { _useAoEBeforeDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseMultiDoT
        { get { return _useMultiDoT; } set { _useMultiDoT = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MultiDoTTargetMax
        { get { return _multiDoTTargetMax; } set { _multiDoTTargetMax = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRepellingShot
        { get { return _showRepellingShot; } set { _showRepellingShot = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMiserysEnd
        { get { return _showMiserysEnd; } set { _showMiserysEnd = value; OnPropertyChanged(); } }

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
        public bool ShowMinuet
        { get { return _showMinuet; } set { _showMinuet = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFeint
        { get { return _showFeint; } set { _showFeint = value; OnPropertyChanged(); } }

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
        public bool ShowDots
        { get { return _showDots; } set { _showDots = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAdvancedRainofDeath
        { get { return _showAdvancedRainofDeath; } set { _showAdvancedRainofDeath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBattleVoice
        { get { return _showBattleVoice; } set { _showBattleVoice = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSongs
        { get { return _showSongs; } set { _showSongs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFlamingArrow
        { get { return _showFlamingArrow; } set { _showFlamingArrow = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowQuellingStrikes
        { get { return _showQuellingStrikes; } set { _showQuellingStrikes = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRainofDeath
        { get { return _showRainofDeath; } set { _showRainofDeath = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPeloton
        { get { return _showPeloton; } set { _showPeloton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBloodforBlood
        { get { return _showBloodoforBlood; } set { _showBloodoforBlood = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPaean
        { get { return _showPaean; } set { _showPaean = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSidewinder
        { get { return _showSidewinder; } set { _showSidewinder = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCure
        { get { return _showCure; } set { _showCure = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFoeRequiem
        { get { return _showFoeRequiem; } set { _showFoeRequiem = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAoEBeforeDoTs
        { get { return _showAoEBeforeDoTs; } set { _showAoEBeforeDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMultiDoT
        { get { return _showMultiDoT; } set { _showMultiDoT = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMinuetDance
        { get { return _useMinuetDance; } set { _useMinuetDance = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMinuetDance
        { get { return _showMinuetDance; } set { _showMinuetDance = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        { get { return _secondWindHpPct; } set { _secondWindHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int NaturesMinneHpPct
        { get { return _naturesMinneHpPct; } set { _naturesMinneHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTactician
        { get { return _useTactician; } set { _useTactician = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTactician
        { get { return _showTactician; } set { _showTactician = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRefresh
        { get { return _useRefresh; } set { _useRefresh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRefresh
        { get { return _showRefresh; } set { _showRefresh = value; OnPropertyChanged(); } }

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
        [DefaultValue(3)]
        public int RepertoireCount
        { get { return _repertoireCount; } set { _repertoireCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int PalisadeHpPct
        { get { return _palisadeHpPct; } set { _palisadeHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualNaturesMinne
        { get { return _useManualNaturesMinne; } set { _useManualNaturesMinne = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualNaturesMinne
        { get { return _showManualNaturesMinne; } set { _showManualNaturesMinne = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetNaturesMinne
        { get { return _useTargetNaturesMinne; } set { _useTargetNaturesMinne = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetNaturesMinne
        { get { return _showTargetNaturesMinne; } set { _showTargetNaturesMinne = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualPalisade
        { get { return _useManualPalisade; } set { _useManualPalisade = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualPalisade
        { get { return _showManualPalisade; } set { _showManualPalisade = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetPalisade
        { get { return _useTargetPalisade; } set { _useTargetPalisade = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetPalisade
        { get { return _showTargetPalisade; } set { _showTargetPalisade = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBusterPalisade
        { get { return _useBusterPalisade; } set { _useBusterPalisade = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBusterPalisade
        { get { return _showBusterPalisade; } set { _showBusterPalisade = value; OnPropertyChanged(); } }

        private TroubadourSongSelection troubadourSongSelection;

        [Setting]
        public TroubadourSongSelection TroubadourSongSelection
        { get { return troubadourSongSelection; } set { troubadourSongSelection = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool PvPManualBluntArrow
        { get { return _pvPManualBluntArrow; } set { _pvPManualBluntArrow = value; OnPropertyChanged(); } }
    }

    public enum TroubadourSongSelection
    {
        Minuet,
        Ballad,
        Paeon,
        None
    }
}