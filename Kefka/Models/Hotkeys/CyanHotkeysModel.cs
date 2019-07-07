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
    public class CyanHotkeysModel : BaseModel
    {
        private static CyanHotkeysModel _instance;
        public static CyanHotkeysModel Instance => _instance ?? (_instance = new CyanHotkeysModel());

        private CyanHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Cyan_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _goad, _potion, _buffs, _ninjutsu, _aoe, _ageha, _shukuchi, _dots, _seigan, _opener, _iaijutsu, _guren, _shadewalker, _autoInterrupt, _meditation;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _goadModifier, _potionModifier,
            _buffsModifier, _ninjutsuModifier, _aoeModifier, _agehaModifier, _shukuchiModifier, _dotsModifier, _seiganModifier, _openerModifier, _iaijutsuModifier,
            _gurenModifier, _shadewalkerModifier, _autoInterruptModifier, _meditationModifier;

        public CyanPresetsSettingsModel PresetNames => CyanPresetsSettingsModel.Instance;

        public CyanPresetsViewModel PresetCommands => new CyanPresetsViewModel();

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
        public Keys GoadKey
        {
            get => _goad;
            set { _goad = value; OnPropertyChanged(); }
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
        public ModifierKeys GoadModifier
        {
            get => _goadModifier;
            set { _goadModifier = value; OnPropertyChanged(); }
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
        public Keys AgehaKey
        {
            get => _ageha;
            set { _ageha = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AgehaModifier
        {
            get => _agehaModifier;
            set { _agehaModifier = value; OnPropertyChanged(); }
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
        public Keys GurenKey
        {
            get => _guren;
            set { _guren = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GurenModifier
        {
            get => _gurenModifier;
            set { _gurenModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SeiganKey
        {
            get => _seigan;
            set { _seigan = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SeiganModifier
        {
            get => _seiganModifier;
            set { _seiganModifier = value; OnPropertyChanged(); }
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
        public Keys IaijutsuKey
        {
            get => _iaijutsu;
            set { _iaijutsu = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys IaijutsuModifier
        {
            get => _iaijutsuModifier;
            set { _iaijutsuModifier = value; OnPropertyChanged(); }
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
        public Keys MeditiationKey
        {
            get => _meditation;
            set { _meditation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MeditationModifier
        {
            get => _meditationModifier;
            set { _meditationModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Cyan_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CyanLog($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Cyan_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CyanLog($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Cyan_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CyanLog($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Cyan_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CyanLog($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Cyan_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CyanLog($"Loading Preset: {CyanPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Cyan_Goad", GoadKey, GoadModifier, hk =>
            {
                CyanSettingsModel.Instance.UseManualGoad = !CyanSettingsModel.Instance.UseManualGoad;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseManualGoad ? "Goad Enabled!" : "Goad Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseManualGoad), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (CyanSettingsModel.Instance.UseManualGoad)
                        if (CyanSettingsModel.Instance.UseGoadTarget)
                            CyanSettingsModel.Instance.UseGoadTarget = false;

                    Logger.CyanLog(CyanSettingsModel.Instance.UseManualGoad ? "Goad Enabled!" : "Goad Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Potion", PotionKey, PotionModifier, hk =>
            {
                CyanSettingsModel.Instance.UseDpsPotion = !CyanSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseDpsPotion ? "DPS Potion Enabled!" : "DPS Potion Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseDpsPotion ? "DPS Potion Enabled!" : "DPS Potion Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                CyanSettingsModel.Instance.UseBuffs = !CyanSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Ninjutsu", NinjutsuKey, NinjutsuModifier, hk =>
            {
                CyanSettingsModel.Instance.UseNinjutsu = !CyanSettingsModel.Instance.UseNinjutsu;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseNinjutsu ? "Ninjutsu Enabled!" : "Ninjutsu Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseNinjutsu), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseNinjutsu ? "Ninjutsu Enabled!" : "Ninjutsu Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_AoE", AoEKey, AoEModifier, hk =>
            {
                CyanSettingsModel.Instance.UseAoE = !CyanSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseAoE ? "AoEs Enabled!" : "AoEs Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Ageha", AgehaKey, AgehaModifier, hk =>
            {
                CyanSettingsModel.Instance.UseAgeha = !CyanSettingsModel.Instance.UseAgeha;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseAgeha ? "Ageha Enabled!" : "Ageha Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseAgeha), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseAgeha ? "Ageha Enabled!" : "Ageha Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Shukuchi", ShukuchiKey, ShukuchiModifier, hk =>
            {
                CyanSettingsModel.Instance.UseShukuchi = !CyanSettingsModel.Instance.UseShukuchi;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseShukuchi ? "Shukuchi Enabled!" : "Shukuchi Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseShukuchi), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseShukuchi ? "Shukuchi Enabled!" : "Shukuchi Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Dots", DotsKey, DotsModifier, hk =>
            {
                CyanSettingsModel.Instance.UseDots = !CyanSettingsModel.Instance.UseDots;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseDots), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Seigan", SeiganKey, SeiganModifier, hk =>
            {
                CyanSettingsModel.Instance.UseSeigan = !CyanSettingsModel.Instance.UseSeigan;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseSeigan ? "Seigan Enabled!" : "Seigan Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseSeigan), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseSeigan ? "Seigan Enabled!" : "Seigan Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Opener", OpenerKey, OpenerModifier, hk =>
            {
                CyanSettingsModel.Instance.UseOpener = !CyanSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Guren", GurenKey, GurenModifier, hk =>
            {
                CyanSettingsModel.Instance.UseGuren = !CyanSettingsModel.Instance.UseGuren;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseGuren ? "Guren Enabled!" : "Guren Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseGuren), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseGuren ? "Guren Enabled!" : "Guren Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Iaijutsu", IaijutsuKey, IaijutsuModifier, hk =>
            {
                CyanSettingsModel.Instance.UseIaijutsu = !CyanSettingsModel.Instance.UseIaijutsu;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseIaijutsu ? "Iaijutsu Enabled!" : "Iaijutsu Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseMercifulEyes), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CyanLog(CyanSettingsModel.Instance.UseIaijutsu ? "Iaijutsu Enabled!" : "Iaijutsu Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Shadewalker", ShadewalkerKey, ShadewalkerModifier, hk =>
            {
                CyanSettingsModel.Instance.UseManualShadewalker = !CyanSettingsModel.Instance.UseManualShadewalker;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseManualShadewalker ? "Shadewalker Enabled!" : "Shadewalker Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseManualShadewalker), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (CyanSettingsModel.Instance.UseManualShadewalker)
                        if (CyanSettingsModel.Instance.UseShadewalkerTarget)
                            CyanSettingsModel.Instance.UseShadewalkerTarget = false;

                    Logger.CyanLog(CyanSettingsModel.Instance.UseManualShadewalker ? "Shadewalker Enabled!" : "Shadewalker Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_AutoInterrupt", AutoInterruptKey, AutoInterruptModifier, hk =>
            {
                CyanSettingsModel.Instance.UseManualInterrupt = !CyanSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(CyanSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CyanSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (CyanSettingsModel.Instance.UseManualInterrupt)
                        if (CyanSettingsModel.Instance.UseInterruptList)
                            CyanSettingsModel.Instance.UseInterruptList = false;

                    Logger.CyanLog(CyanSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Cyan_Meditation", MeditiationKey, MeditationModifier, hk =>
            {
                {
                    ToastManager.AddToast("Meditation!", TimeSpan.FromMilliseconds(750), Colors.LimeGreen, Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                    Logger.CyanLog("Meditation");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Cyan_LoadPreset1");
            HotkeyManager.Unregister("Cyan_LoadPreset2");
            HotkeyManager.Unregister("Cyan_LoadPreset3");
            HotkeyManager.Unregister("Cyan_LoadPreset4");
            HotkeyManager.Unregister("Cyan_LoadPreset5");

            HotkeyManager.Unregister("Cyan_Goad");
            HotkeyManager.Unregister("Cyan_Potion");
            HotkeyManager.Unregister("Cyan_Buffs");
            HotkeyManager.Unregister("Cyan_Ninjutsu");
            HotkeyManager.Unregister("Cyan_AoE");
            HotkeyManager.Unregister("Cyan_Ageha");
            HotkeyManager.Unregister("Cyan_Shukuchi");
            HotkeyManager.Unregister("Cyan_Dots");
            HotkeyManager.Unregister("Cyan_Seigan");
            HotkeyManager.Unregister("Cyan_Opener");
            HotkeyManager.Unregister("Cyan_Guren");
            HotkeyManager.Unregister("Cyan_UI");
            HotkeyManager.Unregister("Cyan_Iaijutsu");
            HotkeyManager.Unregister("Cyan_Shadewalker");
            HotkeyManager.Unregister("Cyan_AutoInterrupt");
            HotkeyManager.Unregister("Cyan_Meditation");
        }
    }
}