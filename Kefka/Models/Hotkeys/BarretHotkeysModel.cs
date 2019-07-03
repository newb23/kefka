using ff14bot;
using static Kefka.Utilities.Constants;
using Kefka.Utilities;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Kefka.ViewModels;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class BarretHotkeysModel : BaseModel
    {
        private static BarretHotkeysModel _instance;
        public static BarretHotkeysModel Instance => _instance ?? (_instance = new BarretHotkeysModel());

        private BarretHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Barret_Hotkeys.json")
        {
        }

        private Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _blank, _potion, _buffs, _cooldowns, _heartBreak,
            _aoe, _gaussBarrel, _interrupt, _autoAmmo, _useAutoTurret, _opener, _hypercharge, _forceOverheat, _wildfire, _flamethrower, _overdrive;

        private ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _blankModifier,
            _potionModifier, _buffsModifier, _cooldownsModifier, _heartBreakModifier, _aoeModifier, _gaussBarrelModifier, _interruptModifier,
            _autoAmmoModifier, _useAutoTurretModifier, _openerModifier, _hyperchargeModifier, _forceOverheatModifier, _wildfireModifier, _flamethrowerModifier,
            _overdriveModifier;

        public BarretPresetsSettingsModel PresetNames => BarretPresetsSettingsModel.Instance;
        public BarretPresetsViewModel PresetCommands => new BarretPresetsViewModel();

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
        public Keys BlankKey
        {
            get => _blank;
            set { _blank = value; OnPropertyChanged(); }
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
        public Keys HeartBreakKey
        {
            get => _heartBreak;
            set { _heartBreak = value; OnPropertyChanged(); }
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
        public ModifierKeys BlankModifier
        {
            get => _blankModifier;
            set { _blankModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys HeartBreakModifier
        {
            get => _heartBreakModifier;
            set { _heartBreakModifier = value; OnPropertyChanged(); }
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
        public Keys GaussBarrelKey
        {
            get => _gaussBarrel;
            set { _gaussBarrel = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GaussBarrelModifier
        {
            get => _gaussBarrelModifier;
            set { _gaussBarrelModifier = value; OnPropertyChanged(); }
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
        public Keys CooldownsKey
        {
            get => _cooldowns;
            set { _cooldowns = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CooldownsModifier
        {
            get => _cooldownsModifier;
            set { _cooldownsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AutoAmmoKey
        {
            get => _autoAmmo;
            set { _autoAmmo = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AutoAmmoModifier
        {
            get => _autoAmmoModifier;
            set { _autoAmmoModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AutoTurretKey
        {
            get => _useAutoTurret;
            set { _useAutoTurret = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AutoTurretModifer
        {
            get => _useAutoTurretModifier;
            set { _useAutoTurretModifier = value; OnPropertyChanged(); }
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
        public Keys HyperchargeKey
        {
            get => _hypercharge;
            set { _hypercharge = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HyperchargeModifier
        {
            get => _hyperchargeModifier;
            set { _hyperchargeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ForceOverheatKey
        {
            get => _forceOverheat;
            set { _forceOverheat = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ForceOverheatModifier
        {
            get => _forceOverheatModifier;
            set { _forceOverheatModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys FlamethrowerKey
        {
            get => _flamethrower;
            set { _flamethrower = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FlamethrowerModifier
        {
            get => _flamethrowerModifier;
            set { _flamethrowerModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys WildfireKey
        {
            get => _wildfire;
            set { _wildfire = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys WildfireModifier
        {
            get => _wildfireModifier;
            set { _wildfireModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OverdriveKey
        {
            get => _overdrive;
            set { _overdrive = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OverdriveModifier
        {
            get => _overdriveModifier;
            set { _overdriveModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Barret_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BarretLog($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Barret_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BarretLog($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Barret_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BarretLog($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Barret_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BarretLog($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Barret_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.BarretLog($"Loading Preset: {BarretPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Barret_Blank", BlankKey, BlankModifier, hk =>
            {
                BarretSettingsModel.Instance.UseBlank = !BarretSettingsModel.Instance.UseBlank;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseBlank ? "Blank Enabled!" : "Blank Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseBlank), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseBlank ? "Blank Enabled!" : "Blank Disabled!");
            });

            HotkeyManager.Register("Barret_Potion", PotionKey, PotionModifier, hk =>
            {
                BarretSettingsModel.Instance.UseDpsPotion = !BarretSettingsModel.Instance.UseDpsPotion;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
            });

            HotkeyManager.Register("Barret_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                BarretSettingsModel.Instance.UseBuffs = !BarretSettingsModel.Instance.UseBuffs;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
            });

            HotkeyManager.Register("Barret_HeartBreak", HeartBreakKey, HeartBreakModifier, hk =>
            {
                BarretSettingsModel.Instance.UseHeartBreak = !BarretSettingsModel.Instance.UseHeartBreak;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseHeartBreak ? "HeartBreak Enabled!" : "HeartBreak Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseHeartBreak), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseHeartBreak ? "HeartBreak Enabled!" : "HeartBreak Disabled!");
            });

            HotkeyManager.Register("Barret_AoE", AoEKey, AoEModifier, hk =>
            {
                BarretSettingsModel.Instance.UseAoE = !BarretSettingsModel.Instance.UseAoE;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!");
            });

            HotkeyManager.Register("Barret_GaussBarrel", GaussBarrelKey, GaussBarrelModifier, hk =>
            {
                BarretSettingsModel.Instance.UseGaussBarrel = !BarretSettingsModel.Instance.UseGaussBarrel;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseGaussBarrel ? "Gauss Barrel Enabled!" : "Gauss Barrel Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseGaussBarrel), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseGaussBarrel ? "Gauss Barrel Enabled!" : "Gauss Barrel Disabled!");
            });

            HotkeyManager.Register("Barret_AutoInterrupt", InterruptKey, InterruptModifier, hk =>
            {
                BarretSettingsModel.Instance.UseManualInterrupt = !BarretSettingsModel.Instance.UseManualInterrupt;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                if (BarretSettingsModel.Instance.UseManualInterrupt)
                    if (BarretSettingsModel.Instance.UseInterruptList)
                        BarretSettingsModel.Instance.UseInterruptList = false;

                Logger.BarretLog(BarretSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
            });

            HotkeyManager.Register("Barret_AutoAmmo", AutoAmmoKey, AutoAmmoModifier, hk =>
            {
                BarretSettingsModel.Instance.UseAutoAmmo = !BarretSettingsModel.Instance.UseAutoAmmo;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseAutoAmmo ? "Auto-Ammo Enabled!" : "Auto-Ammo Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseAutoAmmo), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseAutoAmmo ? "Aut-oAmmo Enabled!" : "Auto-Ammo Disabled!");
            });

            HotkeyManager.Register("Barret_AutoTurret", AutoTurretKey, AutoTurretModifer, hk =>
            {
                BarretSettingsModel.Instance.UseAutoTurret = !BarretSettingsModel.Instance.UseAutoTurret;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseAutoTurret ? "Auto-Turret Enabled!" : "Auto-Turret Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseAutoTurret), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseAutoTurret ? "Auto-Turret Enabled!" : "Auto-Turret Disabled!");
            });

            HotkeyManager.Register("Barret_Opener", OpenerKey, OpenerModifier, hk =>
            {
                BarretSettingsModel.Instance.UseOpener = !BarretSettingsModel.Instance.UseOpener;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
            });

            HotkeyManager.Register("Barret_Cooldowns", CooldownsKey, CooldownsModifier, hk =>
            {
                BarretSettingsModel.Instance.UseCooldowns = !BarretSettingsModel.Instance.UseCooldowns;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseCooldowns ? "Cooldowns Enabled!" : "Cooldowns Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseCooldowns), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseCooldowns ? "Cooldowns Enabled!" : "Cooldowns Disabled!");
            });

            HotkeyManager.Register("Barret_Hypercharge", HyperchargeKey, HyperchargeModifier, hk =>
            {
                BarretSettingsModel.Instance.UseHypercharge = !BarretSettingsModel.Instance.UseHypercharge;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseHypercharge ? "Hypercharge Enabled!" : "Hypercharge Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseHypercharge), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseHypercharge ? "Hypercharge Enabled!" : "Hypercharge Disabled!");
            });

            HotkeyManager.Register("Barret_ForceOverheat", ForceOverheatKey, ForceOverheatModifier, hk =>
            {
                ToastManager.AddToast("Forcing Overheat!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog("Forcing Overheat!");
            });

            HotkeyManager.Register("Barret_Wildfire", WildfireKey, WildfireModifier, hk =>
            {
                BarretSettingsModel.Instance.UseWildfire = !BarretSettingsModel.Instance.UseWildfire;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseWildfire ? "Wildfire Enabled!" : "Wildfire Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseWildfire), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseWildfire ? "Wildfire Enabled!" : "Wildfire Disabled!");
            });

            HotkeyManager.Register("Barret_Overdrive", OverdriveKey, OverdriveModifier, hk =>
            {
                ToastManager.AddToast("Forcing Overdrive!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog("Forcing Overdrive!");
            });

            HotkeyManager.Register("Barret_Flamethrower", FlamethrowerKey, FlamethrowerModifier, hk =>
            {
                BarretSettingsModel.Instance.UseFlamethrower = !BarretSettingsModel.Instance.UseFlamethrower;
                ToastManager.AddToast(BarretSettingsModel.Instance.UseFlamethrower ? "Flamethrower Enabled!" : "Flamethrower Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(BarretSettingsModel.Instance.UseFlamethrower), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                Logger.BarretLog(BarretSettingsModel.Instance.UseFlamethrower ? "Flamethrower Enabled!" : "Flamethrower Disabled!");
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Barret_LoadPreset1");
            HotkeyManager.Unregister("Barret_LoadPreset2");
            HotkeyManager.Unregister("Barret_LoadPreset3");
            HotkeyManager.Unregister("Barret_LoadPreset4");
            HotkeyManager.Unregister("Barret_LoadPreset5");

            HotkeyManager.Unregister("Barret_Blank");
            HotkeyManager.Unregister("Barret_Potion");
            HotkeyManager.Unregister("Barret_Buffs");
            HotkeyManager.Unregister("Barret_HeartBreak");
            HotkeyManager.Unregister("Barret_AoE");
            HotkeyManager.Unregister("Barret_GaussBarrel");
            HotkeyManager.Unregister("Barret_AutoInterrupt");
            HotkeyManager.Unregister("Barret_QueueAbilities");
            HotkeyManager.Unregister("Barret_AutoAmmo");
            HotkeyManager.Unregister("Barret_AutoTurret");
            HotkeyManager.Unregister("Barret_Opener");
            HotkeyManager.Unregister("Barret_Cooldowns");
            HotkeyManager.Unregister("Barret_Hypercharge");
            HotkeyManager.Unregister("Barret_ForceOverheat");
            HotkeyManager.Unregister("Barret_Wildfire");
            HotkeyManager.Unregister("Barret_Flamethrower");
            HotkeyManager.Unregister("Barret_Overdrive");
        }
    }
}