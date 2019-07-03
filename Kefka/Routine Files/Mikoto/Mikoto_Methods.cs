using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Routine_Files.General;
using System.Linq;
using System.Threading.Tasks;
using Kefka.Models;
using Kefka.Utilities;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Mikoto
{
    internal partial class MikotoRotation
    {
        private static async Task<bool> Stone()
        {
            if (Target == null || !Target.CanAttack) return false;

            return await Spells.Stone.Use(Target, MikotoSettingsModel.Instance.UseStoneSpells);
        }

        private static async Task<bool> Aero()
        {
            if (Me.ClassLevel < 4) return false;

            if (Target == null || !Target.CanAttack || !MikotoSettingsModel.Instance.UseAero) return false;

            return await Spells.Aero.CastDot(Target, (!Target.HasAura(Auras.Aero, true, MikotoSettingsModel.Instance.AeroRfsh) && !Target.HasAura(Auras.AeroII, true, MikotoSettingsModel.Instance.AeroRfsh)) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.Aero);
        }

        private static async Task<bool> AeroIII()
        {
            if (Target == null || !Target.CanAttack || !MikotoSettingsModel.Instance.UseAero3) return false;

            if (CombatHelper.LastSpell == Spells.AeroIII || ActionManager.LastSpell == Spells.AeroIII) return false;

            return await Spells.AeroIII.CastDot(Target, !Target.HasAura(Auras.AeroIII, true, MikotoSettingsModel.Instance.Aero3Rfsh) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.AeroIII);
        }

        private static async Task<bool> Cure()
        {
            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.CureHpPct);

            if (target == null) return false;

            if (target.IsTank())
            {
                if (MikotoSettingsModel.Instance.RegenCureFloorTanks && target.HasAura(Auras.Regen) && target.CurrentHealthPercent > MikotoSettingsModel.Instance.RegenCureFloorPct) return false;

                return await Spells.Cure.Use(target, true, true);
            }

            if (target.IsHealer())
            {
                if (MikotoSettingsModel.Instance.RegenCureFloorHealers && target.HasAura(Auras.Regen) && target.CurrentHealthPercent > MikotoSettingsModel.Instance.RegenCureFloorPct) return false;

                return await Spells.Cure.Use(target, true, true);
            }

            if (!target.IsDps()) return false;

            if (MikotoSettingsModel.Instance.RegenCureFloorDps && target.HasAura(Auras.Regen) && target.CurrentHealthPercent > MikotoSettingsModel.Instance.RegenCureFloorPct) return false;

            return await Spells.Cure.Use(target, true, true);
        }

        private static async Task<bool> CureII()
        {
            if (!MikotoSettingsModel.Instance.UseCure2) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.Cure2HpPct);

            if (Me.HasAura(Auras.Freecure))
            {
                target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent < (MikotoSettingsModel.Instance.CureHpPct));
            }

            if (target != null)
            {
                return await Spells.CureII.Use(target, true, true);
            }
            return false;
        }

        private static async Task<bool> CureIII()
        {
            if (!MikotoSettingsModel.Instance.UseCure3) return false;

            var target = HealManager.FirstOrDefault(pm1 => HealManager.Count(pm2 => pm1.Distance(pm2) <= 6 && pm2.CurrentHealthPercent <= MikotoSettingsModel.Instance.Cure3HpPct) >= MikotoSettingsModel.Instance.Cure3PlayerCount);

            if (target != null)
            {
                return await Spells.CureIII.Use(target, true, true);
            }
            return false;
        }

        private static async Task<bool> Regen()
        {
            if (!MikotoSettingsModel.Instance.UseRegen || !Me.InCombat) return false;

            var target = HealManager.FirstOrDefault(hm => (!hm.HasAura(Auras.Regen) && hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.RegenHpPct) ||
            (!hm.HasAura(Auras.Regen, true, 4000) && hm.InCombat &&
            ((hm.IsTank() && MikotoSettingsModel.Instance.KeepRegenOnTanks) ||
            (hm.IsHealer() && MikotoSettingsModel.Instance.KeepRegenOnHealers) ||
            (hm.IsDps() && MikotoSettingsModel.Instance.KeepRegenOnDps))));

            if (target == null) return false;

            if (target.IsTank() && MikotoSettingsModel.Instance.RegenTanks)
            {
                return await Spells.Regen.CastBuff(target, true, Auras.Regen);
            }

            if (target.IsHealer() && MikotoSettingsModel.Instance.RegenHealers)
            {
                return await Spells.Regen.CastBuff(target, true, Auras.Regen);
            }

            if (target.IsDps() && MikotoSettingsModel.Instance.RegenDps)
                return await Spells.Regen.CastBuff(target, true, Auras.Regen);

            return false;
        }

        private static async Task<bool> Medica()
        {
            if (!MikotoSettingsModel.Instance.UseMedica) return false;

            if (HealManager.Count(hm =>
                    hm.Distance(Me) <= 15 &&
                    hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.MedicaHpPct) >= MikotoSettingsModel.Instance.MedicaPlayerCount &&
                    MikotoSettingsModel.Instance.UseMedica)
            {
                return await Spells.Medica.Use(Me, true, true);
            }
            return false;
        }

        private static async Task<bool> MedicaII()
        {
            if (!MikotoSettingsModel.Instance.UseMedica2) return false;

            if (HealManager.Count(hm =>
                    hm.Distance(Me) <= 20 &&
                    hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.Medica2HpPct &&
                    !hm.HasAura(Auras.MedicaII)) >= MikotoSettingsModel.Instance.Medica2PlayerCount &&
                    ActionManager.LastSpell != Spells.MedicaII && CombatHelper.LastSpell != Spells.MedicaII)
            {
                return await Spells.MedicaII.CastHeal(Me, true, Auras.MedicaII);
            }
            return false;
        }

        private static async Task<bool> Raise()
        {
            if (!MikotoSettingsModel.Instance.UseRaise) return false;

            if (!HealManager.Any(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.CureHpPct))
            {
                var target = ResManager.FirstOrDefault(pm => pm.IsDead
                 && !pm.HasAura(Auras.Raise)
                 && !pm.HasAura(Auras.Raise2));

                if (target != null &&
                    ActionManager.CanCast(Spells.Raise, target))
                {
                    if (MikotoSettingsModel.Instance.UseSwiftcastRaise && ActionManager.CanCast(Spells.Swiftcast, Me))
                        await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast);

                    return await Spells.Raise.Use(target, true, true); 
                }
            }
            return false;
        }

        private static async Task<bool> FluidAura()
        {
            if (Target == null || !Target.CanAttack || Me.TargetDistance(5)) return false;

            return await Spells.FluidAura.Use(Target, MikotoSettingsModel.Instance.UseFluidAura);
        }

        private static async Task<bool> Repose()
        {
            if (!MikotoSettingsModel.Instance.UseRepose) return false;

            if (Target == null || !Target.CanAttack || ActionManager.LastSpell == Spells.Repose || CombatHelper.LastSpell == Spells.Repose) return false;

            var bcTarget = Target as BattleCharacter;

            return await Spells.Repose.Use(Target, !bcTarget.InCombat && !Target.HasAura(Auras.Sleep));
        }

        private static async Task<bool> PresenceOfMind()
        {
            if (!MikotoSettingsModel.Instance.UsePresenceofMind) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.PresenceofMindHpPct) < MikotoSettingsModel.Instance.PresenceofMindPlayerCount && !MikotoSettingsModel.Instance.UsePresenceofMindOnTankOnly) return false;

            if (MikotoSettingsModel.Instance.UsePresenceofMindOnTankOnly && !HealManager.Any(hm => hm.IsTank() && hm.CurrentHealthPercent < MikotoSettingsModel.Instance.PresenceofMindHpPct)) return false;

            return await Spells.PresenceofMind.CastBuff(Me, true, Auras.PresenceofMind);
        }

        private static async Task<bool> Holy()
        {
            if (Me.CurrentManaPercent <= MikotoSettingsModel.Instance.HolyMinMpPct) return false;

            return await Spells.Holy.Use(Me, MikotoSettingsModel.Instance.UseHoly && Me.EnemiesInRange(8) >= MikotoSettingsModel.Instance.HolyMinTargets);
        }

        private static async Task<bool> Benediction()
        {
            if (!MikotoSettingsModel.Instance.UseBenediction) return false;

            var target = HealManager.FirstOrDefault(hm =>
            hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.BenedictionHpPct);

            if (target != null)
            {
                return await Spells.Benediction.Use(target, MikotoSettingsModel.Instance.UseBenediction);
            }
            return false;
        }

        private static async Task<bool> Asylum()
        {
            if (!MikotoSettingsModel.Instance.UseAsylum) return false;

            var target = HealManager.FirstOrDefault(pm1 => HealManager.Count(pm2 => pm2.CurrentHealthPercent <= MikotoSettingsModel.Instance.AsylumHpPct) >= MikotoSettingsModel.Instance.AsylumPlayerCount);

            if (target != null)
            {
                return await Spells.Asylum.Use(target, target.AlliesInRange(6) >= MikotoSettingsModel.Instance.AsylumPlayerCount);
            }
            return false;
        }

        private static async Task<bool> Assize()
        {
            if (!MikotoSettingsModel.Instance.UseAssize || (Me.CurrentManaPercent >= 90 && MikotoSettingsModel.Instance.AssizeBelow90)) return false;

            if (MikotoSettingsModel.Instance.AssizeHealOnly)
            {
                return await Spells.Assize.Use(Me, HealManager.Count(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.AssizeHpPct && Me.Distance(hm) <= 15) >= MikotoSettingsModel.Instance.AssizeHealPlayerCount);
            }

            return await Spells.Assize.Use(Me, (Me.CurrentManaPercent <= MikotoSettingsModel.Instance.AssizeManaPct && MikotoSettingsModel.Instance.AssizeManaRegen) || (Me.EnemiesInRange(8) <= MikotoSettingsModel.Instance.AssizeDpsEnemyCount && MikotoSettingsModel.Instance.AssizeToDamage));
        }

        private static async Task<bool> Tetragrammaton()
        {
            if (!MikotoSettingsModel.Instance.UseTetragrammaton) return false;

            var target = HealManager.FirstOrDefault(hm =>
                hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.TetragrammatonHpPct);

            if (target != null && (target.IsTank() || !MikotoSettingsModel.Instance.UseTetragrammatonOnTankOnly))
            {
                return await Spells.Tetragrammaton.Use(target, true);
            }

            return false;
        }

        private static async Task<bool> ThinAir()
        {
            if (!MikotoSettingsModel.Instance.UseThinAir) return false;

            return await Spells.ThinAir.CastBuff(Me, Me.CurrentManaPercent <= MikotoSettingsModel.Instance.ThinAirMpPct);
        }

        private static async Task<bool> DivineBenison()
        {
            if (!MikotoSettingsModel.Instance.UseDivineBenison) return false;

            var target = HealManager.FirstOrDefault(hm =>
                hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.DivineBenisonHpPct);

            if (target != null)
            {
                return await Spells.DivineBenison.Use(target, true);
            }
            return false;
        }

        private static async Task<bool> PlenaryIndulgence()
        {
            if (!MikotoSettingsModel.Instance.UsePlenaryIndulgence) return false;

            if (!HealManager.Any(hm => hm.HasAura(Auras.Confession))) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent < MikotoSettingsModel.Instance.PlenaryIndulgenceHpPct) < MikotoSettingsModel.Instance.PlenaryIndulgencePlayerCount) return false;

            return await Spells.PlenaryIndulgence.Use(Me, true);
        }

        #region Role Actions

        private static async Task<bool> ClericStance()
        {
            return await Spells.ClericStance.CastBuff(Me, HealManager.All(hm => hm.CurrentHealthPercent > MikotoSettingsModel.Instance.CureHpPct) && Me.CurrentManaPercent >= MikotoSettingsModel.Instance.DamageMinMpPct, Auras.ClericStance);
        }

        private static async Task<bool> Break()
        {
            return await Spells.Break.CastDot(Target, true, Auras.Heavy);
        }

        private static async Task<bool> Protect()
        {
            if (!MikotoSettingsModel.Instance.UseProtect) return false;

            if ((CombatHelper.LastSpell == Spells.Protect || ActionManager.LastSpell == Spells.Protect) ||
                (!MikotoSettingsModel.Instance.UseProtectInCombat && PartyMembers.Any(pm => pm.InCombat)) ||
                PartyMembers.Any(pm => pm.Icon == PlayerIcon.Viewing_Cutscene) ||
                HealManager.All(hm => hm.HasAura(Auras.Protect)) ||
                HealManager.Any(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.CureHpPct || hm.IsDead)) return false;

            var target = HealManager.FirstOrDefault(hm => !hm.HasAura(Auras.Protect));

            if (target == null) return false;

            return await Spells.Protect.CastBuff(target, true, Auras.Protect);
        }

        private static async Task<bool> Esuna()
        {
            if (!MikotoSettingsModel.Instance.UseCleanse || HealManager.Any(hm => hm.CurrentHealthPercent < MikotoSettingsModel.Instance.CleanseHP)) return false;

            return await CleanseManager.DoCleanses();
        }

        private static async Task<bool> Healbusters()
        {
            if (Target == null || !Target.CanAttack)
            {
                return false;
            }

            var tar = Me.CurrentTarget as BattleCharacter;

            var hasSpellCureII = HealBusterManager.CureII.Contains(tar.CastingSpellId);
            var hasSpellBenediction = HealBusterManager.Benediction.Contains(tar.CastingSpellId);
            var hasSpellTetragrammaton = HealBusterManager.Tetragrammaton.Contains(tar.CastingSpellId);
            var hasSpellDivineBenison = HealBusterManager.DivineBenison.Contains(tar.CastingSpellId);
            var hasSpellMedica = HealBusterManager.Medica.Contains(tar.CastingSpellId);
            var hasSpellMedicaII = HealBusterManager.MedicaII.Contains(tar.CastingSpellId);
            var hasSpellPlenaryIndulgence = HealBusterManager.PlenaryIndulgence.Contains(tar.CastingSpellId);
            var hasSpellAsylum = HealBusterManager.Asylum.Contains(tar.CastingSpellId);

            if (await Spells.CureII.CastHeal(tar.TargetGameObject, hasSpellCureII)) return true;
            if (await Spells.Benediction.CastHeal(tar.TargetGameObject, hasSpellBenediction)) return true;
            if (await Spells.Tetragrammaton.CastHeal(tar.TargetGameObject, hasSpellTetragrammaton)) return true;
            if (await Spells.DivineBenison.CastHeal(tar.TargetGameObject, hasSpellDivineBenison)) return true;
            if (await Spells.Medica.CastHeal(Me, hasSpellMedica)) return true;
            if (await Spells.MedicaII.CastHeal(Me, hasSpellMedicaII)) return true;
            if (await Spells.PlenaryIndulgence.CastHeal(Me, hasSpellPlenaryIndulgence)) return true;
            if (await Spells.Asylum.CastHeal(Me, hasSpellAsylum)) return true;

            return false;
        }

        private static async Task<bool> LucidDreaming()
        {
            return await Spells.LucidDreaming.Use(Me, MikotoSettingsModel.Instance.UseLucidDreaming && Me.CurrentManaPercent <= MikotoSettingsModel.Instance.LucidDreamingMpPct);
        }

        private static async Task<bool> EyeForAnEye()
        {
            if (!MikotoSettingsModel.Instance.UseEyeforanEye) return false;

            var target = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.HasAura(Auras.EyeforanEye) && hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.EyeforanEyeHpPct);

            if (target == null)
            {
                target = HealManager.FirstOrDefault(hm => !hm.IsMe && !hm.HasAura(Auras.EyeforanEye) && hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.EyeforanEyeHpPct);
            }

            if (target == null) return false;

            return await Spells.EyeforanEye.Use(target, true);
        }

        private static async Task<bool> Largesse()
        {
            if (!MikotoSettingsModel.Instance.UseLargesse) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.LargesseHpPct) < MikotoSettingsModel.Instance.LargessePlayerCount && !MikotoSettingsModel.Instance.UseLargesseOnTankOnly) return false;

            if (MikotoSettingsModel.Instance.UseLargesseOnTankOnly && !HealManager.Any(hm => hm.IsTank() && hm.CurrentHealthPercent < MikotoSettingsModel.Instance.LargesseHpPct)) return false;

            return await Spells.Largesse.CastBuff(Me, true, Auras.Largesse);
        }

        private static async Task<bool> Surecast()
        {
            return await Spells.Surecast.Use(Target, true);
        }

        private static async Task<bool> Rescue()
        {
            return await Spells.Rescue.Use(Target, true);
        }

        #endregion Role Actions
    }
}