using System.ComponentModel;
using System.Configuration;
using System.IO;
using Kefka.Properties;
using Kefka.Utilities;

namespace Kefka.Models
{
    public class SuritoSettingsModel : BaseModel
    {
        private static SuritoSettingsModel _instance;
        public static SuritoSettingsModel Instance => _instance ?? (_instance = new SuritoSettingsModel());

        private SuritoSettingsModel() : base(CharacterSettingsDirectory +
                                             "/Kefka/Routine Settings/Surito/Surito_Settings.json")
        {
        }

        private bool
            _useShitButton,
            _useCleanse,
            _usePotion,
            _useSuccor,
            _useEmergencyTacticsSuccor,
            _useEyeforanEyeOnlyAfterAdloquium,
            _useSummon,
            _useSummonInCombat,
            _useEmbrace,
            _useWhisperingDawn,
            _useFeyCovenant,
            _usePhysick,
            _useLustrate,
            _useFeyIllumination,
            _useSacredSoil,
            _useIndomitability,
            _useSustain,
            _useAdloquium,
            _useSwiftcastResurrection,
            _useEmergencyTactics,
            _autoStopHeal,
            _useDeploymentTactics,
            _useSilentDusk,
            _useFeyCaress,
            _useFeyWind,
            _useEmergencyTacticsAdloquium,
            _useRouseTankOnly,
            _useShadowFlare,
            _useDelpoymentTacticsOnBothBuffsOnly,
            _useProtectInCombat,
            _useAdloquiumOnTankOnly,
            _useRouse,
            _useProtect,
            _useAutoPrebuff,
            _useEyeforanEye,
            _doDamage,
            _stopDpsIfHpDips,
            _useBio,
            _useMiasma,
            _useMiasmaII,
            _useResurrection,
            _useLustrateOnTankOnly,
            _useEmergencyTacticsOnTankOnly,
            _useRuinSpells,
            _useBroil,
            _useDissipation,
            _useEnergyDrain,
            _swiftcastSummon,
            _useExcogitationOnTankOnly,
            _useExcogitation,
            _useChainStratagem,
            _useAetherpactOnTankOnly,
            _useAetherpact,
            _useLargesseOnTankOnly,
            _useLargesse,
            _useLucidDreaming;

        private bool
            _showSummon,
            _showPotion,
            _showDoDamage,
            _showShadowFlare,
            _showChainStratagem,
            _showLustrate,
            _showEmergencyTactics,
            _showIndomitability,
            _showExcogitation,
            _showAetherpact,
            _showEyeforanEye,
            _showLargesse,
            _showRouse,
            _showDissipation;

        private int
            _cleanseHpPct,
            _physickHpPct,
            _adloquiumHpPct,
            _lustrateHpPct,
            _succorHpPct,
            _sacredSoilHpPct,
            _emergencyTacticsSuccorHpPct,
            _indomitabilityHpPct,
            _emergencyTacticsAdloquiumHpPct,
            _succorPlayerCount,
            _sacredSoilPlayerCount,
            _indomitabilityPlayerCount,
            _deploymentTacticsMinBuffTime,
            _rouseHpPct,
            _sustainHpPct,
            _whisperingDawnHpPct,
            _shadowFlareMinTargets,
            _feyCovenantHpPct,
            _feyIlluninationHpPct,
            _eyeforanEyeHpPct,
            _embraceHpPct,
            _damageMinMpPct,
            _bioRfsh,
            _bio2Rfsh,
            _miasmaRfsh,
            _miasma2Rfsh,
            _stopHealHpPct,
            _deploymentTacticsPlayerCount,
            _dissipationHpPct,
            _energyDrainHpPct,
            _energyDrainMpPct,
            _baneEnemyCount,
            _petAoEPlayerCount,
            _lucidDreamingMpPct,
            _excogitationHpPct,
            _aetherpactHpPct,
            _aetherpactMinGuage,
            _largesseHpPct,
            _largessePlayerCount;

        public void Load(string path)
        {
            if (File.Exists(path))
                LoadFrom(path);
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseShitButton
        {
            get => _useShitButton;
            set
            {
                _useShitButton = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCleanse
        {
            get => _useCleanse;
            set
            {
                _useCleanse = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int CleanseHP
        {
            get => _cleanseHpPct;
            set
            {
                _cleanseHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePotion
        {
            get => _usePotion;
            set
            {
                _usePotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSuccor
        {
            get => _useSuccor;
            set
            {
                _useSuccor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTacticsSuccor
        {
            get => _useEmergencyTacticsSuccor;
            set
            {
                _useEmergencyTacticsSuccor = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEyeOnlyAfterAdloquium
        {
            get => _useEyeforanEyeOnlyAfterAdloquium;
            set
            {
                _useEyeforanEyeOnlyAfterAdloquium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSummon
        {
            get => _useSummon;
            set
            {
                _useSummon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSummonInCombat
        {
            get => _useSummonInCombat;
            set
            {
                _useSummonInCombat = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmbrace
        {
            get => _useEmbrace;
            set
            {
                _useEmbrace = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseWhisperingDawn
        {
            get => _useWhisperingDawn;
            set
            {
                _useWhisperingDawn = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLustrate
        {
            get => _useLustrate;
            set
            {
                _useLustrate = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int PhysickHpPct
        {
            get => _physickHpPct;
            set
            {
                _physickHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int AdloquiumHpPct
        {
            get => _adloquiumHpPct;
            set
            {
                _adloquiumHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int LustrateHpPct
        {
            get => _lustrateHpPct;
            set
            {
                _lustrateHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int SuccorHpPct
        {
            get => _succorHpPct;
            set
            {
                _succorHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeyCovenant
        {
            get => _useFeyCovenant;
            set
            {
                _useFeyCovenant = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(90)]
        public int SacredSoilHpPct
        {
            get => _sacredSoilHpPct;
            set
            {
                _sacredSoilHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int EmergencyTacticsSuccorHpPct
        {
            get => _emergencyTacticsSuccorHpPct;
            set
            {
                _emergencyTacticsSuccorHpPct = value;
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
        [DefaultValue(false)]
        public bool UseFeyIllumination
        {
            get => _useFeyIllumination;
            set
            {
                _useFeyIllumination = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSacredSoil
        {
            get => _useSacredSoil;
            set
            {
                _useSacredSoil = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(85)]
        public int IndomitabilityHpPct
        {
            get => _indomitabilityHpPct;
            set
            {
                _indomitabilityHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseIndomitability
        {
            get => _useIndomitability;
            set
            {
                _useIndomitability = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastResurrection
        {
            get => _useSwiftcastResurrection;
            set
            {
                _useSwiftcastResurrection = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDeploymentTactics
        {
            get => _useDeploymentTactics;
            set
            {
                _useDeploymentTactics = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseSilentDusk
        {
            get => _useSilentDusk;
            set
            {
                _useSilentDusk = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeyCaress
        {
            get => _useFeyCaress;
            set
            {
                _useFeyCaress = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeyWind
        {
            get => _useFeyWind;
            set
            {
                _useFeyWind = value;
                OnPropertyChanged();
            }
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
        public bool UseEmergencyTacticsAdloquium
        {
            get => _useEmergencyTacticsAdloquium;
            set
            {
                _useEmergencyTacticsAdloquium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseRouseTankOnly
        {
            get => _useRouseTankOnly;
            set
            {
                _useRouseTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDelpoymentTacticsOnBothBuffsOnly
        {
            get => _useDelpoymentTacticsOnBothBuffsOnly;
            set
            {
                _useDelpoymentTacticsOnBothBuffsOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseProtectInCombat
        {
            get => _useProtectInCombat;
            set
            {
                _useProtectInCombat = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSustain
        {
            get => _useSustain;
            set
            {
                _useSustain = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int EmergencyTacticsAdloquiumHpPct
        {
            get => _emergencyTacticsAdloquiumHpPct;
            set
            {
                _emergencyTacticsAdloquiumHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAdloquiumOnTankOnly
        {
            get => _useAdloquiumOnTankOnly;
            set
            {
                _useAdloquiumOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAdloquium
        {
            get => _useAdloquium;
            set
            {
                _useAdloquium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRouse
        {
            get => _useRouse;
            set
            {
                _useRouse = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int SuccorPlayerCount
        {
            get => _succorPlayerCount;
            set
            {
                _succorPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int SacredSoilPlayerCount
        {
            get => _sacredSoilPlayerCount;
            set
            {
                _sacredSoilPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTactics
        {
            get => _useEmergencyTactics;
            set
            {
                _useEmergencyTactics = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseProtect
        {
            get => _useProtect;
            set
            {
                _useProtect = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AutoStopHeal
        {
            get => _autoStopHeal;
            set
            {
                _autoStopHeal = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2)]
        public int IndomitabilityPlayerCount
        {
            get => _indomitabilityPlayerCount;
            set
            {
                _indomitabilityPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2)]
        public int DeploymentTacticsPlayerCount
        {
            get => _deploymentTacticsPlayerCount;
            set
            {
                _deploymentTacticsPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int DeploymentTacticsMinBuffTime
        {
            get => _deploymentTacticsMinBuffTime;
            set
            {
                _deploymentTacticsMinBuffTime = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(90)]
        public int RouseHpPct
        {
            get => _rouseHpPct;
            set
            {
                _rouseHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(65)]
        public int SustainHpPct
        {
            get => _sustainHpPct;
            set
            {
                _sustainHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int WhisperingDawnHpPct
        {
            get => _whisperingDawnHpPct;
            set
            {
                _whisperingDawnHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int PetAoEPlayerCount
        {
            get => _petAoEPlayerCount;
            set
            {
                _petAoEPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int ShadowFlareMinTargets
        {
            get => _shadowFlareMinTargets;
            set
            {
                _shadowFlareMinTargets = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAutoPrebuff
        {
            get => _useAutoPrebuff;
            set
            {
                _useAutoPrebuff = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEye
        {
            get => _useEyeforanEye;
            set
            {
                _useEyeforanEye = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int FeyCovenantHpPct
        {
            get => _feyCovenantHpPct;
            set
            {
                _feyCovenantHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int FeyIlluninationHpPct
        {
            get => _feyIlluninationHpPct;
            set
            {
                _feyIlluninationHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int EyeforanEyeHpPct
        {
            get => _eyeforanEyeHpPct;
            set
            {
                _eyeforanEyeHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int EmbraceHpPct
        {
            get => _embraceHpPct;
            set
            {
                _embraceHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int DamageMinMpPct
        {
            get => _damageMinMpPct;
            set
            {
                _damageMinMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
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
        [DefaultValue(5000)]
        public int Bio2Rfsh
        {
            get => _bio2Rfsh;
            set
            {
                _bio2Rfsh = value;
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
        [DefaultValue(90)]
        public int StopHealHpPct
        {
            get => _stopHealHpPct;
            set
            {
                _stopHealHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool StopDpsIfHpDips
        {
            get => _stopDpsIfHpDips;
            set
            {
                _stopDpsIfHpDips = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMiasma
        {
            get => _useMiasma;
            set
            {
                _useMiasma = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
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
        [DefaultValue(true)]
        public bool UseMiasmaII
        {
            get => _useMiasmaII;
            set
            {
                _useMiasmaII = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
        public int Miasma2Rfsh
        {
            get => _miasma2Rfsh;
            set
            {
                _miasma2Rfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool DoDamage
        {
            get => _doDamage;
            set
            {
                _doDamage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLustrateOnTankOnly
        {
            get => _useLustrateOnTankOnly;
            set
            {
                _useLustrateOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTacticsOnTankOnly
        {
            get => _useEmergencyTacticsOnTankOnly;
            set
            {
                _useEmergencyTacticsOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBio
        {
            get => _useBio;
            set
            {
                _useBio = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRuinSpells
        {
            get => _useRuinSpells;
            set
            {
                _useRuinSpells = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBroil
        {
            get => _useBroil;
            set
            {
                _useBroil = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDissipation
        {
            get => _useDissipation;
            set
            {
                _useDissipation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int DissipationHpPct
        {
            get => _dissipationHpPct;
            set
            {
                _dissipationHpPct = value;
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
        [DefaultValue(60)]
        public int EnergyDrainHpPct
        {
            get => _energyDrainHpPct;
            set
            {
                _energyDrainHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int EnergyDrainMpPct
        {
            get => _energyDrainMpPct;
            set
            {
                _energyDrainMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(2)]
        public int BaneEnemyCount
        {
            get => _baneEnemyCount;
            set
            {
                _baneEnemyCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool SwiftcastSummon
        {
            get => _swiftcastSummon;
            set
            {
                _swiftcastSummon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseExcogitation
        {
            get => _useExcogitation;
            set
            {
                _useExcogitation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseExcogitationOnTankOnly
        {
            get => _useExcogitationOnTankOnly;
            set
            {
                _useExcogitationOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int ExcogitationHpPct
        {
            get => _excogitationHpPct;
            set
            {
                _excogitationHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseChainStratagem
        {
            get => _useChainStratagem;
            set
            {
                _useChainStratagem = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherpact
        {
            get => _useAetherpact;
            set
            {
                _useAetherpact = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherpactOnTankOnly
        {
            get => _useAetherpactOnTankOnly;
            set
            {
                _useAetherpactOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int AetherpactHpPct
        {
            get => _aetherpactHpPct;
            set
            {
                _aetherpactHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int AetherpactMinGuage
        {
            get => _aetherpactMinGuage;
            set
            {
                _aetherpactMinGuage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesse
        {
            get => _useLargesse;
            set
            {
                _useLargesse = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesseOnTankOnly
        {
            get => _useLargesseOnTankOnly;
            set
            {
                _useLargesseOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int LargesseHpPct
        {
            get => _largesseHpPct;
            set
            {
                _largesseHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public int LargessePlayerCount
        {
            get => _largessePlayerCount;
            set
            {
                _largessePlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLucidDreaming
        {
            get => _useLucidDreaming;
            set
            {
                _useLucidDreaming = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int LucidDreamingMpPct
        {
            get => _lucidDreamingMpPct;
            set
            {
                _lucidDreamingMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSummon
        {
            get => _showSummon;
            set
            {
                _showSummon = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPotion
        {
            get => _showPotion;
            set
            {
                _showPotion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoDamage
        {
            get => _showDoDamage;
            set
            {
                _showDoDamage = value;
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
        public bool ShowChainStratagem
        {
            get => _showChainStratagem;
            set
            {
                _showChainStratagem = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLustrate
        {
            get => _showLustrate;
            set
            {
                _showLustrate = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEmergencyTactics
        {
            get => _showEmergencyTactics;
            set
            {
                _showEmergencyTactics = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowIndomitability
        {
            get => _showIndomitability;
            set
            {
                _showIndomitability = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowExcogitation
        {
            get => _showExcogitation;
            set
            {
                _showExcogitation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAetherpact
        {
            get => _showAetherpact;
            set
            {
                _showAetherpact = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEyeforanEye
        {
            get => _showEyeforanEye;
            set
            {
                _showEyeforanEye = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLargesse
        {
            get => _showLargesse;
            set
            {
                _showLargesse = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDissipation
        {
            get => _showDissipation;
            set
            {
                _showDissipation = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRouse
        {
            get => _showRouse;
            set
            {
                _showRouse = value;
                OnPropertyChanged();
            }
        }

        private SuritoSummonMode _selectedSuritoSummon;

        [Setting]
        public SuritoSummonMode SelectedSuritoSummon
        {
            get => _selectedSuritoSummon;
            set
            {
                _selectedSuritoSummon = value;
                OnPropertyChanged();
            }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SuritoSummonMode
    {
        [LocalizedDescription("Eos", typeof(Strings))]
        Eos,

        [LocalizedDescription("Selene", typeof(Strings))]
        Selene,

        [LocalizedDescription("None", typeof(Strings))]
        None
    }
}