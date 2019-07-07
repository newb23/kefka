using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using Kefka.Commands;

namespace Kefka.Models
{
    public class EdwardSettingsModel : BaseModel
    {
        private static EdwardSettingsModel _instance;
        public static EdwardSettingsModel Instance => _instance ?? (_instance = new EdwardSettingsModel());

        private EdwardSettingsModel() : base(CharacterSettingsDirectory +
                                             "/Kefka/Routine Settings/Edward/Edward_Settings.json")
        {
        }

        private bool _useRepellingShot,
            _useBuffs,
            _useMiserysEnd,
            _useAoE,
            _useDpsPotion,
            _useFeint,
            _useInterruptList,
            _useDots,
            _useOpener,
            _useBattleVoice,
            _useSongs,
            _useFlamingArrow,
            _useQuellingStrikes,
            _useRainofDeath,
            _usePeloton,
            _useTroubadour,
            _usePaean,
            _useSidewinder,
            _useFoeRequiem,
            _useManualInterrupt,
            _useAoEBeforeDoTs,
            _useMultiDoT,
            _useMinuetDance,
            _useTactician,
            _useRefresh,
            _useManualNaturesMinne,
            _useTargetNaturesMinne,
            _useManualPalisade,
            _useTargetPalisade,
            _useBusterPalisade;

        private bool _showRepellingShot,
            _showBuffs,
            _showMiserysEnd,
            _showAoE,
            _showDpsPotion,
            _showMinuet,
            _showFeint,
            _showInterruptList,
            _showDots,
            _showOpener,
            _showBattleVoice,
            _showSongs,
            _showFlamingArrow,
            _showQuellingStrikes,
            _showRainofDeath,
            _showAdvancedRainofDeath,
            _showPeloton,
            _showBloodoforBlood,
            _showPaean,
            _showSidewinder,
            _showCure,
            _showFoeRequiem,
            _showManualInterrupt,
            _showAoEBeforeDoTs,
            _showMultiDoT,
            _showMinuetDance,
            _showManualNaturesMinne,
            _showTargetNaturesMinne,
            _showManualPalisade,
            _showTargetPalisade,
            _showBusterPalisade,
            _showTactician,
            _showRefresh;

        private int _windBiteRfsh,
            _venomBiteRfsh,
            _mobCount,
            _tpLimit,
            _foesMp,
            _roDMobCount,
            _restHPct,
            _restMpPct,
            _battleVoiceMinMpPct,
            _multiDoTTargetMax,
            _secondWindHpPct,
            _naturesMinneHpPct,
            _tacticianTpPct,
            _refreshMpPct,
            _tacticianMemberCount,
            _refreshMemberCount,
            _repertoireCount,
            _palisadeHpPct;

        private bool _pvPManualBluntArrow;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);
        public ICommand UncheckUseTargetNaturesMinneCommand => new DelegateCommand(UncheckUseTargetNaturesMinne);
        public ICommand UncheckUseManualNaturesMinneCommand => new DelegateCommand(UncheckUseManualNaturesMinne);
        public ICommand UncheckUsePalisadeTargetCommand => new DelegateCommand(UncheckUseTargetPalisade);
        public ICommand UncheckUseManualPalisadeCommand => new DelegateCommand(UncheckUseManualPalisade);

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

        public void UncheckUseTargetNaturesMinne()
        {
            if (UseManualNaturesMinne)
                UseTargetNaturesMinne = false;
        }

        public void UncheckUseManualNaturesMinne()
        {
            if (_useTargetNaturesMinne)
                UseManualNaturesMinne = false;
        }

        public void UncheckUseTargetPalisade()
        {
            if (UseManualPalisade)
                UseTargetPalisade = false;
        }

        public void UncheckUseManualPalisade()
        {
            if (_useTargetPalisade)
                UseManualPalisade = false;
        }

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseRepellingShot
        {
            get => _useRepellingShot;
            set
            {
                _useRepellingShot = value;
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
        public bool UseMiserysEnd
        {
            get => _useMiserysEnd;
            set
            {
                _useMiserysEnd = value;
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
        public bool UseFoeRequiem
        {
            get => _useFoeRequiem;
            set
            {
                _useFoeRequiem = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
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
        [DefaultValue(4500)]
        public int WindBiteRfsh
        {
            get => _windBiteRfsh;
            set
            {
                _windBiteRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4500)]
        public int VenomBiteRfsh
        {
            get => _venomBiteRfsh;
            set
            {
                _venomBiteRfsh = value;
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
        [DefaultValue(5)]
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
        public bool UseBattleVoice
        {
            get => _useBattleVoice;
            set
            {
                _useBattleVoice = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSongs
        {
            get => _useSongs;
            set
            {
                _useSongs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int FoesMpRfsh
        {
            get => _foesMp;
            set
            {
                _foesMp = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFlamingArrow
        {
            get => _useFlamingArrow;
            set
            {
                _useFlamingArrow = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseQuellingStrikes
        {
            get => _useQuellingStrikes;
            set
            {
                _useQuellingStrikes = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRainofDeath
        {
            get => _useRainofDeath;
            set
            {
                _useRainofDeath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int RoDMobCount
        {
            get => _roDMobCount;
            set
            {
                _roDMobCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2500)]
        public int IronJawsRsRefresh
        {
            get => _restHPct;
            set
            {
                _restHPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int RestMpPct
        {
            get => _restMpPct;
            set
            {
                _restMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UsePeloton
        {
            get => _usePeloton;
            set
            {
                _usePeloton = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTroubadour
        {
            get => _useTroubadour;
            set
            {
                _useTroubadour = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePaean
        {
            get => _usePaean;
            set
            {
                _usePaean = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSidewinder
        {
            get => _useSidewinder;
            set
            {
                _useSidewinder = value;
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
        [DefaultValue(75)]
        public int BattleVoiceMinMpPct
        {
            get => _battleVoiceMinMpPct;
            set
            {
                _battleVoiceMinMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseAoEBeforeDoTs
        {
            get => _useAoEBeforeDoTs;
            set
            {
                _useAoEBeforeDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseMultiDoT
        {
            get => _useMultiDoT;
            set
            {
                _useMultiDoT = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int MultiDoTTargetMax
        {
            get => _multiDoTTargetMax;
            set
            {
                _multiDoTTargetMax = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRepellingShot
        {
            get => _showRepellingShot;
            set
            {
                _showRepellingShot = value;
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
        public bool ShowMiserysEnd
        {
            get => _showMiserysEnd;
            set
            {
                _showMiserysEnd = value;
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
        public bool ShowMinuet
        {
            get => _showMinuet;
            set
            {
                _showMinuet = value;
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
        public bool ShowAdvancedRainofDeath
        {
            get => _showAdvancedRainofDeath;
            set
            {
                _showAdvancedRainofDeath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBattleVoice
        {
            get => _showBattleVoice;
            set
            {
                _showBattleVoice = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSongs
        {
            get => _showSongs;
            set
            {
                _showSongs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFlamingArrow
        {
            get => _showFlamingArrow;
            set
            {
                _showFlamingArrow = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowQuellingStrikes
        {
            get => _showQuellingStrikes;
            set
            {
                _showQuellingStrikes = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRainofDeath
        {
            get => _showRainofDeath;
            set
            {
                _showRainofDeath = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPeloton
        {
            get => _showPeloton;
            set
            {
                _showPeloton = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBloodforBlood
        {
            get => _showBloodoforBlood;
            set
            {
                _showBloodoforBlood = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPaean
        {
            get => _showPaean;
            set
            {
                _showPaean = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSidewinder
        {
            get => _showSidewinder;
            set
            {
                _showSidewinder = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCure
        {
            get => _showCure;
            set
            {
                _showCure = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFoeRequiem
        {
            get => _showFoeRequiem;
            set
            {
                _showFoeRequiem = value;
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
        public bool ShowAoEBeforeDoTs
        {
            get => _showAoEBeforeDoTs;
            set
            {
                _showAoEBeforeDoTs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMultiDoT
        {
            get => _showMultiDoT;
            set
            {
                _showMultiDoT = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMinuetDance
        {
            get => _useMinuetDance;
            set
            {
                _useMinuetDance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMinuetDance
        {
            get => _showMinuetDance;
            set
            {
                _showMinuetDance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int SecondWindHpPct
        {
            get => _secondWindHpPct;
            set
            {
                _secondWindHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int NaturesMinneHpPct
        {
            get => _naturesMinneHpPct;
            set
            {
                _naturesMinneHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTactician
        {
            get => _useTactician;
            set
            {
                _useTactician = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTactician
        {
            get => _showTactician;
            set
            {
                _showTactician = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRefresh
        {
            get => _useRefresh;
            set
            {
                _useRefresh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRefresh
        {
            get => _showRefresh;
            set
            {
                _showRefresh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int TacticianTpPct
        {
            get => _tacticianTpPct;
            set
            {
                _tacticianTpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(50)]
        public int RefreshMpPct
        {
            get => _refreshMpPct;
            set
            {
                _refreshMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int TacticianMemberCount
        {
            get => _tacticianMemberCount;
            set
            {
                _tacticianMemberCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int RefreshMemberCount
        {
            get => _refreshMemberCount;
            set
            {
                _refreshMemberCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int RepertoireCount
        {
            get => _repertoireCount;
            set
            {
                _repertoireCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int PalisadeHpPct
        {
            get => _palisadeHpPct;
            set
            {
                _palisadeHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualNaturesMinne
        {
            get => _useManualNaturesMinne;
            set
            {
                _useManualNaturesMinne = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualNaturesMinne
        {
            get => _showManualNaturesMinne;
            set
            {
                _showManualNaturesMinne = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetNaturesMinne
        {
            get => _useTargetNaturesMinne;
            set
            {
                _useTargetNaturesMinne = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetNaturesMinne
        {
            get => _showTargetNaturesMinne;
            set
            {
                _showTargetNaturesMinne = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualPalisade
        {
            get => _useManualPalisade;
            set
            {
                _useManualPalisade = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualPalisade
        {
            get => _showManualPalisade;
            set
            {
                _showManualPalisade = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTargetPalisade
        {
            get => _useTargetPalisade;
            set
            {
                _useTargetPalisade = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTargetPalisade
        {
            get => _showTargetPalisade;
            set
            {
                _showTargetPalisade = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBusterPalisade
        {
            get => _useBusterPalisade;
            set
            {
                _useBusterPalisade = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBusterPalisade
        {
            get => _showBusterPalisade;
            set
            {
                _showBusterPalisade = value;
                OnPropertyChanged();
            }
        }

        private TroubadourSongSelection troubadourSongSelection;

        [Setting]
        public TroubadourSongSelection TroubadourSongSelection
        {
            get => troubadourSongSelection;
            set
            {
                troubadourSongSelection = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool PvPManualBluntArrow
        {
            get => _pvPManualBluntArrow;
            set
            {
                _pvPManualBluntArrow = value;
                OnPropertyChanged();
            }
        }
    }

    public enum TroubadourSongSelection
    {
        Minuet,
        Ballad,
        Paeon,
        None
    }
}