using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using ff14bot;
using Kefka.Utilities;
using Kefka.ViewModels;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class SuritoHotkeysModel : BaseModel
    {
        private static SuritoHotkeysModel _instance;
        public static SuritoHotkeysModel Instance => _instance ?? (_instance = new SuritoHotkeysModel());

        private SuritoHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Surito_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _doDamage, _potion, _cleanse, _lustrate, _emrgencyTactics, _dissipation, _rouse, _indomitabilty, _shadowFlare, _chainStratagem, _eyeforanEye, _largesse, _excogitation, _aetherpact, _shit;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _doDamageModifier, _potionModifier, _cleanseModifier, _lustrateModifier, _emrgencyTacticsModifier, _dissipationModifier, _rouseModifier, _indomitabiltyModifier, _shadowFlareModifier, _chainStratagemModifier, _eyeforanEyeModifier, _largesseModifier, _excogitationModifier, _aetherpactModifier, _shitModifier;

        public SuritoPresetsSettingsModel PresetNames => SuritoPresetsSettingsModel.Instance;

        public SuritoPresetsViewModel PresetCommands => new SuritoPresetsViewModel();

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
        public Keys DoDamageKey
        {
            get => _doDamage;
            set { _doDamage = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DoDamageModifier
        {
            get => _doDamageModifier;
            set { _doDamageModifier = value; OnPropertyChanged(); }
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
        public Keys CleanseKey
        {
            get => _cleanse;
            set { _cleanse = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CleanseModifier
        {
            get => _cleanseModifier;
            set { _cleanseModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys LustrateKey
        {
            get => _lustrate;
            set { _lustrate = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys LustrateModifier
        {
            get => _lustrateModifier;
            set { _lustrateModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys EmergencyTacticsKey
        {
            get => _emrgencyTactics;
            set { _emrgencyTactics = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EmergencyTacticsModifier
        {
            get => _emrgencyTacticsModifier;
            set { _emrgencyTacticsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DissipationKey
        {
            get => _dissipation;
            set { _dissipation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DissipationModifier
        {
            get => _dissipationModifier;
            set { _dissipationModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RouseKey
        {
            get => _rouse;
            set { _rouse = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RouseModifier
        {
            get => _rouseModifier;
            set { _rouseModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShadowFlareKey
        {
            get => _shadowFlare;
            set { _shadowFlare = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShadowFlareModifier
        {
            get => _shadowFlareModifier;
            set { _shadowFlareModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys IndomitabilityKey
        {
            get => _indomitabilty;
            set { _indomitabilty = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys IndomitabilityModifier
        {
            get => _indomitabiltyModifier;
            set { _indomitabiltyModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ChainStratagemKey
        {
            get => _chainStratagem;
            set { _chainStratagem = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ChainStratagemModifier
        {
            get => _chainStratagemModifier;
            set { _chainStratagemModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys EyeforanEyeKey
        {
            get => _eyeforanEye;
            set { _eyeforanEye = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EyeforanEyeModifier
        {
            get => _eyeforanEyeModifier;
            set { _eyeforanEyeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys LargesseKey
        {
            get => _largesse;
            set { _largesse = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys LargesseModifier
        {
            get => _largesseModifier;
            set { _largesseModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ExcogitationKey
        {
            get => _excogitation;
            set { _excogitation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ExcogitationModifier
        {
            get => _excogitationModifier;
            set { _excogitationModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AetherpactKey
        {
            get => _aetherpact;
            set { _aetherpact = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AetherpactModifier
        {
            get => _aetherpactModifier;
            set { _aetherpactModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShitButtonKey
        {
            get => _shit;
            set { _shit = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShitButtonModifier
        {
            get => _shitModifier;
            set { _shitModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Surito_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SuritoLog($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Surito_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SuritoLog($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Surito_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SuritoLog($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Surito_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SuritoLog($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Surito_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.SuritoLog($"Loading Preset: {SuritoPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Surito_DoDamage", DoDamageKey, DoDamageModifier, hk =>
            {
                SuritoSettingsModel.Instance.DoDamage = !SuritoSettingsModel.Instance.DoDamage;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.DoDamage ? "DoDamage Enabled!" : "DoDamage Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.DoDamage), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.DoDamage
                        ? "DoDamage Enabled!"
                        : "DoDamage Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Potion", PotionKey, PotionModifier, hk =>
            {
                SuritoSettingsModel.Instance.UsePotion = !SuritoSettingsModel.Instance.UsePotion;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UsePotion ? "Potion Enabled!" : "Potion Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UsePotion), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UsePotion
                        ? "Potion Enabled!"
                        : "Potion Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Cleanse", CleanseKey, CleanseModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseCleanse = !SuritoSettingsModel.Instance.UseCleanse;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseCleanse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Lustrate", LustrateKey, LustrateModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseLustrate = !SuritoSettingsModel.Instance.UseLustrate;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseLustrate
                            ? "Lustrate Enabled!"
                            : "Lustrate Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseLustrate), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseLustrate
                        ? "Lustrate Enabled!"
                        : "Lustrate Disabled!");
                }
            });
            HotkeyManager.Register("Surito_EmergencyTactics", EmergencyTacticsKey, EmergencyTacticsModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseEmergencyTactics = !SuritoSettingsModel.Instance.UseEmergencyTactics;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseEmergencyTactics
                            ? "Emergency Tactics Enabled!"
                            : "Emergency Tactics Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseEmergencyTactics), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseEmergencyTactics
                        ? "Emergency Tactics Enabled!"
                        : "Emergency Tactics Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Dissipation", DissipationKey, DissipationModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseDissipation = !SuritoSettingsModel.Instance.UseDissipation;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseDissipation
                            ? "Dissipation Enabled!"
                            : "Dissipation Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseDissipation),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseDissipation
                        ? "Dissipation Enabled!"
                        : "Dissipation Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Rouse", RouseKey, RouseModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseRouse = !SuritoSettingsModel.Instance.UseRouse;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseRouse
                            ? "Rouse Enabled!"
                            : "Rouse Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseRouse),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseRouse
                        ? "Rouse Enabled!"
                        : "Rouse Disabled!");
                }
            });
            HotkeyManager.Register("Surito_ShadowFlare", ShadowFlareKey, ShadowFlareModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseShadowFlare = !SuritoSettingsModel.Instance.UseShadowFlare;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseShadowFlare
                            ? "Shadow Flare Enabled!"
                            : "Shadow Flare Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseShadowFlare), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseShadowFlare
                        ? "Shadow Flare Enabled!"
                        : "Shadow Flare Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Indomitability", IndomitabilityKey, IndomitabilityModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseIndomitability = !SuritoSettingsModel.Instance.UseIndomitability;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseIndomitability ? "Indomitability Enabled!" : "Indomitability Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseIndomitability), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseIndomitability
                        ? "Indomitability Enabled!"
                        : "Indomitability Disabled!");
                }
            });
            HotkeyManager.Register("Surito_ChainStratagem", ChainStratagemKey, ChainStratagemModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseChainStratagem = !SuritoSettingsModel.Instance.UseChainStratagem;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseChainStratagem ? "ChainStratagem Enabled!" : "ChainStratagem Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseChainStratagem), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseChainStratagem
                        ? "ChainStratagem Enabled!"
                        : "ChainStratagem Disabled!");
                }
            });
            HotkeyManager.Register("Surito_EyeforanEye", EyeforanEyeKey, EyeforanEyeModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseEyeforanEye = !SuritoSettingsModel.Instance.UseEyeforanEye;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseEyeforanEye ? "EyeforanEye Enabled!" : "EyeforanEye Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseEyeforanEye), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseEyeforanEye
                        ? "EyeforanEye Enabled!"
                        : "EyeforanEye Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Largesse", LargesseKey, LargesseModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseLargesse = !SuritoSettingsModel.Instance.UseLargesse;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseLargesse
                            ? "Largesse Enabled!"
                            : "Largesse Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseLargesse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseLargesse
                        ? "Largesse Enabled!"
                        : "Largesse Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Excogitation", ExcogitationKey, ExcogitationModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseExcogitation = !SuritoSettingsModel.Instance.UseExcogitation;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseExcogitation ? "Excogitation Enabled!" : "Excogitation Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseExcogitation), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseExcogitation
                        ? "Excogitation Enabled!"
                        : "Excogitation Disabled!");
                }
            });
            HotkeyManager.Register("Surito_Aetherpact", AetherpactKey, AetherpactModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseAetherpact = !SuritoSettingsModel.Instance.UseAetherpact;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseAetherpact ? "Aetherpact Enabled!" : "Aetherpact Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseAetherpact), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseAetherpact
                        ? "Aetherpact Enabled!"
                        : "Aetherpact Disabled!");
                }
            });
            HotkeyManager.Register("Surito_ShitButton", ShitButtonKey, ShitButtonModifier, hk =>
            {
                SuritoSettingsModel.Instance.UseShitButton = !SuritoSettingsModel.Instance.UseShitButton;
                {
                    Core.OverlayManager.AddToast(
                        () => SuritoSettingsModel.Instance.UseShitButton ? "OH $h!7!!! Button Enabled!" : "OH $h!7!!! Button Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(SuritoSettingsModel.Instance.UseShitButton), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.SuritoLog(SuritoSettingsModel.Instance.UseShitButton
                        ? "OH $h!7!!! Button Enabled!"
                        : "OH $h!7!!! Button Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Surito_LoadPreset1");
            HotkeyManager.Unregister("Surito_LoadPreset2");
            HotkeyManager.Unregister("Surito_LoadPreset3");
            HotkeyManager.Unregister("Surito_LoadPreset4");
            HotkeyManager.Unregister("Surito_LoadPreset5");

            HotkeyManager.Unregister("Surito_DoDamage");
            HotkeyManager.Unregister("Surito_Potion");
            HotkeyManager.Unregister("Surito_Cleanse");
            HotkeyManager.Unregister("Surito_Lustrate");
            HotkeyManager.Unregister("Surito_EmergencyTactics");
            HotkeyManager.Unregister("Surito_Dissipation");
            HotkeyManager.Unregister("Surito_Rouse");
            HotkeyManager.Unregister("Surito_ShadowFlare");
            HotkeyManager.Unregister("Surito_Indomitability");
            HotkeyManager.Unregister("Surito_ChainStratagem");
            HotkeyManager.Unregister("Surito_EyeforanEye");
            HotkeyManager.Unregister("Surito_Largesse");
            HotkeyManager.Unregister("Surito_Excogitation");
            HotkeyManager.Unregister("Surito_Aetherpact");
            HotkeyManager.Unregister("Surito_UI");
            HotkeyManager.Unregister("Surito_ShitButton");
        }
    }
}