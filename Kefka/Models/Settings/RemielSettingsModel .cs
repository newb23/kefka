using static Kefka.Utilities.Constants;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using Kefka.Properties;
using Kefka.Utilities;

namespace Kefka.Models
{
    public class RemielSettingsModel : BaseModel
    {
        private static RemielSettingsModel _instance;
        public static RemielSettingsModel Instance => _instance ?? (_instance = new RemielSettingsModel());

        private RemielSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Remiel/Remiel_Settings.json")
        {
        }

        private bool _useShitButton, _manualCardTarget, _useCleanse, _usePotion, _useHelios, _nocturnalAspectedBeneficTanks, _useCards, _royalRoadEnhanced, _royalRoadExtended, _royalRoadExpanded, _useAspectedBeneficWithNocturnal, _keepNocturnalAspectedBeneficOnTanks, _nocturnalAspectedBeneficDps, _useBenefic, _useEssentialDignity, 
            _keepNocturnalAspectedBeneficOnDps, _keepNocturnalAspectedBeneficOnHealers, _useCollectiveUnconscious, _useGravity, _nocturnalAspectedBeneficHealers, _stopHeliosIfConditionsUnmet, _useSwiftcastAscend, _useSwiftcastRaise, _useBenefic2, _autoStopHeal, _useAscendWithLightspeed, _useNocturnalAspectedHelios, _useCelestialOpposition, 
            _useLucidDreaming, _useMalefic, _useCardPrepOutOfCombat, _useProtectInCombat, _useLightspeed, _useProtect, _useLightspeedOnTankOnly, _useSynastry, _useSynastryOnTankOnly, _useCardPrepOutOfCombatOnlyInParty, _doDamage, _useAscend, _useEssentialDignityOnTankOnly, 
            _useAspectedBeneficWithDiurnal, _diurnalAspectedBeneficTanks, _diurnalAspectedBeneficHealers, _diurnalAspectedBeneficDps, _keepDiurnalAspectedBeneficOnTanks, _keepDiurnalAspectedBeneficOnHealers, _keepDiurnalAspectedBeneficOnDps, _useDiurnalAspectedHelios, _useCombust,
            _useCelestialOppositionAfterCollectiveUnconsciousness, _useCelestialOppositionAfterExpandedCard, _useCelestialOppositionAfterSpearExpanded, _useCelestialOppositionAfterBoleExpanded, _useCelestialOppositionAfterBalanceExpanded, _useCelestialOppositionAfterArrowExpanded, _useCelestialOppositionAfterSpireExpanded, 
            _useCelestialOppositionAfterEwerExpanded, _useTimeDilation, _useTimeDilationAfterBole, _useTimeDilationAfterBalance, _useTimeDilationAfterArrow, _useTimeDilationAfterSpear, _useTimeDilationAfterSpire, _useTimeDilationAfterEwer, _useTimeDilationAfterSynastry, _useTimeDilationAfterTankDiurnalBenefic, _aspectedBeneficFloorTanks, 
            _aspectedBeneficFloorHealers, _aspectedBeneficFloorDps, _useEarthlyStar, _useEarthlyStarForDamage, _useEyeforanEye, _useLargesse, _useLargesseOnTankOnly, _onlyDraw, _useRedraw, _useSpread, _ewerHealer, _boleTank, _useUndraw, _useSleeveDraw, _spreadBalance, _spreadBole, _spreadArrow, _spreadSpear, _spreadEwer, _spreadSpire, _useHeldAndRoyalRoad, _royalRoadBalance, _royalRoadBole, _royalRoadArrow, _royalRoadSpear, _royalRoadEwer, 
            _royalRoadSpire, _castTrashCards, _useCelestialOppositionAfterLucidDreaming, _redrawBalance, _redrawBole, _redrawArrow, _redrawSpear, _redrawEwer, _redrawSpire, _enhancedBalance, _extendedBalance, _expandedBalance, _enhancedBole, _extendedBole, _expandedBole, _enhancedArrow, _extendedArrow, _expandedArrow, _enhancedSpear, _extendedSpear, 
            _expandedSpear, _enhancedEwer, _extendedEwer, _expandedEwer, _enhancedSpire, _extendedSpire, _expandedSpire;

        private bool _showPotion, _showDoDamage, _showGravity, _showEssentialDignity, _showLightspeed, _showSynastry, _showEyeforanEye, _showLargesse, _showCard, _showOnlyDraw, _showSleeveDraw, _showRoyalRoad, _showSpread;

        private int _cleanseHpPct, _beneficHpPct, _benefic2HpPct, _essentialDignityHpPct, _heliosHpPct, _collectiveUnconsciousHpPct, _cardDrawTimeMin, _nocturnalAspectedHeliosHpPct, _nocturnalAspectedHeliosPlayerCount, _collectiveUnconsciousPlayerCount, _lucidDreamingMpPct, _lightspeedHpPct, _lightspeedPlayerCount, _synastryHpPct,
            _damageMinMpPct, _combustRfsh, _combust2Rfsh, _gravityMinTargets, _stopHealHpPct, _diurnalAspectedBeneficHpPct, _nocturnalAspectedBeneficHpPct, _diurnalAspectedHeliosHpPct, _diurnalAspectedHeliosPlayerCount, _aspectedBeneficFloorPct, _ewerMpPct, _spireTpPct, _boleHpPct, _heliosPlayerCount, _expandedPlayerCount, _celestialOppositionPlayerCount, 
            _gravityMinMpPct, _earthlyStarPlayerCount, _earthlyStarHpPct, _ladyofCrownsHpPct, _eyeforanEyeHpPct, _largesseHpPct, _largessePlayerCount;

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
        {
            get => _useShitButton;
            set { _useShitButton = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ManualCardTarget
        {
            get => _manualCardTarget;
            set { _manualCardTarget = value; OnPropertyChanged(); }
        }

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
        {
            get => _usePotion;
            set { _usePotion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMalefic
        {
            get => _useMalefic;
            set { _useMalefic = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHelios
        {
            get => _useHelios;
            set { _useHelios = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool NocturnalAspectedBeneficTanks
        {
            get => _nocturnalAspectedBeneficTanks;
            set { _nocturnalAspectedBeneficTanks = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAspectedBeneficWithNocturnal
        {
            get => _useAspectedBeneficWithNocturnal;
            set { _useAspectedBeneficWithNocturnal = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool KeepNocturnalAspectedBeneficOnTanks
        {
            get => _keepNocturnalAspectedBeneficOnTanks;
            set { _keepNocturnalAspectedBeneficOnTanks = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool NocturnalAspectedBeneficDps
        {
            get => _nocturnalAspectedBeneficDps;
            set { _nocturnalAspectedBeneficDps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEssentialDignity
        {
            get => _useEssentialDignity;
            set { _useEssentialDignity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(80)]
        public int BeneficHpPct
        {
            get => _beneficHpPct;
            set { _beneficHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(40)]
        public int Benefic2HpPct
        {
            get => _benefic2HpPct;
            set { _benefic2HpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(20)]
        public int EssentialDignityHpPct
        {
            get => _essentialDignityHpPct;
            set { _essentialDignityHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int HeliosHpPct
        {
            get => _heliosHpPct;
            set { _heliosHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int CollectiveUnconsciousHpPct
        {
            get => _collectiveUnconsciousHpPct;
            set { _collectiveUnconsciousHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBenefic
        {
            get => _useBenefic;
            set { _useBenefic = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool KeepNocturnalAspectedBeneficOnDps
        {
            get => _keepNocturnalAspectedBeneficOnDps;
            set { _keepNocturnalAspectedBeneficOnDps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool KeepNocturnalAspectedBeneficOnHealers
        {
            get => _keepNocturnalAspectedBeneficOnHealers;
            set { _keepNocturnalAspectedBeneficOnHealers = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCollectiveUnconscious
        {
            get => _useCollectiveUnconscious;
            set { _useCollectiveUnconscious = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseGravity
        {
            get => _useGravity;
            set { _useGravity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastAscend
        {
            get => _useSwiftcastAscend;
            set { _useSwiftcastAscend = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastRaise
        {
            get => _useSwiftcastRaise;
            set { _useSwiftcastRaise = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAscendWithLightspeed
        {
            get => _useAscendWithLightspeed;
            set { _useAscendWithLightspeed = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseNocturnalAspectedHelios
        {
            get => _useNocturnalAspectedHelios;
            set { _useNocturnalAspectedHelios = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOpposition
        {
            get => _useCelestialOpposition;
            set { _useCelestialOpposition = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLucidDreaming
        {
            get => _useLucidDreaming;
            set { _useLucidDreaming = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCardPrepOutOfCombat
        {
            get => _useCardPrepOutOfCombat;
            set { _useCardPrepOutOfCombat = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseProtectInCombat
        {
            get => _useProtectInCombat;
            set { _useProtectInCombat = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool NocturnalAspectedBeneficHealers
        {
            get => _nocturnalAspectedBeneficHealers;
            set { _nocturnalAspectedBeneficHealers = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(75)]
        public int NocturnalAspectedHeliosHpPct
        {
            get => _nocturnalAspectedHeliosHpPct;
            set { _nocturnalAspectedHeliosHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool StopHeliosIfConditionsUnmet
        {
            get => _stopHeliosIfConditionsUnmet;
            set { _stopHeliosIfConditionsUnmet = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int NocturnalAspectedHeliosPlayerCount
        {
            get => _nocturnalAspectedHeliosPlayerCount;
            set { _nocturnalAspectedHeliosPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int CollectiveUnconsciousPlayerCount
        {
            get => _collectiveUnconsciousPlayerCount;
            set { _collectiveUnconsciousPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBenefic2
        {
            get => _useBenefic2;
            set { _useBenefic2 = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseProtect
        {
            get => _useProtect;
            set { _useProtect = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AutoStopHeal
        {
            get => _autoStopHeal;
            set { _autoStopHeal = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(2)]
        public int HeliosPlayerCount
        {
            get => _heliosPlayerCount;
            set { _heliosPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(80)]
        public int LucidDreamingMpPct
        {
            get => _lucidDreamingMpPct;
            set { _lucidDreamingMpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseLightspeed
        {
            get => _useLightspeed;
            set { _useLightspeed = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(2)]
        public int LightspeedPlayerCount
        {
            get => _lightspeedPlayerCount;
            set { _lightspeedPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(50)]
        public int LightspeedHpPct
        {
            get => _lightspeedHpPct;
            set { _lightspeedHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseLightspeedOnTankOnly
        {
            get => _useLightspeedOnTankOnly;
            set { _useLightspeedOnTankOnly = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSynastry
        {
            get => _useSynastry;
            set { _useSynastry = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool UseSynastryOnTankOnly
        {
            get => _useSynastryOnTankOnly;
            set { _useSynastryOnTankOnly = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int DiurnalAspectedHeliosPlayerCount
        {
            get => _diurnalAspectedHeliosPlayerCount;
            set { _diurnalAspectedHeliosPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int SynastryHpPct
        {
            get => _synastryHpPct;
            set { _synastryHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int DamageMinMpPct
        {
            get => _damageMinMpPct;
            set { _damageMinMpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(5000)]
        public int CombustRfsh
        {
            get => _combustRfsh;
            set { _combustRfsh = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(5000)]
        public int Combust2Rfsh
        {
            get => _combust2Rfsh;
            set { _combust2Rfsh = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int GravityMinTargets
        {
            get => _gravityMinTargets;
            set { _gravityMinTargets = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int GravityMinMpPct
        {
            get => _gravityMinMpPct;
            set { _gravityMinMpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAscend
        {
            get => _useAscend;
            set { _useAscend = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(90)]
        public int StopHealHpPct
        {
            get => _stopHealHpPct;
            set { _stopHealHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEssentialDignityOnTankOnly
        {
            get => _useEssentialDignityOnTankOnly;
            set { _useEssentialDignityOnTankOnly = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool DoDamage
        {
            get => _doDamage;
            set { _doDamage = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAspectedBeneficWithDiurnal
        {
            get => _useAspectedBeneficWithDiurnal;
            set { _useAspectedBeneficWithDiurnal = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool DiurnalAspectedBeneficTanks
        {
            get => _diurnalAspectedBeneficTanks;
            set { _diurnalAspectedBeneficTanks = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool DiurnalAspectedBeneficHealers
        {
            get => _diurnalAspectedBeneficHealers;
            set { _diurnalAspectedBeneficHealers = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool DiurnalAspectedBeneficDps
        {
            get => _diurnalAspectedBeneficDps;
            set { _diurnalAspectedBeneficDps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool KeepDiurnalAspectedBeneficOnTanks
        {
            get => _keepDiurnalAspectedBeneficOnTanks;
            set { _keepDiurnalAspectedBeneficOnTanks = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool KeepDiurnalAspectedBeneficOnHealers
        {
            get => _keepDiurnalAspectedBeneficOnHealers;
            set { _keepDiurnalAspectedBeneficOnHealers = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool KeepDiurnalAspectedBeneficOnDps
        {
            get => _keepDiurnalAspectedBeneficOnDps;
            set { _keepDiurnalAspectedBeneficOnDps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDiurnalAspectedHelios
        {
            get => _useDiurnalAspectedHelios;
            set { _useDiurnalAspectedHelios = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int DiurnalAspectedBeneficHpPct
        {
            get => _diurnalAspectedBeneficHpPct;
            set { _diurnalAspectedBeneficHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int NocturnalAspectedBeneficHpPct
        {
            get => _nocturnalAspectedBeneficHpPct;
            set { _nocturnalAspectedBeneficHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(70)]
        public int DiurnalAspectedHeliosHpPct
        {
            get => _diurnalAspectedHeliosHpPct;
            set { _diurnalAspectedHeliosHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCombust
        {
            get => _useCombust;
            set { _useCombust = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterCollectiveUnconsciousness
        {
            get => _useCelestialOppositionAfterCollectiveUnconsciousness;
            set { _useCelestialOppositionAfterCollectiveUnconsciousness = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterExpandedCard
        {
            get => _useCelestialOppositionAfterExpandedCard;
            set { _useCelestialOppositionAfterExpandedCard = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterSpearExpanded
        {
            get => _useCelestialOppositionAfterSpearExpanded;
            set { _useCelestialOppositionAfterSpearExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterBoleExpanded
        {
            get => _useCelestialOppositionAfterBoleExpanded;
            set { _useCelestialOppositionAfterBoleExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterBalanceExpanded
        {
            get => _useCelestialOppositionAfterBalanceExpanded;
            set { _useCelestialOppositionAfterBalanceExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterArrowExpanded
        {
            get => _useCelestialOppositionAfterArrowExpanded;
            set { _useCelestialOppositionAfterArrowExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterSpireExpanded
        {
            get => _useCelestialOppositionAfterSpireExpanded;
            set { _useCelestialOppositionAfterSpireExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterEwerExpanded
        {
            get => _useCelestialOppositionAfterEwerExpanded;
            set { _useCelestialOppositionAfterEwerExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int CelestialOppositionPlayerCount
        {
            get => _celestialOppositionPlayerCount;
            set { _celestialOppositionPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilation
        {
            get => _useTimeDilation;
            set { _useTimeDilation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterBole
        {
            get => _useTimeDilationAfterBole;
            set { _useTimeDilationAfterBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterBalance
        {
            get => _useTimeDilationAfterBalance;
            set { _useTimeDilationAfterBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterArrow
        {
            get => _useTimeDilationAfterArrow;
            set { _useTimeDilationAfterArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterSpear
        {
            get => _useTimeDilationAfterSpear;
            set { _useTimeDilationAfterSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterSpire
        {
            get => _useTimeDilationAfterSpire;
            set { _useTimeDilationAfterSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterEwer
        {
            get => _useTimeDilationAfterEwer;
            set { _useTimeDilationAfterEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterSynastry
        {
            get => _useTimeDilationAfterSynastry;
            set { _useTimeDilationAfterSynastry = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTimeDilationAfterTankDiurnalBenefic
        {
            get => _useTimeDilationAfterTankDiurnalBenefic;
            set { _useTimeDilationAfterTankDiurnalBenefic = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int AspectedBeneficFloorPct
        {
            get => _aspectedBeneficFloorPct;
            set { _aspectedBeneficFloorPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AspectedBeneficFloorTanks
        {
            get => _aspectedBeneficFloorTanks;
            set { _aspectedBeneficFloorTanks = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AspectedBeneficFloorHealers
        {
            get => _aspectedBeneficFloorHealers;
            set { _aspectedBeneficFloorHealers = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AspectedBeneficFloorDps
        {
            get => _aspectedBeneficFloorDps;
            set { _aspectedBeneficFloorDps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseEarthlyStar
        { get { return _useEarthlyStar; } set { _useEarthlyStar = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEarthlyStarForDamage
        { get { return _useEarthlyStarForDamage; } set { _useEarthlyStarForDamage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int EarthlyStarHpPct
        { get { return _earthlyStarHpPct; } set { _earthlyStarHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int EarthlyStarPlayerCount
        { get { return _earthlyStarPlayerCount; } set { _earthlyStarPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(50)]
        public int LadyofCrownsHpPct
        { get { return _ladyofCrownsHpPct; } set { _ladyofCrownsHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEye
        { get { return _useEyeforanEye; } set { _useEyeforanEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int EyeforanEyeHpPct
        { get { return _eyeforanEyeHpPct; } set { _eyeforanEyeHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesse
        { get { return _useLargesse; } set { _useLargesse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
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
        public bool UseCards
        {
            get => _useCards;
            set { _useCards = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool OnlyDraw
        {
            get => _onlyDraw;
            set { _onlyDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(30)]
        public int CardDrawTimeMin
        {
            get => _cardDrawTimeMin;
            set { _cardDrawTimeMin = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSpread
        {
            get => _useSpread;
            set { _useSpread = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRedraw
        {
            get => _useRedraw;
            set { _useRedraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool CastTrashCards
        {
            get => _castTrashCards;
            set { _castTrashCards = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCardPrepOutOfCombatOnlyInParty
        {
            get => _useCardPrepOutOfCombatOnlyInParty;
            set { _useCardPrepOutOfCombatOnlyInParty = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseUndraw
        {
            get => _useUndraw;
            set { _useUndraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSleeveDraw
        {
            get => _useSleeveDraw;
            set { _useSleeveDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int BoleHpPct
        {
            get => _boleHpPct;
            set { _boleHpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int EwerMpPct
        {
            get => _ewerMpPct;
            set { _ewerMpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(60)]
        public int SpireTpPct
        {
            get => _spireTpPct;
            set { _spireTpPct = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool BoleTank
        {
            get => _boleTank;
            set { _boleTank = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EwerHealer
        {
            get => _ewerHealer;
            set { _ewerHealer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawBalance
        {
            get => _redrawBalance;
            set { _redrawBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawBole
        {
            get => _redrawBole;
            set { _redrawBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawArrow
        {
            get => _redrawArrow;
            set { _redrawArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawSpear
        {
            get => _redrawSpear;
            set { _redrawSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawEwer
        {
            get => _redrawEwer;
            set { _redrawEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RedrawSpire
        {
            get => _redrawSpire;
            set { _redrawSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedBalance
        {
            get => _enhancedBalance;
            set { _enhancedBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedBalance
        {
            get => _extendedBalance;
            set { _extendedBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedBalance
        {
            get => _expandedBalance;
            set { _expandedBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedBole
        {
            get => _enhancedBole;
            set { _enhancedBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedBole
        {
            get => _extendedBole;
            set { _extendedBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedBole
        {
            get => _expandedBole;
            set { _expandedBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedArrow
        {
            get => _enhancedArrow;
            set { _enhancedArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedArrow
        {
            get => _extendedArrow;
            set { _extendedArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedArrow
        {
            get => _expandedArrow;
            set { _expandedArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedSpear
        {
            get => _enhancedSpear;
            set { _enhancedSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedSpear
        {
            get => _extendedSpear;
            set { _extendedSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedSpear
        {
            get => _expandedSpear;
            set { _expandedSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedEwer
        {
            get => _enhancedEwer;
            set { _enhancedEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedEwer
        {
            get => _extendedEwer;
            set { _extendedEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedEwer
        {
            get => _expandedEwer;
            set { _expandedEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool EnhancedSpire
        {
            get => _enhancedSpire;
            set { _enhancedSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExtendedSpire
        {
            get => _extendedSpire;
            set { _extendedSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ExpandedSpire
        {
            get => _expandedSpire;
            set { _expandedSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadEnhanced
        {
            get => _royalRoadEnhanced;
            set { _royalRoadEnhanced = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadExtended
        {
            get => _royalRoadExtended;
            set { _royalRoadExtended = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadExpanded
        {
            get => _royalRoadExpanded;
            set { _royalRoadExpanded = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool SpreadBalance
        {
            get => _spreadBalance;
            set { _spreadBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool SpreadBole
        {
            get => _spreadBole;
            set { _spreadBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool SpreadArrow
        {
            get => _spreadArrow;
            set { _spreadArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool SpreadSpear
        {
            get => _spreadSpear;
            set { _spreadSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool SpreadEwer
        {
            get => _spreadEwer;
            set { _spreadEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool SpreadSpire
        {
            get => _spreadSpire;
            set { _spreadSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHeldAndRoyalRoad
        {
            get => _useHeldAndRoyalRoad;
            set { _useHeldAndRoyalRoad = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RoyalRoadBalance
        {
            get => _royalRoadBalance;
            set { _royalRoadBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadBole
        {
            get => _royalRoadBole;
            set { _royalRoadBole = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadArrow
        {
            get => _royalRoadArrow;
            set { _royalRoadArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadSpear
        {
            get => _royalRoadSpear;
            set { _royalRoadSpear = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadEwer
        {
            get => _royalRoadEwer;
            set { _royalRoadEwer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RoyalRoadSpire
        {
            get => _royalRoadSpire;
            set { _royalRoadSpire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(3)]
        public int ExpandedPlayerCount
        {
            get => _expandedPlayerCount;
            set { _expandedPlayerCount = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCelestialOppositionAfterLucidDreaming
        {
            get => _useCelestialOppositionAfterLucidDreaming;
            set { _useCelestialOppositionAfterLucidDreaming = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPotion
        {
            get => _showPotion;
            set { _showPotion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDoDamage
        {
            get => _showDoDamage;
            set { _showDoDamage = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGravity
        {
            get => _showGravity;
            set { _showGravity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEssentialDignity
        {
            get => _showEssentialDignity;
            set { _showEssentialDignity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLightspeed
        {
            get => _showLightspeed;
            set { _showLightspeed = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSynastry
        {
            get => _showSynastry;
            set { _showSynastry = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowEyeforanEye
        {
            get => _showEyeforanEye;
            set { _showEyeforanEye = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLargesse
        {
            get => _showLargesse;
            set { _showLargesse = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowCards
        {
            get => _showCard;
            set { _showCard = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOnlyDraw
        {
            get => _showOnlyDraw;
            set { _showOnlyDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSleeveDraw
        {
            get => _showSleeveDraw;
            set { _showSleeveDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRoyalRoad
        {
            get => _showRoyalRoad;
            set { _showRoyalRoad = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSpread
        {
            get => _showSpread;
            set { _showSpread = value; OnPropertyChanged(); }
        }

        private SoloSectMode _selectedSectMode;

        [Setting]
        public SoloSectMode SelectedSectMode
        {
            get => _selectedSectMode;
            set { _selectedSectMode = value; OnPropertyChanged(); }
        }
    }

    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SoloSectMode
    {
        [LocalizedDescription("None", typeof(Strings))]
        None,

        [LocalizedDescription("Nocturnal", typeof(Strings))]
        Nocturnal,

        [LocalizedDescription("Diurnal", typeof(Strings))]
        Diurnal,
    }
}