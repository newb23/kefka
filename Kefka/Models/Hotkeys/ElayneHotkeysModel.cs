using ff14bot;
using Kefka.Utilities;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using HotkeyManager = ff14bot.Managers.HotkeyManager;

namespace Kefka.Models
{
    public class ElayneHotkeysModel : BaseModel
    {
        private static ElayneHotkeysModel _instance;
        public static ElayneHotkeysModel Instance => _instance ?? (_instance = new ElayneHotkeysModel());

        private ElayneHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Elayne_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _contreSixte, _potion, _buffs, _displacement, _aoe, _swiftcast, _dots, _opener, _vercure, _embolden, _corpsacorps, _melee, _diversion, _verraise;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _contreSixteModifier, _potionModifier, _buffsModifier, _displacementModifier, _aoeModifier, _diversionModifier,
            _swiftcastModifier, _dotsModifier, _openerModifier, _vercureModifier, _emboldenModifier, _corpsacorpsModifier, _meleeModifier, _verraiseModifier;

        public ElaynePresetsSettingsModel PresetNames => ElaynePresetsSettingsModel.Instance;

        public ElaynePresetsViewModel PresetCommands => new ElaynePresetsViewModel();

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
        public Keys ContreSixteKey
        {
            get => _contreSixte;
            set { _contreSixte = value; OnPropertyChanged(); }
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
        public Keys DisplacementKey
        {
            get => _displacement;
            set { _displacement = value; OnPropertyChanged(); }
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
        public ModifierKeys ContreSixteModifier
        {
            get => _contreSixteModifier;
            set { _contreSixteModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys DisplacementModifier
        {
            get => _displacementModifier;
            set { _displacementModifier = value; OnPropertyChanged(); }
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
        public Keys VercureKey
        {
            get => _vercure;
            set { _vercure = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys VercureModifier
        {
            get => _vercureModifier;
            set { _vercureModifier = value; OnPropertyChanged(); }
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
        public Keys EmboldenKey
        {
            get => _embolden;
            set { _embolden = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EmboldenModifier
        {
            get => _emboldenModifier;
            set { _emboldenModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys CorpsacorpsKey
        {
            get => _corpsacorps;
            set { _corpsacorps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CorpsacorpsModifier
        {
            get => _corpsacorpsModifier;
            set { _corpsacorpsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys MeleeKey
        {
            get => _melee;
            set { _melee = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MeleeModifier
        {
            get => _meleeModifier;
            set { _meleeModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys DiversionKey
        {
            get => _diversion;
            set { _diversion = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys DiversionModifier
        {
            get => _diversionModifier;
            set { _diversionModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys VerraiseKey
        {
            get => _verraise;
            set { _verraise = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys VerraiseModifier
        {
            get => _verraiseModifier;
            set { _verraiseModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Elayne_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ElayneLog($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Elayne_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ElayneLog($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Elayne_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ElayneLog($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Elayne_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ElayneLog($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Elayne_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.ElayneLog($"Loading Preset: {ElaynePresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Elayne_ContraSixte", ContreSixteKey, ContreSixteModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseContraSixte = !ElayneSettingsModel.Instance.UseContraSixte;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseContraSixte ? "Contra Sixte Enabled!" : "Contra Sixte Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseContraSixte), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseContraSixte ? "Contra Sixte Enabled!" : "Contra Sixte Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_Potion", PotionKey, PotionModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseDpsPotion = !ElayneSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseBuffs = !ElayneSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_AoE", AoEKey, AoEModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseAoE = !ElayneSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_Swiftcast", SwiftcastKey, SwiftcastModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseSwiftcast = !ElayneSettingsModel.Instance.UseSwiftcast;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseSwiftcast), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseSwiftcast ? "Swiftcast Enabled!" : "Swiftcast Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_DoTs", DoTsKey, DoTsModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseDoTs = !ElayneSettingsModel.Instance.UseDoTs;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseDoTs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_Opener", OpenerKey, OpenerModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseOpener = !ElayneSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_Embolden", EmboldenKey, EmboldenModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseEmbolden = !ElayneSettingsModel.Instance.UseEmbolden;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseEmbolden ? "Embolden Enabled!" : "Embolden Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseEmbolden), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseEmbolden ? "Embolden Enabled!" : "Embolden Disabled!");
                }
            });
            HotkeyManager.Register("Elayne_CorpsaCorps", CorpsacorpsKey, CorpsacorpsModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseCorpsacorps = !ElayneSettingsModel.Instance.UseCorpsacorps;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseCorpsacorps ? "Corps-a-Corps Enabled!" : "Corps-a-Corps Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseEmbolden), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseCorpsacorps ? "Corps-a-Corps Enabled!" : "Corps-a-Corps Disabled!");
                }
            });

            HotkeyManager.Register("Elayne_Displacement", DisplacementKey, DisplacementModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseDisplacement = !ElayneSettingsModel.Instance.UseDisplacement;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseDisplacement ? "Displacement Enabled!" : "Displacement Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseEmbolden), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseDisplacement ? "Displacement Enabled!" : "Displacement Disabled!");
                }
            });

            HotkeyManager.Register("Elayne_Melee", MeleeKey, MeleeModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseMelee = !ElayneSettingsModel.Instance.UseMelee;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseMelee ? "Melee Enabled!" : "Melee Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseMelee), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseMelee ? "Melee Enabled!" : "Melee Disabled!");
                }
            });

            HotkeyManager.Register("Elayne_Diversion", DiversionKey, DiversionModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseDiversion = !ElayneSettingsModel.Instance.UseDiversion;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseDiversion ? "Diversion Enabled!" : "Diversion Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseEmbolden), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseDiversion ? "Diversion Enabled!" : "Diversion Disabled!");
                }
            });

            HotkeyManager.Register("Elayne_Verraise", VerraiseKey, VerraiseModifier, hk =>
            {
                ElayneSettingsModel.Instance.UseVerraise = !ElayneSettingsModel.Instance.UseVerraise;
                {
                    ToastManager.AddToast(ElayneSettingsModel.Instance.UseVerraise ? "Verraise Enabled!" : "Verraise Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(ElayneSettingsModel.Instance.UseEmbolden), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.ElayneLog(ElayneSettingsModel.Instance.UseVerraise ? "Verraise Enabled!" : "Verraise Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Elayne_LoadPreset1");
            HotkeyManager.Unregister("Elayne_LoadPreset2");
            HotkeyManager.Unregister("Elayne_LoadPreset3");
            HotkeyManager.Unregister("Elayne_LoadPreset4");
            HotkeyManager.Unregister("Elayne_LoadPreset5");

            HotkeyManager.Unregister("Elayne_ContraSixte");
            HotkeyManager.Unregister("Elayne_Potion");
            HotkeyManager.Unregister("Elayne_Buffs");
            HotkeyManager.Unregister("Elayne_AoE");
            HotkeyManager.Unregister("Elayne_Swiftcast");
            HotkeyManager.Unregister("Elayne_DoTs");
            HotkeyManager.Unregister("Elayne_Opener");
            HotkeyManager.Unregister("Elayne_Embolden");
            HotkeyManager.Unregister("Elayne_CorpsaCorps");
            HotkeyManager.Unregister("Elayne_Displacement");
            HotkeyManager.Unregister("Elayne_Melee");
            HotkeyManager.Unregister("Elayne_Diversion");
            HotkeyManager.Unregister("Elayne_Verraise");
        }
    }
}