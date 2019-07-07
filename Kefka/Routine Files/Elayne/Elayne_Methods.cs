using System;
using System.Linq;
using System.Threading.Tasks;
using ff14bot.Enums;
using ff14bot.Managers;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using static ff14bot.Managers.ActionResourceManager.RedMage;
using static Kefka.Utilities.Extensions.GameObjectExtensions;

namespace Kefka.Routine_Files.Elayne
{
    public static partial class ElayneRotation
    {
        private static bool _swiftcastReady => ElayneSettingsModel.Instance.UseSwiftcast && Spells.Swiftcast.Cooldown == TimeSpan.Zero;

        private static async Task<bool> Jolt()
        {
            return await Spells.Jolt.Use(Target, Me.ClassLevel < 4
                || (!Me.HasAura(Auras.Dualcast)
                && !Me.HasAura(Auras.Swiftcast)
                && (!Me.HasAura(Auras.VerstoneReady) || (WhiteMana > 91 && BlackMana < 91))
                && (!Me.HasAura(Auras.VerfireReady) || (BlackMana > 91 && WhiteMana < 91))));
        }

        private static async Task<bool> Scatter()
        {
            if (!ElayneSettingsModel.Instance.UseAoE) return false;

            if (Target?.EnemiesInRange(8) == ElayneSettingsModel.Instance.MobCount && !Me.HasAura(Auras.Dualcast) && !Me.HasAura(Auras.Swiftcast))
            {
                return await Spells.Scatter.Use(Target, true);
            }

            if (Target?.EnemiesInRange(8) > ElayneSettingsModel.Instance.MobCount)
            {
                return await Spells.Scatter.Use(Target, true);
            }

            return false;
        }

        private static async Task<bool> Impact()
        {
            return await Spells.Impact.Use(Target, !Me.HasAura(Auras.Dualcast) && !Me.HasAura(Auras.Swiftcast));
        }

        private static async Task<bool> Veraero()
        {
            if (Me.HasAura(Auras.VerstoneReady)) return false;

            if ((Me.HasAura(Auras.Dualcast) || Me.HasAura(Auras.Swiftcast) || _swiftcastReady) &&
                WhiteMana <= BlackMana)
            {
                if (!ElayneSettingsModel.Instance.UseSwiftcastForVerraise)
                    await Swiftcast();
                return await Spells.Veraero.Use(Target, Me.HasAura(Auras.Dualcast) || Me.HasAura(Auras.Swiftcast));
            }

            return false;
        }

        private static async Task<bool> Verthunder()
        {
            if (Me.HasAura(Auras.VerfireReady)) return false;

            if ((Me.HasAura(Auras.Dualcast) || Me.HasAura(Auras.Swiftcast) || _swiftcastReady) &&
                (BlackMana < WhiteMana || Me.ClassLevel < 10))
            {
                if (!ElayneSettingsModel.Instance.UseSwiftcastForVerraise)
                    await Swiftcast();
                return await Spells.Verthunder.Use(Target, Me.HasAura(Auras.Dualcast) || Me.HasAura(Auras.Swiftcast));
            }

            return false;
        }

        private static async Task<bool> Verfire()
        {
            if (Me.HasAura(Auras.Impactful) && !Me.HasAura(Auras.Impactful, true, 6000))
                return await Impact();

            return await Spells.Verfire.Use(Target, !Me.HasAura(Auras.Swiftcast) && !ActionManager.CanCast(Spells.Verflare, Target) && (BlackMana <= 91 || (BlackMana >= 91 && WhiteMana >= 91)));
        }

        private static async Task<bool> Verstone()
        {
            if (Me.HasAura(Auras.Impactful) && !Me.HasAura(Auras.Impactful, true, 6000))
                return await Impact();

            return await Spells.Verstone.Use(Target, !Me.HasAura(Auras.Swiftcast) && !ActionManager.CanCast(Spells.Verflare, Target) && (WhiteMana <= 91 || (BlackMana >= 91 && WhiteMana >= 91)));
        }

        private static async Task<bool> Verflare()
        {
            return await Spells.Verflare.Use(Target, Me.ClassLevel < 70 || WhiteMana > BlackMana);
        }

        private static async Task<bool> Verholy()
        {
            return await Spells.Verholy.Use(Target, BlackMana >= WhiteMana);
        }

        private static async Task<bool> CorpsaCorps()
        {
            return await Spells.Corpsacorps.Use(Target, ElayneSettingsModel.Instance.UseCorpsacorps
                && WhiteMana >= 80 && BlackMana >= 80
                && (!Me.HasAura(Auras.VerfireReady) || BlackMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt)
                && (!Me.HasAura(Auras.VerstoneReady) || WhiteMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt)
                && !Me.HasAura(Auras.Dualcast));
        }

        private static async Task<bool> CorpsaCorpsAoE()
        {
            return await Spells.Corpsacorps.Use(Target, ElayneSettingsModel.Instance.UseCorpsacorps && WhiteMana >= 90 && BlackMana >= 90);
        }

        private static async Task<bool> Riposte()
        {
            if (await Spells.Riposte.Use(Target, ElayneSettingsModel.Instance.UseMelee
                && (Me.ClassLevel < 2 || (WhiteMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt && BlackMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt))))
                return await Embolden();

            return false;
        }

        private static async Task<bool> Zwerchhau()
        {
            return await Spells.Zwerchhau.Use(Target, ActionManager.LastSpell == Spells.Riposte || CombatHelper.LastSpell == Spells.Riposte);
        }

        private static async Task<bool> Redoublement()
        {
            return await Spells.Redoublement.Use(Target, ActionManager.LastSpell == Spells.Zwerchhau || CombatHelper.LastSpell == Spells.Zwerchhau);
        }

        private static async Task<bool> Displacement()
        {
            return await Spells.Displacement.Use(Target, ElayneSettingsModel.Instance.UseDisplacement && WhiteMana < 25 && BlackMana < 25);
        }

        private static async Task<bool> Fleche()
        {
            return await Spells.Fleche.Use(Target, true);
        }

        private static async Task<bool> Acceleration()
        {
            if (ActionManager.LastSpell != Spells.Veraero && CombatHelper.LastSpell != Spells.Veraero
                && ActionManager.LastSpell != Spells.Verstone && CombatHelper.LastSpell != Spells.Verstone
                && ActionManager.LastSpell != Spells.Verfire && CombatHelper.LastSpell != Spells.Verfire
                && ActionManager.LastSpell != Spells.Verthunder && CombatHelper.LastSpell != Spells.Verthunder
                && ActionManager.LastSpell != Spells.Verflare && CombatHelper.LastSpell != Spells.Verflare
                && ActionManager.LastSpell != Spells.Verholy && CombatHelper.LastSpell != Spells.Verholy) return false;

            if (Me.HasAura(Auras.VerstoneReady) || Me.HasAura(Auras.VerfireReady) || Me.HasAura(Auras.Dualcast)) return false;

            if (WhiteMana >= 80 && BlackMana >= 80) return false;

            return await Spells.Acceleration.Use(Me, ElayneSettingsModel.Instance.UseBuffs);
        }

        private static async Task<bool> Swiftcast()
        {
            return await Spells.Swiftcast.Use(Me, !Me.HasAura(Auras.Dualcast));
        }

        private static async Task<bool> Moulinet()
        {
            return await Spells.Moulinet.Use(Target, Target.Distance(Me) <= 6 && Target?.EnemiesInRange(6) >= ElayneSettingsModel.Instance.MobCount && WhiteMana >= 30 && BlackMana >= 30);
        }

        private static async Task<bool> Vercure()
        {
            return await Spells.Vercure.Use(Me, ElayneSettingsModel.Instance.UseVercure
                && ActionManager.LastSpell != Spells.Riposte && CombatHelper.LastSpell != Spells.Riposte
                && ActionManager.LastSpell != Spells.Zwerchhau && CombatHelper.LastSpell != Spells.Zwerchhau
                && ActionManager.LastSpell != Spells.Redoublement && CombatHelper.LastSpell != Spells.Redoublement
                && ActionManager.LastSpell != Spells.Displacement && CombatHelper.LastSpell != Spells.Displacement
                && (BotManager.Current.IsAutonomous || ElayneSettingsModel.Instance.UseVercureInNonAutonomous)
                && Me.CurrentHealthPercent < ElayneSettingsModel.Instance.SelfHealPct);
        }

        private static async Task<bool> ContreSixte()
        {
            return await Spells.ContreSixte.Use(Target, ElayneSettingsModel.Instance.UseContraSixte);
        }

        private static async Task<bool> Embolden()
        {
            return await Spells.Embolden.Use(Me, ElayneSettingsModel.Instance.UseEmbolden
                && (ActionManager.LastSpell == Spells.Riposte || CombatHelper.LastSpell == Spells.Riposte));
        }

        private static async Task<bool> Manafication()
        {
            if (ActionManager.LastSpell == Spells.Riposte || CombatHelper.LastSpell == Spells.Riposte
                || ActionManager.LastSpell == Spells.Zwerchhau || CombatHelper.LastSpell == Spells.Zwerchhau
                || ActionManager.LastSpell == Spells.Redoublement || CombatHelper.LastSpell == Spells.Redoublement) return false;

            return await Spells.Manafication.Use(Me,
                WhiteMana >= ElayneSettingsModel.Instance.ManaficationLevel
                && BlackMana >= ElayneSettingsModel.Instance.ManaficationLevel
                && WhiteMana < 60
                && BlackMana < 60);
        }

        private static async Task<bool> Verraise()
        {
            if (!ElayneSettingsModel.Instance.UseVerraise || Me.CurrentManaPercent < ElayneSettingsModel.Instance.VerraiseMinMpPct || !Me.HasAura(Auras.Dualcast) && !Me.HasAura(Auras.Swiftcast)) return false;

            var target = PartyMembers.FirstOrDefault(pm => pm.IsDead
                 && pm.Type == GameObjectType.Pc
                 && !pm.HasAura(Auras.Raise)
                 && !pm.HasAura(Auras.Raise2));

            return await Spells.Verraise.Use(target, true);
        }

        private static async Task<bool> LucidDreaming()
        {
            return await Spells.LucidDreaming.Use(Me, ElayneSettingsModel.Instance.UseBuffs && Me.CurrentManaPercent < 70);
        }

        private static async Task<bool> Diversion()
        {
            return await Spells.Diversion.Use(Me, ElayneSettingsModel.Instance.UseDiversion);
        }

        private static async Task<bool> Erase()
        {
            return await Spells.Erase.Use(Target, true);
        }

        private static async Task<bool> Drain()
        {
            return await Spells.Drain.Use(Target, Me.CurrentHealthPercent <= ElayneSettingsModel.Instance.SelfHealPct
                && Me.ClassLevel < 54);
        }

        #region Misc

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !ElayneSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, ElayneSettingsModel.Instance.UseMelee && (Me.ClassLevel < 2 || (WhiteMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt && BlackMana >= ElayneSettingsModel.Instance.MeleeComboMinManaInt)));
        }

        #endregion Misc
    }
}