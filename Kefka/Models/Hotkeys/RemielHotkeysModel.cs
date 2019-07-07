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
    public class RemielHotkeysModel : BaseModel
    {
        private static RemielHotkeysModel _instance;
        public static RemielHotkeysModel Instance => _instance ?? (_instance = new RemielHotkeysModel());

        private RemielHotkeysModel() : base(CharacterSettingsDirectory + "/Kefka/Hotkeys/Remiel_Hotkeys.json")
        {
        }

        private volatile Keys _preset1Key, _preset2Key, _preset3Key, _preset4Key, _preset5Key,
            _doDamage, _potion, _cleanse, _lightspeed, _synastry, _essentialDignity, _largesse, _eyeforanEye, _gravity, _collectiveUnconscious, _celestialOpposition, _timeDilation, _earthlyStar,
            _cards, _onlyDraw, _sleeveDraw, _spread, _royalRoad, _shit;

        private volatile ModifierKeys _preset1Modifier, _preset2Modifier, _preset3Modifier, _preset4Modifier, _preset5Modifier,
            _doDamageModifier, _potionModifier, _cleanseModifier, _lightspeedModifier, _synastryModifier, _essentialDignityModifier, _largesseModifier, _eyeforanEyeModifier, _gravityModifier, _collectiveUnconsciousModifier, _celestialOppositionModifier, _timeDilationModifier, _earthlyStarModifier,
            _cardsModifier, _onlyDrawModifier, _sleeveDrawModifier, _spreadModifier, _royalRoadModifier, _shitModifier;

        public RemielPresetsSettingsModel PresetNames => RemielPresetsSettingsModel.Instance;

        public RemielPresetsViewModel PresetCommands => new RemielPresetsViewModel();

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
        public Keys LightspeedKey
        {
            get => _lightspeed;
            set { _lightspeed = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys LightspeedModifier
        {
            get => _lightspeedModifier;
            set { _lightspeedModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SynastryKey
        {
            get => _synastry;
            set { _synastry = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SynastryModifier
        {
            get => _synastryModifier;
            set { _synastryModifier = value; OnPropertyChanged(); }
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
        public Keys GravityKey
        {
            get => _gravity;
            set { _gravity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys GravityModifier
        {
            get => _gravityModifier;
            set { _gravityModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys EssentialDignityKey
        {
            get => _essentialDignity;
            set { _essentialDignity = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EssentialDignityModifier
        {
            get => _essentialDignityModifier;
            set { _essentialDignityModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys CollectiveUnconsciousKey
        {
            get => _collectiveUnconscious;
            set { _collectiveUnconscious = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CollectiveUnconsciousModifier
        {
            get => _collectiveUnconsciousModifier;
            set { _collectiveUnconsciousModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys CelestialOppositionKey
        {
            get => _celestialOpposition;
            set { _celestialOpposition = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CelestialOppositionModifier
        {
            get => _celestialOppositionModifier;
            set { _celestialOppositionModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys TimeDilationKey
        {
            get => _timeDilation;
            set { _timeDilation = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys TimeDilationModifier
        {
            get => _timeDilationModifier;
            set { _timeDilationModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys EarthlyStarKey
        {
            get => _earthlyStar;
            set { _earthlyStar = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys EarthlyStarModifier
        {
            get => _earthlyStarModifier;
            set { _earthlyStarModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys CardsKey
        {
            get => _cards;
            set { _cards = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys CardsModifier
        {
            get => _cardsModifier;
            set { _cardsModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys OnlyDrawKey
        {
            get => _onlyDraw;
            set { _onlyDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys OnlyDrawModifier
        {
            get => _onlyDrawModifier;
            set { _onlyDrawModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SleeveDrawKey
        {
            get => _sleeveDraw;
            set { _sleeveDraw = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SleeveDrawModifier
        {
            get => _sleeveDrawModifier;
            set { _sleeveDrawModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys SpreadKey
        {
            get => _spread;
            set { _spread = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys SpreadModifier
        {
            get => _spreadModifier;
            set { _spreadModifier = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(Keys.None)]
        public Keys RoyalRoadKey
        {
            get => _royalRoad;
            set { _royalRoad = value; OnPropertyChanged(); }
        }

        [Setting]
        [DefaultValue(ModifierKeys.None)]
        public ModifierKeys RoyalRoadModifier
        {
            get => _royalRoadModifier;
            set { _royalRoadModifier = value; OnPropertyChanged(); }
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
            HotkeyManager.Register("Remiel_LoadPreset1", Preset1Key, Preset1Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset1Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.RemielLog($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset1Name}");

                PresetCommands.LoadPreset1.Execute(null);
            });

            HotkeyManager.Register("Remiel_LoadPreset2", Preset2Key, Preset2Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset2Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.RemielLog($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset2Name}");

                PresetCommands.LoadPreset2.Execute(null);
            });

            HotkeyManager.Register("Remiel_LoadPreset3", Preset3Key, Preset3Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset3Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.RemielLog($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset3Name}");

                PresetCommands.LoadPreset3.Execute(null);
            });

            HotkeyManager.Register("Remiel_LoadPreset4", Preset4Key, Preset4Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset4Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.RemielLog($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset4Name}");

                PresetCommands.LoadPreset4.Execute(null);
            });

            HotkeyManager.Register("Remiel_LoadPreset5", Preset5Key, Preset5Modifier, hk =>
            {
                ToastManager.AddToast($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset5Name}", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                Logger.RemielLog($"Loading Preset: {RemielPresetsSettingsModel.Instance.Preset5Name}");

                PresetCommands.LoadPreset5.Execute(null);
            });

            HotkeyManager.Register("Remiel_DoDamage", DoDamageKey, DoDamageModifier, hk =>
            {
                RemielSettingsModel.Instance.DoDamage = !RemielSettingsModel.Instance.DoDamage;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.DoDamage ? "DoDamage Enabled!" : "DoDamage Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.DoDamage), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.DoDamage
                        ? "DoDamage Enabled!"
                        : "DoDamage Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Potion", PotionKey, PotionModifier, hk =>
            {
                RemielSettingsModel.Instance.UsePotion = !RemielSettingsModel.Instance.UsePotion;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UsePotion ? "Potion Enabled!" : "Potion Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UsePotion), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UsePotion
                        ? "Potion Enabled!"
                        : "Potion Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Cleanse", CleanseKey, CleanseModifier, hk =>
            {
                RemielSettingsModel.Instance.UseCleanse = !RemielSettingsModel.Instance.UseCleanse;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseCleanse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseCleanse ? "Cleanse Enabled!" : "Cleanse Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Cards", CardsKey, CardsModifier, hk =>
            {
                RemielSettingsModel.Instance.UseCards = !RemielSettingsModel.Instance.UseCards;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseCards
                            ? "Cards Enabled!"
                            : "Cards Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseCards), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseCards
                        ? "Cards Enabled!"
                        : "Cards Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Lightspeed", LightspeedKey, LightspeedModifier, hk =>
            {
                RemielSettingsModel.Instance.UseLightspeed = !RemielSettingsModel.Instance.UseLightspeed;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseLightspeed
                            ? "Lightspeed Enabled!"
                            : "Lightspeed Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseLightspeed), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseLightspeed
                        ? "Lightspeed Enabled!"
                        : "Lightspeed Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Synastry", SynastryKey, SynastryModifier, hk =>
            {
                RemielSettingsModel.Instance.UseSynastry = !RemielSettingsModel.Instance.UseSynastry;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseSynastry
                            ? "Synastry Enabled!"
                            : "Synastry Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseSynastry),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseSynastry
                        ? "Synastry Enabled!"
                        : "Synastry Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Spread", SpreadKey, SpreadModifier, hk =>
            {
                RemielSettingsModel.Instance.UseSpread = !RemielSettingsModel.Instance.UseSpread;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseSpread
                            ? "Spread Enabled!"
                            : "Spread Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseSpread),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseSpread
                        ? "Spread Enabled!"
                        : "Spread Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_OnlyDraw", OnlyDrawKey, OnlyDrawModifier, hk =>
            {
                RemielSettingsModel.Instance.OnlyDraw = !RemielSettingsModel.Instance.OnlyDraw;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.OnlyDraw
                            ? "Only Draw Enabled!"
                            : "Only Draw Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.OnlyDraw),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.OnlyDraw
                        ? "Only Draw Enabled!"
                        : "Only Draw Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_SleeveDraw", SleeveDrawKey, SleeveDrawModifier, hk =>
            {
                RemielSettingsModel.Instance.UseSleeveDraw = !RemielSettingsModel.Instance.UseSleeveDraw;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseSleeveDraw
                            ? "SleeveDraw Enabled!"
                            : "SleeveDraw Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseSleeveDraw),
                        Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseSleeveDraw
                        ? "SleeveDraw Enabled!"
                        : "SleeveDraw Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Gravity", GravityKey, GravityModifier, hk =>
            {
                RemielSettingsModel.Instance.UseGravity = !RemielSettingsModel.Instance.UseGravity;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseGravity
                            ? "Gravity Enabled!"
                            : "Gravity Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseGravity), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseGravity
                        ? "Gravity Enabled!"
                        : "Gravity Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_Largesse", LargesseKey, LargesseModifier, hk =>
            {
                RemielSettingsModel.Instance.UseLargesse = !RemielSettingsModel.Instance.UseLargesse;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseLargesse
                            ? "Largesse Enabled!"
                            : "Largesse Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseLargesse), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseLargesse
                        ? "Largesse Enabled!"
                        : "Largesse Disabled!");
                }
            }); HotkeyManager.Register("Remiel_EyeforanEye", EyeforanEyeKey, EyeforanEyeModifier, hk =>
            {
                RemielSettingsModel.Instance.UseEyeforanEye = !RemielSettingsModel.Instance.UseEyeforanEye;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseEyeforanEye
                            ? "Eye for an Eye Enabled!"
                            : "Eye for an Eye Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseEyeforanEye), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseEyeforanEye
                        ? "Eye for an Eye Enabled!"
                        : "Eye for an Eye Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_EssentialDignity", EssentialDignityKey, EssentialDignityModifier, hk =>
            {
                RemielSettingsModel.Instance.UseEssentialDignity = !RemielSettingsModel.Instance.UseEssentialDignity;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseEssentialDignity ? "Essential Dignity Enabled!" : "Essential Dignity Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseEssentialDignity), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseEssentialDignity
                        ? "Essential Dignity Enabled!"
                        : "Essential Dignity Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_CollectiveUnconscious", CollectiveUnconsciousKey, CollectiveUnconsciousModifier, hk =>
            {
                RemielSettingsModel.Instance.UseCollectiveUnconscious = !RemielSettingsModel.Instance.UseCollectiveUnconscious;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseCollectiveUnconscious
                            ? "Collective Unconscious Enabled!"
                            : "Collective Unconscious Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseCollectiveUnconscious), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseCollectiveUnconscious
                        ? "Collective Unconscious Enabled!"
                        : "Collective Unconscious Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_CelestialOpposition", CelestialOppositionKey, CelestialOppositionModifier, hk =>
            {
                RemielSettingsModel.Instance.UseCelestialOpposition = !RemielSettingsModel.Instance.UseCelestialOpposition;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseCelestialOpposition
                            ? "Celestial Opposition Enabled!"
                            : "Celestial Opposition Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseCelestialOpposition), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseCelestialOpposition
                        ? "Celestial Opposition Enabled!"
                        : "Celestial Opposition Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_TimeDilation", TimeDilationKey, TimeDilationModifier, hk =>
            {
                RemielSettingsModel.Instance.UseTimeDilation = !RemielSettingsModel.Instance.UseTimeDilation;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseTimeDilation
                            ? "Time Dilation Enabled!"
                            : "Time Dilation Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseTimeDilation), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseTimeDilation
                        ? "Time Dilation Enabled!"
                        : "Time Dilation Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_EarthlyStar", EarthlyStarKey, EarthlyStarModifier, hk =>
            {
                RemielSettingsModel.Instance.UseEarthlyStar = !RemielSettingsModel.Instance.UseEarthlyStar;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseEarthlyStar
                            ? "Earthly Star Enabled!"
                            : "Earthly Star Disabled!", TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseEarthlyStar), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseEarthlyStar
                        ? "Earthly Star Enabled!"
                        : "Earthly Star Disabled!");
                }
            });
            HotkeyManager.Register("Remiel_ShitButton", ShitButtonKey, ShitButtonModifier, hk =>
            {
                RemielSettingsModel.Instance.UseShitButton = !RemielSettingsModel.Instance.UseShitButton;
                {
                    Core.OverlayManager.AddToast(
                        () => RemielSettingsModel.Instance.UseShitButton ? "OH $h!7!!! Button Enabled!" : "OH $h!7!!! Button Disabled!",
                        TimeSpan.FromMilliseconds(750),
                        MainSettingsModel.Instance.ToastColor(RemielSettingsModel.Instance.UseShitButton), Colors.White,
                        new FontFamily("High Tower Text Italic"), new FontWeight(), 52);

                    Logger.RemielLog(RemielSettingsModel.Instance.UseShitButton
                        ? "OH $h!7!!! Button Enabled!"
                        : "OH $h!7!!! Button Disabled!");
                }
            });
        }

        public void UnregisterAll()
        {
            HotkeyManager.Unregister("Remiel_LoadPreset1");
            HotkeyManager.Unregister("Remiel_LoadPreset2");
            HotkeyManager.Unregister("Remiel_LoadPreset3");
            HotkeyManager.Unregister("Remiel_LoadPreset4");
            HotkeyManager.Unregister("Remiel_LoadPreset5");

            HotkeyManager.Unregister("Remiel_DoDamage");
            HotkeyManager.Unregister("Remiel_Potion");
            HotkeyManager.Unregister("Remiel_Cleanse");
            HotkeyManager.Unregister("Remiel_Lightspeed");
            HotkeyManager.Unregister("Remiel_Synastry");
            HotkeyManager.Unregister("Remiel_Gravity");
            HotkeyManager.Unregister("Remiel_Largesse");
            HotkeyManager.Unregister("Remiel_EyeforanEye");
            HotkeyManager.Unregister("Remiel_EssentialDignity");
            HotkeyManager.Unregister("Remiel_UI");
            HotkeyManager.Unregister("Remiel_CollectiveUnconscious");
            HotkeyManager.Unregister("Remiel_CelestialOpposition");
            HotkeyManager.Unregister("Remiel_TimeDilation");
            HotkeyManager.Unregister("Remiel_EarthlyStar");
            HotkeyManager.Unregister("Remiel_Card");
            HotkeyManager.Unregister("Remiel_OnlyDraw");
            HotkeyManager.Unregister("Remiel_SleeveDraw");
            HotkeyManager.Unregister("Remiel_Spread");
            HotkeyManager.Unregister("Remiel_RoyalRoad");
            HotkeyManager.Unregister("Remiel_Shit");
        }
    }
}