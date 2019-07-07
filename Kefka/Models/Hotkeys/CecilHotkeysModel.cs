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
    public class CecilHotkeysModel : BaseModel
    {
        private static CecilHotkeysModel _instance;
        public static CecilHotkeysModel Instance => _instance ?? (_instance = new CecilHotkeysModel());

        private CecilHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Cecil_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _awareness, _potion, _tankSwap, _buffs, _unleash, _aoESpam, _interrupt, _darkMind, _shadowWall, _plunge, _darkArts, _livingDead, _busterDefense, _grit, _shit, _opener, _enmityOverride, _damageOverride, _saltedEarth, _unmend, _defensives, _blackestNight, _rampart, _anticipation, _convalescence, _reprisal;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _awarenessModifier, _potionModifier, _tankSwapModifier, _buffsModifier, _unleashModifier, _aoESpamModifier, _defensivesModifier, _interruptModifier, _darkMindModifier, _shadowWallModifier, _plungeModifier, _darkArtsModifier, _livingDeadModifier, _busterDefenseModifier,
            _gritModifier, _shitModifier, _openerModifier, _enmityOverrideModifier, _damageOverrideModifier, _saltedEarthModifier, _unmendModifier, _blackestNightModifier, _rampartModifier, _anticipationModifier, _convalescenceModifier, _reprisalModifier;

        public CecilPresetsSettingsModel PresetNames => CecilPresetsSettingsModel.Instance;

        public CecilPresetsViewModel PresetCommands => new CecilPresetsViewModel();

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
        public Keys BuffsKey
        {
            get => _buffs;
            set { _buffs = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BuffsModifier
        {
            get => _buffsModifier;
            set { _buffsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys UnleashKey
        {
            get => _unleash;
            set { _unleash = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys UnleashModifier
        {
            get => _unleashModifier;
            set { _unleashModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AoESpamKey
        {
            get => _aoESpam;
            set { _aoESpam = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AoESpamModifier
        {
            get => _aoESpamModifier;
            set { _aoESpamModifier = value; OnPropertyChanged(); }
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
        public Keys DarkMindKey
        {
            get => _darkMind;
            set { _darkMind = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DarkMindModifier
        {
            get => _darkMindModifier;
            set { _darkMindModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ShadowWallKey
        {
            get => _shadowWall;
            set { _shadowWall = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ShadowWallModifier
        {
            get => _shadowWallModifier;
            set { _shadowWallModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PlungeKey
        {
            get => _plunge;
            set { _plunge = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PlungeModifier
        {
            get => _plungeModifier;
            set { _plungeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DarkArtsKey
        {
            get => _darkArts;
            set { _darkArts = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DarkArtsModifier
        {
            get => _darkArtsModifier;
            set { _darkArtsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys LivingDeadKey
        {
            get => _livingDead;
            set { _livingDead = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys LivingDeadModifier
        {
            get => _livingDeadModifier;
            set { _livingDeadModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys GritKey
        {
            get => _grit;
            set { _grit = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GritModifier
        {
            get => _gritModifier;
            set { _gritModifier = value; OnPropertyChanged(); }
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
        public Keys EnmityOverrideKey
        {
            get => _enmityOverride;
            set { _enmityOverride = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EnmityOverrideModifier
        {
            get => _enmityOverrideModifier;
            set { _enmityOverrideModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DamageOverrideKey
        {
            get => _damageOverride;
            set { _damageOverride = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DamageOverrideModifier
        {
            get => _damageOverrideModifier;
            set { _damageOverrideModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SaltedEarthKey
        {
            get => _saltedEarth;
            set { _saltedEarth = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SaltedEarthModifier
        {
            get => _saltedEarthModifier;
            set { _saltedEarthModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys UnmendKey
        {
            get => _unmend;
            set { _unmend = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys UnmendModifier
        {
            get => _unmendModifier;
            set { _unmendModifier = value; OnPropertyChanged(); }
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
        public Keys BlackestNightKey
        {
            get => _blackestNight;
            set { _blackestNight = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BlackestNightModifier
        {
            get => _blackestNightModifier;
            set { _blackestNightModifier = value; OnPropertyChanged(); }
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
        public Keys ConvalescenceKey
        {
            get => _convalescence;
            set { _convalescence = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ConvalescenceModifier
        {
            get => _convalescenceModifier;
            set { _convalescenceModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Cecil_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CecilLog($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Cecil_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CecilLog($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Cecil_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CecilLog($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Cecil_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CecilLog($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Cecil_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.CecilLog($"Loading Preset: {CecilPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Cecil_Awareness", AwarenessKey, AwarenessModifier, hk =>
            {
                CecilSettingsModel.Instance.UseAwareness = !CecilSettingsModel.Instance.UseAwareness;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseAwareness), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_Potion", PotionKey, PotionModifier, hk =>
            {
                CecilSettingsModel.Instance.UseDpsPotion = !CecilSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_TankSwap", TankSwapKey, TankSwapModifier, hk =>
            {
                CecilSettingsModel.Instance.Swap = !CecilSettingsModel.Instance.Swap;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.Swap ? "Tank Swap Enabled!" : "Tank Swap Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.Swap), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.Swap ? "Tank Swap Enabled!" : "Tank Swap Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                CecilSettingsModel.Instance.UseBuffs = !CecilSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_Unleash", UnleashKey, UnleashModifier, hk =>
            {
                CecilSettingsModel.Instance.UseUnleash = !CecilSettingsModel.Instance.UseUnleash;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseUnleash ? "Unleash Enabled!" : "Unleash Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseUnleash), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseUnleash ? "Unleash Enabled!" : "Unleash Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_Defensives", DefensivesKey, DefensivesModifier, hk =>
            {
                CecilSettingsModel.Instance.UseDefensives = !CecilSettingsModel.Instance.UseDefensives;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseDefensives), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_AutoInterrupt", InterruptKey, InterruptModifier, hk =>
            {
                CecilSettingsModel.Instance.UseManualInterrupt = !CecilSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (CecilSettingsModel.Instance.UseManualInterrupt)
                        if (CecilSettingsModel.Instance.UseInterruptList)
                            CecilSettingsModel.Instance.UseInterruptList = false;

                    Logger.CecilLog(CecilSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_DarkMind", DarkMindKey, DarkMindModifier, hk =>
            {
                CecilSettingsModel.Instance.UseDarkMind = !CecilSettingsModel.Instance.UseDarkMind;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseDarkMind ? "Dark Mind Enabled!" : "Dark Mind Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseDarkMind), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseDarkMind ? "Dark Mind Enabled!" : "Dark Mind Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_ShadowWall", ShadowWallKey, ShadowWallModifier, hk =>
            {
                CecilSettingsModel.Instance.UseShadowWall = !CecilSettingsModel.Instance.UseShadowWall;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseShadowWall ? "Shadow Wall Enabled!" : "Shadow Wall Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseShadowWall), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseShadowWall ? "Shadow Wall Enabled!" : "Shadow Wall Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_ArmoftheDestoyer", PlungeKey, PlungeModifier, hk =>
            {
                CecilSettingsModel.Instance.UsePlunge = !CecilSettingsModel.Instance.UsePlunge;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UsePlunge ? "Plunge Enabled!" : "Plunge Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UsePlunge), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UsePlunge ? "Plunge Enabled!" : "Plunge Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_DarkArts", DarkArtsKey, DarkArtsModifier, hk =>
            {
                CecilSettingsModel.Instance.UseDarkArts = !CecilSettingsModel.Instance.UseDarkArts;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseDarkArts ? "Dark Arts Enabled!" : "Dark Arts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseDarkArts), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseDarkArts ? "Dark Arts Enabled!" : "Dark Arts Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_LivingDead", LivingDeadKey, LivingDeadModifier, hk =>
            {
                CecilSettingsModel.Instance.UseLivingDead = !CecilSettingsModel.Instance.UseLivingDead;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseLivingDead ? "Living Dead Enabled!" : "Living Dead Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseLivingDead), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseLivingDead ? "Living Dead Enabled!" : "Living Dead Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_BusterDefense", BusterDefenseKey, BusterDefenseModifier, hk =>
            {
                CecilSettingsModel.Instance.UseBusterDefense = !CecilSettingsModel.Instance.UseBusterDefense;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseBusterDefense), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Grit", GritKey, GritModifier, hk =>
            {
                CecilSettingsModel.Instance.UseGrit = !CecilSettingsModel.Instance.UseGrit;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseGrit ? "Grit Enabled!" : "Grit Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseGrit), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseGrit ? "Grit Enabled!" : "Grit Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Opener", OpenerKey, OpenerModifier, hk =>
            {
                CecilSettingsModel.Instance.UseOpener = !CecilSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_SaltedEarth", SaltedEarthKey, SaltedEarthModifier, hk =>
            {
                CecilSettingsModel.Instance.UseSaltedEarth = !CecilSettingsModel.Instance.UseSaltedEarth;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseSaltedEarth ? "Salted Earth Enabled!" : "Salted Earth Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseSaltedEarth), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseSaltedEarth ? "Salted Earth Enabled!" : "Salted Earth Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_AoESpam", AoESpamKey, AoESpamModifier, hk =>
            {
                CecilSettingsModel.Instance.AoESpam = !CecilSettingsModel.Instance.AoESpam;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.AoESpam ? "AoE Spam Enabled!" : "AoE Spam Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.AoESpam), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.AoESpam ? "AoE Spam Enabled!" : "AoE Spam Disabled!");
                }
            });
            HotkeyManager.Register("Cecil_Unmend", UnmendKey, UnmendModifier, hk =>
            {
                CecilSettingsModel.Instance.UseUnmend = !CecilSettingsModel.Instance.UseUnmend;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseUnmend ? "Unmend Enabled!" : "Unmend Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseUnmend), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseUnmend ? "Unmend Enabled!" : "Unmend Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_BlackestNight", BlackestNightKey, BlackestNightModifier, hk =>
            {
                CecilSettingsModel.Instance.UseBlackestNight = !CecilSettingsModel.Instance.UseBlackestNight;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseBlackestNight ? "Blackest Night Enabled!" : "Blackest Night Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseBlackestNight), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseBlackestNight ? "Blackest Night Enabled!" : "Blackest Night Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Rampart", RampartKey, RampartModifier, hk =>
            {
                CecilSettingsModel.Instance.UseRampart = !CecilSettingsModel.Instance.UseRampart;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseRampart), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Anticipation", AnticipationKey, AnticipationModifier, hk =>
            {
                CecilSettingsModel.Instance.UseAnticipation = !CecilSettingsModel.Instance.UseAnticipation;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseAnticipation), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Convalescence", ConvalescenceKey, ConvalescenceModifier, hk =>
            {
                CecilSettingsModel.Instance.UseConvalescence = !CecilSettingsModel.Instance.UseConvalescence;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseConvalescence), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!");
                }
            });

            HotkeyManager.Register("Cecil_Reprisal", ReprisalKey, ReprisalModifier, hk =>
            {
                CecilSettingsModel.Instance.UseReprisal = !CecilSettingsModel.Instance.UseReprisal;
                {
                    ToastManager.AddToast(CecilSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(CecilSettingsModel.Instance.UseReprisal), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.CecilLog(CecilSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Cecil_LoadPreset1");
            HotkeyManager.Unregister("Cecil_LoadPreset2");
            HotkeyManager.Unregister("Cecil_LoadPreset3");
            HotkeyManager.Unregister("Cecil_LoadPreset4");
            HotkeyManager.Unregister("Cecil_LoadPreset5");

            HotkeyManager.Unregister("Cecil_Potion");
            HotkeyManager.Unregister("Cecil_TankSwap");
            HotkeyManager.Unregister("Cecil_Buffs");
            HotkeyManager.Unregister("Cecil_Unleash");

            HotkeyManager.Unregister("Cecil_AutoInterrupt");
            HotkeyManager.Unregister("Cecil_Convalescence");
            HotkeyManager.Unregister("Cecil_DarkMind");
            HotkeyManager.Unregister("Cecil_ShadowWall");
            HotkeyManager.Unregister("Cecil_Plunge");
            HotkeyManager.Unregister("Cecil_UI");
            HotkeyManager.Unregister("Cecil_DarkArts");
            HotkeyManager.Unregister("Cecil_LivingDead");
            HotkeyManager.Unregister("Cecil_BusterDefense");
            HotkeyManager.Unregister("Cecil_Grit");
            HotkeyManager.Unregister("Cecil_Shit");
            HotkeyManager.Unregister("Cecil_Opener");
            HotkeyManager.Unregister("Cecil_EnmityOverride");
            HotkeyManager.Unregister("Cecil_DamageOverride");
            HotkeyManager.Unregister("Cecil_SaltedEarth");
            HotkeyManager.Unregister("Cecil_AoESpam");
            HotkeyManager.Unregister("Cecil_Unmend");
            HotkeyManager.Unregister("Cecil_Defensives");
            HotkeyManager.Unregister("Cecil_Rampart");
            HotkeyManager.Unregister("Cecil_Anticipation");
            HotkeyManager.Unregister("Cecil_Convalescence");
            HotkeyManager.Unregister("Cecil_Awareness");
            HotkeyManager.Unregister("Cecil_Reprisal");
        }
    }
}