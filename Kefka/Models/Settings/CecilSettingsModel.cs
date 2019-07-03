using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows.Input;
using ff14bot;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Commands;

namespace Kefka.Models
{
    public class CecilSettingsModel : BaseModel
    {
        private static CecilSettingsModel _instance;
        public static CecilSettingsModel Instance => _instance ?? (_instance = new CecilSettingsModel());

        private CecilSettingsModel() : base(@"Settings/" + Me.Name + "/Kefka/Routine Settings/Cecil/Cecil_Settings.json")
        {
        }

        private bool _swap, _mainTank, _damageOverride, _useAwareness, _useBuffs, _useDamageRotation, _useUnleash, _useAbyssalDrain, _singleTargetSaltedEarth, _useAoESpam, _useDpsPotion, _useRampart, _useReprisal, _useDefensives, _useInterruptList, _useConvalescence, _useDarkMind, _useShadowWall, _usePlunge, _useDarkArts, _useLivingDead, _useBusterDefense, _useGrit, _useShitButton, _useOpener, _useProvoke, 
            _useSaltedEarth, _useSoleSurvivor, _useUnmend, _useManualInterrupt, _useBlackestNight, _useDASouleater, _useDASyphonStrike, _useDABloodspiller, _useDACarveandSpit, _useCarveandSpitMpRegen, _useDAQuietus, _useDAAbyssalDrain, _useDarkPassenger;

        private bool _showAoESpam, _showSwap, _showAwareness, _showBuffs, _showDamageRotation, _showUnleash, _showDpsPotion, _showDefensives, _showInterruptList, _showConvalescence, _showDarkMind, _showShadowWall, _showPlunge, _showDarkArts, _showLivingDead, _showBusterDefense, _showGrit, _showShitButton, _showOpener, 
            _showProvoke, _showSaltedEarth, _showSoleSurvivor, _showUnmend, _showManualInterrupt, _showRampart, _showAnticipation, _showReprisal, _showTheBlackestNight;

        private int _unleashCount, _powerSlashCount, _aoESpamCount, _bloodWeaponMpPct, _livingDeadHpPct, _convalescenceHpPct, _awarenessHpPct, _darkMindHpPct, _shadowWallHpPct, _anticipationHpPct, _rampartHpPct, _aoEMinEnemies, _abyssalDrainHpPct, _blackestNightHpPct, _darkArtsStartMpPct, _darkArtsStopMpPct, _dASyphonStrikeMpPct, _reprisalHpPct;

        public ICommand UncheckUseInterruptListCommand => new DelegateCommand(UncheckUseInterruptList);
        public ICommand UncheckUseManualInterruptCommand => new DelegateCommand(UncheckUseManualInterrupt);

        public void UncheckUseInterruptList()
        {
            if (UseManualInterrupt)
            {
                UseInterruptList = false;
            }
        }

        public void UncheckUseManualInterrupt()
        {
            if (_useInterruptList)
            {
                UseManualInterrupt = false;
            }
        }

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
        [DefaultValue(true)]
        public bool UseGrit
        { get { return _useGrit; } set { _useGrit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool MainTank
        { get { return _mainTank; } set { _mainTank = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int PowerSlashCount
        { get { return _powerSlashCount; } set { _powerSlashCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseUnmend
        { get { return _useUnmend; } set { _useUnmend = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UsePlunge
        { get { return _usePlunge; } set { _usePlunge = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseUnleash
        { get { return _useUnleash; } set { _useUnleash = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(3)]
        public int AoEMinEnemies
        { get { return _aoEMinEnemies; } set { _aoEMinEnemies = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(500)]
        public int UnleashCount
        { get { return _unleashCount; } set { _unleashCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAbyssalDrain
        { get { return _useAbyssalDrain; } set { _useAbyssalDrain = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int AbyssalDrainHpPct
        { get { return _abyssalDrainHpPct; } set { _abyssalDrainHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool AoESpam
        { get { return _useAoESpam; } set { _useAoESpam = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(6)]
        public int AoESpamCount
        { get { return _aoESpamCount; } set { _aoESpamCount = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSaltedEarth
        { get { return _useSaltedEarth; } set { _useSaltedEarth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool SingleTargetSaltedEarth
        { get { return _singleTargetSaltedEarth; } set { _singleTargetSaltedEarth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBuffs
        { get { return _useBuffs; } set { _useBuffs = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int BloodWeaponMpPct
        { get { return _bloodWeaponMpPct; } set { _bloodWeaponMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseSoleSurvivor
        { get { return _useSoleSurvivor; } set { _useSoleSurvivor = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseProvoke
        { get { return _useProvoke; } set { _useProvoke = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseDarkPassenger
        { get { return _useDarkPassenger; } set { _useDarkPassenger = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDarkArts
        { get { return _useDarkArts; } set { _useDarkArts = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int DarkArtsStartMpPct
        { get { return _darkArtsStartMpPct; } set { _darkArtsStartMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(25)]
        public int DarkArtsStopMpPct
        { get { return _darkArtsStopMpPct; } set { _darkArtsStopMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDASouleater
        { get { return _useDASouleater; } set { _useDASouleater = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDASyphonStrike
        { get { return _useDASyphonStrike; } set { _useDASyphonStrike = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int DASyphonStrikeMpPct
        { get { return _dASyphonStrikeMpPct; } set { _dASyphonStrikeMpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDABloodspiller
        { get { return _useDABloodspiller; } set { _useDABloodspiller = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDACarveandSpit
        { get { return _useDACarveandSpit; } set { _useDACarveandSpit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseCarveandSpitMpRegen
        { get { return _useCarveandSpitMpRegen; } set { _useCarveandSpitMpRegen = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDAQuietus
        { get { return _useDAQuietus; } set { _useDAQuietus = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseDAAbyssalDrain
        { get { return _useDAAbyssalDrain; } set { _useDAAbyssalDrain = value; OnPropertyChanged(); } }

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
        public bool UseDarkMind
        { get { return _useDarkMind; } set { _useDarkMind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(70)]
        public int DarkMindHpPct
        { get { return _darkMindHpPct; } set { _darkMindHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseShadowWall
        { get { return _useShadowWall; } set { _useShadowWall = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(40)]
        public int ShadowWallHpPct
        { get { return _shadowWallHpPct; } set { _shadowWallHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseLivingDead
        { get { return _useLivingDead; } set { _useLivingDead = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(10)]
        public int LivingDeadHpPct
        { get { return _livingDeadHpPct; } set { _livingDeadHpPct = value; OnPropertyChanged(); } }

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
        [DefaultValue(75)]
        public int ConvalescenceHpPct
        { get { return _convalescenceHpPct; } set { _convalescenceHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseBlackestNight
        { get { return _useBlackestNight; } set { _useBlackestNight = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int BlackestNightHpPct
        { get { return _blackestNightHpPct; } set { _blackestNightHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseAnticipation
        { get { return _useAwareness; } set { _useAwareness = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int AnticipationHpPct
        { get { return _anticipationHpPct; } set { _anticipationHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseRampart
        { get { return _useRampart; } set { _useRampart = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(60)]
        public int RampartHpPct
        { get { return _rampartHpPct; } set { _rampartHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool UseReprisal
        { get { return _useReprisal; } set { _useReprisal = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(80)]
        public int ReprisalHpPct
        { get { return _reprisalHpPct; } set { _reprisalHpPct = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseManualInterrupt
        { get { return _useManualInterrupt; } set { _useManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(false)]
        public bool UseInterruptList
        { get { return _useInterruptList; } set { _useInterruptList = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAoESpam
        { get { return _showAoESpam; } set { _showAoESpam = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSwap
        { get { return _showSwap; } set { _showSwap = value; OnPropertyChanged(); } }

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
        public bool ShowDamageRotation
        { get { return _showDamageRotation; } set { _showDamageRotation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowUnleash
        { get { return _showUnleash; } set { _showUnleash = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDpsPotion
        { get { return _showDpsPotion; } set { _showDpsPotion = value; OnPropertyChanged(); } }

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
        public bool ShowSaltedEarth
        { get { return _showSaltedEarth; } set { _showSaltedEarth = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowConvalescence
        { get { return _showConvalescence; } set { _showConvalescence = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowPlunge
        { get { return _showPlunge; } set { _showPlunge = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDarkMind
        { get { return _showDarkMind; } set { _showDarkMind = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowBusterDefense
        { get { return _showBusterDefense; } set { _showBusterDefense = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowDarkArts
        { get { return _showDarkArts; } set { _showDarkArts = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowLivingDead
        { get { return _showLivingDead; } set { _showLivingDead = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShadowWall
        { get { return _showShadowWall; } set { _showShadowWall = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowGrit
        { get { return _showGrit; } set { _showGrit = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowShitButton
        { get { return _showShitButton; } set { _showShitButton = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowOpener
        { get { return _showOpener; } set { _showOpener = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowProvoke
        { get { return _showProvoke; } set { _showProvoke = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowSoleSurvivor
        { get { return _showSoleSurvivor; } set { _showSoleSurvivor = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowUnmend
        { get { return _showUnmend; } set { _showUnmend = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowManualInterrupt
        { get { return _showManualInterrupt; } set { _showManualInterrupt = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowRampart
        { get { return _showRampart; } set { _showRampart = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowAnticipation
        { get { return _showAnticipation; } set { _showAnticipation = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowReprisal
        { get { return _showReprisal; } set { _showReprisal = value; OnPropertyChanged(); } }

        [Setting]
        [DefaultValue(true)]
        public bool ShowTheBlackestNight
        { get { return _showTheBlackestNight; } set { _showTheBlackestNight = value; OnPropertyChanged(); } }
    }
}