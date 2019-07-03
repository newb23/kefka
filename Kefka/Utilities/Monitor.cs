using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Auras = Kefka.Routine_Files.General.Auras;
using static ff14bot.Managers.ActionResourceManager.Samurai;
using static ff14bot.Managers.ActionResourceManager.Samurai.Iaijutsu;

namespace Kefka.Utilities
{
    public class Monitor
    {
        private static string currentPositional, combatTime, lastSkill, combatMode, petSelection, upcomingPositional;
        public static event EventHandler PropertyUpdate;

        private static SolidColorBrush infoTextColor = Brushes.LawnGreen;
        private static SolidColorBrush positionalColor;

        public string CombatTime
        { get { return combatTime; } set { combatTime = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); } }

        public string LastSkill
        { get { return lastSkill; } set { lastSkill = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); } }

        public static string CombatMode
        { get { return combatMode; } set { combatMode = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.CombatMode = value; } }

        public static string PetSelection
        { get { return petSelection; } set { petSelection = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.PetSelection = value; } }

        public static string CurrentPositional
        { get { return currentPositional; } set { currentPositional = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.CurrentPositional = value; } }

        public static SolidColorBrush InfoTextColor
        { get { return infoTextColor; } set { infoTextColor = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.InfoTextColor = value; } }

        public static SolidColorBrush PositionalColor
        { get { return positionalColor; } set { positionalColor = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.PositionalColor = value; } }

        public static string UpcomingPositional
        { get { return upcomingPositional; } set { upcomingPositional = value; PropertyUpdate?.Invoke(null, EventArgs.Empty); OverlayViewModel.Instance.UpcomingPositional = value; } }

        public static void SpellLog()
        {
            var target = Core.Player.CurrentTarget as BattleCharacter;
            if (target != null && target.IsCasting)
            {
                if (SpellLogViewModel.Instance.SpellLogCollection.All(m => m.SpellId != target.SpellCastInfo.ActionId))
                {
                    SpellLogViewModel.Instance.LogSpell(target.EnglishName, target.NpcId, target.SpellCastInfo.SpellData.LocalizedName,
                        target.SpellCastInfo.ActionId);
                }
            }
        }

        public static void OverlayUpdate()
        {
            CombatModeText();
            SelectedPet();
            Positionals();

            if (!LocationManager.PvPMapList.Contains(WorldManager.ZoneId) || !MainSettingsModel.Instance.UseEnemyOverlay)
                EnemyOverlayLogic.UpdateEnemyInfo();
        }

        #region Positional Information

        public static void Positionals()
        {
            if (Ability.OpenerEnabled)
            {
                OpenerEnabled();
                return;
            }

            switch (Me.CurrentJob)
            {
                case ClassJobType.Samurai:
                    CyanPositionals();
                    break;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    FreyaPositionals();
                    break;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    ShadowPositionals();
                    break;

                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                    SabinPositionals();
                    break;
            }
        }

        private static void CyanPositionals()
        {
            var jinpuAura = Me.CharacterAuras.FirstOrDefault(aura => aura != null && aura.Name.Contains("Jinpu"));
            var shifuAura = Me.CharacterAuras.FirstOrDefault(aura => aura != null && aura.Name.Contains("Shifu"));

            if (Me.HasAura(Auras.MeikyoShisui))
            {
                if (!Sen.HasFlag(Ka))
                {
                    if (!Target.IsFlanking)
                        FlankingRed();
                    else FlankingGreen();
                    return;
                }

                if (!Sen.HasFlag(Getsu))
                {
                    if (!Target.IsBehind)
                        BehindRed();
                    else BehindGreen();
                    return;
                }
            }

            if (Me.HasTarget && Target.CanAttack)
            {
                // Kasha
                if ((shifuAura == null || shifuAura.TimespanLeft == TimeSpan.Zero || shifuAura?.TimespanLeft < jinpuAura?.TimespanLeft) && ActionManager.LastSpell != Spells.Jinpu && !Target.IsFlanking)
                {
                    FlankingRed();
                    return;
                }

                if ((shifuAura == null || shifuAura.TimespanLeft == TimeSpan.Zero || shifuAura?.TimespanLeft < jinpuAura?.TimespanLeft || ActionManager.LastSpell == Spells.Shifu) && Target.IsFlanking)
                {
                    FlankingGreen();
                    return;
                }
                // Gekko
                if ((jinpuAura == null || jinpuAura.TimespanLeft == TimeSpan.Zero || jinpuAura?.TimespanLeft < shifuAura?.TimespanLeft) && ActionManager.LastSpell != Spells.Shifu && !Target.IsBehind)
                {
                    BehindRed();
                    return;
                }

                if ((jinpuAura == null || jinpuAura.TimespanLeft == TimeSpan.Zero || jinpuAura?.TimespanLeft < shifuAura?.TimespanLeft || ActionManager.LastSpell == Spells.Jinpu) && Target.IsBehind)
                {
                    BehindGreen();
                    return;
                }
            }

            CurrentPositional = "Target";
            PositionalColor = Brushes.Red;
        }

        private static void FreyaPositionals()
        {
            {
                if (Target == null)
                {
                    CurrentPositional = "Target";
                    PositionalColor = Brushes.Red;
                    return;
                }

                // Priority to 4th tier
                if (Me.HasAura(Auras.SharperFangandClaw) && !Target.IsFlanking)
                {
                    FlankingRed();
                    return;
                }

                if (Me.HasAura(Auras.SharperFangandClaw) && Target.IsFlanking)
                {
                    FlankingGreen();
                    return;
                }

                if (Me.HasAura(Auras.EnhancedWheelingThrust) && !Target.IsBehind)
                {
                    BehindRed();
                    return;
                }

                if (Me.HasAura(Auras.EnhancedWheelingThrust) && Target.IsBehind)
                {
                    BehindGreen();
                    return;
                }

                // Chaos Thrust
                if (ActionManager.LastSpell == Spells.Disembowel && !Target.IsBehind)
                {
                    BehindRed();
                    return;
                }

                if (ActionManager.LastSpell == Spells.Disembowel && Target.IsBehind)
                {
                    BehindGreen();
                    return;
                }

                // Heavy Thrust
                if (!Me.HasAura(Auras.HeavyThrust, true, FreyaSettingsModel.Instance.HeavyThrustRfsh, false) && !Target.IsFlanking)
                {
                    FlankingRed();
                    return;
                }

                if (!Me.HasAura(Auras.HeavyThrust, true, FreyaSettingsModel.Instance.HeavyThrustRfsh, false) && Target.IsFlanking)
                {
                    FlankingGreen();
                    return;
                }

                CurrentPositional = "Target";
                PositionalColor = Brushes.LawnGreen;
            }
        }

        private static void ShadowPositionals()
        {
            if (Me.HasTarget && Target.CanAttack)
            {
                // Trick Attack
                if ((Me.HasAura(Auras.Suiton) || Target.HasAura(Auras.VulnerabilityUp)) && !Target.IsBehind)
                {
                    BehindRed();
                    return;
                }

                if ((Me.HasAura(Auras.Suiton) || Target.HasAura(Auras.VulnerabilityUp)) && Target.IsBehind)
                {
                    BehindGreen();
                    return;
                }

                // Armor Crush
                if (ActionResourceManager.Ninja.HutonTimer.TotalMilliseconds < ShadowSettingsModel.Instance.ArmorCrushRfsh + 250 && !Target.IsFlanking && Me.ClassLevel >= 54)
                {
                    FlankingRed();
                    return;
                }

                if (ActionResourceManager.Ninja.HutonTimer.TotalMilliseconds < ShadowSettingsModel.Instance.ArmorCrushRfsh + 250 && Target.IsFlanking && Me.ClassLevel >= 54)
                {
                    FlankingGreen();
                    return;
                }

                // Normal Position
                if (!Target.IsBehind)
                {
                    BehindRed();
                    return;
                }

                if (Target.IsBehind)
                {
                    BehindGreen();
                    return;
                }
            }

            CurrentPositional = "Target";
            PositionalColor = Brushes.Red;
        }

        private static void SabinPositionals()
        {
            if (Target == null || !Target.CanAttack)
            {
                TargetRed();
                if (!Me.HasAura(Auras.CoeurlForm) && !Me.HasAura(Auras.RaptorForm) && !Me.HasAura(Auras.Opo_opoForm))
                    UpcomingPositional_Method("Bootshine - Rear");

                return;
            }

            if (Me.HasAura(Auras.PerfectBalance))
            {
                UpcomingPositional_Method("Snap Punch - Flank");
                CurrentPositional_Method("Snap Punch - Flank", Target.IsFlanking);
                return;
            }

            if (Me.HasAura(Auras.Opo_opoForm))
            {
                if (!Target.HasAura(Auras.DragonKick, false, SabinSettingsModel.Instance.DragonKickRfsh, false))
                    CurrentPositional_Method("Dragon Kick - Flank", Target.IsFlanking);
                else
                {
                    CurrentPositional_Method("Bootshine - Rear", Target.IsBehind);
                }

                UpcomingPositional_Method(!Me.HasAura(Auras.TwinSnakes, true, SabinSettingsModel.Instance.TwinSnakesRfsh + CombatHelper.GCD * 1.5, false) ? "Twin Snakes - Flank" : "True Strike - Rear");

                return;
            }

            if (Me.HasAura(Auras.RaptorForm))
            {
                if (!Me.HasAura(Auras.TwinSnakes, true, SabinSettingsModel.Instance.TwinSnakesRfsh, false))
                    CurrentPositional_Method("Twin Snakes - Flank", Target.IsFlanking);
                else
                {
                    CurrentPositional_Method("True Strike - Rear", Target.IsBehind);
                }

                UpcomingPositional_Method(!Target.HasAura(Auras.Demolish, true, SabinSettingsModel.Instance.DemolishRfsh + CombatHelper.GCD * 1.5, false) ? "Demolish - Rear" : "Snap Punch - Flank");

                return;
            }

            if (!Me.HasAura(Auras.CoeurlForm)) return;

            if (!Target.HasAura(Auras.Demolish, true, SabinSettingsModel.Instance.DemolishRfsh, false))
                CurrentPositional_Method("Demolish - Rear", Target.IsBehind);
            else
            {
                CurrentPositional_Method("Snap Punch - Flank", Target.IsFlanking);
            }

            if (!Me.HasAura(Auras.CoeurlForm) && !Me.HasAura(Auras.RaptorForm) && !Me.HasAura(Auras.Opo_opoForm))
            {
                UpcomingPositional_Method("Bootshine - Rear");
                CurrentPositional_Method("Bootshine - Rear", Target.IsBehind);
            }
            else
            {
                UpcomingPositional_Method(!Target.HasAura(Auras.DragonKick, false, SabinSettingsModel.Instance.DragonKickRfsh + CombatHelper.GCD * 1.5, false) ? "Dragon Kick - Flank" : "Bootshine - Rear");
            }
        }

        private static void UpcomingPositional_Method(string moveName)
        {
            UpcomingPositional = moveName;
        }

        private static void CurrentPositional_Method(string moveName, bool properPosition)
        {
            CurrentPositional = moveName;
            PositionalColor = properPosition ? Brushes.LawnGreen : Brushes.Red;
        }

        private static void TargetRed()
        {
            CurrentPositional = "Target";
            PositionalColor = Brushes.Red;
        }

        private static void FlankingRed()
        {
            CurrentPositional = "Flank";
            PositionalColor = Brushes.Red;
        }

        private static void FlankingGreen()
        {
            CurrentPositional = "Flank";
            PositionalColor = Brushes.LawnGreen;
        }

        private static void BehindRed()
        {
            CurrentPositional = "Rear";
            PositionalColor = Brushes.Red;
        }

        private static void BehindGreen()
        {
            CurrentPositional = "Rear";
            PositionalColor = Brushes.LawnGreen;
        }

        private static void OpenerEnabled()
        {
            CurrentPositional = "Opener";
            PositionalColor = Brushes.LawnGreen;
        }

        #endregion Positional Information

        public static void SelectedPet()
        {
            switch (EikoSettingsModel.Instance.SelectedEikoSummon)
            {
                case EikoSummonMode.Garuda:
                    PetSelection = "Garuda";
                    break;

                case EikoSummonMode.Titan:
                    PetSelection = "Titan";
                    break;

                case EikoSummonMode.Ifrit:
                    PetSelection = "Ifrit";
                    break;

                case EikoSummonMode.None:
                    PetSelection = "None";
                    return;
            }
        }

        public static void CombatModeText()
        {
            CombatMode = EikoSettingsModel.Instance.UseAoE ? "AoE" : "Single";
        }
    }
}