using System.ComponentModel;
using System.Configuration;
using System.IO;

namespace Kefka.Models
{
    public class MikotoSettingsModel : BaseModel
    {
        private static MikotoSettingsModel _instance;
        public static MikotoSettingsModel Instance => _instance ?? (_instance = new MikotoSettingsModel());

        private MikotoSettingsModel() : base(CharacterSettingsDirectory +
                                             "/Kefka/Routine Settings/Mikoto/Mikoto_Settings.json")
        {
        }

        private bool _useShitButton,
            _useCleanse,
            _usePotion,
            _useMedica,
            _regenTanks,
            _useFluidAura,
            _useRegen,
            _keepRegenOnTanks,
            _regenDps,
            _useCure,
            _useBenediction,
            _keepRegenOnDps,
            _keepRegenOnHealers,
            _useMedica2,
            _useAsylum,
            _regenHealers,
            _useTetragrammaton,
            _useSwiftcastRaise,
            _useCure2,
            _autoStopHeal,
            _useCure3,
            _regenCureFloorTanks,
            _regenCureFloorHealers,
            _regenCureFloorDps,
            _assizeToDamage,
            _assizeManaRegen,
            _useAssize,
            _assizeHealOnly,
            _useLucidDreaming,
            _useProtectInCombat,
            _assizeBelow90,
            _useLargesseOnTankOnly,
            _useLargesse,
            _useProtect,
            _usePresenceofMind,
            _usePresenceofMindOnTankOnly,
            _useEyeforanEye,
            _useRepose,
            _doDamage,
            _useStoneSpells,
            _useAero,
            _useAero2,
            _useAero3,
            _useHoly,
            _useRaise,
            _useBenedictionOnTankOnly,
            _useTetragrammatonOnTankOnly,
            _useThinAir,
            _useDivineBenison,
            _usePlenaryIndulgence;

        private bool _showPotion,
            _showDoDamage,
            _showHoly,
            _showDivineBenison,
            _showPlenaryIndulgence,
            _showAsylum,
            _showAssize,
            _showPresenceofMind,
            _showTetragrammaton,
            _showBenediction,
            _showThinAir,
            _showFluidAura,
            _showEyeforanEye,
            _showLargesse;

        private int _cleanseHpPct,
            _cureHpPct,
            _cure2HpPct,
            _benedictionHpPct,
            _medicaHpPct,
            _medica2HpPct,
            _tetragrammatonHpPct,
            _asylumHpPct,
            _cure3HpPct,
            _medicaPlayerCount,
            _medica2PlayerCount,
            _asylumPlayerCount,
            _cure3PlayerCount,
            _regenHpPct,
            _regenCureFloorPct,
            _assizeHpPct,
            _assizeHealPlayerCount,
            _assizeManaPct,
            _assizeDpsEnemyCount,
            _lucidDreamingMpPct,
            _largesseHpPct,
            _largessePlayerCount,
            _presenceofMindHpPct,
            _presenceofMindPlayerCount,
            _eyeforanEyeHpPct,
            _damageMinMpPct,
            _aeroRfsh,
            _aero2Rfsh,
            _aero3Rfsh,
            _holyMinTargets,
            _stopHealHpPct,
            _holyMinMpPct,
            _thinAirMpPct,
            _divineBenisonHpPct,
            _plenaryIndulgenceHpPct,
            _plenaryIndulgencePlayerCount;

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
        public bool UseMedica
        {
            get => _useMedica;
            set
            {
                _useMedica = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RegenTanks
        {
            get => _regenTanks;
            set
            {
                _regenTanks = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseFluidAura
        {
            get => _useFluidAura;
            set
            {
                _useFluidAura = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRegen
        {
            get => _useRegen;
            set
            {
                _useRegen = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool KeepRegenOnTanks
        {
            get => _keepRegenOnTanks;
            set
            {
                _keepRegenOnTanks = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RegenDps
        {
            get => _regenDps;
            set
            {
                _regenDps = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseBenediction
        {
            get => _useBenediction;
            set
            {
                _useBenediction = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int CureHpPct
        {
            get => _cureHpPct;
            set
            {
                _cureHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int Cure2HpPct
        {
            get => _cure2HpPct;
            set
            {
                _cure2HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int BenedictionHpPct
        {
            get => _benedictionHpPct;
            set
            {
                _benedictionHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int MedicaHpPct
        {
            get => _medicaHpPct;
            set
            {
                _medicaHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int Medica2HpPct
        {
            get => _medica2HpPct;
            set
            {
                _medica2HpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(30)]
        public int TetragrammatonHpPct
        {
            get => _tetragrammatonHpPct;
            set
            {
                _tetragrammatonHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure
        {
            get => _useCure;
            set
            {
                _useCure = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool KeepRegenOnDps
        {
            get => _keepRegenOnDps;
            set
            {
                _keepRegenOnDps = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool KeepRegenOnHealers
        {
            get => _keepRegenOnHealers;
            set
            {
                _keepRegenOnHealers = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseMedica2
        {
            get => _useMedica2;
            set
            {
                _useMedica2 = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(85)]
        public int AsylumHpPct
        {
            get => _asylumHpPct;
            set
            {
                _asylumHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAsylum
        {
            get => _useAsylum;
            set
            {
                _useAsylum = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseSwiftcastRaise
        {
            get => _useSwiftcastRaise;
            set
            {
                _useSwiftcastRaise = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure3
        {
            get => _useCure3;
            set
            {
                _useCure3 = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RegenCureFloorTanks
        {
            get => _regenCureFloorTanks;
            set
            {
                _regenCureFloorTanks = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool RegenCureFloorHealers
        {
            get => _regenCureFloorHealers;
            set
            {
                _regenCureFloorHealers = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool RegenCureFloorDps
        {
            get => _regenCureFloorDps;
            set
            {
                _regenCureFloorDps = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeToDamage
        {
            get => _assizeToDamage;
            set
            {
                _assizeToDamage = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeManaRegen
        {
            get => _assizeManaRegen;
            set
            {
                _assizeManaRegen = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAssize
        {
            get => _useAssize;
            set
            {
                _useAssize = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(false)]
        public bool AssizeHealOnly
        {
            get => _assizeHealOnly;
            set
            {
                _assizeHealOnly = value;
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
        public bool RegenHealers
        {
            get => _regenHealers;
            set
            {
                _regenHealers = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool AssizeBelow90
        {
            get => _assizeBelow90;
            set
            {
                _assizeBelow90 = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(75)]
        public int Cure3HpPct
        {
            get => _cure3HpPct;
            set
            {
                _cure3HpPct = value;
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
        [DefaultValue(true)]
        public bool UseTetragrammaton
        {
            get => _useTetragrammaton;
            set
            {
                _useTetragrammaton = value;
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
        [DefaultValue(3)]
        public int MedicaPlayerCount
        {
            get => _medicaPlayerCount;
            set
            {
                _medicaPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int Medica2PlayerCount
        {
            get => _medica2PlayerCount;
            set
            {
                _medica2PlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseCure2
        {
            get => _useCure2;
            set
            {
                _useCure2 = value;
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
        public int AsylumPlayerCount
        {
            get => _asylumPlayerCount;
            set
            {
                _asylumPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int Cure3PlayerCount
        {
            get => _cure3PlayerCount;
            set
            {
                _cure3PlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(90)]
        public int RegenHpPct
        {
            get => _regenHpPct;
            set
            {
                _regenHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(65)]
        public int RegenCureFloorPct
        {
            get => _regenCureFloorPct;
            set
            {
                _regenCureFloorPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(80)]
        public int AssizeHpPct
        {
            get => _assizeHpPct;
            set
            {
                _assizeHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int AssizeHealPlayerCount
        {
            get => _assizeHealPlayerCount;
            set
            {
                _assizeHealPlayerCount = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(40)]
        public int AssizeManaPct
        {
            get => _assizeManaPct;
            set
            {
                _assizeManaPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int AssizeDpsEnemyCount
        {
            get => _assizeDpsEnemyCount;
            set
            {
                _assizeDpsEnemyCount = value;
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
        [DefaultValue(true)]
        public bool UseRepose
        {
            get => _useRepose;
            set
            {
                _useRepose = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseThinAir
        {
            get => _useThinAir;
            set
            {
                _useThinAir = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(20)]
        public int ThinAirMpPct
        {
            get => _thinAirMpPct;
            set
            {
                _thinAirMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseDivineBenison
        {
            get => _useDivineBenison;
            set
            {
                _useDivineBenison = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int DivineBenisonHpPct
        {
            get => _divineBenisonHpPct;
            set
            {
                _divineBenisonHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePlenaryIndulgence
        {
            get => _usePlenaryIndulgence;
            set
            {
                _usePlenaryIndulgence = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int PlenaryIndulgenceHpPct
        {
            get => _plenaryIndulgenceHpPct;
            set
            {
                _plenaryIndulgenceHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public int PlenaryIndulgencePlayerCount
        {
            get => _plenaryIndulgencePlayerCount;
            set
            {
                _plenaryIndulgencePlayerCount = value;
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
        public bool UsePresenceofMind
        {
            get => _usePresenceofMind;
            set
            {
                _usePresenceofMind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UsePresenceofMindOnTankOnly
        {
            get => _usePresenceofMindOnTankOnly;
            set
            {
                _usePresenceofMindOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(70)]
        public int PresenceofMindHpPct
        {
            get => _presenceofMindHpPct;
            set
            {
                _presenceofMindHpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(1)]
        public int PresenceofMindPlayerCount
        {
            get => _presenceofMindPlayerCount;
            set
            {
                _presenceofMindPlayerCount = value;
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
        public int AeroRfsh
        {
            get => _aeroRfsh;
            set
            {
                _aeroRfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
        public int Aero2Rfsh
        {
            get => _aero2Rfsh;
            set
            {
                _aero2Rfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(5000)]
        public int Aero3Rfsh
        {
            get => _aero3Rfsh;
            set
            {
                _aero3Rfsh = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(3)]
        public int HolyMinTargets
        {
            get => _holyMinTargets;
            set
            {
                _holyMinTargets = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(60)]
        public int HolyMinMpPct
        {
            get => _holyMinMpPct;
            set
            {
                _holyMinMpPct = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseRaise
        {
            get => _useRaise;
            set
            {
                _useRaise = value;
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
        public bool UseStoneSpells
        {
            get => _useStoneSpells;
            set
            {
                _useStoneSpells = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseHoly
        {
            get => _useHoly;
            set
            {
                _useHoly = value;
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
        public bool UseBenedictionOnTankOnly
        {
            get => _useBenedictionOnTankOnly;
            set
            {
                _useBenedictionOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseTetragrammatonOnTankOnly
        {
            get => _useTetragrammatonOnTankOnly;
            set
            {
                _useTetragrammatonOnTankOnly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero
        {
            get => _useAero;
            set
            {
                _useAero = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero2
        {
            get => _useAero2;
            set
            {
                _useAero2 = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool UseAero3
        {
            get => _useAero3;
            set
            {
                _useAero3 = value;
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
        public bool ShowHoly
        {
            get => _showHoly;
            set
            {
                _showHoly = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDivineBenison
        {
            get => _showDivineBenison;
            set
            {
                _showDivineBenison = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPlenaryIndulgence
        {
            get => _showPlenaryIndulgence;
            set
            {
                _showPlenaryIndulgence = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAsylum
        {
            get => _showAsylum;
            set
            {
                _showAsylum = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAssize
        {
            get => _showAssize;
            set
            {
                _showAssize = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPresenceofMind
        {
            get => _showPresenceofMind;
            set
            {
                _showPresenceofMind = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTetragrammaton
        {
            get => _showTetragrammaton;
            set
            {
                _showTetragrammaton = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBenediction
        {
            get => _showBenediction;
            set
            {
                _showBenediction = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowThinAir
        {
            get => _showThinAir;
            set
            {
                _showThinAir = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(true)]
        public bool ShowFluidAura
        {
            get => _showFluidAura;
            set
            {
                _showFluidAura = value;
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
    }
}