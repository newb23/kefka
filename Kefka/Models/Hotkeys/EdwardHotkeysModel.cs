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
    public class EdwardHotkeysModel : BaseModel
    {
        private static EdwardHotkeysModel _instance;
        public static EdwardHotkeysModel Instance => _instance ?? (_instance = new EdwardHotkeysModel());

        private EdwardHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Edward_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _repellingShot, _potion, _buffs, _miserysEnd, _aoe,
            _foeRequiem, _feint, _interrupt, _dots, _flamingArrow, _sing, _quellingStrikes, _roD, _opener, _peloton, _troubadour, _sidewinder,
            _tactician, _refresh;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _repellingShotModifier,
            _potionModifier, _buffsModifier, _miserysEndModifier, _aoeModifier, _foeRequiemModifier, _feintModifier, _interruptModifier,
            _dotsModifier, _flamingArrowModifier, _singModifier, _quellingStrikesModifier, _roDModifier, _pelotonModifier, _troubadourModifier,
            _openerModifier, _sidewinderModifier, _tacticianModifier, _refreshModifier;

        public EdwardPresetsSettingsModel PresetNames => EdwardPresetsSettingsModel.Instance;

        public EdwardPresetsViewModel PresetCommands => new EdwardPresetsViewModel();

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
        public Keys RepellingShotKey
        {
            get => _repellingShot;
            set { _repellingShot = value; OnPropertyChanged(); }
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
        public Keys MiserysEndKey
        {
            get => _miserysEnd;
            set { _miserysEnd = value; OnPropertyChanged(); }
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
        public ModifierKeys RepellingShotModifier
        {
            get => _repellingShotModifier;
            set { _repellingShotModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys MiserysEndModifier
        {
            get => _miserysEndModifier;
            set { _miserysEndModifier = value; OnPropertyChanged(); }
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
        public Keys FoeRequiemKey
        {
            get => _foeRequiem;
            set { _foeRequiem = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FoeRequiemModifier
        {
            get => _foeRequiemModifier;
            set { _foeRequiemModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys FeintKey
        {
            get => _feint;
            set { _feint = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FeintModifier
        {
            get => _feintModifier;
            set { _feintModifier = value; OnPropertyChanged(); }
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
        public Keys FlamingArrowKey
        {
            get => _flamingArrow;
            set { _flamingArrow = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys FlamingArrowModifier
        {
            get => _flamingArrowModifier;
            set { _flamingArrowModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SingKey
        {
            get => _sing;
            set { _sing = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SingModifier
        {
            get => _singModifier;
            set { _singModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys QuellingStrikesKey
        {
            get => _quellingStrikes;
            set { _quellingStrikes = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys QuellingStrikesModifier
        {
            get => _quellingStrikesModifier;
            set { _quellingStrikesModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RoDKey
        {
            get => _roD;
            set { _roD = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RoDModifier
        {
            get => _roDModifier;
            set { _roDModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys PelotonKey
        {
            get => _peloton;
            set { _peloton = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys PelotonModifier
        {
            get => _pelotonModifier;
            set { _pelotonModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TroubadourKey
        {
            get => _troubadour;
            set { _troubadour = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TroubadourModifier
        {
            get => _troubadourModifier;
            set { _troubadourModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SidewinderKey
        {
            get => _sidewinder;
            set { _sidewinder = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SidewinderModifier
        {
            get => _sidewinderModifier;
            set { _sidewinderModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TacticianKey
        {
            get => _tactician;
            set { _tactician = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TacticianModifier
        {
            get => _tacticianModifier;
            set { _tacticianModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RefreshKey
        {
            get => _refresh;
            set { _refresh = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RefreshModifier
        {
            get => _refreshModifier;
            set { _refreshModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Edward_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EdwardLog($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Edward_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EdwardLog($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Edward_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EdwardLog($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Edward_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EdwardLog($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Edward_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.EdwardLog($"Loading Preset: {EdwardPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Edward_RepellingShot", RepellingShotKey, RepellingShotModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseRepellingShot = !EdwardSettingsModel.Instance.UseRepellingShot;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseRepellingShot ? "Repel Enabled!" : "Repel Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseRepellingShot), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseRepellingShot ? "Repel Enabled!" : "Repel Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Potion", PotionKey, PotionModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseDpsPotion = !EdwardSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseBuffs = !EdwardSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Miserys End", MiserysEndKey, MiserysEndModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseMiserysEnd = !EdwardSettingsModel.Instance.UseMiserysEnd;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseMiserysEnd ? "Misery Enabled!" : "Misery Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseMiserysEnd), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseMiserysEnd ? "Misery Enabled!" : "Misery Disabled!");
                }
            });
            HotkeyManager.Register("Edward_AoE", AoEKey, AoEModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseAoE = !EdwardSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Edward_FoeRequiem", FoeRequiemKey, FoeRequiemModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseFoeRequiem = !EdwardSettingsModel.Instance.UseFoeRequiem;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseFoeRequiem ? "Foe Requiem Enabled!" : "Foe Requiem Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseFoeRequiem), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseFoeRequiem ? "Foe Requiem Enabled!" : "Foe Requiem Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Feint", FeintKey, FeintModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseFeint = !EdwardSettingsModel.Instance.UseFeint;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseFeint ? "Feint Enabled!" : "Feint Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseFeint), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseFeint ? "Feint Enabled!" : "Feint Disabled!");
                }
            });
            HotkeyManager.Register("Edward_AutoInterrupt", InterruptKey, InterruptModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseManualInterrupt = !EdwardSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (EdwardSettingsModel.Instance.UseManualInterrupt)
                        if (EdwardSettingsModel.Instance.UseInterruptList)
                            EdwardSettingsModel.Instance.UseInterruptList = false;

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Dots", DotsKey, DotsModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseDots = !EdwardSettingsModel.Instance.UseDots;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseDots), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseDots ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Edward_FlamingArrow", FlamingArrowKey, FlamingArrowModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseFlamingArrow = !EdwardSettingsModel.Instance.UseFlamingArrow;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseFlamingArrow ? "Flaming Arrow Enabled!" : "Flaming Arrow Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseFlamingArrow), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseFlamingArrow ? "Flaming Arrow Enabled!" : "Flaming Arrow Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Sing", SingKey, SingModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseSongs = !EdwardSettingsModel.Instance.UseSongs;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseSongs ? "Songs Enabled!" : "Songs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseSongs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseSongs ? "Songs Enabled!" : "Songs Disabled!");
                }
            });
            HotkeyManager.Register("Edward_QuellingStrikes", QuellingStrikesKey, QuellingStrikesModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseQuellingStrikes = !EdwardSettingsModel.Instance.UseQuellingStrikes;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseQuellingStrikes ? "Quelling Strikes Enabled!" : "Quelling Strikes Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseQuellingStrikes), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseQuellingStrikes ? "Quelling Strikes Enabled!" : "Quelling Strikes Disabled!");
                }
            });
            HotkeyManager.Register("Edward_RainofDeath", RoDKey, RoDModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseRainofDeath = !EdwardSettingsModel.Instance.UseRainofDeath;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseRainofDeath ? "Rain of Death Enabled!" : "Rain of Death Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseRainofDeath), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseRainofDeath ? "Rain of Death Enabled!" : "Rain of Death Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Opener", OpenerKey, OpenerModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseOpener = !EdwardSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Peloton", PelotonKey, PelotonModifier, hk =>
            {
                EdwardSettingsModel.Instance.UsePeloton = !EdwardSettingsModel.Instance.UsePeloton;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UsePeloton ? "Peloton Enabled!" : "Peloton Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UsePeloton), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UsePeloton ? "Peloton Enabled!" : "Peloton Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Troubadour", TroubadourKey, TroubadourModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseTroubadour = !EdwardSettingsModel.Instance.UseTroubadour;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseTroubadour ? "Troubadour Enabled!" : "Troubadour Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseTroubadour), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseTroubadour ? "Troubadour Enabled!" : "Troubadour Disabled!");
                }
            });
            HotkeyManager.Register("Edward_Sidewinder", SidewinderKey, SidewinderModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseSidewinder = !EdwardSettingsModel.Instance.UseSidewinder;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseSidewinder ? "Sidewinder Enabled!" : "Sidewinder Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseSidewinder), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseSidewinder ? "Sidewinder Enabled!" : "Sidewinder Disabled!");
                }
            });

            HotkeyManager.Register("Edward_Tactician", TacticianKey, TacticianModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseTactician = !EdwardSettingsModel.Instance.UseTactician;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseTactician ? "Tactician Enabled!" : "Tactician Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseTactician), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseTactician ? "Tactician Enabled!" : "Tactician Disabled!");
                }
            });

            HotkeyManager.Register("Edward_Refresh", RefreshKey, RefreshModifier, hk =>
            {
                EdwardSettingsModel.Instance.UseRefresh = !EdwardSettingsModel.Instance.UseRefresh;
                {
                    ToastManager.AddToast(EdwardSettingsModel.Instance.UseRefresh ? "Refresh Enabled!" : "Refresh Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(EdwardSettingsModel.Instance.UseRefresh), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.EdwardLog(EdwardSettingsModel.Instance.UseRefresh ? "Refresh Enabled!" : "Refresh Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Edward_LoadPreset1");
            HotkeyManager.Unregister("Edward_LoadPreset2");
            HotkeyManager.Unregister("Edward_LoadPreset3");
            HotkeyManager.Unregister("Edward_LoadPreset4");
            HotkeyManager.Unregister("Edward_LoadPreset5");

            HotkeyManager.Unregister("Edward_RepellingShot");
            HotkeyManager.Unregister("Edward_Potion");
            HotkeyManager.Unregister("Edward_Buffs");
            HotkeyManager.Unregister("Edward_Miserys End");
            HotkeyManager.Unregister("Edward_AoE");
            HotkeyManager.Unregister("Edward_FoeRequiem");
            HotkeyManager.Unregister("Edward_Feint");
            HotkeyManager.Unregister("Edward_AutoInterrupt");
            HotkeyManager.Unregister("Edward_Dots");
            HotkeyManager.Unregister("Edward_UI");
            HotkeyManager.Unregister("Edward_FlamingArrow");
            HotkeyManager.Unregister("Edward_Sing");
            HotkeyManager.Unregister("Edward_QuellingStrikes");
            HotkeyManager.Unregister("Edward_RainofDeath");
            HotkeyManager.Unregister("Edward_Opener");
            HotkeyManager.Unregister("Edward_Peloton");
            HotkeyManager.Unregister("Edward_Troubadour");
            HotkeyManager.Unregister("Edward_Sidewinder");
            HotkeyManager.Unregister("Edward_Tactician");
            HotkeyManager.Unregister("Edward_Refresh");
        }
    }
}