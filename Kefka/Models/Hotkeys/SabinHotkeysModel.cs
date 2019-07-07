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
    public class SabinHotkeysModel : BaseModel
    {
        private static SabinHotkeysModel _instance;
        public static SabinHotkeysModel Instance => _instance ?? (_instance = new SabinHotkeysModel());

        private SabinHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Sabin_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _mantra, _potion, _buffs, _holdoGcDs, _aoe, _mercyStroke, _shoulderTackle,
            _autoInterrupt, _dots, _positionals, _perfectBalance, _opener, _armoftheDestroyer, _tornadoKick, _changeFistMode, _howlingFist, _elixirField, _aoeCDs, _formShift,
            _riddleofEarth;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _mantraModifier, _potionModifier, _buffsModifier,
            _holdoGcDsModifier, _aoeModifier, _mercyStrokeModifier, _shoulderTackleModifier, _autoInterruptModifier, _dotsModifier, _positionalsModifier, _perfectBalanceModifier,
            _openerModifier, _armoftheDestroyerModifier, _tornadoKickModifier, _changeFistModeModifier, _howlingFistModifier, _elixirFieldModifier, _aoeCDsModifier, _formShiftModifier,
            _riddleofEarthModifier;

        public SabinPresetsSettingsModel PresetNames => SabinPresetsSettingsModel.Instance;

        public SabinPresetsViewModel PresetCommands => new SabinPresetsViewModel();

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

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MantraKey
        {
            get => _mantra;
            set { _mantra = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PotionKey
        {
            get => _potion;
            set { _potion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BuffsKey
        {
            get => _buffs;
            set { _buffs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys HoldoGcDsKey
        {
            get => _holdoGcDs;
            set { _holdoGcDs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AoEKey
        {
            get => _aoe;
            set { _aoe = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MantraModifier
        {
            get => _mantraModifier;
            set { _mantraModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PotionModifier
        {
            get => _potionModifier;
            set { _potionModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BuffsModifier
        {
            get => _buffsModifier;
            set { _buffsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HoldoGcDsModifier
        {
            get => _holdoGcDsModifier;
            set { _holdoGcDsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AoEModifier
        {
            get => _aoeModifier;
            set { _aoeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MercyStrokeKey
        {
            get => _mercyStroke;
            set { _mercyStroke = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MercyStrokeModifier
        {
            get => _mercyStrokeModifier;
            set { _mercyStrokeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShoulderTackleKey
        {
            get => _shoulderTackle;
            set { _shoulderTackle = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShoulderTackleModifier
        {
            get => _shoulderTackleModifier;
            set { _shoulderTackleModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AutoInterruptKey
        {
            get => _autoInterrupt;
            set { _autoInterrupt = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AutoInterruptModifier
        {
            get => _autoInterruptModifier;
            set { _autoInterruptModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DotsKey
        {
            get => _dots;
            set { _dots = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DotsModifier
        {
            get => _dotsModifier;
            set { _dotsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TornadoKickKey
        {
            get => _tornadoKick;
            set { _tornadoKick = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TornadoKickModifier
        {
            get => _tornadoKickModifier;
            set { _tornadoKickModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PositionalsKey
        {
            get => _positionals;
            set { _positionals = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PositionalsModifier
        {
            get => _positionalsModifier;
            set { _positionalsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PerfectBalanceKey
        {
            get => _perfectBalance;
            set { _perfectBalance = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PerfectBalanceModifier
        {
            get => _perfectBalanceModifier;
            set { _perfectBalanceModifier = value; OnPropertyChanged(); }
        }

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
        public Keys ArmoftheDestroyerKey
        {
            get => _armoftheDestroyer;
            set { _armoftheDestroyer = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ArmoftheDestroyerModifier
        {
            get => _armoftheDestroyerModifier;
            set { _armoftheDestroyerModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ChangeFistModeKey
        {
            get => _changeFistMode;
            set { _changeFistMode = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ChangeFistModeModifier
        {
            get => _changeFistModeModifier;
            set { _changeFistModeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys HowlingFistKey
        {
            get => _howlingFist;
            set { _howlingFist = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HowlingFistModifier
        {
            get => _howlingFistModifier;
            set { _howlingFistModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ElixirFieldKey
        {
            get => _elixirField;
            set { _elixirField = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ElixirFieldModifier
        {
            get => _elixirFieldModifier;
            set { _elixirFieldModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AoeCDsKey
        {
            get => _aoeCDs;
            set { _aoeCDs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AoeCDsModifier
        {
            get => _aoeCDsModifier;
            set { _aoeCDsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys FormShiftKey
        {
            get => _formShift;
            set { _formShift = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FormShiftModifier
        {
            get => _formShiftModifier;
            set { _formShiftModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RiddleofEarthKey
        {
            get => _riddleofEarth;
            set { _riddleofEarth = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RiddleofEarthModifier
        {
            get => _riddleofEarthModifier;
            set { _riddleofEarthModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Sabin_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SabinLog($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Sabin_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SabinLog($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Sabin_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SabinLog($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Sabin_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SabinLog($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Sabin_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SabinLog($"Loading Preset: {SabinPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Sabin_Mantra", MantraKey, MantraModifier, hk =>
            {
                SabinSettingsModel.Instance.UseMantra = !SabinSettingsModel.Instance.UseMantra;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseMantra ? "Mantra Enabled!" : "Mantra Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseMantra), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseMantra ? "Mantra Enabled!" : "Mantra Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_Potion", PotionKey, PotionModifier, hk =>
            {
                SabinSettingsModel.Instance.UseDpsPotion = !SabinSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                SabinSettingsModel.Instance.UseBuffs = !SabinSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_HoldoGCDs", HoldoGcDsKey, HoldoGcDsModifier, hk =>
            {
                SabinSettingsModel.Instance.UseHoldoGcDs = !SabinSettingsModel.Instance.UseHoldoGcDs;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseHoldoGcDs ? "Hold oGCDs Peak Enabled!" : "Hold oGCDs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseHoldoGcDs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseHoldoGcDs ? "Hold oGCDs Peak Enabled!" : "Hold oGCDs Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_AoE", AoEKey, AoEModifier, hk =>
            {
                SabinSettingsModel.Instance.UseAoE = !SabinSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_MercyStroke", MercyStrokeKey, MercyStrokeModifier, hk =>
            {
                SabinSettingsModel.Instance.UseMercyStroke = !SabinSettingsModel.Instance.UseMercyStroke;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseMercyStroke ? "Mercy Stroke Enabled!" : "Mercy Stroke Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseMercyStroke), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseMercyStroke ? "Mercy Stroke Enabled!" : "Mercy Stroke Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_ShoulderTackle", ShoulderTackleKey, ShoulderTackleModifier, hk =>
            {
                SabinSettingsModel.Instance.UseShoulderTackle = !SabinSettingsModel.Instance.UseShoulderTackle;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseShoulderTackle ? "Shoulder Tackle Enabled!" : "Shoulder Tackle Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseShoulderTackle), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseShoulderTackle ? "Shoulder Tackle Enabled!" : "Shoulder Tackle Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_AutoInterrupt", AutoInterruptKey, AutoInterruptModifier, hk =>
            {
                SabinSettingsModel.Instance.UseManualInterrupt = !SabinSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (SabinSettingsModel.Instance.UseManualInterrupt)
                        if (SabinSettingsModel.Instance.UseInterruptList)
                            SabinSettingsModel.Instance.UseInterruptList = false;

                    Logger.SabinLog(SabinSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_Dots", DotsKey, DotsModifier, hk =>
            {
                SabinSettingsModel.Instance.UseDoTs = !SabinSettingsModel.Instance.UseDoTs;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseDoTs ? "Dots Enabled!" : "Dots Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseDoTs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseDoTs ? "Dots Enabled!" : "Dots Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_Positionals", PositionalsKey, PositionalsModifier, hk =>
            {
                SabinSettingsModel.Instance.UseHoldPositionals = !SabinSettingsModel.Instance.UseHoldPositionals;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseHoldPositionals ? "Positionals Enabled!" : "Positionals Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseHoldPositionals), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseHoldPositionals ? "Positionals Enabled!" : "Positionals Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_PerfectBalance", PerfectBalanceKey, PerfectBalanceModifier, hk =>
            {
                SabinSettingsModel.Instance.UsePerfectBalance = !SabinSettingsModel.Instance.UsePerfectBalance;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UsePerfectBalance ? "Perfect Balance Enabled!" : "Perfect Balance Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UsePerfectBalance), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UsePerfectBalance ? "Perfect Balance Enabled!" : "Perfect Balance Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_Opener", OpenerKey, OpenerModifier, hk =>
            {
                SabinSettingsModel.Instance.UseOpener = !SabinSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_ArmoftheDestoyer", ArmoftheDestroyerKey, ArmoftheDestroyerModifier, hk =>
            {
                SabinSettingsModel.Instance.UseArmoftheDestroyer = !SabinSettingsModel.Instance.UseArmoftheDestroyer;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseArmoftheDestroyer ? "Destroyer Enabled!" : "Destroyer Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseArmoftheDestroyer), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseArmoftheDestroyer ? "Destroyer Enabled!" : "Destroyer Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_TornadoKick", TornadoKickKey, TornadoKickModifier, hk =>
            {
                SabinSettingsModel.Instance.UseTornadoKick = !SabinSettingsModel.Instance.UseTornadoKick;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseTornadoKick ? "Tornado Kick Enabled!" : "Tornado Kick Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseTornadoKick), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseTornadoKick ? "Tornado Kick Enabled!" : "Tornado Kick Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_ChangeFistMode", ChangeFistModeKey, ChangeFistModeModifier, hk =>
            {
                SabinSettingsModel.Instance.ChangeFistModeCommand.Execute(null);
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.Fist.ToString(), TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.Fist + " selected!");
                }
            });
            HotkeyManager.Register("Sabin_HowlingFist", HowlingFistKey, HowlingFistModifier, hk =>
            {
                SabinSettingsModel.Instance.UseHowlingFist = !SabinSettingsModel.Instance.UseHowlingFist;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseHowlingFist ? "Howling Fist Enabled!" : "Howling Fist Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseHowlingFist), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseHowlingFist ? "Howling Fist Enabled!" : "Howling Fist Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_ElixirField", ElixirFieldKey, ElixirFieldModifier, hk =>
            {
                SabinSettingsModel.Instance.UseElixirField = !SabinSettingsModel.Instance.UseElixirField;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseElixirField ? "Elixir Field Enabled!" : "Elixir Field Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseElixirField), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseElixirField ? "Elixir Field Enabled!" : "Elixir Field Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_AoeCDs", AoeCDsKey, AoeCDsModifier, hk =>
            {
                if (SabinSettingsModel.Instance.UseHowlingFist && SabinSettingsModel.Instance.UseHowlingFist || !SabinSettingsModel.Instance.UseHowlingFist && !SabinSettingsModel.Instance.UseHowlingFist)
                {
                    SabinSettingsModel.Instance.UseHowlingFist = !SabinSettingsModel.Instance.UseHowlingFist;
                    SabinSettingsModel.Instance.UseElixirField = !SabinSettingsModel.Instance.UseElixirField;
                }

                if (SabinSettingsModel.Instance.UseHowlingFist && !SabinSettingsModel.Instance.UseElixirField)
                {
                    SabinSettingsModel.Instance.UseElixirField = true;
                }

                if (!SabinSettingsModel.Instance.UseHowlingFist && SabinSettingsModel.Instance.UseElixirField)
                {
                    SabinSettingsModel.Instance.UseHowlingFist = true;
                }

                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseElixirField && SabinSettingsModel.Instance.UseHowlingFist ? "AoE CDs Enabled!" : "AoE CDs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseElixirField && SabinSettingsModel.Instance.UseHowlingFist), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseElixirField && SabinSettingsModel.Instance.UseHowlingFist ? "AoE CDs Enabled!" : "AoE CDs Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_FormShift", FormShiftKey, FormShiftModifier, hk =>
            {
                SabinSettingsModel.Instance.UseFormShift = !SabinSettingsModel.Instance.UseFormShift;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseFormShift ? "Form Shift Enabled!" : "Form Shift Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseFormShift), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseFormShift ? "Form Shift Enabled!" : "Form Shift Disabled!");
                }
            });
            HotkeyManager.Register("Sabin_RiddleofEarth", RiddleofEarthKey, RiddleofEarthModifier, hk =>
            {
                SabinSettingsModel.Instance.UseRiddleofEarth = !SabinSettingsModel.Instance.UseRiddleofEarth;
                {
                    ToastManager.AddToast(SabinSettingsModel.Instance.UseRiddleofEarth ? "Riddle of Earth Enabled!" : "Riddle of Earth Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(SabinSettingsModel.Instance.UseRiddleofEarth), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SabinLog(SabinSettingsModel.Instance.UseRiddleofEarth ? "Riddle of Earth Enabled!" : "Riddle of Earth Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Sabin_LoadPreset1");
            HotkeyManager.Unregister("Sabin_LoadPreset2");
            HotkeyManager.Unregister("Sabin_LoadPreset3");
            HotkeyManager.Unregister("Sabin_LoadPreset4");
            HotkeyManager.Unregister("Sabin_LoadPreset5");

            HotkeyManager.Unregister("Sabin_Mantra");
            HotkeyManager.Unregister("Sabin_Potion");
            HotkeyManager.Unregister("Sabin_Buffs");
            HotkeyManager.Unregister("Sabin_HoldoGCDs");
            HotkeyManager.Unregister("Sabin_AoE");
            HotkeyManager.Unregister("Sabin_MercyStroke");
            HotkeyManager.Unregister("Sabin_ShoulderTackle");
            HotkeyManager.Unregister("Sabin_AutoInterrupt");
            HotkeyManager.Unregister("Sabin_Dots");
            HotkeyManager.Unregister("Sabin_Positionals");
            HotkeyManager.Unregister("Sabin_Demolish");
            HotkeyManager.Unregister("Sabin_Opener");
            HotkeyManager.Unregister("Sabin_ArmoftheDestroyer");
            HotkeyManager.Unregister("Sabin_UI");
            HotkeyManager.Unregister("Sabin_TornadoKick");
            HotkeyManager.Unregister("Sabin_ChangeFistMode");
            HotkeyManager.Unregister("Sabin_HowlingFist");
            HotkeyManager.Unregister("Sabin_ElixirField");
            HotkeyManager.Unregister("Sabin_AoeCDs");
            HotkeyManager.Unregister("Sabin_FormShift");
            HotkeyManager.Unregister("Sabin_RiddleofEarth");
        }
    }
}