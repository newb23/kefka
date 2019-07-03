using static Kefka.Utilities.Constants;
using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace Kefka.Models
{
    public class MikotoSettingsModel : BaseModel
    {
        private static MikotoSettingsModel _instance;
        public static MikotoSettingsModel Instance => _instance ?? (_instance = new MikotoSettingsModel());

        private MikotoSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Mikoto/Mikoto_Settings.json")
        {
        }

        private bool _useShitButton, _useCleanse, _usePotion, _useMedica, _regenTanks, _useFluidAura, _useRegen, _keepRegenOnTanks, _regenDps, _useCure, _useBenediction, _keepRegenOnDps, _keepRegenOnHealers, _useMedica2, _useAsylum, _regenHealers, _useTetragrammaton, _useSwiftcastRaise, _useCure2, _autoStopHeal, _useCure3, _regenCureFloorTanks, 
            _regenCureFloorHealers, _regenCureFloorDps, _assizeToDamage, _assizeManaRegen, _useAssize, _assizeHealOnly, _useLucidDreaming, _useProtectInCombat, _assizeBelow90, _useLargesseOnTankOnly, _useLargesse, _useProtect, _usePresenceofMind, _usePresenceofMindOnTankOnly, _useEyeforanEye, _useRepose, _doDamage, _useStoneSpells, _useAero, 
            _useAero2, _useAero3, _useHoly, _useRaise, _useBenedictionOnTankOnly, _useTetragrammatonOnTankOnly, _useThinAir, _useDivineBenison, _usePlenaryIndulgence;

        private bool _showPotion, _showDoDamage, _showHoly, _showDivineBenison, _showPlenaryIndulgence, _showAsylum, _showAssize, _showPresenceofMind, _showTetragrammaton, _showBenediction, _showThinAir, _showFluidAura, _showEyeforanEye, _showLargesse;

        private int _cleanseHpPct, _cureHpPct, _cure2HpPct, _benedictionHpPct, _medicaHpPct, _medica2HpPct, _tetragrammatonHpPct, _asylumHpPct, _cure3HpPct, _medicaPlayerCount, _medica2PlayerCount, _asylumPlayerCount, _cure3PlayerCount, _regenHpPct, _regenCureFloorPct, _assizeHpPct, _assizeHealPlayerCount, _assizeManaPct, _assizeDpsEnemyCount, _lucidDreamingMpPct, 
            _largesseHpPct, _largessePlayerCount, _presenceofMindHpPct, _presenceofMindPlayerCount, _eyeforanEyeHpPct, _damageMinMpPct, _aeroRfsh, _aero2Rfsh, _aero3Rfsh, _holyMinTargets, _stopHealHpPct, _holyMinMpPct, _thinAirMpPct, _divineBenisonHpPct, _plenaryIndulgenceHpPct, _plenaryIndulgencePlayerCount;

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
        public bool UseMedica
        { get { return _useMedica; } set { _useMedica = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool RegenTanks
        { get { return _regenTanks; } set { _regenTanks = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseFluidAura
        { get { return _useFluidAura; } set { _useFluidAura = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRegen
        { get { return _useRegen; } set { _useRegen = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool KeepRegenOnTanks
        { get { return _keepRegenOnTanks; } set { _keepRegenOnTanks = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool RegenDps
        { get { return _regenDps; } set { _regenDps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBenediction
        { get { return _useBenediction; } set { _useBenediction = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int CureHpPct
        { get { return _cureHpPct; } set { _cureHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int Cure2HpPct
        { get { return _cure2HpPct; } set { _cure2HpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int BenedictionHpPct
        { get { return _benedictionHpPct; } set { _benedictionHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int MedicaHpPct
        { get { return _medicaHpPct; } set { _medicaHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int Medica2HpPct
        { get { return _medica2HpPct; } set { _medica2HpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(30)]
        public int TetragrammatonHpPct
        { get { return _tetragrammatonHpPct; } set { _tetragrammatonHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure
        { get { return _useCure; } set { _useCure = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool KeepRegenOnDps
        { get { return _keepRegenOnDps; } set { _keepRegenOnDps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool KeepRegenOnHealers
        { get { return _keepRegenOnHealers; } set { _keepRegenOnHealers = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseMedica2
        { get { return _useMedica2; } set { _useMedica2 = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(85)]
        public int AsylumHpPct
        { get { return _asylumHpPct; } set { _asylumHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAsylum
        { get { return _useAsylum; } set { _useAsylum = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastRaise
        { get { return _useSwiftcastRaise; } set { _useSwiftcastRaise = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure3
        { get { return _useCure3; } set { _useCure3 = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool RegenCureFloorTanks
        { get { return _regenCureFloorTanks; } set { _regenCureFloorTanks = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool RegenCureFloorHealers
        { get { return _regenCureFloorHealers; } set { _regenCureFloorHealers = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool RegenCureFloorDps
        { get { return _regenCureFloorDps; } set { _regenCureFloorDps = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeToDamage
        { get { return _assizeToDamage; } set { _assizeToDamage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeManaRegen
        { get { return _assizeManaRegen; } set { _assizeManaRegen = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAssize
        { get { return _useAssize; } set { _useAssize = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool AssizeHealOnly
        { get { return _assizeHealOnly; } set { _assizeHealOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLucidDreaming
        { get { return _useLucidDreaming; } set { _useLucidDreaming = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseProtectInCombat
        { get { return _useProtectInCombat; } set { _useProtectInCombat = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool RegenHealers
        { get { return _regenHealers; } set { _regenHealers = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeBelow90
        { get { return _assizeBelow90; } set { _assizeBelow90 = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int Cure3HpPct
        { get { return _cure3HpPct; } set { _cure3HpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesseOnTankOnly
        { get { return _useLargesseOnTankOnly; } set { _useLargesseOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTetragrammaton
        { get { return _useTetragrammaton; } set { _useTetragrammaton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLargesse
        { get { return _useLargesse; } set { _useLargesse = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int MedicaPlayerCount
        { get { return _medicaPlayerCount; } set { _medicaPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int Medica2PlayerCount
        { get { return _medica2PlayerCount; } set { _medica2PlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure2
        { get { return _useCure2; } set { _useCure2 = value; OnPropertyChanged(); } }

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
        public int AsylumPlayerCount
        { get { return _asylumPlayerCount; } set { _asylumPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int Cure3PlayerCount
        { get { return _cure3PlayerCount; } set { _cure3PlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int RegenHpPct
        { get { return _regenHpPct; } set { _regenHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(65)]
        public int RegenCureFloorPct
        { get { return _regenCureFloorPct; } set { _regenCureFloorPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int AssizeHpPct
        { get { return _assizeHpPct; } set { _assizeHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int AssizeHealPlayerCount
        { get { return _assizeHealPlayerCount; } set { _assizeHealPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int AssizeManaPct
        { get { return _assizeManaPct; } set { _assizeManaPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int AssizeDpsEnemyCount
        { get { return _assizeDpsEnemyCount; } set { _assizeDpsEnemyCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseEyeforanEye
        { get { return _useEyeforanEye; } set { _useEyeforanEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRepose
        { get { return _useRepose; } set { _useRepose = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseThinAir
        { get { return _useThinAir; } set { _useThinAir = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(20)]
        public int ThinAirMpPct
        { get { return _thinAirMpPct; } set { _thinAirMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDivineBenison
        { get { return _useDivineBenison; } set { _useDivineBenison = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int DivineBenisonHpPct
        { get { return _divineBenisonHpPct; } set { _divineBenisonHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePlenaryIndulgence
        { get { return _usePlenaryIndulgence; } set { _usePlenaryIndulgence = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int PlenaryIndulgenceHpPct
        { get { return _plenaryIndulgenceHpPct; } set { _plenaryIndulgenceHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(1)]
        public int PlenaryIndulgencePlayerCount
        { get { return _plenaryIndulgencePlayerCount; } set { _plenaryIndulgencePlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(75)]
        public int LucidDreamingMpPct
        { get { return _lucidDreamingMpPct; } set { _lucidDreamingMpPct = value; OnPropertyChanged(); } }

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
        public bool UsePresenceofMind
        { get { return _usePresenceofMind; } set { _usePresenceofMind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePresenceofMindOnTankOnly
        { get { return _usePresenceofMindOnTankOnly; } set { _usePresenceofMindOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int PresenceofMindHpPct
        { get { return _presenceofMindHpPct; } set { _presenceofMindHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(1)]
        public int PresenceofMindPlayerCount
        { get { return _presenceofMindPlayerCount; } set { _presenceofMindPlayerCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int EyeforanEyeHpPct
        { get { return _eyeforanEyeHpPct; } set { _eyeforanEyeHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int DamageMinMpPct
        { get { return _damageMinMpPct; } set { _damageMinMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int AeroRfsh
        { get { return _aeroRfsh; } set { _aeroRfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int Aero2Rfsh
        { get { return _aero2Rfsh; } set { _aero2Rfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(5000)]
        public int Aero3Rfsh
        { get { return _aero3Rfsh; } set { _aero3Rfsh = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int HolyMinTargets
        { get { return _holyMinTargets; } set { _holyMinTargets = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int HolyMinMpPct
        { get { return _holyMinMpPct; } set { _holyMinMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRaise
        { get { return _useRaise; } set { _useRaise = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(90)]
        public int StopHealHpPct
        { get { return _stopHealHpPct; } set { _stopHealHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseStoneSpells
        { get { return _useStoneSpells; } set { _useStoneSpells = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseHoly
        { get { return _useHoly; } set { _useHoly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool DoDamage
        { get { return _doDamage; } set { _doDamage = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBenedictionOnTankOnly
        { get { return _useBenedictionOnTankOnly; } set { _useBenedictionOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseTetragrammatonOnTankOnly
        { get { return _useTetragrammatonOnTankOnly; } set { _useTetragrammatonOnTankOnly = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero
        { get { return _useAero; } set { _useAero = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero2
        { get { return _useAero2; } set { _useAero2 = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero3
        { get { return _useAero3; } set { _useAero3 = value; OnPropertyChanged(); } }

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
        public bool ShowHoly
        { get { return _showHoly; } set { _showHoly = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowDivineBenison
        { get { return _showDivineBenison; } set { _showDivineBenison = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowPlenaryIndulgence
        { get { return _showPlenaryIndulgence; } set { _showPlenaryIndulgence = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAsylum
        { get { return _showAsylum; } set { _showAsylum = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAssize
        { get { return _showAssize; } set { _showAssize = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPresenceofMind
        { get { return _showPresenceofMind; } set { _showPresenceofMind = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowTetragrammaton
        { get { return _showTetragrammaton; } set { _showTetragrammaton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBenediction
        { get { return _showBenediction; } set { _showBenediction = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowThinAir
        { get { return _showThinAir; } set { _showThinAir = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowFluidAura
        { get { return _showFluidAura; } set { _showFluidAura = value; OnPropertyChanged(); } }

        //
        [Setting]
        [DefaultValue(true)]
        public bool ShowEyeforanEye
        { get { return _showEyeforanEye; } set { _showEyeforanEye = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLargesse
        { get { return _showLargesse; } set { _showLargesse = value; OnPropertyChanged(); } }
    }
}