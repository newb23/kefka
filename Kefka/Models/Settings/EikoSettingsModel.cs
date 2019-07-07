using System.ComponentModel;
using System.Configuration;
using System.IO;
using Kefka.Properties;
using Kefka.Routine_Files.Eiko;
using Kefka.Utilities;

namespace Kefka.Models
{
    public class EikoSettingsModel : BaseModel
    {
        private static EikoSettingsModel _instance;
        public static EikoSettingsModel Instance => _instance ?? (_instance = new EikoSettingsModel());

        private EikoSettingsModel() : base(CharacterSettingsDirectory +
                                           "/Kefka/Routine Settings/Eiko/Eiko_Settings.json")
        {
        }

        private bool _useShadowFlare,
            _useBuffs,
            _useSummonPets,
            _useAoE,
            _useDpsPotion,
            _useSwiftcast,
            _useDoTs,
            _useOpener,
            _useAetherflowAbilities,
            _useQuellingStrikes,
            _useRuin2Filler,
            _useTriDisaster,
            _usePreRuinoGcDs,
            _usePhysick,
            _usePhysickInNonAutonomous,
            _useEnergyDrain,
            _useAetherflow,
            _useContagion,
            _useHeel,
            _useResurrection;

        private bool _showShadowFlare,
            _showBuffs,
            _showSummonPets,
            _showAoE,
            _showDpsPotion,
            _showSwiftcast,
            _showDoTs,
            _showOpener,
            _showAetherflowAbilities,
            _showQuellingStrikes,
            _showRuin2Filler,
            _showTriDisaster,
            _showpreRuinoGcDs,
            _showPhysick,
            _showPhysickInNonAutonomous,
            _showEnergyDrain,
            _showAetherflow,
            _showContagion,
            _showResurrection;

        private int _bioRfsh,
            _bioIiRfsh,
            _miasmaRfsh,
            _miasmaIiRfsh,
            _mobCount,
            _mpLimitPct,
            _triDisasterMinHp,
            _summonHealPct,
            _selfHealPct,
            _minBaneTime,
            _heelDistance,
            _resurrectionMinMpPct;

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseShadowFlare
        {
            get => _useShadowFlare;
            set
            {
                _useShadowFlare = value;
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
        public bool UseSummonPets
        {
            get => _useSummonPets;
            set
            {
                _useSummonPets = value;
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
        public bool UseSwiftcast
        {
            get => _useSwiftcast;
            set
            {
                _useSwiftcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherflowAbilities
        {
            get => _useAetherflowAbilities;
            set
            {
                _useAetherflowAbilities = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int BioRfsh
        {
            get => _bioRfsh;
            set
            {
                _bioRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int BioIiRfsh
        {
            get => _bioIiRfsh;
            set
            {
                _bioIiRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int MiasmaRfsh
        {
            get => _miasmaRfsh;
            set
            {
                _miasmaRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(4000)]
        public int MiasmaIiRfsh
        {
            get => _miasmaIiRfsh;
            set
            {
                _miasmaIiRfsh = value;
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
        [DefaultValue(40)]
        public int MpLimitPct
        {
            get => _mpLimitPct;
            set
            {
                _mpLimitPct = value;
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
        [DefaultValue(false)]
        public bool UseRuin2Filler
        {
            get => _useRuin2Filler;
            set
            {
                _useRuin2Filler = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTriDisaster
        {
            get => _useTriDisaster;
            set
            {
                _useTriDisaster = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(25000)]
        public int TriDisasterMinHp
        {
            get => _triDisasterMinHp;
            set
            {
                _triDisasterMinHp = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePreRuinoGcDs
        {
            get => _usePreRuinoGcDs;
            set
            {
                _usePreRuinoGcDs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherflow
        {
            get => _useAetherflow;
            set
            {
                _useAetherflow = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadowFlare
        {
            get => _showShadowFlare;
            set
            {
                _showShadowFlare = value;
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
        public bool ShowSummonPets
        {
            get => _showSummonPets;
            set
            {
                _showSummonPets = value;
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
        public bool ShowSwiftcast
        {
            get => _showSwiftcast;
            set
            {
                _showSwiftcast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAetherflowAbilities
        {
            get => _showAetherflowAbilities;
            set
            {
                _showAetherflowAbilities = value;
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
        public bool ShowRuin2Filler
        {
            get => _showRuin2Filler;
            set
            {
                _showRuin2Filler = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTriDisaster
        {
            get => _showTriDisaster;
            set
            {
                _showTriDisaster = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPreRuinoGcDs
        {
            get => _showpreRuinoGcDs;
            set
            {
                _showpreRuinoGcDs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePhysick
        {
            get => _usePhysick;
            set
            {
                _usePhysick = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPhysick
        {
            get => _showPhysick;
            set
            {
                _showPhysick = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int SummonHealPct
        {
            get => _summonHealPct;
            set
            {
                _summonHealPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePhysickInNonAutonomous
        {
            get => _usePhysickInNonAutonomous;
            set
            {
                _usePhysickInNonAutonomous = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPhysickInNonAutonomous
        {
            get => _showPhysickInNonAutonomous;
            set
            {
                _showPhysickInNonAutonomous = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEnergyDrain
        {
            get => _useEnergyDrain;
            set
            {
                _useEnergyDrain = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEnergyDrain
        {
            get => _showEnergyDrain;
            set
            {
                _showEnergyDrain = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAetherflow
        {
            get => _showAetherflow;
            set
            {
                _showAetherflow = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int SelfHealPct
        {
            get => _selfHealPct;
            set
            {
                _selfHealPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
        public int MinBaneTime
        {
            get => _minBaneTime;
            set
            {
                _minBaneTime = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseContagion
        {
            get => _useContagion;
            set
            {
                _useContagion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowContagion
        {
            get => _showContagion;
            set
            {
                _showContagion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseHeel
        {
            get => _useHeel;
            set
            {
                _useHeel = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int HeelDistance
        {
            get => _heelDistance;
            set
            {
                _heelDistance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseResurrection
        {
            get => _useResurrection;
            set
            {
                _useResurrection = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowResurrection
        {
            get => _showResurrection;
            set
            {
                _showResurrection = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int ResurrectionMinMpPct
        {
            get => _resurrectionMinMpPct;
            set
            {
                _resurrectionMinMpPct = value;
                OnPropertyChanged();
            }
        }

        private EikoSummonMode _selectedEikoSummon;

        [Setting]
        public EikoSummonMode SelectedEikoSummon
        {
            get => _selectedEikoSummon;
            set
            {
                _selectedEikoSummon = value;
                OnPropertyChanged();
            }
        }

        internal static GarudaGlamour selectedGarudaGlamour;

        [Setting]
        public GarudaGlamour SelectedGarudaGlamour
        {
            get => selectedGarudaGlamour;
            set
            {
                if (!Kefka.windowInitialized)
                    return;

                selectedGarudaGlamour = value;
                OnPropertyChanged();
                EikoRotation.SetGlamours("Garuda");
            }
        }

        internal static TitanGlamour selectedTitanGlamour;

        [Setting]
        public TitanGlamour SelectedTitanGlamour
        {
            get => selectedTitanGlamour;
            set
            {
                if (!Kefka.windowInitialized)
                    return;

                selectedTitanGlamour = value;
                OnPropertyChanged();
                EikoRotation.SetGlamours("Titan");
            }
        }

        internal static IfritGlamour selectedIfritGlamour;

        [Setting]
        public IfritGlamour SelectedIfritGlamour
        {
            get => selectedIfritGlamour;
            set
            {
                if (!Kefka.windowInitialized)
                    return;

                selectedIfritGlamour = value;
                OnPropertyChanged();
                EikoRotation.SetGlamours("Ifrit");
            }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum EikoSummonMode
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("Garuda", typeof(Strings))]
        Garuda,

        [LocalizedDescription("Ifrit", typeof(Strings))]
        Ifrit,

        [LocalizedDescription("Titan", typeof(Strings))]
        Titan
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum GarudaGlamour
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("EmeraldCarbuncle", typeof(Strings))]
        EmeraldCarbuncle,

        [LocalizedDescription("TopazCarbuncle", typeof(Strings))]
        TopazCarbuncle,

        [LocalizedDescription("RubyCarbuncle", typeof(Strings))]
        RubyCarbuncle
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum TitanGlamour
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("EmeraldCarbuncle", typeof(Strings))]
        EmeraldCarbuncle,

        [LocalizedDescription("TopazCarbuncle", typeof(Strings))]
        TopazCarbuncle,

        [LocalizedDescription("RubyCarbuncle", typeof(Strings))]
        RubyCarbuncle
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum IfritGlamour
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("EmeraldCarbuncle", typeof(Strings))]
        EmeraldCarbuncle,

        [LocalizedDescription("TopazCarbuncle", typeof(Strings))]
        TopazCarbuncle,

        [LocalizedDescription("RubyCarbuncle", typeof(Strings))]
        RubyCarbuncle
    }
}