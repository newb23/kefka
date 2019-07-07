using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Kefka.Utilities;
using Kefka.ViewModels;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class BeatrixHotkeysModel : BaseModel
    {
        private static BeatrixHotkeysModel _instance;
        public static BeatrixHotkeysModel Instance => _instance ?? (_instance = new BeatrixHotkeysModel());

        private BeatrixHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Beatrix_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _opener, _potion, _tankSwap, _swordOath,
            _mainTank, _flash, _shieldLob, _clemency, _buffs,
            _defensives, _awareness, _sheltron, _divineVeil, _hallowedGround, _sentinel, _bulwark, _rampart, _convalescence, _anticipation, _reprisal,
            _interrupt, _busterDefense;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _openerModifier, _potionModifier, _tankSwapModifier, _swordOathModifier,
            _mainTankModifier, _flashModifier, _shieldLobModifier, _buffsModifier,
            _defensivesModifier, _awarenessModifier, _sheltronModifier, _clemencyModifier, _divineVeilModifier, _hallowedGroundModifier, _sentinelModifier, _bulwarkModifier, _rampartModifier, _convalescenceModifier, _anticipationModifier, _reprisalModifier,
            _interruptModifier, _busterDefenseModifier;

        public BeatrixPresetsSettingsModel PresetNames => BeatrixPresetsSettingsModel.Instance;

        public BeatrixPresetsViewModel PresetCommands => new BeatrixPresetsViewModel();

        #region Presets

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys Preset1Key
        {
            get => _preset1Key;
            set { _preset1Key = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys Preset1Modifier
        {
            get => _preset1Modifier;
            set { _preset1Modifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys Preset2Key
        {
            get => _preset2Key;
            set { _preset2Key = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys Preset2Modifier
        {
            get => _preset2Modifier;
            set { _preset2Modifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys Preset3Key
        {
            get => _preset3Key;
            set { _preset3Key = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys Preset3Modifier
        {
            get => _preset3Modifier;
            set { _preset3Modifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys Preset4Key
        {
            get => _preset4Key;
            set { _preset4Key = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys Preset4Modifier
        {
            get => _preset4Modifier;
            set { _preset4Modifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys Preset5Key
        {
            get => _preset5Key;
            set { _preset5Key = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys Preset5Modifier
        {
            get => _preset5Modifier;
            set { _preset5Modifier = value; OnPropertyChanged(); }
        }

        #endregion Presets

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OpenerKey
        {
            get => _opener;
            set { _opener = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OpenerModifier
        {
            get => _openerModifier;
            set { _openerModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PotionKey
        {
            get => _potion;
            set { _potion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PotionModifier
        {
            get => _potionModifier;
            set { _potionModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TankSwapKey
        {
            get => _tankSwap;
            set { _tankSwap = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TankSwapModifier
        {
            get => _tankSwapModifier;
            set { _tankSwapModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SwordOathKey
        {
            get => _swordOath;
            set { _swordOath = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SwordOathModifier
        {
            get => _swordOathModifier;
            set { _swordOathModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MainTankKey
        {
            get => _mainTank;
            set { _mainTank = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MainTankModifier
        {
            get => _mainTankModifier;
            set { _mainTankModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AwarenessKey
        {
            get => _awareness;
            set { _awareness = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AwarenessModifier
        {
            get => _awarenessModifier;
            set { _awarenessModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys FightorFlightKey
        {
            get => _buffs;
            set { _buffs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FightorFlightModifier
        {
            get => _buffsModifier;
            set { _buffsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RequiescatKey
        {
            get => _buffs;
            set { _buffs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RequiescatModifier
        {
            get => _buffsModifier;
            set { _buffsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys FlashKey
        {
            get => _flash;
            set { _flash = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public ModifierKeys FlashModifier
        {
            get => _flashModifier;
            set { _flashModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DefensivesKey
        {
            get => _defensives;
            set { _defensives = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DefensivesModifier
        {
            get => _defensivesModifier;
            set { _defensivesModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys InterruptKey
        {
            get => _interrupt;
            set { _interrupt = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys InterruptModifier
        {
            get => _interruptModifier;
            set { _interruptModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ConvalescenceKey
        {
            get => _convalescence;
            set { _convalescence = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public ModifierKeys ConvalescenceModifier
        {
            get => _convalescenceModifier;
            set { _convalescenceModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SentinelKey
        {
            get => _sentinel;
            set { _sentinel = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SentinelModifier
        {
            get => _sentinelModifier;
            set { _sentinelModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BusterDefenseKey
        {
            get => _busterDefense;
            set { _busterDefense = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BusterDefenseModifier
        {
            get => _busterDefenseModifier;
            set { _busterDefenseModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BulwarkKey
        {
            get => _bulwark;
            set { _bulwark = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BulwarkModifier
        {
            get => _bulwarkModifier;
            set { _bulwarkModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RampartKey
        {
            get => _rampart;
            set { _rampart = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RampartModifier
        {
            get => _rampartModifier;
            set { _rampartModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ClemencyKey
        {
            get => _clemency;
            set { _clemency = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ClemencyModifier
        {
            get => _clemencyModifier;
            set { _clemencyModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DivineVeilKey
        {
            get => _divineVeil;
            set { _divineVeil = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DivineVeilModifier
        {
            get => _divineVeilModifier;
            set { _divineVeilModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SheltronKey
        {
            get => _sheltron;
            set { _sheltron = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SheltronModifier
        {
            get => _sheltronModifier;
            set { _sheltronModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys HallowedGroundKey
        {
            get => _hallowedGround;
            set { _hallowedGround = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HallowedGroundModifier
        {
            get => _hallowedGroundModifier;
            set { _hallowedGroundModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AnticipationKey
        {
            get => _anticipation;
            set { _anticipation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AnticipationModifier
        {
            get => _anticipationModifier;
            set { _anticipationModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ReprisalKey
        {
            get => _reprisal;
            set { _reprisal = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ReprisalModifier
        {
            get => _reprisalModifier;
            set { _reprisalModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShieldLobKey
        {
            get => _shieldLob;
            set { _shieldLob = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShieldLobModifier
        {
            get => _shieldLobModifier;
            set { _shieldLobModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            #region Presets

            HotkeyManager.Register("Beatrix_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BeatrixLog($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Beatrix_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BeatrixLog($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Beatrix_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BeatrixLog($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Beatrix_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BeatrixLog($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Beatrix_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BeatrixLog($"Loading Preset: {BeatrixPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            #endregion Presets

            HotkeyManager.Register("Beatrix_Awareness", AwarenessKey, AwarenessModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseAwareness = !BeatrixSettingsModel.Instance.UseAwareness;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseAwareness), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Potion", PotionKey, PotionModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseDpsPotion = !BeatrixSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_FightorFlight", FightorFlightKey, FightorFlightModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseFightorFlight = !BeatrixSettingsModel.Instance.UseFightorFlight;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseFightorFlight ? "Fight or Flight Enabled!" : "Fight or Flight Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseFightorFlight), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseFightorFlight ? "Fight or Flight Enabled!" : "Fight or Flight Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Requiescat", RequiescatKey, RequiescatModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseRequiescat = !BeatrixSettingsModel.Instance.UseRequiescat;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseRequiescat ? "Requiescat Enabled!" : "Requiescat Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseRequiescat), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseRequiescat ? "Requiescat Enabled!" : "Requiescat Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Flash", FlashKey, FlashModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseFlash = !BeatrixSettingsModel.Instance.UseFlash;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseFlash ? "Flash Enabled!" : "Flash Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseFlash), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (BeatrixSettingsModel.Instance.UseFlash)
                        if (BeatrixSettingsModel.Instance.UseTotalEclipse)
                            BeatrixSettingsModel.Instance.UseTotalEclipse = false;

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseFlash ? "Flash Enabled!" : "Flash Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Defensives", DefensivesKey, DefensivesModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseDefensives = !BeatrixSettingsModel.Instance.UseDefensives;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseDefensives), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Anticipation", AnticipationKey, AnticipationModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseAnticipation = !BeatrixSettingsModel.Instance.UseAnticipation;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseAnticipation), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_AutoInterrupt", InterruptKey, InterruptModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseManualInterrupt = !BeatrixSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (BeatrixSettingsModel.Instance.UseManualInterrupt)
                        if (BeatrixSettingsModel.Instance.UseInterruptList)
                            BeatrixSettingsModel.Instance.UseInterruptList = false;

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Convalescence", ConvalescenceKey, ConvalescenceModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseConvalescence = !BeatrixSettingsModel.Instance.UseConvalescence;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseConvalescence), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Sentinel", SentinelKey, SentinelModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseSentinel = !BeatrixSettingsModel.Instance.UseSentinel;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseSentinel ? "Sentinel Enabled!" : "Sentinel Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseSentinel), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseSentinel ? "Sentinel Enabled!" : "Sentinel Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Bulwark", BulwarkKey, BulwarkModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseBulwark = !BeatrixSettingsModel.Instance.UseBulwark;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseBulwark ? "Bulwark Enabled!" : "Bulwark Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseBulwark), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseBulwark ? "Bulwark Enabled!" : "Bulwark Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Rampart", RampartKey, RampartModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseRampart = !BeatrixSettingsModel.Instance.UseRampart;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseRampart), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Opener", OpenerKey, OpenerModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseOpener = !BeatrixSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Clemency", ClemencyKey, ClemencyModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseManualClemency = !BeatrixSettingsModel.Instance.UseManualClemency;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseManualClemency ? "Clemency Enabled!" : "Clemency Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseManualClemency), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (BeatrixSettingsModel.Instance.UseManualClemency)
                        if (BeatrixSettingsModel.Instance.UseClemencyTarget)
                            BeatrixSettingsModel.Instance.UseClemencyTarget = false;

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseManualClemency ? "Clemency Enabled!" : "Clemency Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_DivineVeil", DivineVeilKey, DivineVeilModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseDivineVeil = !BeatrixSettingsModel.Instance.UseDivineVeil;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseDivineVeil ? "DivineVeil Enabled!" : "DivineVeil Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseDivineVeil), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseDivineVeil ? "DivineVeil Enabled!" : "DivineVeil Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Sheltron", SheltronKey, SheltronModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseSheltron = !BeatrixSettingsModel.Instance.UseSheltron;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseSheltron ? "Sheltron Enabled!" : "Sheltron Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseSheltron), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseSheltron ? "Sheltron Enabled!" : "Sheltron Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_HallowedGround", HallowedGroundKey, HallowedGroundModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseHallowedGround = !BeatrixSettingsModel.Instance.UseHallowedGround;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseHallowedGround ? "HallowedGround Enabled!" : "HallowedGround Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseHallowedGround), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseHallowedGround ? "HallowedGround Enabled!" : "HallowedGround Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_BusterDefense", BusterDefenseKey, BusterDefenseModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseBusterDefense = !BeatrixSettingsModel.Instance.UseBusterDefense;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseBusterDefense), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_ShieldLob", ShieldLobKey, ShieldLobModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseShieldLob = !BeatrixSettingsModel.Instance.UseShieldLob;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseShieldLob ? "Shield Lob Enabled!" : "Shield Lob Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseShieldLob), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseShieldLob ? "Shield Lob Enabled!" : "Shield Lob Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_SwordOath", SwordOathKey, SwordOathModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseSwordOath = !BeatrixSettingsModel.Instance.UseSwordOath;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseSwordOath ? "Sword Oath Enabled!" : "Shield Oath Enabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseSwordOath), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseSwordOath ? "Sword Oath Enabled!" : "Shield Oath Enabled!");
                }
            });

            HotkeyManager.Register("Beatrix_TankSwap", TankSwapKey, TankSwapModifier, hk =>
            {
                BeatrixSettingsModel.Instance.Swap = !BeatrixSettingsModel.Instance.Swap;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.Swap ? "Swap Enabled!" : "Swap Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.Swap), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.Swap ? "Swap Enabled!" : "Swap Disabled!");
                }
            });

            HotkeyManager.Register("Beatrix_MainTank", MainTankKey, MainTankModifier, hk =>
            {
                BeatrixSettingsModel.Instance.MainTank = !BeatrixSettingsModel.Instance.MainTank;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.MainTank ? "Main Tank Enabled!" : "Off Tank Enabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.MainTank), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.MainTank ? "Main Tank Enabled!" : "Off Tank Enabled!");
                }
            });

            HotkeyManager.Register("Beatrix_Reprisal", ReprisalKey, ReprisalModifier, hk =>
            {
                BeatrixSettingsModel.Instance.UseReprisal = !BeatrixSettingsModel.Instance.UseReprisal;
                {
                    ToastManager.AddToast(BeatrixSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BeatrixSettingsModel.Instance.UseReprisal), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.BeatrixLog(BeatrixSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Beatrix_LoadPreset1");
            HotkeyManager.Unregister("Beatrix_LoadPreset2");
            HotkeyManager.Unregister("Beatrix_LoadPreset3");
            HotkeyManager.Unregister("Beatrix_LoadPreset4");
            HotkeyManager.Unregister("Beatrix_LoadPreset5");

            HotkeyManager.Unregister("Beatrix_UI");
            HotkeyManager.Unregister("Beatrix_Opener");
            HotkeyManager.Unregister("Beatrix_Potion");
            HotkeyManager.Unregister("Beatrix_SwordOath");
            HotkeyManager.Unregister("Beatrix_TankSwap");
            HotkeyManager.Unregister("Beatrix_MainTank");
            HotkeyManager.Unregister("Beatrix_DamageOverride");
            HotkeyManager.Unregister("Beatrix_ShieldLob");
            HotkeyManager.Unregister("Beatrix_FightorFlight");
            HotkeyManager.Unregister("Beatrix_Requiescat");
            HotkeyManager.Unregister("Beatrix_Flash");
            HotkeyManager.Unregister("Beatrix_MercyStroke");
            HotkeyManager.Unregister("Beatrix_Defensives");
            HotkeyManager.Unregister("Beatrix_BusterDefense");
            HotkeyManager.Unregister("Beatrix_Clemency");
            HotkeyManager.Unregister("Beatrix_DivineVeil");
            HotkeyManager.Unregister("Beatrix_Sheltron");
            HotkeyManager.Unregister("Beatrix_HallowedGround");
            HotkeyManager.Unregister("Beatrix_Sentinel");
            HotkeyManager.Unregister("Beatrix_Bulwark");
            HotkeyManager.Unregister("Beatrix_Rampart");
            HotkeyManager.Unregister("Beatrix_Anticipation");
            HotkeyManager.Unregister("Beatrix_Convalescence");
            HotkeyManager.Unregister("Beatrix_Awareness");
            HotkeyManager.Unregister("Beatrix_AutoInterrupt");
            HotkeyManager.Unregister("Beatrix_Reprisal");
        }
    }
}