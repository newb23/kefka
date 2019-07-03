using System.Linq;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Enums;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Surito
{
    internal partial class SuritoRotation
    {
        private static async Task<bool> Ruin()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (Me.ClassLevel >= 54)
                return await Broil();

            return await Spells.Ruin.Use(Target, SuritoSettingsModel.Instance.UseRuinSpells);
        }

        private static async Task<bool> Bio()
        {
            if (Target == null || !Target.CanAttack || !SuritoSettingsModel.Instance.UseBio) return false;

            if (Me.ClassLevel >= 26)
                return await Spells.BioII.CastDot(Target, !Target.HasAura(Auras.BioII, true, SuritoSettingsModel.Instance.Bio2Rfsh) &&
                    Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.BioII);

            return await Spells.Bio.CastDot(Target, !Target.HasAura(Auras.Bio, true, SuritoSettingsModel.Instance.BioRfsh) &&
                    Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.Bio);
        }

        private static async Task<bool> Physick()
        {
            if (!SuritoSettingsModel.Instance.UsePhysick) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.PhysickHpPct);

            if (target != null)
            {
                return await Spells.Physick.Use(target, true, true);
            }
            return false;
        }

        private static async Task<bool> Aetherflow()
        {
            if (!ActionResourceManager.Arcanist.Aetherflow.Equals(0) && Me.CurrentManaPercent >= 40) return false;

            return await Spells.Aetherflow.Use(Me, true);
        }

        private static async Task<bool> EnergyDrain()
        {
            if (!SuritoSettingsModel.Instance.UseEnergyDrain) return false;

            return await Spells.EnergyDrain.Use(Target, Me.CurrentManaPercent <= SuritoSettingsModel.Instance.EnergyDrainMpPct || Me.CurrentHealthPercent <= SuritoSettingsModel.Instance.EnergyDrainHpPct);
        }

        private static async Task<bool> Miasma()
        {
            if (Target == null || !Target.CanAttack || !SuritoSettingsModel.Instance.UseMiasma) return false;

            return await Spells.Miasma.CastDot(Target, CombatHelper.LastSpell != Spells.Miasma &&
                !Target.HasAura(Auras.Miasma, true, SuritoSettingsModel.Instance.MiasmaRfsh) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.Miasma);
        }

        private static async Task<bool> MiasmaII()
        {
            if (Target == null || !Target.CanAttack || !SuritoSettingsModel.Instance.UseMiasmaII) return false;

            if (Target.Distance(Me) > 5) return false;

            return await Spells.MiasmaII.CastDot(Me, CombatHelper.LastSpell != Spells.Miasma &&
                !Target.HasAura(Auras.Miasma2, true, SuritoSettingsModel.Instance.Miasma2Rfsh) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.Miasma2);
        }

        private static async Task<bool> Resurrection()
        {
            if (!SuritoSettingsModel.Instance.UseResurrection) return false;

            if (!HealManager.Any(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.PhysickHpPct))
            {
                var target = ResManager.FirstOrDefault(pm => pm.IsDead
                 && !pm.HasAura(Auras.Raise)
                 && !pm.HasAura(Auras.Raise2));

                if (target != null &&
                    ActionManager.CanCast(Spells.Resurrection, target))
                {
                    if (SuritoSettingsModel.Instance.UseSwiftcastResurrection)
                    {
                        if (ActionManager.CanCast(Spells.Swiftcast, Me))
                        await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast);

                        if (Spells.Swiftcast.Cooldown.TotalMilliseconds > 5800 && !Me.HasAura(Auras.Swiftcast)) return false;
                    }
                    return await Spells.Resurrection.Use(target, true, true);
                }
            }
            return false;
        }

        private static async Task<bool> Bane()
        {
            if (ActionResourceManager.Arcanist.Aetherflow.Equals(0)) return false;

            if (Target?.EnemiesInRange(8) >= SuritoSettingsModel.Instance.BaneEnemyCount &&
                (Target.HasAura(Auras.Bio, true, SuritoSettingsModel.Instance.BioRfsh) || Target.HasAura(Auras.BioII, true, SuritoSettingsModel.Instance.Bio2Rfsh)) &&
                Target.HasAura(Auras.Miasma, true, SuritoSettingsModel.Instance.MiasmaRfsh) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck())
            {
                return await Spells.Bane.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> Rouse()
        {
            if (!SuritoSettingsModel.Instance.UseRouse) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.RouseHpPct && (hm.IsTank() || !SuritoSettingsModel.Instance.UseRouseTankOnly));

            if (target != null)
            {
                return await Spells.Rouse.Use(Me, true);
            }
            return false;
        }

        private static async Task<bool> ShadowFlare()
        {
            if (Target == null || !Target.CanAttack || !SuritoSettingsModel.Instance.UseShadowFlare ||
                !ActionManager.CanCast(Spells.ShadowFlare, Target))
                return false;

            return await Spells.ShadowFlare.CastBuff(Target, Target.HealthCheck(true) && Target.TimeToDeathCheck(), Auras.ShadowFlare, 28000);
        }

        private static async Task<bool> Adloquium()
        {
            if (!SuritoSettingsModel.Instance.UseAdloquium) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.AdloquiumHpPct && !hm.HasAura(Auras.Adloquium) && ((Me.HasAura(Auras.EmergencyTactics) && !SuritoSettingsModel.Instance.UseEmergencyTacticsOnTankOnly) || !SuritoSettingsModel.Instance.UseAdloquiumOnTankOnly || hm.IsTank()));

            if (target == null && SuritoSettingsModel.Instance.UseDelpoymentTacticsOnBothBuffsOnly)
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.EyeforanEye));

            if (target != null)
            {
                if (target.HasAura(Auras.Adloquium) && !Me.HasAura(Auras.EmergencyTactics)) return false;

                return await Spells.Adloquium.Use(target, true, true);
            }
            return false;
        }

        private static async Task<bool> Succor()
        {
            if (!SuritoSettingsModel.Instance.UseSuccor) return false;

            if (HealManager.Count(hm => hm.Distance2D(Me) <= 15 && hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.SuccorHpPct && (!hm.HasAura(Auras.Adloquium) || Me.HasAura(Auras.EmergencyTactics) && SuritoSettingsModel.Instance.UseEmergencyTacticsSuccor)) >= SuritoSettingsModel.Instance.SuccorPlayerCount)
            {
                return await Spells.Succor.Use(Me, true, true);
            }
            return false;
        }

        private static async Task<bool> SacredSoil()
        {
            if (!SuritoSettingsModel.Instance.UseSacredSoil || ActionResourceManager.Arcanist.Aetherflow.Equals(0)) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.SacredSoilHpPct && HealManager.Count(hm2 => hm2.CurrentHealthPercent <= SuritoSettingsModel.Instance.SacredSoilHpPct && hm2.Distance2D(hm) <= 8) >= SuritoSettingsModel.Instance.SacredSoilPlayerCount);
            return await Spells.SacredSoil.Use(target, true, true);
        }

        private static async Task<bool> Lustrate()
        {
            if (!SuritoSettingsModel.Instance.UseLustrate || ActionResourceManager.Arcanist.Aetherflow.Equals(0)) return false;

            var target = HealManager.FirstOrDefault(hm =>
                hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.LustrateHpPct);

            if (target != null && (target.IsTank() || SuritoSettingsModel.Instance.UseLustrateOnTankOnly))
            {
                return await Spells.Lustrate.Use(target, true);
            }
            return false;
        }

        private static async Task<bool> Indomitability()
        {
            if (!SuritoSettingsModel.Instance.UseIndomitability || ActionResourceManager.Arcanist.Aetherflow.Equals(0)) return false;

            return await Spells.Indomitability.Use(Me, HealManager.Count(hm => hm.Distance2D(Me) <= 15 && hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.IndomitabilityHpPct) >= SuritoSettingsModel.Instance.IndomitabilityPlayerCount);
        }

        private static async Task<bool> Broil()
        {
            if (!SuritoSettingsModel.Instance.UseBroil) return false;

            if (Me.ClassLevel >= 64)
                return await Spells.BroilII.Use(Target, true);

            return await Spells.Broil.Use(Target, true);
        }

        private static async Task<bool> DeploymentTactics()
        {
            if (!SuritoSettingsModel.Instance.UseDeploymentTactics) return false;

            var target = PartyMembers.FirstOrDefault(hm => (hm.HasAura(Auras.Adloquium, true, SuritoSettingsModel.Instance.DeploymentTacticsMinBuffTime) || hm.HasAura(Auras.EyeforanEye, true, SuritoSettingsModel.Instance.DeploymentTacticsMinBuffTime)) && 
            !hm.IsMe && hm.AlliesInRange(10) >= SuritoSettingsModel.Instance.DeploymentTacticsPlayerCount);

            if (SuritoSettingsModel.Instance.UseDelpoymentTacticsOnBothBuffsOnly)
               target = PartyMembers.FirstOrDefault(hm => (hm.HasAura(Auras.Adloquium, true, SuritoSettingsModel.Instance.DeploymentTacticsMinBuffTime) && hm.HasAura(Auras.EyeforanEye, true, SuritoSettingsModel.Instance.DeploymentTacticsMinBuffTime)) &&
               !hm.IsMe && hm.AlliesInRange(10) >= SuritoSettingsModel.Instance.DeploymentTacticsPlayerCount);

            if (target == null) return false;

            return await Spells.DeploymentTactics.Use(target, true);
        }

        private static async Task<bool> EmergencyTactics()
        {
            if (!SuritoSettingsModel.Instance.UseEmergencyTactics) return false;

            if (!SuritoSettingsModel.Instance.UseEmergencyTacticsOnTankOnly && HealManager.Count(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.EmergencyTacticsSuccorHpPct) >= SuritoSettingsModel.Instance.SuccorPlayerCount)
            {
                return await Spells.EmergencyTactics.CastBuff(Me, true, Auras.EmergencyTactics);
            }
            var target = HealManager.FirstOrDefault(hm =>
                hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.EmergencyTacticsAdloquiumHpPct);

            if (target != null && (target.IsTank() || !SuritoSettingsModel.Instance.UseEmergencyTacticsOnTankOnly))
            {
                return await Spells.EmergencyTactics.CastBuff(Me, true, Auras.EmergencyTactics);
            }

            return false;
        }

        private static async Task<bool> Dissipation()
        {
            if (!SuritoSettingsModel.Instance.UseDissipation || Me.Pet == null || Me.ClassLevel < 60) return false;

            if (Me.Pet.HasAura(Auras.Rouse)) return false;

            return await Spells.Dissipation.CastBuff(Me, HealManager.Any(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.DissipationHpPct), Auras.Dissipation);
        }

        private static async Task<bool> Excogitation()
        {
            if (!SuritoSettingsModel.Instance.UseExcogitation || ActionResourceManager.Arcanist.Aetherflow.Equals(0)) return false;

            var target = HealManager.FirstOrDefault(hm => !hm.IsMe &&
                hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.ExcogitationHpPct &&
                (hm.IsTank() || !SuritoSettingsModel.Instance.UseExcogitationOnTankOnly));

            if (target == null) return false;

            return await Spells.Excogitation.CastBuff(target, true, Auras.Excogitation);
        }

        private static async Task<bool> ChainStratagem()
        {
            if (!SuritoSettingsModel.Instance.UseChainStratagem || Target == null || !Target.CanAttack) return false;

            return await Spells.ChainStrategem.CastDot(Target, true, Auras.ChainStratagem);
        }

        private static async Task<bool> Aetherpact()
        {
            if (!SuritoSettingsModel.Instance.UseAetherpact || Me.Pet == null) return false;

            if (ActionResourceManager.Scholar.FaerieGauge < SuritoSettingsModel.Instance.AetherpactMinGuage) return false;

            var target = HealManager.FirstOrDefault(hm => hm.Distance(Me.Pet) <= 12 &&
                hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.AetherpactHpPct &&
                (hm.IsTank() || !SuritoSettingsModel.Instance.UseAetherpactOnTankOnly));

            if (target == null) return false;

            return await Spells.Aetherpact2.CastBuff(target, true, Auras.FeyUnion);
        }

        private static async Task<bool> Healbusters()
        {
            if (Target == null || !Target.CanAttack)
            {
                return false;
            }

            var tar = Me.CurrentTarget as BattleCharacter;

            var hasSpellAdloquium = HealBusterManager.Adloquium.Contains(tar.CastingSpellId);
            var hasSpellExcogitation = HealBusterManager.Excogitation.Contains(tar.CastingSpellId);
            var hasSpellLustrate = HealBusterManager.Lustrate.Contains(tar.CastingSpellId);
            var hasSpellAetherpact = HealBusterManager.Aetherpact.Contains(tar.CastingSpellId);
            var hasSpellSuccor = HealBusterManager.Succor.Contains(tar.CastingSpellId);
            var hasSpellSacredSoil = HealBusterManager.SacredSoil.Contains(tar.CastingSpellId);
            var hasSpellRouse = HealBusterManager.Rouse.Contains(tar.CastingSpellId);

            if (await Spells.Adloquium.CastHeal(tar.TargetGameObject, hasSpellAdloquium)) return true;
            if (await Spells.Excogitation.CastHeal(tar.TargetGameObject, hasSpellExcogitation)) return true;
            if (await Spells.Lustrate.CastHeal(tar.TargetGameObject, hasSpellLustrate)) return true;
            if (await Spells.Aetherpact.CastHeal(tar.TargetGameObject, hasSpellAetherpact)) return true;
            if (await Spells.Succor.CastHeal(Me, hasSpellSuccor)) return true;
            if (await Spells.SacredSoil.CastHeal(Me, hasSpellSacredSoil)) return true;
            if (await Spells.Rouse.CastHeal(Me, hasSpellRouse)) return true;

            return false;
        }

        #region Role Actions

        private static async Task<bool> ClericStance()
        {
            return await Spells.ClericStance.CastBuff(Me, HealManager.All(hm => hm.CurrentHealthPercent > SuritoSettingsModel.Instance.PhysickHpPct) && Me.CurrentManaPercent >= SuritoSettingsModel.Instance.DamageMinMpPct, Auras.ClericStance);
        }

        private static async Task<bool> Break()
        {
            return await Spells.Break.CastDot(Target, true, Auras.Heavy);
        }

        private static async Task<bool> Protect()
        {
            if (!SuritoSettingsModel.Instance.UseProtect) return false;

            if (PartyManager.IsInParty)
                if (CombatHelper.LastSpell == Spells.Protect || ActionManager.LastSpell == Spells.Protect ||
                    !SuritoSettingsModel.Instance.UseProtectInCombat && PartyMembers.Any(pm => pm.InCombat) ||
                    PartyMembers.Any(pm => pm.Icon == PlayerIcon.Viewing_Cutscene) ||
                    HealManager.All(hm => hm.HasAura(Auras.Protect)) ||
                    HealManager.Any(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.PhysickHpPct || hm.IsDead)) return false;

            var target = HealManager.FirstOrDefault(hm => !hm.HasAura(Auras.Protect));

            if (target == null) return false;

            return await Spells.Protect.CastBuff(target, CombatHelper.LastSpell != Spells.Protect, Auras.Protect);
        }

        private static async Task<bool> Esuna()
        {
            if (!SuritoSettingsModel.Instance.UseCleanse || HealManager.Any(hm => hm.CurrentHealthPercent < SuritoSettingsModel.Instance.CleanseHP)) return false;

            return await CleanseManager.DoCleanses();
        }

        private static async Task<bool> LucidDreaming()
        {
            return await Spells.LucidDreaming.Use(Me, SuritoSettingsModel.Instance.UseLucidDreaming && Me.CurrentManaPercent <= SuritoSettingsModel.Instance.LucidDreamingMpPct);
        }

        private static async Task<bool> EyeForAnEye()
        {
            if (!SuritoSettingsModel.Instance.UseEyeforanEye) return false;

            var target = HealManager.FirstOrDefault(hm => hm.IsTank() && (!SuritoSettingsModel.Instance.UseEyeforanEyeOnlyAfterAdloquium || hm.HasAura(Auras.Adloquium, true)));

            if (target == null)
            {
                target = HealManager.FirstOrDefault(hm => !hm.IsMe && (!SuritoSettingsModel.Instance.UseEyeforanEyeOnlyAfterAdloquium || hm.HasAura(Auras.Adloquium, true)));
            }

            if (target != null)
            {
                return await Spells.EyeforanEye.Use(target, !target.HasAura(Auras.EyeforanEye));
            }
            return false;
        }

        private static async Task<bool> Largesse()
        {
            if (!SuritoSettingsModel.Instance.UseLargesse) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.LargesseHpPct) < SuritoSettingsModel.Instance.LargessePlayerCount && !SuritoSettingsModel.Instance.UseLargesseOnTankOnly) return false;

            if (SuritoSettingsModel.Instance.UseLargesseOnTankOnly && !HealManager.Any(hm => hm.IsTank() && hm.CurrentHealthPercent < SuritoSettingsModel.Instance.LargesseHpPct)) return false;

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

        #region Custom Spells

        private static async Task<bool> Summon()
        {
            if (!SuritoSettingsModel.Instance.UseSummon || Me.ClassLevel < 4 || Me.HasAura(Auras.Dissipation) || (Me.InCombat && !SuritoSettingsModel.Instance.UseSummonInCombat))
            {
                return false;
            }

            switch (SuritoSettingsModel.Instance.SelectedSuritoSummon)
            {
                case SuritoSummonMode.None:
                    break;

                case SuritoSummonMode.Eos:
                    if (previousSuritoSummon == SuritoSummonMode.Selene && Me.ClassLevel > 14)
                    {
                        SuritoSettingsModel.Instance.SelectedSuritoSummon = SuritoSummonMode.Selene;
                        break;
                    }

                    if (ActionManager.LastSpell == Spells.Summon) return false;

                    if (Me.Pet == null || Me.Pet.EnglishName != "Eos")
                    {
                        if (ActionManager.CanCast(Spells.Swiftcast, Me) && SuritoSettingsModel.Instance.SwiftcastSummon)
                        {
                            if (await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast))
                                await Spells.Summon.Use(Me, true);
                        }

                        if (await Spells.Summon.Use(Me, true))
                        {
                            PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                            PetManager.DoAction(Spells.Obey.LocalizedName, Me);
                            return true;
                        }
                    }
                    break;

                case SuritoSummonMode.Selene:
                    if (Me.ClassLevel <= 14)
                    {
                        previousSuritoSummon = SuritoSummonMode.Selene;
                        SuritoSettingsModel.Instance.SelectedSuritoSummon = SuritoSummonMode.Eos;
                        break;
                    }

                    if (ActionManager.LastSpell == Spells.SummonII) return false;

                    if (Me.Pet == null || Me.Pet.EnglishName != "Selene")
                    {
                        if (ActionManager.CanCast(Spells.Swiftcast, Me) && SuritoSettingsModel.Instance.SwiftcastSummon)
                        {
                            if (await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast))
                                await Spells.SummonII.Use(Me, true);
                        }

                        if (await Spells.SummonII.Use(Me, true))
                        {
                            PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                            PetManager.DoAction(Spells.Obey.LocalizedName, Me);
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }

        private static async Task<bool> PetAction()
        {
            if (Me.HasAura(Auras.Dissipation) || Me.Pet == null || HealManager.Any(hm => hm.HasAura(Auras.FeyUnion)) || CombatHelper.GcdTimeRemaining < 10)
            {
                return false;
            }

            var target = HealManager.FirstOrDefault(hm => hm.InCombat);

            switch (SuritoSettingsModel.Instance.SelectedSuritoSummon)
            {
                case SuritoSummonMode.Eos:
                    if (SuritoSettingsModel.Instance.UseWhisperingDawn &&
                        PetManager.CanCast(Spells.WhisperingDawn.LocalizedName, Me.Pet) &&
                        HealManager.Count(hm => hm.Distance2D(Me.Pet) <= 15 && hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.WhisperingDawnHpPct) >= SuritoSettingsModel.Instance.PetAoEPlayerCount)
                    {
                        return PetManager.DoAction(Spells.WhisperingDawn.LocalizedName, Me.Pet);
                    }

                    if (SuritoSettingsModel.Instance.UseFeyCovenant &&
                        PetManager.CanCast(Spells.FeyCovenant.LocalizedName, Me.Pet) &&
                        HealManager.Count(hm => hm.Distance2D(Me.Pet) <= 15 && hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.FeyCovenantHpPct) >= SuritoSettingsModel.Instance.PetAoEPlayerCount)
                    {
                        return PetManager.DoAction(Spells.FeyCovenant.LocalizedName, Me.Pet);
                    }

                    if (SuritoSettingsModel.Instance.UseFeyIllumination &&
                        PetManager.CanCast(Spells.FeyIllumination.LocalizedName, Me.Pet) &&
                        HealManager.Count(hm => hm.Distance2D(Me.Pet) <= 15 && hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.FeyIlluninationHpPct) >= SuritoSettingsModel.Instance.PetAoEPlayerCount)
                    {
                        return PetManager.DoAction(Spells.FeyIllumination.LocalizedName, Me.Pet);
                    }

                    if (SuritoSettingsModel.Instance.UseEmbrace)
                    {
                        target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.EmbraceHpPct);
                        if (target != null && PetManager.CanCast(Spells.Embrace.LocalizedName, target))
                        return PetManager.DoAction(Spells.Embrace.LocalizedName, target);
                    }
                    break;

                case SuritoSummonMode.Selene:
                    if (SuritoSettingsModel.Instance.UseEmbrace)
                    {
                        target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.EmbraceHpPct);
                        if (target != null && PetManager.CanCast(Spells.Embrace.LocalizedName, target))
                        return PetManager.DoAction(Spells.Embrace.LocalizedName, target);
                    }

                    if (SuritoSettingsModel.Instance.UseSilentDusk)
                    {
                        target = HealManager.FirstOrDefault(hm => hm.CanSilence());
                        if (target != null && PetManager.CanCast(Spells.SilentDusk.LocalizedName, target))
                        return PetManager.DoAction(Spells.SilentDusk.LocalizedName, target);
                    }

                    if (SuritoSettingsModel.Instance.UseFeyCaress &&
                    PetManager.CanCast(Spells.FeyCaress.LocalizedName, Me.Pet) &&
                    HealManager.Count(hm => hm.Distance2D(Me.Pet) <= 20) >= SuritoSettingsModel.Instance.PetAoEPlayerCount)
                    {
                        return await CleanseManager.PetCleanse();
                    }

                    if (SuritoSettingsModel.Instance.UseFeyWind &&
                        PetManager.CanCast(Spells.FeyWind.LocalizedName, Me.Pet) &&
                        HealManager.Count(hm => hm.IsDps() && hm.Distance2D(Me.Pet) <= 20) >= SuritoSettingsModel.Instance.PetAoEPlayerCount)
                    {
                        return PetManager.DoAction(Spells.FeyWind.LocalizedName, Me.Pet);
                    }
                    break;
            }
            return false;
        }

        #endregion Custom Spells
    }
}