using static Kefka.Utilities.Constants;
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

        private SuritoSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Surito/Surito_Settings.json")
        {
        }

        private bool _useShitButton, _useCleanse, _usePotion, _useSuccor, _useEmergencyTacticsSuccor, _useEyeforanEyeOnlyAfterAdloquium, _useSummon, _useSummonInCombat, _useEmbrace, _useWhisperingDawn, _useFeyCovenant, _usePhysick, _useLustrate, _useFeyIllumination, _useSacredSoil, _useIndomitability, _useSustain, _useAdloquium,
            _useSwiftcastResurrection, _useEmergencyTactics, _autoStopHeal, _useDeploymentTactics, _useSilentDusk, _useFeyCaress, _useFeyWind, _useEmergencyTacticsAdloquium, _useRouseTankOnly, _useShadowFlare, _useDelpoymentTacticsOnBothBuffsOnly, _useProtectInCombat,
            _useAdloquiumOnTankOnly, _useRouse, _useProtect, _useAutoPrebuff, _useEyeforanEye, _doDamage, _stopDpsIfHpDips, _useBio, _useMiasma, _useMiasmaII, _useResurrection, _useLustrateOnTankOnly, _useEmergencyTacticsOnTankOnly, _useRuinSpells, _useBroil, _useDissipation,
            _useEnergyDrain, _swiftcastSummon, _useExcogitationOnTankOnly, _useExcogitation, _useChainStratagem, _useAetherpactOnTankOnly, _useAetherpact, _useLargesseOnTankOnly, _useLargesse, _useLucidDreaming;

        private bool _showSummon, _showPotion, _showDoDamage, _showShadowFlare, _showChainStratagem, _showLustrate, _showEmergencyTactics, _showIndomitability, _showExcogitation, _showAetherpact, _showEyeforanEye, _showLargesse, _showRouse, _showDissipation;

        private int _cleanseHpPct, _physickHpPct, _adloquiumHpPct, _lustrateHpPct, _succorHpPct, _sacredSoilHpPct, _emergencyTacticsSuccorHpPct, _indomitabilityHpPct, _emergencyTacticsAdloquiumHpPct, _succorPlayerCount, _sacredSoilPlayerCount, _indomitabilityPlayerCount, _deploymentTacticsMinBuffTime, _rouseHpPct, _sustainHpPct, _whisperingDawnHpPct,
            _shadowFlareMinTargets, _feyCovenantHpPct, _feyIlluninationHpPct, _eyeforanEyeHpPct, _embraceHpPct, _damageMinMpPct, _bioRfsh, _bio2Rfsh, _miasmaRfsh, _miasma2Rfsh, _stopHealHpPct, _deploymentTacticsPlayerCount, _dissipationHpPct, _energyDrainHpPct, _energyDrainMpPct, _baneEnemyCount, _petAoEPlayerCount,
            _lucidDreamingMpPct, _excogitationHpPct, _aetherpactHpPct, _aetherpactMinGuage, _largesseHpPct, _largessePlayerCount;

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                LoadFrom(path);
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseShitButton
        { get { return _useShitButton; } set { _useShitButton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCleanse
        { get { return _useCleanse; } set { _useCleanse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int CleanseHP
        { get { return _cleanseHpPct; } set { _cleanseHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePotion
        { get { return _usePotion; } set { _usePotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSuccor
        { get { return _useSuccor; } set { _useSuccor = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTacticsSuccor
        { get { return _useEmergencyTacticsSuccor; } set { _useEmergencyTacticsSuccor = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEyeOnlyAfterAdloquium
        { get { return _useEyeforanEyeOnlyAfterAdloquium; } set { _useEyeforanEyeOnlyAfterAdloquium = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSummon
        { get { return _useSummon; } set { _useSummon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSummonInCombat
        { get { return _useSummonInCombat; } set { _useSummonInCombat = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmbrace
        { get { return _useEmbrace; } set { _useEmbrace = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseWhisperingDawn
        { get { return _useWhisperingDawn; } set { _useWhisperingDawn = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLustrate
        { get { return _useLustrate; } set { _useLustrate = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int PhysickHpPct
        { get { return _physickHpPct; } set { _physickHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int AdloquiumHpPct
        { get { return _adloquiumHpPct; } set { _adloquiumHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int LustrateHpPct
        { get { return _lustrateHpPct; } set { _lustrateHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int SuccorHpPct
        { get { return _succorHpPct; } set { _succorHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeyCovenant
        { get { return _useFeyCovenant; } set { _useFeyCovenant = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int SacredSoilHpPct
        { get { return _sacredSoilHpPct; } set { _sacredSoilHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(30)]
        public int EmergencyTacticsSuccorHpPct
        { get { return _emergencyTacticsSuccorHpPct; } set { _emergencyTacticsSuccorHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePhysick
        { get { return _usePhysick; } set { _usePhysick = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeyIllumination
        { get { return _useFeyIllumination; } set { _useFeyIllumination = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSacredSoil
        { get { return _useSacredSoil; } set { _useSacredSoil = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(85)]
        public int IndomitabilityHpPct
        { get { return _indomitabilityHpPct; } set { _indomitabilityHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseIndomitability
        { get { return _useIndomitability; } set { _useIndomitability = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastResurrection
        { get { return _useSwiftcastResurrection; } set { _useSwiftcastResurrection = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDeploymentTactics
        { get { return _useDeploymentTactics; } set { _useDeploymentTactics = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseSilentDusk
        { get { return _useSilentDusk; } set { _useSilentDusk = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseFeyCaress
        { get { return _useFeyCaress; } set { _useFeyCaress = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFeyWind
        { get { return _useFeyWind; } set { _useFeyWind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseShadowFlare
        { get { return _useShadowFlare; } set { _useShadowFlare = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTacticsAdloquium
        { get { return _useEmergencyTacticsAdloquium; } set { _useEmergencyTacticsAdloquium = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseRouseTankOnly
        { get { return _useRouseTankOnly; } set { _useRouseTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDelpoymentTacticsOnBothBuffsOnly
        { get { return _useDelpoymentTacticsOnBothBuffsOnly; } set { _useDelpoymentTacticsOnBothBuffsOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseProtectInCombat
        { get { return _useProtectInCombat; } set { _useProtectInCombat = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSustain
        { get { return _useSustain; } set { _useSustain = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int EmergencyTacticsAdloquiumHpPct
        { get { return _emergencyTacticsAdloquiumHpPct; } set { _emergencyTacticsAdloquiumHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAdloquiumOnTankOnly
        { get { return _useAdloquiumOnTankOnly; } set { _useAdloquiumOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAdloquium
        { get { return _useAdloquium; } set { _useAdloquium = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRouse
        { get { return _useRouse; } set { _useRouse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int SuccorPlayerCount
        { get { return _succorPlayerCount; } set { _succorPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int SacredSoilPlayerCount
        { get { return _sacredSoilPlayerCount; } set { _sacredSoilPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTactics
        { get { return _useEmergencyTactics; } set { _useEmergencyTactics = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseProtect
        { get { return _useProtect; } set { _useProtect = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool AutoStopHeal
        { get { return _autoStopHeal; } set { _autoStopHeal = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(2)]
        public int IndomitabilityPlayerCount
        { get { return _indomitabilityPlayerCount; } set { _indomitabilityPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(2)]
        public int DeploymentTacticsPlayerCount
        { get { return _deploymentTacticsPlayerCount; } set { _deploymentTacticsPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int DeploymentTacticsMinBuffTime
        { get { return _deploymentTacticsMinBuffTime; } set { _deploymentTacticsMinBuffTime = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int RouseHpPct
        { get { return _rouseHpPct; } set { _rouseHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(65)]
        public int SustainHpPct
        { get { return _sustainHpPct; } set { _sustainHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int WhisperingDawnHpPct
        { get { return _whisperingDawnHpPct; } set { _whisperingDawnHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int PetAoEPlayerCount
        { get { return _petAoEPlayerCount; } set { _petAoEPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int ShadowFlareMinTargets
        { get { return _shadowFlareMinTargets; } set { _shadowFlareMinTargets = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAutoPrebuff
        { get { return _useAutoPrebuff; } set { _useAutoPrebuff = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEye
        { get { return _useEyeforanEye; } set { _useEyeforanEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int FeyCovenantHpPct
        { get { return _feyCovenantHpPct; } set { _feyCovenantHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int FeyIlluninationHpPct
        { get { return _feyIlluninationHpPct; } set { _feyIlluninationHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int EyeforanEyeHpPct
        { get { return _eyeforanEyeHpPct; } set { _eyeforanEyeHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int EmbraceHpPct
        { get { return _embraceHpPct; } set { _embraceHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int DamageMinMpPct
        { get { return _damageMinMpPct; } set { _damageMinMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int BioRfsh
        { get { return _bioRfsh; } set { _bioRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int Bio2Rfsh
        { get { return _bio2Rfsh; } set { _bio2Rfsh = value; OnPropertyChanged(); } }
        
        [Setting]
        [DefaultValue(true)]
        public bool UseResurrection
        { get { return _useResurrection; } set { _useResurrection = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int StopHealHpPct
        { get { return _stopHealHpPct; } set { _stopHealHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool StopDpsIfHpDips
        { get { return _stopDpsIfHpDips; } set { _stopDpsIfHpDips = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMiasma
        { get { return _useMiasma; } set { _useMiasma = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int MiasmaRfsh
        { get { return _miasmaRfsh; } set { _miasmaRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMiasmaII
        { get { return _useMiasmaII; } set { _useMiasmaII = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int Miasma2Rfsh
        { get { return _miasma2Rfsh; } set { _miasma2Rfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool DoDamage
        { get { return _doDamage; } set { _doDamage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLustrateOnTankOnly
        { get { return _useLustrateOnTankOnly; } set { _useLustrateOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEmergencyTacticsOnTankOnly
        { get { return _useEmergencyTacticsOnTankOnly; } set { _useEmergencyTacticsOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBio
        { get { return _useBio; } set { _useBio = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRuinSpells
        { get { return _useRuinSpells; } set { _useRuinSpells = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBroil
        { get { return _useBroil; } set { _useBroil = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDissipation
        { get { return _useDissipation; } set { _useDissipation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int DissipationHpPct
        { get { return _dissipationHpPct; } set { _dissipationHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEnergyDrain
        { get { return _useEnergyDrain; } set { _useEnergyDrain = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int EnergyDrainHpPct
        { get { return _energyDrainHpPct; } set { _energyDrainHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int EnergyDrainMpPct
        { get { return _energyDrainMpPct; } set { _energyDrainMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(2)]
        public int BaneEnemyCount
        { get { return _baneEnemyCount; } set { _baneEnemyCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool SwiftcastSummon
        { get { return _swiftcastSummon; } set { _swiftcastSummon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseExcogitation
        { get { return _useExcogitation; } set { _useExcogitation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseExcogitationOnTankOnly
        { get { return _useExcogitationOnTankOnly; } set { _useExcogitationOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int ExcogitationHpPct
        { get { return _excogitationHpPct; } set { _excogitationHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseChainStratagem
        { get { return _useChainStratagem; } set { _useChainStratagem = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherpact
        { get { return _useAetherpact; } set { _useAetherpact = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAetherpactOnTankOnly
        { get { return _useAetherpactOnTankOnly; } set { _useAetherpactOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int AetherpactHpPct
        { get { return _aetherpactHpPct; } set { _aetherpactHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int AetherpactMinGuage
        { get { return _aetherpactMinGuage; } set { _aetherpactMinGuage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesse
        { get { return _useLargesse; } set { _useLargesse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesseOnTankOnly
        { get { return _useLargesseOnTankOnly; } set { _useLargesseOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int LargesseHpPct
        { get { return _largesseHpPct; } set { _largesseHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(1)]
        public int LargessePlayerCount
        { get { return _largessePlayerCount; } set { _largessePlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLucidDreaming
        { get { return _useLucidDreaming; } set { _useLucidDreaming = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int LucidDreamingMpPct
        { get { return _lucidDreamingMpPct; } set { _lucidDreamingMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSummon
        { get { return _showSummon; } set { _showSummon = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPotion
        { get { return _showPotion; } set { _showPotion = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoDamage
        { get { return _showDoDamage; } set { _showDoDamage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadowFlare
        { get { return _showShadowFlare; } set { _showShadowFlare = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowChainStratagem
        { get { return _showChainStratagem; } set { _showChainStratagem = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLustrate
        { get { return _showLustrate; } set { _showLustrate = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEmergencyTactics
        { get { return _showEmergencyTactics; } set { _showEmergencyTactics = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowIndomitability
        { get { return _showIndomitability; } set { _showIndomitability = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowExcogitation
        { get { return _showExcogitation; } set { _showExcogitation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAetherpact
        { get { return _showAetherpact; } set { _showAetherpact = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEyeforanEye
        { get { return _showEyeforanEye; } set { _showEyeforanEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLargesse
        { get { return _showLargesse; } set { _showLargesse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDissipation
        { get { return _showDissipation; } set { _showDissipation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRouse
        { get { return _showRouse; } set { _showRouse = value; OnPropertyChanged(); } }

        private SuritoSummonMode _selectedSuritoSummon;

        [Setting]
        public SuritoSummonMode SelectedSuritoSummon
        { get { return _selectedSuritoSummon; } set { _selectedSuritoSummon = value; OnPropertyChanged(); } }
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