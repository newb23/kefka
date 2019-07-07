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
    public class EikoHotkeysModel : BaseModel
    {
        private static EikoHotkeysModel _instance;
        public static EikoHotkeysModel Instance => _instance ?? (_instance = new EikoHotkeysModel());

        private EikoHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Eiko_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _shadowFlare, _potion, _buffs, _summon, _aoe, _swiftcast,
            _dots, _opener, _aetherflowAbilities, _triDisaster, _aetherflow, _contagion, _ruinIIFiller;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _shadowFlareModifier,
            _potionModifier, _buffsModifier, _summonModifier, _aoeModifier, _swiftcastModifier, _dotsModifier, _openerModifier, _aetherflowAbilitiesModifier,
            _triDisasterModifier, _aetherflowModifier, _contagionModifier, _ruinIIFillerModifier;

        public EikoPresetsSettingsModel PresetNames => EikoPresetsSettingsModel.Instance;

        public EikoPresetsViewModel PresetCommands => new EikoPresetsViewModel();

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
        public Keys ShadowFlareKey
        {
            get => _shadowFlare;
            set { _shadowFlare = value; OnPropertyChanged(); }
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
        public Keys SummonKey
        {
            get => _summon;
            set { _summon = value; OnPropertyChanged(); }
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
        public ModifierKeys ShadowFlareModifier
        {
            get => _shadowFlareModifier;
            set { _shadowFlareModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys SummonModifier
        {
            get => _summonModifier;
            set { _summonModifier = value; OnPropertyChanged(); }
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
        public Keys AetherflowAbilitiesKey
        {
            get => _aetherflowAbilities;
            set { _aetherflowAbilities = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AetherflowAbilitiesModifier
        {
            get => _aetherflowAbilitiesModifier;
            set { _aetherflowAbilitiesModifier = value; OnPropertyChanged(); }
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
        public Keys TriDisasterKey
        {
            get => _triDisaster;
            set { _triDisaster = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TriDisasterModifier
        {
            get => _triDisasterModifier;
            set { _triDisasterModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AetherflowKey
        {
            get => _aetherflow;
            set { _aetherflow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AetherflowModifier
        {
            get => _aetherflowModifier;
            set { _aetherflowModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ContagionKey
        {
            get => _contagion;
            set { _contagion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ContagionModifier
        {
            get => _contagionModifier;
            set { _contagionModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RuinIIFillerKey
        {
            get => _ruinIIFiller;
            set { _ruinIIFiller = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RuinIIFillerModifier
        {
            get => _ruinIIFillerModifier;
            set { _ruinIIFillerModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Eiko_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EikoLog($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Eiko_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EikoLog($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Eiko_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EikoLog($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Eiko_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EikoLog($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Eiko_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EikoLog($"Loading Preset: {EikoPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Eiko_ShadowFlare", ShadowFlareKey, ShadowFlareModifier, hk =>
            {
                EikoSettingsModel.Instance.UseShadowFlare = !EikoSettingsModel.Instance.UseShadowFlare;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseShadowFlare ? "Shadow Flare Enabled!" : "Shadow Flare Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseShadowFlare), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseShadowFlare ? "Shadow Flare Enabled!" : "Shadow Flare Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Potion", PotionKey, PotionModifier, hk =>
            {
                EikoSettingsModel.Instance.UseDpsPotion = !EikoSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                EikoSettingsModel.Instance.UseBuffs = !EikoSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Summon", SummonKey, SummonModifier, hk =>
            {
                EikoSettingsModel.Instance.UseSummonPets = !EikoSettingsModel.Instance.UseSummonPets;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseSummonPets ? "Summons Enabled!" : "Summons Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseSummonPets), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseSummonPets ? "Summons Enabled!" : "Summons Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_AoE", AoEKey, AoEModifier, hk =>
            {
                EikoSettingsModel.Instance.UseAoE = !EikoSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Swiftcast", SwiftcastKey, SwiftcastModifier, hk =>
            {
                EikoSettingsModel.Instance.UseSwiftcast = !EikoSettingsModel.Instance.UseSwiftcast;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseSwiftcast), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_DoTs", DoTsKey, DoTsModifier, hk =>
            {
                EikoSettingsModel.Instance.UseDoTs = !EikoSettingsModel.Instance.UseDoTs;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseDoTs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Opener", OpenerKey, OpenerModifier, hk =>
            {
                EikoSettingsModel.Instance.UseOpener = !EikoSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_TriDisaster", TriDisasterKey, TriDisasterModifier, hk =>
            {
                EikoSettingsModel.Instance.UseTriDisaster = !EikoSettingsModel.Instance.UseTriDisaster;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseTriDisaster ? "TriDisaster Enabled!" : "TriDisaster Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseTriDisaster), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseTriDisaster ? "TriDisaster Enabled!" : "TriDisaster Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_AetherflowAbilities", AetherflowAbilitiesKey, AetherflowAbilitiesModifier, hk =>
            {
                EikoSettingsModel.Instance.UseAetherflowAbilities = !EikoSettingsModel.Instance.UseAetherflowAbilities;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseAetherflowAbilities ? "Aetherflow Abilities Enabled!" : "Aetherflow Abilities Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseAetherflowAbilities), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseAetherflowAbilities ? "Aetherflow Abilities Enabled!" : "Aetherflow Abilities Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Aetherflow", AetherflowKey, AetherflowModifier, hk =>
            {
                EikoSettingsModel.Instance.UseAetherflow = !EikoSettingsModel.Instance.UseAetherflow;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseAetherflow ? "Aetherflow Enabled!" : "Aetherflow Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseAetherflow), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseAetherflow ? "Aetherflow Enabled!" : "Aetherflow Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_Contagion", ContagionKey, ContagionModifier, hk =>
            {
                EikoSettingsModel.Instance.UseContagion = !EikoSettingsModel.Instance.UseContagion;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseContagion ? "Contagion Enabled!" : "Contagion Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseContagion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseContagion ? "Contagion Enabled!" : "Contagion Disabled!");
                }
            });
            HotkeyManager.Register("Eiko_RuinIIFiller", RuinIIFillerKey, RuinIIFillerModifier, hk =>
            {
                EikoSettingsModel.Instance.UseRuin2Filler = !EikoSettingsModel.Instance.UseRuin2Filler;
                {
                    ToastManager.AddToast(EikoSettingsModel.Instance.UseContagion ? "RuinII Filler Enabled!" : "RuinII Filler Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EikoSettingsModel.Instance.UseContagion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EikoLog(EikoSettingsModel.Instance.UseRuin2Filler ? "RuinII Filler Enabled!" : "RuinII Filler Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Eiko_LoadPreset1");
            HotkeyManager.Unregister("Eiko_LoadPreset2");
            HotkeyManager.Unregister("Eiko_LoadPreset3");
            HotkeyManager.Unregister("Eiko_LoadPreset4");
            HotkeyManager.Unregister("Eiko_LoadPreset5");

            HotkeyManager.Unregister("Eiko_ShadowFlare");
            HotkeyManager.Unregister("Eiko_Potion");
            HotkeyManager.Unregister("Eiko_Buffs");
            HotkeyManager.Unregister("Eiko_Summon");
            HotkeyManager.Unregister("Eiko_AoE");
            HotkeyManager.Unregister("Eiko_Swiftcast");
            HotkeyManager.Unregister("Eiko_DoTs");
            HotkeyManager.Unregister("Eiko_Opener");
            HotkeyManager.Unregister("Eiko_TriDisaster");
            HotkeyManager.Unregister("Eiko_AetherflowAbilities");
            HotkeyManager.Unregister("Eiko_Aetherflow");
            HotkeyManager.Unregister("Eiko_Contagion");
            HotkeyManager.Unregister("Eiko_RuinIIFiller");
        }
    }
}