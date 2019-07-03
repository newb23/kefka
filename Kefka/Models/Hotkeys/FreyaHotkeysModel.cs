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
    public class FreyaHotkeysModel : BaseModel
    {
        private static FreyaHotkeysModel _instance;
        public static FreyaHotkeysModel Instance => _instance ?? (_instance = new FreyaHotkeysModel());

        private FreyaHotkeysModel() : base(@"Settings/" + Me.Name + "/Kefka/Hotkeys/Freya_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key, _dragonfireDive, _potion, _buffs, _autoInterrupt, _aoe, _mercyStroke, _defensives, _dots, _jumps, _opener, _bloodoftheDragon, _battleLitany, _geirskogul, _aoeSpam;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier, _dragonfireDiveModifier, _potionModifier, _buffsModifier, _autoInterruptModifier, _aoeModifier, _mercyStrokeModifier, _defensivesModifier, _dotsModifier, _jumpsModifier, _openerModifier, _bloodoftheDragonModifier, _battleLitanyModifier, _geirskogulModifier, _aoeSpamModifier;

        public FreyaPresetsSettingsModel PresetNames => FreyaPresetsSettingsModel.Instance;

        public FreyaPresetsViewModel PresetCommands => new FreyaPresetsViewModel();

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
        public Keys DragonfireDiveKey
        {
            get => _dragonfireDive;
            set { _dragonfireDive = value; OnPropertyChanged(); }
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
        public Keys AutoInterruptKey
        {
            get => _autoInterrupt;
            set { _autoInterrupt = value; OnPropertyChanged(); }
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
        public ModifierKeys DragonfireDiveModifier
        {
            get => _dragonfireDiveModifier;
            set { _dragonfireDiveModifier = value; OnPropertyChanged(); }
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
        public ModifierKeys AutoInterruptModifier
        {
            get => _autoInterruptModifier;
            set { _autoInterruptModifier = value; OnPropertyChanged(); }
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
        public Keys MercyStrokeKey
        {
            get => _mercyStroke;
            set { _mercyStroke = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys MercyStrokeModifier
        {
            get => _mercyStrokeModifier;
            set { _mercyStrokeModifier = value; OnPropertyChanged(); }
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
        public Keys BattleLitanyKey
        {
            get => _battleLitany;
            set { _battleLitany = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BattleLitanyModifier
        {
            get => _battleLitanyModifier;
            set { _battleLitanyModifier = value; OnPropertyChanged(); }
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
        public Keys GeirskogulKey
        {
            get => _geirskogul;
            set { _geirskogul = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GeirskogulModifier
        {
            get => _geirskogulModifier;
            set { _geirskogulModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys JumpsKey
        {
            get => _jumps;
            set { _jumps = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys JumpsModifier
        {
            get => _jumpsModifier;
            set { _jumpsModifier = value; OnPropertyChanged(); }
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
        public Keys BloodoftheDragonKey
        {
            get => _bloodoftheDragon;
            set { _bloodoftheDragon = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys BloodoftheDragonModifier
        {
            get => _bloodoftheDragonModifier;
            set { _bloodoftheDragonModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys AoeSpamKey
        {
            get => _aoeSpam;
            set { _aoeSpam = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys AoeSpamModifier
        {
            get => _aoeSpamModifier;
            set { _aoeSpamModifier = value; OnPropertyChanged(); }
        }

        public void RegisterAll()
        {
            HotkeyManager.Register("Freya_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.FreyaLog($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Freya_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.FreyaLog($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Freya_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.FreyaLog($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Freya_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.FreyaLog($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Freya_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.FreyaLog($"Loading Preset: {FreyaPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Freya_DragonfireDive", DragonfireDiveKey, DragonfireDiveModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseDragonfireDive = !FreyaSettingsModel.Instance.UseDragonfireDive;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseDragonfireDive ? "Dragonfire Dive Enabled!" : "Dragonfire Dive Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseDragonfireDive), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseDragonfireDive ? "Dragonfire Dive Enabled!" : "Dragonfire Dive Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Potion", PotionKey, PotionModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseDpsPotion = !FreyaSettingsModel.Instance.UseDpsPotion;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseDpsPotion), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseDpsPotion ? "Potions Enabled!" : "Potions Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Buffs", BuffsKey, BuffsModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseBuffs = !FreyaSettingsModel.Instance.UseBuffs;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseBuffs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseBuffs ? "Buffs Enabled!" : "Buffs Disabled!");
                }
            });
            HotkeyManager.Register("Freya_AutoInterrupt", AutoInterruptKey, AutoInterruptModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseManualInterrupt = !FreyaSettingsModel.Instance.UseManualInterrupt;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseManualInterrupt), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    if (FreyaSettingsModel.Instance.UseManualInterrupt)
                        if (FreyaSettingsModel.Instance.UseInterruptList)
                            FreyaSettingsModel.Instance.UseInterruptList = false;

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseManualInterrupt ? "Interrupts Enabled!" : "Interrupts Disabled!");
                }
            });
            HotkeyManager.Register("Freya_AoE", AoEKey, AoEModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseAoE = !FreyaSettingsModel.Instance.UseAoE;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseAoE), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseAoE ? "AoE Enabled!" : "AoE Disabled!");
                }
            });
            HotkeyManager.Register("Freya_MercyStroke", MercyStrokeKey, MercyStrokeModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseTrueNorth = !FreyaSettingsModel.Instance.UseTrueNorth;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseTrueNorth ? "Mercy Stroke Enabled!" : "Mercy Stroke Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseTrueNorth), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseTrueNorth ? "Mercy Stroke Enabled!" : "Mercy Stroke Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Defensives", DefensivesKey, DefensivesModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseDefensives = !FreyaSettingsModel.Instance.UseDefensives;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseDefensives), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseDefensives ? "Defensives Enabled!" : "Defensives Disabled!");
                }
            });
            HotkeyManager.Register("Freya_DoTs", DoTsKey, DoTsModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseDoTs = !FreyaSettingsModel.Instance.UseDoTs;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseDoTs), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseDoTs ? "DoTs Enabled!" : "DoTs Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Jumps", JumpsKey, JumpsModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseJumps = !FreyaSettingsModel.Instance.UseJumps;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseJumps ? "Jumps Enabled!" : "Jumps Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseJumps), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseJumps ? "Jumps Enabled!" : "Jumps Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Opener", OpenerKey, OpenerModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseOpener = !FreyaSettingsModel.Instance.UseOpener;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseOpener), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseOpener ? "Opener Enabled!" : "Opener Disabled!");
                }
            });
            HotkeyManager.Register("Freya_BloodoftheDragon", BloodoftheDragonKey, BloodoftheDragonModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseBloodoftheDragon = !FreyaSettingsModel.Instance.UseBloodoftheDragon;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseBloodoftheDragon ? "BotD Enabled!" : "BotD Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseBloodoftheDragon), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseBloodoftheDragon ? "BotD Enabled!" : "BotD Disabled!");
                }
            });
            HotkeyManager.Register("Freya_BattleLitany", BattleLitanyKey, BattleLitanyModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseBattleLitany = !FreyaSettingsModel.Instance.UseBattleLitany;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseBattleLitany ? "Battle Litany Enabled!" : "Battle Litany Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseBattleLitany), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseBattleLitany ? "Battle Litany Enabled!" : "Battle Litany Disabled!");
                }
            });
            HotkeyManager.Register("Freya_Geirskogul", GeirskogulKey, GeirskogulModifier, hk =>
            {
                FreyaSettingsModel.Instance.UseGeirskogul = !FreyaSettingsModel.Instance.UseGeirskogul;
                {
                    ToastManager.AddToast(FreyaSettingsModel.Instance.UseGeirskogul ? "Geirskogul Enabled!" : "Geirskogul Disabled!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(FreyaSettingsModel.Instance.UseGeirskogul), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.FreyaLog(FreyaSettingsModel.Instance.UseGeirskogul ? "Geirskogul Enabled!" : "Geirskogul Disabled!");
                }
            });
            HotkeyManager.Register("Freya_AoeSpam", AoeSpamKey, AoeSpamModifier, hk =>
            {
                {
                    ToastManager.AddToast("AoE Spam!", TimeSpan.FromMilliseconds(750), Colors.Red, Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                    Logger.PaineLog("AoE Spam!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Freya_LoadPreset1");
            HotkeyManager.Unregister("Freya_LoadPreset2");
            HotkeyManager.Unregister("Freya_LoadPreset3");
            HotkeyManager.Unregister("Freya_LoadPreset4");
            HotkeyManager.Unregister("Freya_LoadPreset5");

            HotkeyManager.Unregister("Freya_DragonfireDive");
            HotkeyManager.Unregister("Freya_Potion");
            HotkeyManager.Unregister("Freya_Buffs");
            HotkeyManager.Unregister("Freya_AutoInterrupt");
            HotkeyManager.Unregister("Freya_AoE");
            HotkeyManager.Unregister("Freya_MercyStroke");
            HotkeyManager.Unregister("Freya_Defensives");
            HotkeyManager.Unregister("Freya_DoTs");
            HotkeyManager.Unregister("Freya_QueueAbilities");
            HotkeyManager.Unregister("Freya_Jumps");
            HotkeyManager.Unregister("Freya_Opener");
            HotkeyManager.Unregister("Freya_BloodoftheDragon");
            HotkeyManager.Unregister("Freya_UI");
            HotkeyManager.Unregister("Freya_BattleLitany");
            HotkeyManager.Unregister("Freya_Geirskogul");
            HotkeyManager.Unregister("Freya_AoeSpam");
        }
    }
}