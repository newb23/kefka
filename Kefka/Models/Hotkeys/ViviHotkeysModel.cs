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
    public class ViviHotkeysModel : BaseModel
    {
        private static ViviHotkeysModel _instance;
        public static ViviHotkeysModel Instance => _instance ?? (_instance = new ViviHotkeysModel());

        private ViviHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Vivi_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _enochian, _potion, _buffs, _sharpcast, _aoe, _swiftcast, _dots, _opener, _leyLines, _convert, _defensives, _virus;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _enochianModifier, _potionModifier, _buffsModifier, _sharpcastModifier, _aoeModifier, _swiftcastModifier, _dotsModifier, _openerModifier, _leyLinesModifier, _convertModifier, _defensivesModifier, _virusModifier;

        public ViviPresetsSettingsModel PresetNames => ViviPresetsSettingsModel.Instance;

        public ViviPresetsViewModel PresetCommands => new ViviPresetsViewModel();

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
        public Keys EnochianKey
        {
            get => _enochian;
            set { _enochian = value; OnPropertyChanged(); }
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
        public Keys SharpcastKey
        {
            get => _sharpcast;
            set { _sharpcast = value; OnPropertyChanged(); }
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
        public ModifierKeys EnochianModifier
        {
            get => _enochianModifier;
            set { _enochianModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys SharpcastModifier
        {
            get => _sharpcastModifier;
            set { _sharpcastModifier = value; OnPropertyChanged(); }
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
        public Keys SwiftcastKey
        {
            get => _swiftcast;
            set { _swiftcast = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SwiftcastModifier
        {
            get => _swiftcastModifier;
            set { _swiftcastModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys LeyLinesKey
        {
            get => _leyLines;
            set { _leyLines = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys LeyLinesModifier
        {
            get => _leyLinesModifier;
            set { _leyLinesModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ConvertKey
        {
            get => _convert;
            set { _convert = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ConvertModifier
        {
            get => _convertModifier;
            set { _convertModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DoTsKey
        {
            get => _dots;
            set { _dots = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DoTsModifier
        {
            get => _dotsModifier;
            set { _dotsModifier = value; OnPropertyChanged(); }
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
        public Keys VirusKey
        {
            get => _virus;
            set { _virus = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys VirusModifier
        {
            get => _virusModifier;
            set { _virusModifier = value; OnPropertyChanged(); }
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

        public void RegisterAll()
        {
            HotkeyManager.Register("Vivi_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ViviLog($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Vivi_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ViviLog($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Vivi_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ViviLog($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Vivi_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ViviLog($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Vivi_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ViviLog($"Loading Preset: {ViviPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Vivi_Enochian", EnochianKey, EnochianModifier, hk =>
            {
                ViviSettingsModel.Instance.UseEnochian = !ViviSettingsModel.Instance.UseEnochian;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseEnochian ? "Enochian Enabled!" : "Enochian Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseEnochian), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseEnochian ? "Enochian Enabled!" : "Enochian Disabled!");
                }
            });

            HotkeyManager.Register("Vivi_Potion", PotionKey, PotionModifier, hk =>
            {
                ViviSettingsModel.Instance.UseDpsPotion = !ViviSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                ViviSettingsModel.Instance.UseBuffs = !ViviSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Sharpcast", SharpcastKey, SharpcastModifier, hk =>
            {
                ViviSettingsModel.Instance.UseSharpcast = !ViviSettingsModel.Instance.UseSharpcast;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseSharpcast ? "Sharpcast Enabled!" : "Sharpcast Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseSharpcast), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseSharpcast ? "Sharpcast Enabled!" : "Sharpcast Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_AoE", AoEKey, AoEModifier, hk =>
            {
                ViviSettingsModel.Instance.UseAoE = !ViviSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Swiftcast", SwiftcastKey, SwiftcastModifier, hk =>
            {
                ViviSettingsModel.Instance.UseSwiftcast = !ViviSettingsModel.Instance.UseSwiftcast;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseSwiftcast), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_DoTs", DoTsKey, DoTsModifier, hk =>
            {
                ViviSettingsModel.Instance.UseDoTs = !ViviSettingsModel.Instance.UseDoTs;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseDoTs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Opener", OpenerKey, OpenerModifier, hk =>
            {
                ViviSettingsModel.Instance.UseOpener = !ViviSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_LeyLines", LeyLinesKey, LeyLinesModifier, hk =>
            {
                ViviSettingsModel.Instance.UseLeyLines = !ViviSettingsModel.Instance.UseLeyLines;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseLeyLines ? "LeyLines Enabled!" : "LeyLines Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseLeyLines), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseLeyLines ? "LeyLines Enabled!" : "LeyLines Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Convert", ConvertKey, ConvertModifier, hk =>
            {
                ViviSettingsModel.Instance.UseConvert = !ViviSettingsModel.Instance.UseConvert;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseConvert ? "Convert Enabled!" : "Convert Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseConvert), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseConvert ? "Convert Enabled!" : "Convert Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Defensives", DefensivesKey, DefensivesModifier, hk =>
            {
                ViviSettingsModel.Instance.UseDefensives = !ViviSettingsModel.Instance.UseDefensives;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseDefensives), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!");
                }
            });
            HotkeyManager.Register("Vivi_Virus", VirusKey, VirusModifier, hk =>
            {
                ViviSettingsModel.Instance.UseVirus = !ViviSettingsModel.Instance.UseVirus;
                {
                    ToastManager.AddToast(ViviSettingsModel.Instance.UseVirus ? "Virus Enabled!" : "Virus Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ViviSettingsModel.Instance.UseVirus), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ViviLog(ViviSettingsModel.Instance.UseVirus ? "Virus Enabled!" : "Virus Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Vivi_LoadPreset1");
            HotkeyManager.Unregister("Vivi_LoadPreset2");
            HotkeyManager.Unregister("Vivi_LoadPreset3");
            HotkeyManager.Unregister("Vivi_LoadPreset4");
            HotkeyManager.Unregister("Vivi_LoadPreset5");

            HotkeyManager.Unregister("Vivi_Enochian");
            HotkeyManager.Unregister("Vivi_Potion");
            HotkeyManager.Unregister("Vivi_Buffs");
            HotkeyManager.Unregister("Vivi_Sharpcast");
            HotkeyManager.Unregister("Vivi_AoE");
            HotkeyManager.Unregister("Vivi_Swiftcast");
            HotkeyManager.Unregister("Vivi_DoTs");
            HotkeyManager.Unregister("Vivi_Opener");
            HotkeyManager.Unregister("Vivi_LeyLines");
            HotkeyManager.Unregister("Vivi_Convert");
            HotkeyManager.Unregister("Vivi_Defensives");
            HotkeyManager.Unregister("Vivi_Virus");
        }
    }
}