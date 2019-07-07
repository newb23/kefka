using System;
using System.Linq;
using System.Threading.Tasks;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;
using Resource = ff14bot.Managers.ActionResourceManager.BlackMage;

namespace Kefka.Routine_Files.Vivi
{
    public static partial class ViviRotation
    {
        private static bool EnochianActive => Resource.Enochian;
        private static double StackTimer => Resource.StackTimer.TotalMilliseconds;
        private static int UmbralHearts => Resource.UmbralHearts;
        private static int AstralStacks => Resource.AstralStacks;
        private static int UmbralStacks => Resource.UmbralStacks;

        private static int TriplecastCatch()
        {
            return !Me.HasAura(Auras.Triplecast) ? 0 : 2400;
        }

        private static uint AdjustedCost(this SpellData InputSpell, bool IsFireSpell)
        {
            var adustedSpellCost = InputSpell.Cost;

            if (IsFireSpell)
            {
                if (AstralStacks > 0)
                {
                    return adustedSpellCost * 2;
                }
                switch (UmbralStacks)
                {
                    case 3:
                    case 2:
                        return adustedSpellCost / 4;

                    case 1:
                        return adustedSpellCost / 2;
                }
                return adustedSpellCost;
            }

            switch (AstralStacks)
            {
                case 3:
                case 2:
                    return adustedSpellCost / 4;

                case 1:
                    return adustedSpellCost / 2;
            }

            return adustedSpellCost;
        }

        private static bool UmbralAura => UmbralStacks > 0;

        private static bool AstralAura => AstralStacks > 0;

        private static bool LastSpellThunder()
        {
            return ActionManager.LastSpell == Spells.Thunder
                   || CombatHelper.LastSpell == Spells.Thunder
                   || ActionManager.LastSpell == Spells.ThunderII
                   || CombatHelper.LastSpell == Spells.ThunderII
                   || ActionManager.LastSpell == Spells.ThunderIII
                   || CombatHelper.LastSpell == Spells.ThunderIII
                   || ActionManager.LastSpell == Spells.ThunderIV
                   || CombatHelper.LastSpell == Spells.ThunderIV;
        }

        private static uint ThunderAuraSingle()
        {
            return Me.ClassLevel >= 45 ? Auras.ThunderIII : Auras.Thunder;
        }

        private static uint ThunderAuraAoE()
        {
            return Me.ClassLevel >= 64 ? Auras.ThunderIV : Auras.ThunderII;
        }

        private static async Task<bool> Blizzard()
        {
            return await Spells.Blizzard.Use(Target, (UmbralStacks < 3
                && Me.CurrentManaPercent < ViviSettingsModel.Instance.EnoRfshPct * .5
                && !ActionManager.CanCast(Spells.BlizzardIII, Target))

                || Me.ClassLevel < Spells.Fire.LevelAcquired);
        }

        private static async Task<bool> Fire()
        {
            return await Spells.Fire.Use(Target, (!EnochianActive || StackTimer < ViviSettingsModel.Instance.AstralRfsh) && (!UmbralAura || Me.ClassLevel < 34));
        }

        private static async Task<bool> Transpose()
        {
            return await Spells.Transpose.Use(Me, (Me.HasAura(Auras.FireStarter) && UmbralStacks == 3 && Me.CurrentManaPercent == 100) ||
                (MovementManager.IsMoving || CombatHelper.LastSpell == Spells.Flare || ActionManager.LastSpell == Spells.Flare)
                && AstralAura
                && AstralStacks > 0);
        }

        private static async Task<bool> Thunder()
        {
            return await Spells.Thunder.CastDot(Target, ViviSettingsModel.Instance.UseDoTs
                && !LastSpellThunder()
                && !Me.HasAura(Auras.Swiftcast)
                && !Me.HasAura(Auras.Triplecast)
                && CombatHelper.LastSpell != Spells.Swiftcast
                && (!Target.HasAura(ThunderAuraSingle(), true, ViviSettingsModel.Instance.ThunderRfsh) || Me.HasAura(Auras.ThunderCloud))
                && StackTimer > 6000
                && Target.HealthCheck(true)
                && Target.TimeToDeathCheck(), ThunderAuraSingle(), 5000);
        }

        private static async Task<bool> Scathe()
        {
            return await Spells.Scathe.Use(Target, ViviSettingsModel.Instance.UseScathe && !Me.HasAura(Auras.Triplecast) && MovementManager.IsMoving);
        }

        private static async Task<bool> Swiftcast()
        {
            if (!ViviSettingsModel.Instance.UseSwiftcast || Me.HasAura(Auras.Triplecast) || (ViviSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(8) >= ViviSettingsModel.Instance.MobCount))
            {
                return false;
            }

            return await Spells.Swiftcast.Use(Me, CombatHelper.LastSpell == Spells.BlizzardIII);
        }

        private static async Task<bool> Convert()
        {
            if (await Spells.Convert.Use(Me, ViviSettingsModel.Instance.UseConvert && ViviSettingsModel.Instance.UseAoE && CombatHelper.LastSpell == Spells.Flare)) return true;

            return await Spells.Convert.Use(Me, ViviSettingsModel.Instance.UseConvert && !ViviSettingsModel.Instance.UseAoE && Me.CurrentManaPercent <= 8);
        }

        private static async Task<bool> Manaward()
        {
            return await Spells.Manaward.CastBuff(Me, ViviSettingsModel.Instance.UseDefensives && Me.CurrentHealthPercent <= 30, Auras.Manaward);
        }

        private static async Task<bool> FireIII()
        {
            return await Spells.FireIII.Use(Target, CombatHelper.LastSpell != Spells.FireIII
                && (!AstralAura || ActionManager.LastSpell == Spells.Transpose || CombatHelper.LastSpell == Spells.Transpose)
                && (CombatHelper.LastSpell == Spells.BlizzardIV || Me.HasAura(Auras.FireStarter) || AstralStacks < 3));
        }

        private static async Task<bool> FireIV()
        {
            return await Spells.FireIV.Use(Target, AstralAura && (UmbralHearts > 0 || Me.CurrentManaPercent > ViviSettingsModel.Instance.EnoRfshPct)
                && StackTimer >= Math.Max(ViviSettingsModel.Instance.AstralRfsh, Spells.FireIV.AdjustedCastTime.TotalMilliseconds + Spells.Fire.AdjustedCastTime.TotalMilliseconds + TriplecastCatch()));
        }

        private static async Task<bool> Triplecast()
        {
            return await Spells.Triplecast.Use(Me,
                ViviSettingsModel.Instance.UseTriplecast
                && AstralAura
                && (UmbralHearts > 0 || Me.CurrentManaPercent > ViviSettingsModel.Instance.EnoRfshPct)
                && StackTimer >= ViviSettingsModel.Instance.AstralRfsh);
        }

        private static async Task<bool> BlizzardIII()
        {
            if (await Spells.BlizzardIII.Use(Target, CombatHelper.LastSpell != Spells.BlizzardIV
                 && CombatHelper.LastSpell != Spells.BlizzardIII
                 && CombatHelper.LastSpell != Spells.Swiftcast
                 && !UmbralAura
                 && (UmbralHearts == 0 || StackTimer < 3000 || Me.CurrentMana < Spells.Fire.AdjustedCost(true))
                 && Me.CurrentManaPercent <= ViviSettingsModel.Instance.EnoRfshPct
                 && EnochianActive))

                return await BlizzardIV();

            return false;
        }

        private static async Task<bool> BlizzardIV()
        {
            if (await Spells.BlizzardIV.Use(Target,
                (Me.CurrentManaPercent <= ViviSettingsModel.Instance.EnoRfshPct
                || (CombatHelper.LastSpell == Spells.BlizzardIII
                || CombatHelper.LastSpell == Spells.Swiftcast
                || CombatHelper.LastSpell == Spells.Thunder
                || CombatHelper.LastSpell == Spells.ThunderIII
                || CombatHelper.LastSpell == Spells.Enochian))
                && UmbralHearts < 3
                && StackTimer >= Math.Max(ViviSettingsModel.Instance.AstralRfsh, Spells.BlizzardIV.AdjustedCastTime.TotalMilliseconds + Spells.Fire.AdjustedCastTime.TotalMilliseconds + TriplecastCatch()))) return true;

            return false;
        }

        private static async Task<bool> Drain()
        {
            return await Spells.Drain.Use(Target, ViviSettingsModel.Instance.UseDrain
                && Me.CurrentHealthPercent <= ViviSettingsModel.Instance.SelfHealPct
                && (AstralAura || UmbralAura));
        }

        private static async Task<bool> LeyLines()
        {
            return await Spells.LeyLines.CastBuff(Me, ViviSettingsModel.Instance.UseLeyLines, Auras.LeyLines);
        }

        private static async Task<bool> Sharpcast()
        {
            return await Spells.Sharpcast.CastBuff(Me, ViviSettingsModel.Instance.UseSharpcast
                && CombatHelper.LastSpell == Spells.FireIV, Auras.Sharpcast);
        }

        private static async Task<bool> Enochian()
        {
            return await Spells.Enochian.Use(Me, ViviSettingsModel.Instance.UseEnochian && !EnochianActive);
        }

        private static async Task<bool> Foul()
        {
            return await Spells.Foul.Use(Target, StackTimer >= Math.Max(ViviSettingsModel.Instance.AstralRfsh, Spells.Foul.AdjustedCastTime.TotalMilliseconds + Spells.Fire.AdjustedCastTime.TotalMilliseconds + TriplecastCatch()));
        }

        #region Misc

        private static async Task<bool> Diversion()
        {
            return await Spells.Diversion.Use(Me, ViviSettingsModel.Instance.UseDiversion);
        }

        private static async Task<bool> AoERotation()
        {
            if (!ViviSettingsModel.Instance.UseAoE) { return false; }

            if (Target == null || !Target.CanAttack)
                return false;

            if (await Spells.Scathe.Use(Target, ViviSettingsModel.Instance.UseScathe && !Me.HasAura(Auras.Triplecast) && MovementManager.IsMoving)) return true;
            if (await Spells.Foul.Use(Target, StackTimer >= Math.Max(ViviSettingsModel.Instance.AstralRfsh, Spells.Foul.AdjustedCastTime.TotalMilliseconds + Spells.Fire.AdjustedCastTime.TotalMilliseconds + TriplecastCatch()))) return true;

            if (Me.CurrentMana < Spells.FireII.AdjustedCost(true)
                && Me.CurrentMana >= 1200
                && ActionManager.LastSpell != Spells.BlizzardIII
                && CombatHelper.LastSpell != Spells.BlizzardIII
                && (Spells.Convert.Cooldown.TotalMilliseconds <= 4 || Spells.Transpose.Cooldown.TotalMilliseconds <= 4))
            {
                await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast);
                return await Spells.Flare.Use(Target, true);
            }

            if (Me.HasAura(Auras.Swiftcast)) return false;

            if (await Spells.ThunderII.CastDot(Target, ViviSettingsModel.Instance.UseDoTs && !LastSpellThunder() && (UmbralAura || Me.HasAura(Auras.ThunderCloud)) && (!Target.HasAura(ThunderAuraAoE(), true, 4000) || Me.HasAura(Auras.ThunderCloud)), ThunderAuraAoE())) return true;
            if (await Spells.FireIII.Use(Target, !AstralAura)) return true;
            Logger.KefkaLog(Spells.FireII.AdjustedCost(true).ToString());
            if (await Spells.BlizzardIII.Use(Target, Me.CurrentMana < Spells.FireII.AdjustedCost(true))) return true;
            if (await Spells.Transpose.Use(Me, AstralAura && CombatHelper.LastSpell != Spells.Convert && (Me.CurrentMana < Spells.BlizzardIII.AdjustedCost(false) || CombatHelper.LastSpell == Spells.Flare))) return true;
            if (await Spells.Blizzard.Use(Target, Me.CurrentMana < Spells.BlizzardIII.AdjustedCost(false) && Spells.Transpose.Cooldown.TotalMilliseconds > 3 && Me.CurrentMana == Spells.Blizzard.Cost / 2 + Spells.Blizzard.Cost)) return true;
            return await Spells.FireII.Use(Target, AstralAura || CombatHelper.LastSpell == Spells.FireIII);
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !ViviSettingsModel.Instance.UseDpsPotion || !Me.HasAura(Auras.LeyLines))
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, Me.HasAura(Auras.BloodforBlood));
        }

        #endregion Misc
    }
}