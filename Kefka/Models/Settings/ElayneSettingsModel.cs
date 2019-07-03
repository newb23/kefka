using static Kefka.Utilities.Constants;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace Kefka.Models
{
    public class ElayneSettingsModel : BaseModel
    {
        private static ElayneSettingsModel _instance;
        public static ElayneSettingsModel Instance => _instance ?? (_instance = new ElayneSettingsModel());

        private ElayneSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Elayne/Elayne_Settings.json")
        {
        }

        private bool _useContraSixte, _useBuffs, _useVerraise, _useAoE, _useDpsPotion, _useSwiftcast, _useDoTs, _useOpener, _useDiversion, _useMelee, _useSwiftcastForVerraise, _useEmbolden, _useCorpsacorps, _useVercure, _useVercureInNonAutonomous, _useDisplacement;

        private bool _showCorpsacorps, _showBuffs, _showVerraise, _showAoE, _showDpsPotion, _showSwiftcast, _showDoTs, _showOpener, _showMelee, _showQuellingStrikes, _showDisplacement, _showContreSixte, _showDiversion, _showVercure, _showVercureInNonAutonomous, _showEmbolden,
            _showUseSwiftcastForVerraise;

        private int _verraiseMinMpPct, _meleeComboMinManaInt, _miasmaRfsh, _miasmaIiRfsh, _mobCount, _manaficationLevel, _triDisasterMinHp, _summonHealPct, _selfHealPct;

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseContraSixte
        { get { return _useContraSixte; } set { _useContraSixte = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseVerraise
        { get { return _useVerraise; } set { _useVerraise = value; OnPropertyChanged(); } }

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
        public bool UseSwiftcast
        { get { return _useSwiftcast; } set { _useSwiftcast = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDiversion
        { get { return _useDiversion; } set { _useDiversion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int VerraiseMinMpPct
        { get { return _verraiseMinMpPct; } set { _verraiseMinMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int MeleeComboMinManaInt
        { get { return _meleeComboMinManaInt; } set { _meleeComboMinManaInt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4000)]
        public int MiasmaRfsh
        { get { return _miasmaRfsh; } set { _miasmaRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(4000)]
        public int MiasmaIiRfsh
        { get { return _miasmaIiRfsh; } set { _miasmaIiRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDoTs
        { get { return _useDoTs; } set { _useDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MobCount
        { get { return _mobCount; } set { _mobCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int ManaficationLevel
        { get { return _manaficationLevel; } set { _manaficationLevel = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseOpener
        { get { return _useOpener; } set { _useOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMelee
        { get { return _useMelee; } set { _useMelee = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseSwiftcastForVerraise
        { get { return _useSwiftcastForVerraise; } set { _useSwiftcastForVerraise = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmbolden
        { get { return _useEmbolden; } set { _useEmbolden = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(25000)]
        public int TriDisasterMinHp
        { get { return _triDisasterMinHp; } set { _triDisasterMinHp = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCorpsacorps
        { get { return _useCorpsacorps; } set { _useCorpsacorps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCorpsacorps
        { get { return _showCorpsacorps; } set { _showCorpsacorps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBuffs
        { get { return _showBuffs; } set { _showBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowVerraise
        { get { return _showVerraise; } set { _showVerraise = value; OnPropertyChanged(); } }

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
        public bool ShowSwiftcast
        { get { return _showSwiftcast; } set { _showSwiftcast = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowMelee
        { get { return _showMelee; } set { _showMelee = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoTs
        { get { return _showDoTs; } set { _showDoTs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowQuellingStrikes
        { get { return _showQuellingStrikes; } set { _showQuellingStrikes = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDisplacement
        { get { return _showDisplacement; } set { _showDisplacement = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowContreSixte
        { get { return _showContreSixte; } set { _showContreSixte = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDiversion
        { get { return _showDiversion; } set { _showDiversion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseVercure
        { get { return _useVercure; } set { _useVercure = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowVercure
        { get { return _showVercure; } set { _showVercure = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int SummonHealPct
        { get { return _summonHealPct; } set { _summonHealPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseVercureInNonAutonomous
        { get { return _useVercureInNonAutonomous; } set { _useVercureInNonAutonomous = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowVercureInNonAutonomous
        { get { return _showVercureInNonAutonomous; } set { _showVercureInNonAutonomous = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDisplacement
        { get { return _useDisplacement; } set { _useDisplacement = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEmbolden
        { get { return _showEmbolden; } set { _showEmbolden = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int SelfHealPct
        { get { return _selfHealPct; } set { _selfHealPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowUseSwiftcastForVerraise
        { get { return _showUseSwiftcastForVerraise; } set { _showUseSwiftcastForVerraise = value; OnPropertyChanged(); } }
    }
}