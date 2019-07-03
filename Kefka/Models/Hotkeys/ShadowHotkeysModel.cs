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
    public class ShadowHotkeysModel : BaseModel
    {
        private static ShadowHotkeysModel _instance;
        public static ShadowHotkeysModel Instance => _instance ?? (_instance = new ShadowHotkeysModel());

        private ShadowHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Shadow_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _potion, _buffs, _ninjutsu, _aoe, _assassinate, _shukuchi, _dots, _opener, _db, _tenChiJin, _shadewalker, _autoInterrupt, _dbSpam, _tenChiJinSelector;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _potionModifier, _buffsModifier,
            _ninjutsuModifier, _aoeModifier, _assassinateModifier, _shukuchiModifier, _dotsModifier, _openerModifier, _dbModifier,
            _tenChiJinModifier, _shadewalkerModifier, _autoInterruptModifier, _dbSpamModifier, _tenChiJinSelectorModifier;

        public ShadowPresetsSettingsModel PresetNames => ShadowPresetsSettingsModel.Instance;

        public ShadowPresetsViewModel PresetCommands => new ShadowPresetsViewModel();

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
        public Keys NinjutsuKey
        {
            get => _ninjutsu;
            set { _ninjutsu = value; OnPropertyChanged(); }
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
        public ModifierKeys NinjutsuModifier
        {
            get => _ninjutsuModifier;
            set { _ninjutsuModifier = value; OnPropertyChanged(); }
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
        public Keys AssassinateKey
        {
            get => _assassinate;
            set { _assassinate = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AssassinateModifier
        {
            get => _assassinateModifier;
            set { _assassinateModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShukuchiKey
        {
            get => _shukuchi;
            set { _shukuchi = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShukuchiModifier
        {
            get => _shukuchiModifier;
            set { _shukuchiModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShadewalkerKey
        {
            get => _shadewalker;
            set { _shadewalker = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShadewalkerModifier
        {
            get => _shadewalkerModifier;
            set { _shadewalkerModifier = value; OnPropertyChanged(); }
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
        public Keys TenChiJinKey
        {
            get => _tenChiJin;
            set { _tenChiJin = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TenChiJinModifier
        {
            get => _tenChiJinModifier;
            set { _tenChiJinModifier = value; OnPropertyChanged(); }
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
        public Keys DbKey
        {
            get => _db;
            set { _db = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DbModifier
        {
            get => _dbModifier;
            set { _dbModifier = value; OnPropertyChanged(); }
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
        public Keys DbSpamKey
        {
            get => _dbSpam;
            set { _dbSpam = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DbSpamModifier
        {
            get => _dbSpamModifier;
            set { _dbSpamModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TenChiJinSelectorKey
        {
            get => _tenChiJinSelector;
            set { _tenChiJinSelector = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TenChiJinSelectorModifier
        {
            get => _tenChiJinSelectorModifier;
            set { _tenChiJinSelectorModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Shadow_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ShadowLog($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Shadow_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ShadowLog($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Shadow_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ShadowLog($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Shadow_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ShadowLog($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Shadow_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ShadowLog($"Loading Preset: {ShadowPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Shadow_Potion", PotionKey, PotionModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseDpsPotion = !ShadowSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseDpsPotion ? "DPS Potion Enabled!" : "DPS Potion Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseDpsPotion ? "DPS Potion Enabled!" : "DPS Potion Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseBuffs = !ShadowSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Ninjutsu", NinjutsuKey, NinjutsuModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseNinjutsu = !ShadowSettingsModel.Instance.UseNinjutsu;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseNinjutsu ? "Ninjutsu Enabled!" : "Ninjutsu Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseNinjutsu), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseNinjutsu ? "Ninjutsu Enabled!" : "Ninjutsu Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_AoE", AoEKey, AoEModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseAoE = !ShadowSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Assassinate", AssassinateKey, AssassinateModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseAssassinate = !ShadowSettingsModel.Instance.UseAssassinate;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseAssassinate ? "Assassinate Enabled!" : "Assassinate Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseAssassinate), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseAssassinate ? "Assassinate Enabled!" : "Assassinate Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Shukuchi", ShukuchiKey, ShukuchiModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseShukuchi = !ShadowSettingsModel.Instance.UseShukuchi;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseShukuchi ? "Shukuchi Enabled!" : "Shukuchi Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseShukuchi), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseShukuchi ? "Shukuchi Enabled!" : "Shukuchi Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Dots", DotsKey, DotsModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseDots = !ShadowSettingsModel.Instance.UseDots;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseDots), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Opener", OpenerKey, OpenerModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseOpener = !ShadowSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_DB", DbKey, DbModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseDeathBlossom = !ShadowSettingsModel.Instance.UseDeathBlossom;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseDeathBlossom ? "Death Blossom Enabled!" : "Death Blossom Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseDeathBlossom), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseDeathBlossom ? "Death Blossom Enabled!" : "Death Blossom Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_TenChiJin", TenChiJinKey, TenChiJinModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseTenChiJin = !ShadowSettingsModel.Instance.UseTenChiJin;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseTenChiJin ? "Ten Chi Jin Enabled!" : "Ten Chi Jin Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseTenChiJin), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseTenChiJin ? "Ten Chi Jin Enabled!" : "Ten Chi Jin Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_Shadewalker", ShadewalkerKey, ShadewalkerModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseManualShadewalker = !ShadowSettingsModel.Instance.UseManualShadewalker;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseManualShadewalker ? "Shadewalker Enabled!" : "Shadewalker Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseManualShadewalker), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (ShadowSettingsModel.Instance.UseManualShadewalker)
                        if (ShadowSettingsModel.Instance.UseShadewalkerTarget)
                            ShadowSettingsModel.Instance.UseShadewalkerTarget = false;

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseManualShadewalker ? "Shadewalker Enabled!" : "Shadewalker Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_AutoInterrupt", AutoInterruptKey, AutoInterruptModifier, hk =>
            {
                ShadowSettingsModel.Instance.UseManualInterrupt = !ShadowSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (ShadowSettingsModel.Instance.UseManualInterrupt)
                        if (ShadowSettingsModel.Instance.UseInterruptList)
                            ShadowSettingsModel.Instance.UseInterruptList = false;

                    Logger.ShadowLog(ShadowSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Shadow_DbSpam", DbSpamKey, DbSpamModifier, hk =>
            {
                {
                    ToastManager.AddToast("DbSpam!", TimeSpan.FromMilliseconds(750), Colors.LimeGreen, Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                    Logger.ShadowLog("DbSpam");
                }
            });
            HotkeyManager.Register("Shadow_TenChiJinSelector", TenChiJinSelectorKey, TenChiJinSelectorModifier, hk =>
            {
                ShadowSettingsModel.Instance.ChangeTenChiJinSelectionCommand.Execute(null);
                {
                    ToastManager.AddToast(ShadowSettingsModel.Instance.TcjSelection.ToString(), TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ShadowSettingsModel.Instance.UseTenChiJin), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ShadowLog(ShadowSettingsModel.Instance.TcjSelection.ToString());
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Shadow_LoadPreset1");
            HotkeyManager.Unregister("Shadow_LoadPreset2");
            HotkeyManager.Unregister("Shadow_LoadPreset3");
            HotkeyManager.Unregister("Shadow_LoadPreset4");
            HotkeyManager.Unregister("Shadow_LoadPreset5");

            HotkeyManager.Unregister("Shadow_Potion");
            HotkeyManager.Unregister("Shadow_Buffs");
            HotkeyManager.Unregister("Shadow_Ninjutsu");
            HotkeyManager.Unregister("Shadow_AoE");
            HotkeyManager.Unregister("Shadow_Assassinate");
            HotkeyManager.Unregister("Shadow_Shukuchi");
            HotkeyManager.Unregister("Shadow_Dots");
            HotkeyManager.Unregister("Shadow_Opener");
            HotkeyManager.Unregister("Shadow_DB");
            HotkeyManager.Unregister("Shadow_TenChiJin");
            HotkeyManager.Unregister("Shadow_Shadewalker");
            HotkeyManager.Unregister("Shadow_AutoInterrupt");
            HotkeyManager.Unregister("Shadow_DbSpam");
            HotkeyManager.Unregister("Shadow_TenChiJinSelector");
        }
    }
}