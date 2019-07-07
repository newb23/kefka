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
    public class PaineHotkeysModel : BaseModel
    {
        private static PaineHotkeysModel _instance;
        public static PaineHotkeysModel Instance => _instance ?? (_instance = new PaineHotkeysModel());

        private PaineHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Paine_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _tankSwap, _awareness, _potion, _buffs, _tomahawk, _defensives, _autoInterrupt, _convalescence, _thrillofBattle, _vengeance, _opener, _berserk, _onslaught, _innerBeast, _equilibrium, _holmgang, _busterDefense, _provoke, _deliverance, _overpowerSpam, _mainTank, _damageOverride, _rampart, _anticipation, _reprisal;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _tankSwapModifier, _awarenessModifier, _potionModifier, _buffsModifier, _tomahawkModifier, _defensivesModifier, _autoInterruptModifier, _convalescenceModifier, _thrillofBattleModifier, _vengeanceModifier, _openerModifier, _berserkModifier, _onslaughtModifier, _innerBeastModifier, _equilibriumModifier, _holmgangModifier,
            _busterDefenseModifier, _provokeModifier, _deliveranceModifier, _overpowerSpamModifier, _mainTankModifier, _damageOverrideModifier, _rampartModifier, _anticipationModifier, _reprisalModifier;

        public PainePresetsSettingsModel PresetNames => PainePresetsSettingsModel.Instance;

        public PainePresetsViewModel PresetCommands => new PainePresetsViewModel();

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
        public Keys OverpowerSpamKey
        {
            get => _overpowerSpam;
            set
            {
                _overpowerSpam = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OverpowerSpamModifier
        {
            get => _overpowerSpamModifier;
            set
            {
                _overpowerSpamModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AwarenessKey
        {
            get => _awareness;
            set
            {
                _awareness = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PotionKey
        {
            get => _potion;
            set
            {
                _potion = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BuffsKey
        {
            get => _buffs;
            set
            {
                _buffs = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TomahawkKey
        {
            get => _tomahawk;
            set
            {
                _tomahawk = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AwarenessModifier
        {
            get => _awarenessModifier;
            set
            {
                _awarenessModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PotionModifier
        {
            get => _potionModifier;
            set
            {
                _potionModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BuffsModifier
        {
            get => _buffsModifier;
            set
            {
                _buffsModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TomahawkModifier
        {
            get => _tomahawkModifier;
            set
            {
                _tomahawkModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DefensivesKey
        {
            get => _defensives;
            set
            {
                _defensives = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DefensivesModifier
        {
            get => _defensivesModifier;
            set
            {
                _defensivesModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AutoInterruptKey
        {
            get => _autoInterrupt;
            set
            {
                _autoInterrupt = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AutoInterruptModifier
        {
            get => _autoInterruptModifier;
            set
            {
                _autoInterruptModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ConvalescenceKey
        {
            get => _convalescence;
            set
            {
                _convalescence = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ConvalescenceModifier
        {
            get => _convalescenceModifier;
            set
            {
                _convalescenceModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ThrillofBattleKey
        {
            get => _thrillofBattle;
            set
            {
                _thrillofBattle = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ThrillofBattleModifier
        {
            get => _thrillofBattleModifier;
            set
            {
                _thrillofBattleModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BusterDefenseKey
        {
            get => _busterDefense;
            set
            {
                _busterDefense = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BusterDefenseModifier
        {
            get => _busterDefenseModifier;
            set
            {
                _busterDefenseModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys VengeanceKey
        {
            get => _vengeance;
            set
            {
                _vengeance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys VengeanceModifier
        {
            get => _vengeanceModifier;
            set
            {
                _vengeanceModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OpenerKey
        {
            get => _opener;
            set
            {
                _opener = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OpenerModifier
        {
            get => _openerModifier;
            set
            {
                _openerModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys BerserkKey
        {
            get => _berserk;
            set
            {
                _berserk = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BerserkModifier
        {
            get => _berserkModifier;
            set
            {
                _berserkModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OnslaughtKey
        {
            get => _onslaught;
            set
            {
                _onslaught = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OnslaughtModifier
        {
            get => _onslaughtModifier;
            set
            {
                _onslaughtModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys InnerBeastKey
        {
            get => _innerBeast;
            set
            {
                _innerBeast = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys InnerBeastModifier
        {
            get => _innerBeastModifier;
            set
            {
                _innerBeastModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys EquilibriumKey
        {
            get => _equilibrium;
            set
            {
                _equilibrium = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EquilibriumModifier
        {
            get => _equilibriumModifier;
            set
            {
                _equilibriumModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys HolmgangKey
        {
            get => _holmgang;
            set
            {
                _holmgang = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys HolmgangModifier
        {
            get => _holmgangModifier;
            set
            {
                _holmgangModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys ProvokeKey
        {
            get => _provoke;
            set
            {
                _provoke = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys ProvokeModifier
        {
            get => _provokeModifier;
            set
            {
                _provokeModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DeliveranceKey
        {
            get => _deliverance;
            set
            {
                _deliverance = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DeliveranceModifier
        {
            get => _deliveranceModifier;
            set
            {
                _deliveranceModifier = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MainTankKey
        {
            get => _mainTank;
            set
            {
                _mainTank = value;
                OnPropertyChanged();
            }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MainTankModifier
        {
            get => _mainTankModifier;
            set
            {
                _mainTankModifier = value;
                OnPropertyChanged();
            }
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

        public void RegisterAll()
        {
            HotkeyManager.Register("Paine_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.PaineLog($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Paine_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.PaineLog($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Paine_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.PaineLog($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Paine_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.PaineLog($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Paine_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.PaineLog($"Loading Preset: {PainePresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Paine_Potion", PotionKey, PotionModifier, hk =>
            {
                PaineSettingsModel.Instance.UseDpsPotion = !PaineSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                PaineSettingsModel.Instance.UseBuffs = !PaineSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Tomahawk", TomahawkKey, TomahawkModifier, hk =>
            {
                PaineSettingsModel.Instance.UseTomahawk = !PaineSettingsModel.Instance.UseTomahawk;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseTomahawk ? "Tomahawk Enabled!" : "Tomahawk Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseTomahawk), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseTomahawk ? "Tomahawk Enabled!" : "Tomahawk Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Defensives", DefensivesKey, DefensivesModifier, hk =>
            {
                PaineSettingsModel.Instance.UseDefensives = !PaineSettingsModel.Instance.UseDefensives;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseDefensives), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!");
                }
            });
            HotkeyManager.Register("Paine_AutoInterrupt", AutoInterruptKey, AutoInterruptModifier, hk =>
            {
                PaineSettingsModel.Instance.UseManualInterrupt = !PaineSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (PaineSettingsModel.Instance.UseManualInterrupt)
                        if (PaineSettingsModel.Instance.UseInterruptList)
                            PaineSettingsModel.Instance.UseInterruptList = false;

                    Logger.PaineLog(PaineSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Paine_TankSwap", TankSwapKey, TankSwapModifier, hk =>
            {
                PaineSettingsModel.Instance.Swap = !PaineSettingsModel.Instance.Swap;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.Swap ? "Swap Enabled!" : "Swap Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.Swap), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.Swap ? "Swap Enabled!" : "Swap Disabled!");
                }
            });
            HotkeyManager.Register("Paine_ThrillofBattle", ThrillofBattleKey, ThrillofBattleModifier, hk =>
            {
                PaineSettingsModel.Instance.UseThrillofBattle = !PaineSettingsModel.Instance.UseThrillofBattle;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseThrillofBattle ? "Thrill of Battle Enabled!" : "Thrill of Battle Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseThrillofBattle), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseThrillofBattle ? "Thrill of Battle Enabled!" : "Thrill of Battle Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Vengeance", VengeanceKey, VengeanceModifier, hk =>
            {
                PaineSettingsModel.Instance.UseVengeance = !PaineSettingsModel.Instance.UseVengeance;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseVengeance ? "Vengeance Enabled!" : "Vengeance Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseVengeance), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseVengeance ? "Vengeance Enabled!" : "Vengeance Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Opener", OpenerKey, OpenerModifier, hk =>
            {
                PaineSettingsModel.Instance.UseOpener = !PaineSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Berserk", BerserkKey, BerserkModifier, hk =>
            {
                PaineSettingsModel.Instance.UseBerserk = !PaineSettingsModel.Instance.UseBerserk;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseBerserk ? "Berserk Enabled!" : "Berserk Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseBerserk), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseBerserk ? "Berserk Enabled!" : "Berserk Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Onslaught", OnslaughtKey, OnslaughtModifier, hk =>
            {
                PaineSettingsModel.Instance.UseOnslaught = !PaineSettingsModel.Instance.UseOnslaught;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseOnslaught ? "Onslaught Enabled!" : "Onslaught Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseOnslaught), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseOnslaught ? "Onslaught Enabled!" : "Onslaught Disabled!");
                }
            });
            HotkeyManager.Register("Paine_innerBeast", InnerBeastKey, InnerBeastModifier, hk =>
            {
                PaineSettingsModel.Instance.UseInnerBeast = !PaineSettingsModel.Instance.UseInnerBeast;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseInnerBeast ? "Inner Beast Enabled!" : "Inner Beast Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseInnerBeast), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseInnerBeast ? "Inner Beast Enabled!" : "Inner Beast Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Equilibrium", EquilibriumKey, EquilibriumModifier, hk =>
            {
                PaineSettingsModel.Instance.UseEquilibrium = !PaineSettingsModel.Instance.UseEquilibrium;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseEquilibrium ? "Equilibrium Enabled!" : "Equilibrium Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseEquilibrium), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseEquilibrium ? "Equilibrium Enabled!" : "Equilibrium Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Holmgang", HolmgangKey, HolmgangModifier, hk =>
            {
                PaineSettingsModel.Instance.UseHolmgang = !PaineSettingsModel.Instance.UseHolmgang;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseHolmgang ? "Holmgang Enabled!" : "Holmgang Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseHolmgang), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseHolmgang ? "Holmgang Enabled!" : "Holmgang Disabled!");
                }
            });
            HotkeyManager.Register("Paine_BusterDefense", BusterDefenseKey, BusterDefenseModifier, hk =>
            {
                PaineSettingsModel.Instance.UseBusterDefense = !PaineSettingsModel.Instance.UseBusterDefense;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseBusterDefense), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseBusterDefense ? "Buster Defense Enabled!" : "Buster Defense Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Provoke", ProvokeKey, ProvokeModifier, hk =>
            {
                PaineSettingsModel.Instance.UseProvoke = !PaineSettingsModel.Instance.UseProvoke;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseProvoke ? "Provoke Enabled!" : "Provoke Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseProvoke), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseProvoke ? "Provoke Enabled!" : "Provoke Disabled!");
                }
            });
            HotkeyManager.Register("Paine_Deliverance", DeliveranceKey, DeliveranceModifier, hk =>
            {
                PaineSettingsModel.Instance.UseDeliverance = !PaineSettingsModel.Instance.UseDeliverance;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseDeliverance ? "Deliverance Enabled!" : "Defiance Enabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseDeliverance), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseDeliverance ? "Deliverance Enabled!" : "Defiance Enabled!");
                }
            });
            HotkeyManager.Register("Paine_MainTank", MainTankKey, MainTankModifier, hk =>
            {
                PaineSettingsModel.Instance.MainTank = !PaineSettingsModel.Instance.MainTank;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.MainTank ? "Enmity Override Enabled!" : "Enmity Override Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.MainTank), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.MainTank ? "Enmity Override Enabled!" : "Enmity Override Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Rampart", RampartKey, RampartModifier, hk =>
            {
                PaineSettingsModel.Instance.UseRampart = !PaineSettingsModel.Instance.UseRampart;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseRampart), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseRampart ? "Rampart Enabled!" : "Rampart Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Anticipation", AnticipationKey, AnticipationModifier, hk =>
            {
                PaineSettingsModel.Instance.UseAnticipation = !PaineSettingsModel.Instance.UseAnticipation;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseAnticipation), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseAnticipation ? "Anticipation Enabled!" : "Anticipation Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Awareness", AwarenessKey, AwarenessModifier, hk =>
            {
                PaineSettingsModel.Instance.UseAwareness = !PaineSettingsModel.Instance.UseAwareness;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseAwareness), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseAwareness ? "Awareness Enabled!" : "Awareness Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Convalescence", ConvalescenceKey, ConvalescenceModifier, hk =>
            {
                PaineSettingsModel.Instance.UseConvalescence = !PaineSettingsModel.Instance.UseConvalescence;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseConvalescence), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseConvalescence ? "Convalescence Enabled!" : "Convalescence Disabled!");
                }
            });

            HotkeyManager.Register("Paine_Reprisal", ReprisalKey, ReprisalModifier, hk =>
            {
                PaineSettingsModel.Instance.UseReprisal = !PaineSettingsModel.Instance.UseReprisal;
                {
                    ToastManager.AddToast(PaineSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(PaineSettingsModel.Instance.UseReprisal), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.PaineLog(PaineSettingsModel.Instance.UseReprisal ? "Reprisal Enabled!" : "Reprisal Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Paine_LoadPreset1");
            HotkeyManager.Unregister("Paine_LoadPreset2");
            HotkeyManager.Unregister("Paine_LoadPreset3");
            HotkeyManager.Unregister("Paine_LoadPreset4");
            HotkeyManager.Unregister("Paine_LoadPreset5");

            HotkeyManager.Unregister("Paine_TankSwap");
            HotkeyManager.Unregister("Paine_Awareness");
            HotkeyManager.Unregister("Paine_Potion");
            HotkeyManager.Unregister("Paine_Buffs");
            HotkeyManager.Unregister("Paine_StormsPath");
            HotkeyManager.Unregister("Paine_Tomahawk");
            HotkeyManager.Unregister("Paine_Defensives");
            HotkeyManager.Unregister("Paine_AutoInterrupt");
            HotkeyManager.Unregister("Paine_Convalescence");
            HotkeyManager.Unregister("Paine_ThrillofBattle");
            HotkeyManager.Unregister("Paine_Vengeance");
            HotkeyManager.Unregister("Paine_Opener");
            HotkeyManager.Unregister("Paine_UI");
            HotkeyManager.Unregister("Paine_Berserk");
            HotkeyManager.Unregister("Paine_Onslaught");
            HotkeyManager.Unregister("Paine_innerBeast");
            HotkeyManager.Unregister("Paine_Equilibrium");
            HotkeyManager.Unregister("Paine_Holmgang");
            HotkeyManager.Unregister("Paine_BusterDefense");
            HotkeyManager.Unregister("Paine_Provoke");
            HotkeyManager.Unregister("Paine_Deliverance");
            HotkeyManager.Unregister("Paine_MainTank");
            HotkeyManager.Unregister("Paine_Rampart");
            HotkeyManager.Unregister("Paine_Anticipation");
            HotkeyManager.Unregister("Paine_Reprisal");
        }
    }
}