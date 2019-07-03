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
using static Kefka.Utilities.Constants;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class MikotoHotkeysModel : BaseModel
    {
        private static MikotoHotkeysModel _instance;
        public static MikotoHotkeysModel Instance => _instance ?? (_instance = new MikotoHotkeysModel());

        private MikotoHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Mikoto_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _doDamage, _potion, _cleanse, _fluidAura, _holy, _divineBenison, _plenaryIndulgence, _thinAir, _tetragrammaton, _benediction, _largesse, _eyeforanEye, _asylum, _assize, _presenceofMind, _shit;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _doDamageModifier, _potionModifier, _cleanseModifier, _fluidAuraModifier, _holyModifier, _divineBenisonModifier, _plenaryIndulgenceModifier, _thinAirModifier, _tetragrammatonModifier, _benedictionModifier, _largesseModifier, _eyeforanEyeModifier, _asylumModifier, _assizeModifier, _presenceofMindModifier, _shitModifier;

        public MikotoPresetsSettingsModel PresetNames => MikotoPresetsSettingsModel.Instance;

        public MikotoPresetsViewModel PresetCommands => new MikotoPresetsViewModel();

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
        public Keys FluidAuraKey
        {
            get => _fluidAura;
            set { _fluidAura = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FluidAuraModifier
        {
            get => _fluidAuraModifier;
            set { _fluidAuraModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys HolyKey
        {
            get => _holy;
            set { _holy = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HolyModifier
        {
            get => _holyModifier;
            set { _holyModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DivineBenisonKey
        {
            get => _divineBenison;
            set { _divineBenison = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DivineBenisonModifier
        {
            get => _divineBenisonModifier;
            set { _divineBenisonModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PlenaryIndulgenceKey
        {
            get => _plenaryIndulgence;
            set { _plenaryIndulgence = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PlenaryIndulgenceModifier
        {
            get => _plenaryIndulgenceModifier;
            set { _plenaryIndulgenceModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ThinAirKey
        {
            get => _thinAir;
            set { _thinAir = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ThinAirModifier
        {
            get => _thinAirModifier;
            set { _thinAirModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TetragrammatonKey
        {
            get => _tetragrammaton;
            set { _tetragrammaton = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TetragrammatonModifier
        {
            get => _tetragrammatonModifier;
            set { _tetragrammatonModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BenedictionKey
        {
            get => _benediction;
            set { _benediction = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BenedictionModifier
        {
            get => _benedictionModifier;
            set { _benedictionModifier = value; OnPropertyChanged(); }
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
        public Keys AsylumKey
        {
            get => _asylum;
            set { _asylum = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AsylumModifier
        {
            get => _asylumModifier;
            set { _asylumModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AssizeKey
        {
            get => _assize;
            set { _assize = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AssizeModifier
        {
            get => _assizeModifier;
            set { _assizeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PresenceofMindKey
        {
            get => _presenceofMind;
            set { _presenceofMind = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PresenceofMindModifier
        {
            get => _presenceofMindModifier;
            set { _presenceofMindModifier = value; OnPropertyChanged(); }
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
            HotkeyManager.Register("Mikoto_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.MikotoLog($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Mikoto_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.MikotoLog($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Mikoto_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.MikotoLog($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Mikoto_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.MikotoLog($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Mikoto_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.MikotoLog($"Loading Preset: {MikotoPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Mikoto_DoDamage", DoDamageKey, DoDamageModifier, hk =>
            {
                MikotoSettingsModel.Instance.DoDamage = !MikotoSettingsModel.Instance.DoDamage;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.DoDamage ? "DoDamage Enabled!" : "DoDamage Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.DoDamage), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.DoDamage
                        ? "DoDamage Enabled!"
                        : "DoDamage Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Potion", PotionKey, PotionModifier, hk =>
            {
                MikotoSettingsModel.Instance.UsePotion = !MikotoSettingsModel.Instance.UsePotion;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UsePotion ? "Potion Enabled!" : "Potion Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UsePotion), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UsePotion
                        ? "Potion Enabled!"
                        : "Potion Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Cleanse", CleanseKey, CleanseModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseCleanse = !MikotoSettingsModel.Instance.UseCleanse;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseCleanse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Largesse", LargesseKey, LargesseModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseLargesse = !MikotoSettingsModel.Instance.UseLargesse;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseLargesse
                            ? "Divine Seal Enabled!"
                            : "Divine Seal Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseLargesse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseLargesse
                        ? "Divine Seal Enabled!"
                        : "Divine Seal Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Asylum", AsylumKey, AsylumModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseAsylum = !MikotoSettingsModel.Instance.UseAsylum;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseAsylum
                            ? "Asylum Enabled!"
                            : "Asylum Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseAsylum), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseAsylum
                        ? "Asylum Enabled!"
                        : "Asylum Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Assize", AssizeKey, AssizeModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseAssize = !MikotoSettingsModel.Instance.UseAssize;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseAssize
                            ? "Assize Enabled!"
                            : "Assize Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseAssize),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseAssize
                        ? "Assize Enabled!"
                        : "Assize Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_PresenceofMind", PresenceofMindKey, PresenceofMindModifier, hk =>
            {
                MikotoSettingsModel.Instance.UsePresenceofMind = !MikotoSettingsModel.Instance.UsePresenceofMind;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UsePresenceofMind
                            ? "Presence Of Mind Enabled!"
                            : "Presence Of Mind Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UsePresenceofMind),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UsePresenceofMind
                        ? "Presence Of Mind Enabled!"
                        : "Presence Of Mind Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_FluidAura", FluidAuraKey, FluidAuraModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseFluidAura = !MikotoSettingsModel.Instance.UseFluidAura;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseFluidAura
                            ? "Fluid Aura Enabled!"
                            : "Fluid Aura Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseFluidAura), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseFluidAura
                        ? "Fluid Aura Enabled!"
                        : "Fluid Aura Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Holy", HolyKey, HolyModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseHoly = !MikotoSettingsModel.Instance.UseHoly;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseHoly
                            ? "Holy Enabled!"
                            : "Holy Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseHoly), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseHoly
                        ? "Holy Enabled!"
                        : "Holy Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_DivineBenison", DivineBenisonKey, DivineBenisonModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseDivineBenison = !MikotoSettingsModel.Instance.UseDivineBenison;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseDivineBenison
                            ? "Divine Benison Enabled!"
                            : "Divine Benison Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseDivineBenison), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseDivineBenison
                        ? "Divine Benison Enabled!"
                        : "Divine Benison Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_PlenaryIndulgence", PlenaryIndulgenceKey, PlenaryIndulgenceModifier, hk =>
            {
                MikotoSettingsModel.Instance.UsePlenaryIndulgence = !MikotoSettingsModel.Instance.UsePlenaryIndulgence;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UsePlenaryIndulgence
                            ? "Plenary Indulgence Enabled!"
                            : "Plenary Indulgence Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UsePlenaryIndulgence), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UsePlenaryIndulgence
                        ? "Plenary Indulgence Enabled!"
                        : "Plenary Indulgence Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_ThinAir", ThinAirKey, ThinAirModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseThinAir = !MikotoSettingsModel.Instance.UseThinAir;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseThinAir
                            ? "Thin Air Enabled!"
                            : "Thin Air Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseThinAir), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseThinAir
                        ? "Thin Air Enabled!"
                        : "Thin Air Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Tetragrammaton", TetragrammatonKey, TetragrammatonModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseTetragrammaton = !MikotoSettingsModel.Instance.UseTetragrammaton;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseTetragrammaton
                            ? "Tetragrammaton Enabled!"
                            : "Tetragrammaton Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseTetragrammaton), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseTetragrammaton
                        ? "Tetragrammaton Enabled!"
                        : "Tetragrammaton Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_Benediction", BenedictionKey, BenedictionModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseBenediction = !MikotoSettingsModel.Instance.UseBenediction;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseBenediction ? "Benediction Enabled!" : "Benediction Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseBenediction), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseBenediction
                        ? "Benediction Enabled!"
                        : "Benediction Disabled!");
                }
            });
            HotkeyManager.Register("Mikoto_ShitButton", ShitButtonKey, ShitButtonModifier, hk =>
            {
                MikotoSettingsModel.Instance.UseShitButton = !MikotoSettingsModel.Instance.UseShitButton;
                {
                    Core.OverlayManager.AddToast(
                        () => MikotoSettingsModel.Instance.UseShitButton ? "OH $h!7!!! Button Enabled!" : "OH $h!7!!! Button Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(MikotoSettingsModel.Instance.UseShitButton), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.MikotoLog(MikotoSettingsModel.Instance.UseShitButton
                        ? "OH $h!7!!! Button Enabled!"
                        : "OH $h!7!!! Button Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Mikoto_LoadPreset1");
            HotkeyManager.Unregister("Mikoto_LoadPreset2");
            HotkeyManager.Unregister("Mikoto_LoadPreset3");
            HotkeyManager.Unregister("Mikoto_LoadPreset4");
            HotkeyManager.Unregister("Mikoto_LoadPreset5");

            HotkeyManager.Unregister("Mikoto_DoDamage");
            HotkeyManager.Unregister("Mikoto_Potion");
            HotkeyManager.Unregister("Mikoto_Cleanse");
            HotkeyManager.Unregister("Mikoto_Asylum");
            HotkeyManager.Unregister("Mikoto_Assize");
            HotkeyManager.Unregister("Mikoto_PresenceofMind");
            HotkeyManager.Unregister("Mikoto_FluidAura");
            HotkeyManager.Unregister("Mikoto_Holy");
            HotkeyManager.Unregister("Mikoto_ThinAir");
            HotkeyManager.Unregister("Mikoto_Tetragrammaton");
            HotkeyManager.Unregister("Mikoto_Benediction");
            HotkeyManager.Unregister("Mikoto_UI");
            HotkeyManager.Unregister("Mikoto_Shit");
        }
    }
}