using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Buddy.Coroutines;
using Clio.Utilities.Helpers;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Eiko
{
    public static partial class EikoRotation
    {
        private static EikoSummonMode previousEikoSummon;
        private static int summonLimiterCount;
        private static DateTime summonLimiter;

        private static int AetherflowStacks => ActionResourceManager.Arcanist.Aetherflow;
        private static int AetherialStacks => ActionResourceManager.Arcanist.AetherAttunement;
        private static bool DreadwormTrance => ActionResourceManager.Summoner.DreadwyrmTrance;
        private static double DreadwormTranceTime => ActionResourceManager.Summoner.Timer.TotalMilliseconds;

        private static uint BioAura()
        {
            if (Me.ClassLevel >= 66) return Auras.BioIII;
            return Me.ClassLevel >= 26 ? Auras.BioII : Auras.Bio;
        }

        private static uint MiasmaAura()
        {
            return Me.ClassLevel >= 66 ? Auras.MiasmaIII : Auras.Miasma;
        }

        private static async Task<bool> Ruin()
        {
            if (CombatHelper.LastSpell == Spells.DreadwyrmTrance) return false;

            var conditions = !DreadwormTrance || DreadwormTrance && DreadwormTranceTime >= Spells.RuinIII.AdjustedCastTime.TotalMilliseconds + 250;

            return Me.ClassLevel >= 54 ? await Spells.RuinIII.Use(Target, conditions)
                : await Spells.Ruin.Use(Target, conditions);
        }

        //private static async Task<bool> RuinIII()
        //{
        //    return await Spells.RuinIII.Use(Target, DreadwormTrance && DreadwormTranceTime >= Spells.RuinIII.AdjustedCastTime.TotalMilliseconds + 250
        //                                            || (!DreadwormTrance && Me.CurrentManaPercent >= EikoSettingsModel.Instance.MpLimitPct));
        //}

        private static async Task<bool> RuinIV()
        {
            return await Spells.RuinIV.Use(Target, Me.HasAura(Auras.FurtherRuin));
        }

        private static async Task<bool> Bio()
        {
            if (Target == null || !Target.CanAttack) return false;

            return await Spells.Bio.CastDot(Target, (Spells.TriDisaster.Cooldown.TotalSeconds > 6 || AetherialStacks < 3 || Me.ClassLevel < 56) &&
                EikoSettingsModel.Instance.UseDoTs &&
                !DreadwormTrance &&
                (!Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.BioRfsh) || (!Target.HasAura(BioAura(), true, 10000) && Spells.DreadwyrmTrance.Cooldown.TotalSeconds <= 3 && AetherialStacks >= 2)) &&
                ActionManager.LastSpell != Spells.Bio &&
                CombatHelper.LastSpell != Spells.Bio &&
                Target.HealthCheck(true)
                && Target.TimeToDeathCheck(),
                BioAura());
        }

        private static async Task<bool> Physick()
        {
            if (EikoSettingsModel.Instance.UsePhysick || (!BotManager.Current.IsAutonomous && !EikoSettingsModel.Instance.UsePhysickInNonAutonomous)) return false;

            if (Me.CurrentHealthPercent < EikoSettingsModel.Instance.SelfHealPct)
                return await Spells.Physick.Use(Me, true);

            if (Me.Pet != null && Me.Pet.CurrentHealthPercent <= EikoSettingsModel.Instance.SummonHealPct)
                return await Spells.Physick.Use(Me.Pet, true);

            return false;
        }

        private static async Task<bool> Aetherflow()
        {
            if (EikoSettingsModel.Instance.UseAetherflow && AetherialStacks == 0 && AetherflowStacks == 0)
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && (ActionManager.CanCast(Spells.Aetherflow, Me) || Me.ClassLevel < 38)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Aetherflow, Me));
                    return await Spells.Aetherflow.Use(Me, true);
                }
                return await Spells.Aetherflow.Use(Me, true);
            }
            return false;
        }

        private static async Task<bool> EnergyDrain()
        {
            if (EikoSettingsModel.Instance.UseAetherflowAbilities &&
                ((Me.CurrentManaPercent <= EikoSettingsModel.Instance.MpLimitPct && EikoSettingsModel.Instance.UseEnergyDrain) || (Me.CurrentManaPercent < 95 && Me.ClassLevel < 30)) &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && (ActionManager.CanCast(Spells.EnergyDrain, Target) || Me.ClassLevel < 38)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.EnergyDrain, Target));
                    return await Spells.EnergyDrain.Use(Target, true);
                }
                return await Spells.EnergyDrain.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> Miasma()
        {
            if (Target == null || !Target.CanAttack) return false;

            return await Spells.Miasma.CastDot(Target, (Spells.TriDisaster.Cooldown.TotalSeconds > 6 || AetherialStacks < 3 || Me.ClassLevel < 56) &&
                EikoSettingsModel.Instance.UseDoTs &&
                !DreadwormTrance &&
                (!Target.HasAura(MiasmaAura(), true, EikoSettingsModel.Instance.MiasmaRfsh) || (!Target.HasAura(MiasmaAura(), true, 15000) && Spells.DreadwyrmTrance.Cooldown.TotalSeconds <= 3 && AetherialStacks >= 2)) &&
                ActionManager.LastSpell != Spells.Miasma &&
                CombatHelper.LastSpell != Spells.Miasma &&
                ActionManager.LastSpell != Spells.MiasmaIII &&
                CombatHelper.LastSpell != Spells.MiasmaIII &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck(),
                MiasmaAura());
        }

        private static async Task<bool> Resurrection()
        {
            if (!EikoSettingsModel.Instance.UseResurrection || Me.CurrentManaPercent < EikoSettingsModel.Instance.ResurrectionMinMpPct && !Me.HasAura(Auras.Swiftcast)) return false;

            var target = PartyMembers.FirstOrDefault(pm => pm.IsDead
                && pm.Type == GameObjectType.Pc
                && pm.IsHealer()
                && !pm.HasAura(Auras.Raise)
                && !pm.HasAura(Auras.Raise2));

            return await Spells.Resurrection.Use(target, true);
        }

        private static async Task<bool> Bane()
        {
            if (EikoSettingsModel.Instance.UseAoE
                && EikoSettingsModel.Instance.UseAetherflowAbilities
                && Target?.EnemiesInRange(8) >= EikoSettingsModel.Instance.MobCount
                && Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.MinBaneTime)
                && Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.MinBaneTime)
                && Target.HasAura(MiasmaAura(), true, EikoSettingsModel.Instance.MinBaneTime)
                && Target.HealthCheck(true)
                && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && (ActionManager.CanCast(Spells.Bane, Target) || Me.ClassLevel < 38)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Bane, Target));
                    return await Spells.Bane.Use(Target, true);
                }
                return await Spells.Bane.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> Sustain()
        {
            return await Spells.Sustain.Use(Me, Me.Pet != null && Me.Pet.CurrentHealthPercent < EikoSettingsModel.Instance.SummonHealPct && CombatHelper.LastSpell != Spells.Sustain && !Me.Pet.HasAura(Auras.Sustain));
        }

        private static async Task<bool> RuinII()
        {
            if (await Spells.RuinII.Use(Target, MovementManager.IsMoving && !DreadwormTrance))
                return true;

            return await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UseRuin2Filler && !DreadwormTrance && CombatHelper.LastSpell != Spells.DreadwyrmTrance && AetherialStacks <= 3 && !ActionManager.CanCast(Spells.DreadwyrmTrance, Me));
        }

        private static async Task<bool> Shadowflare()
        {
            if (Target == null || !Target.CanAttack || !EikoSettingsModel.Instance.UseShadowFlare ||
                Me.HasAura(Auras.ShadowFlare) || DreadwormTrance ||
                !ActionManager.CanCast(Spells.ShadowFlare, Target) ||
                !Target.HealthCheck(false) || !Target.TimeToDeathCheck())
                return false;

            return await Spells.ShadowFlare.CastBuff(Target, true, Auras.ShadowFlare, 28000);
        }

        private static async Task<bool> Protect()
        {
            if (!Me.HasAura(Auras.Protect))
            {
                return await Spells.Protect.CastBuff(Me, ActionManager.LastSpell != Spells.Protect && CombatHelper.LastSpell != Spells.Protect, Auras.Protect);
            }
            return false;
        }

        private static async Task<bool> Fester()
        {
            if (EikoSettingsModel.Instance.UseAetherflowAbilities &&
                (Target?.EnemiesInRange(8) < EikoSettingsModel.Instance.MobCount || !EikoSettingsModel.Instance.UseAoE) &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck() &&
                Target.HasAura(BioAura(), true) && Target.HasAura(BioAura(), true) &&
                Target.HasAura(MiasmaAura(), true))
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && (ActionManager.CanCast(Spells.Fester, Target) || Me.ClassLevel < 38)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Fester, Target));
                    return await Spells.Fester.Use(Target, true);
                }
                return await Spells.Fester.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> Rouse()
        {
            if (ActionManager.CanCast(Spells.Rouse, Me) && EikoSettingsModel.Instance.UseBuffs &&
                CombatHelper.LastSpell != Spells.Rouse &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.Rouse, Me)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Rouse, Me));
                    await Spells.Rouse.Use(Me, true);
                    return false;
                }
                await Spells.Rouse.Use(Me, true);
                return false;
            }
            return false;
        }

        private static async Task<bool> Enkindle()
        {
            if (ActionManager.CanCast(Spells.Enkindle, Target) && EikoSettingsModel.Instance.UseBuffs &&
                CombatHelper.LastSpell != Spells.Enkindle &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.Enkindle, Target)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Enkindle, Target));
                    await Spells.Enkindle.Use(Target, true);
                    return false;
                }
                await Spells.Enkindle.Use(Target, true);
                return false;
            }
            return false;
        }

        private static async Task<bool> Aetherpact()
        {
            if (ActionManager.CanCast(Spells.Aetherpact, Me) && EikoSettingsModel.Instance.UseBuffs
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                if (await Spells.Aetherpact.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.Aetherpact, Me)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Aetherpact, Me));
                    await Spells.Aetherpact.Use(Me, true);
                    return false;
                }
                await Spells.Aetherpact.Use(Me, true);
                return false;
            }
            return false;
        }

        private static async Task<bool> Painflare()
        {
            if (EikoSettingsModel.Instance.UseAetherflowAbilities
                && EikoSettingsModel.Instance.UseAoE
                && Target?.EnemiesInRange(8) >= EikoSettingsModel.Instance.MobCount
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.Painflare, Target)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Painflare, Target));
                    return await Spells.Painflare.Use(Target, true);
                }
                return await Spells.Painflare.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> Tridisaster_SingleTarget()
        {
            if (EikoSettingsModel.Instance.UseDoTs &&
                EikoSettingsModel.Instance.UseTriDisaster &&
                DreadwormTrance && DreadwormTranceTime >= 4000 &&
                (!Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.BioRfsh) || !Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.BioIiRfsh) || !Target.HasAura(MiasmaAura(), true, EikoSettingsModel.Instance.MiasmaRfsh) || Spells.Contagion.Cooldown.TotalSeconds <= 3) &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.TriDisaster, Target)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.TriDisaster, Target));
                    return await Spells.TriDisaster.CastDot(Target, true, MiasmaAura(), 22000);
                }
                return await Spells.TriDisaster.CastDot(Target, true, MiasmaAura(), 22000);
            }
            return false;
        }

        private static async Task<bool> Tridisaster_AoE()
        {
            if (EikoSettingsModel.Instance.UseDoTs &&
                EikoSettingsModel.Instance.UseTriDisaster &&
                EikoSettingsModel.Instance.UseAoE &&
                (!Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.BioRfsh) || !Target.HasAura(BioAura(), true, EikoSettingsModel.Instance.BioIiRfsh) || !Target.HasAura(MiasmaAura(), true, EikoSettingsModel.Instance.MiasmaRfsh)) &&
                Target.EnemiesInRange(8) >= EikoSettingsModel.Instance.MobCount &&
                Target.HealthCheck(true) && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.TriDisaster, Target)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.TriDisaster, Target));
                    return await Spells.TriDisaster.CastDot(Target, true, MiasmaAura(), 22000);
                }
                return await Spells.TriDisaster.CastDot(Target, true, MiasmaAura(), 22000);
            }
            return false;
        }

        private static async Task<bool> DreadwyrmTrance()
        {
            if (EikoSettingsModel.Instance.UseAetherflowAbilities
                && ((Target.HasAura(BioAura(), true, 3000) && Target.HasAura(BioAura(), true, 3000) && Target.HasAura(MiasmaAura(), true, 3000)) || Spells.TriDisaster.Cooldown.TotalSeconds < 3)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, ActionManager.CanCast(Spells.DreadwyrmTrance, Me)))
                {
                    if (EikoSettingsModel.Instance.UseSwiftcast && ActionManager.CanCast(Spells.Swiftcast, Me))
                    {
                        CombatHelper.CombatQueue.Enqueue(Spells.Swiftcast);
                        CombatHelper.CombatQueue.Enqueue(Spells.DreadwyrmTrance);
                        CombatHelper.CombatQueue.Enqueue(Spells.RuinIII);

                        var swiftcastStopwatch = new Stopwatch();
                        swiftcastStopwatch.Start();

                        while (Target != null && CombatHelper.CombatQueue.Count > 0 &&
                               swiftcastStopwatch.ElapsedMilliseconds < 2000)
                        {
                            var swiftcastSpell = CombatHelper.CombatQueue.Peek();

                            await Coroutine.Wait(2500, () => ActionManager.CanCast(swiftcastSpell, Me));

                            if (swiftcastSpell.Range == 0)
                            {
                                if (await swiftcastSpell.Use(Me, true))
                                {
                                    CombatHelper.CombatQueue.Dequeue();
                                    continue;
                                }
                            }

                            if (await swiftcastSpell.Use(Target, true))
                            {
                                CombatHelper.CombatQueue.Dequeue();
                                continue;
                            }

                            await Coroutine.Yield();
                        }
                        CombatHelper.CombatQueue.Clear();
                        swiftcastStopwatch.Stop();
                        return true;
                    }
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.DreadwyrmTrance, Me));
                    return await Spells.DreadwyrmTrance.Use(Me, true);
                }
                return await Spells.DreadwyrmTrance.Use(Me, true);
            }
            return false;
        }

        private static async Task<bool> Deathflare()
        {
            if (EikoSettingsModel.Instance.UseAetherflowAbilities
                && DreadwormTranceTime < 1000
                && ActionManager.LastSpell != Spells.DreadwyrmTrance
                && CombatHelper.LastSpell != Spells.DreadwyrmTrance
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck())
            {
                if (await Spells.RuinII.Use(Target, EikoSettingsModel.Instance.UsePreRuinoGcDs && ActionManager.CanCast(Spells.Deathflare, Target)))
                {
                    await Coroutine.Wait(1000, () => ActionManager.CanCast(Spells.Deathflare, Target));
                    return await Spells.Deathflare.Use(Target, true);
                }
                return await Spells.Deathflare.Use(Target, true);
            }
            return false;
        }

        private static async Task<bool> LucidDreaming()
        {
            return await Spells.LucidDreaming.Use(Me, Me.CurrentManaPercent <= EikoSettingsModel.Instance.MpLimitPct);
        }

        private static async Task<bool> ManaShift()
        {
            var manaShiftTarget = ManaShiftManager.FirstOrDefault();

            return await Spells.ManaShift.Use(manaShiftTarget, Me.CurrentManaPercent >= 50);
        }

        private static IEnumerable<BattleCharacter> ManaShiftManager
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                        .Where(hm => hm.IsAlive
                                    && PartyMembers.Contains(hm)
                                    && !hm.IsNpc
                                    && ((hm.IsHealer() && hm.CurrentManaPercent < 75) || (hm.CurrentJob == ClassJobType.Bard && hm.CurrentManaPercent < 25)));
            }
        }

        private static async Task<bool> Drain()
        {
            return await Spells.Drain.Use(Target, Me.ClassLevel < 4 && Me.CurrentHealthPercent <= EikoSettingsModel.Instance.SelfHealPct);
        }

        #region Misc

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !EikoSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        private static async Task<bool> SummonBahamut()
        {
            if (await Spells.SummonBahamut.Use(Me, AetherflowStacks == 3))
            {
                await Spells.Addle.Use(Target, true);
                return await EnkindleBahamut();
            }

            return false;
        }

        private static async Task<bool> EnkindleBahamut()
        {
            return await Spells.EnkindleBahamut.Use(Target, true);
        }

        private static async Task<bool> Heel()
        {
            return Me.Pet != null && !Me.IsMounted && EikoSettingsModel.Instance.UseHeel && Me.Distance(Me.Pet) > EikoSettingsModel.Instance.HeelDistance && PetManager.DoAction(Spells.Heel.LocalizedName, Me.Pet);
        }

        private static async Task<bool> PetActions()
        {
            if (Target == null || !Target.CanAttack || Me.Pet == null || !EikoSettingsModel.Instance.UseBuffs || !Target.HealthCheck(false) || !Target.TimeToDeathCheck() || !PetManager.LockTimer.IsFinished)
                return false;

            if (PetManager.LockTimer.WaitTime.Seconds != 2)
                PetManager.LockTimer = new WaitTimer(new TimeSpan(0, 0, 0, 2));

            if (Me.Pet.CurrentTargetId != Me.CurrentTargetObjId || Me.Pet.TargetCharacter == null || PetManager.PetMode != PetMode.Obey)
                PetManager.DoAction(Spells.Obey.LocalizedName, Target);

            if (PetManager.PetStance != PetStance.Guard)
                PetManager.DoAction(Spells.Guard.LocalizedName, Me);

            if (!DreadwormTrance)
            {
                if (await Aetherpact()) return true;
                if (await Rouse()) return true;
                if (await Enkindle()) return true;
            }

            switch (EikoSettingsModel.Instance.SelectedEikoSummon)
            {
                case EikoSummonMode.Garuda:
                    if (EikoSettingsModel.Instance.UseContagion
                        && Me.ClassLevel >= 40
                        && PetManager.CanCast(Spells.Contagion.LocalizedName, Target)
                        && DreadwormTrance
                        && Target.HasAura(BioAura(), true, 5000)
                        && Target.HasAura(MiasmaAura(), true, 5000)
                        && Spells.TriDisaster.Cooldown.TotalSeconds > 5 || Me.ClassLevel < 56)
                        return PetManager.DoAction(Spells.Contagion.LocalizedName, Target);

                    if (PetManager.CanCast(Spells.AerialSlash.LocalizedName, Target) &&
                        !DreadwormTrance)
                        return PetManager.DoAction(Spells.AerialSlash.LocalizedName, Target);
                    break;

                case EikoSummonMode.Titan:
                    if (PetManager.CanCast(Spells.MountainBuster.LocalizedName, Me.Pet))
                        return PetManager.DoAction(Spells.MountainBuster.LocalizedName, Me.Pet);

                    if (PetManager.CanCast(Spells.EarthenWard.LocalizedName, Me.Pet))
                        return PetManager.DoAction(Spells.EarthenWard.LocalizedName, Me.Pet);

                    if (PetManager.CanCast(Spells.Landslide.LocalizedName, Target) && (Target.CanStun() || ((Character)Target).IsCasting))
                        return PetManager.DoAction(Spells.Landslide.LocalizedName, Target);
                    break;

                case EikoSummonMode.Ifrit:
                    if (PetManager.CanCast(Spells.CrimsonCyclone.LocalizedName, Target) && (Target.CanStun() || ((Character)Target).IsCasting))
                        return PetManager.DoAction(Spells.CrimsonCyclone.LocalizedName, Target);

                    if (PetManager.CanCast(Spells.RadiantShield.LocalizedName, Me.Pet))
                        return PetManager.DoAction(Spells.RadiantShield.LocalizedName, Me.Pet);

                    if (PetManager.CanCast(Spells.FlamingCrush.LocalizedName, Me.Pet))
                        return PetManager.DoAction(Spells.FlamingCrush.LocalizedName, Me.Pet);
                    break;
            }

            return false;
        }

        private static async Task<bool> Summon()
        {
            if (!EikoSettingsModel.Instance.UseSummonPets
                || !ActionManager.CanCast(Spells.Summon, Me)
                || Me.ClassLevel <= 3
                || Me.IsCasting
                || CombatHelper.LastSpell == Spells.Summon
                || CombatHelper.LastSpell == Spells.SummonII
                || CombatHelper.LastSpell == Spells.SummonIII
                || ActionManager.LastSpell == Spells.Summon
                || ActionManager.LastSpell == Spells.SummonII
                || ActionManager.LastSpell == Spells.SummonIII
                || Me.Pet?.NpcId == 6566) return false;

            if (Me.Pet == null && summonLimiterCount < 2)
            {
                if (DateTime.Now < summonLimiter) return false;
                summonLimiter = DateTime.Now.AddMilliseconds(500);
                summonLimiterCount++;
                return false;
            }

            if (Me.Pet != null && summonLimiterCount != 0)
                summonLimiterCount = 0;

            switch (Me.CurrentJob)
            {
                case ClassJobType.Arcanist:
                    switch (EikoSettingsModel.Instance.SelectedEikoSummon)
                    {
                        case EikoSummonMode.None:
                            break;

                        case EikoSummonMode.Garuda:
                            if (previousEikoSummon == EikoSummonMode.Titan && Me.ClassLevel > 14)
                            {
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Titan;
                                break;
                            }

                            if (Me.Pet == null || PetManager.ActivePetType != PetType.Emerald_Carbuncle)
                            {
                                await Spells.Summon.Use(Me, true);

                                PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                                return true;
                            }
                            break;

                        case EikoSummonMode.Titan:
                            if (Me.ClassLevel <= 14)
                            {
                                previousEikoSummon = EikoSummonMode.Titan;
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Garuda;
                                break;
                            }

                            if (Me.Pet == null || PetManager.ActivePetType != PetType.Topaz_Carbuncle)
                            {
                                await Spells.SummonII.Use(Me, true);

                                PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                                return true;
                            }
                            break;
                    }
                    break;

                case ClassJobType.Summoner:
                    switch (EikoSettingsModel.Instance.SelectedEikoSummon)
                    {
                        case EikoSummonMode.None:
                            break;

                        case EikoSummonMode.Garuda:

                            if (previousEikoSummon == EikoSummonMode.Titan && Me.ClassLevel > 14)
                            {
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Titan;
                                break;
                            }

                            if (Me.Pet == null || PetManager.ActivePetType != PetType.Garuda_Egi)
                            {
                                await Spells.Summon.Use(Me, true);

                                PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                                return true;
                            }
                            break;

                        case EikoSummonMode.Titan:
                            if (previousEikoSummon == EikoSummonMode.Ifrit && Me.ClassLevel > 29)
                            {
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Ifrit;
                                break;
                            }

                            if (Me.ClassLevel <= 14)
                            {
                                previousEikoSummon = EikoSummonMode.Titan;
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Garuda;
                                break;
                            }

                            if (Me.Pet == null || PetManager.ActivePetType != PetType.Titan_Egi)
                            {
                                await Spells.SummonII.Use(Me, true);

                                PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                                return true;
                            }
                            break;

                        case EikoSummonMode.Ifrit:
                            if (Me.ClassLevel <= 14)
                            {
                                previousEikoSummon = EikoSummonMode.Ifrit;
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Garuda;
                            }

                            if (Me.ClassLevel <= 29)
                            {
                                previousEikoSummon = EikoSummonMode.Ifrit;
                                EikoSettingsModel.Instance.SelectedEikoSummon = EikoSummonMode.Titan;
                            }

                            if (Me.Pet == null || PetManager.ActivePetType != PetType.Ifrit_Egi)
                            {
                                await Spells.SummonIII.Use(Me, true);

                                PetManager.DoAction(Spells.Guard.LocalizedName, Me);
                                return true;
                            }
                            break;
                    }
                    break;
            }
            return false;
        }

        public static async Task SetGlamours(string Glamour)
        {
            if (Me.CurrentJob == ClassJobType.Summoner && !QuestLogManager.IsQuestCompleted(67896))
            {
                switch (EikoSettingsModel.selectedGarudaGlamour)
                {
                    default:
                        if (EikoSettingsModel.Instance.SelectedGarudaGlamour != GarudaGlamour.None)
                            EikoSettingsModel.Instance.SelectedGarudaGlamour = GarudaGlamour.None;
                        break;
                }
                switch (EikoSettingsModel.selectedTitanGlamour)
                {
                    default:
                        if (EikoSettingsModel.Instance.SelectedTitanGlamour != TitanGlamour.None)
                            EikoSettingsModel.Instance.SelectedTitanGlamour = TitanGlamour.None;
                        break;
                }
                switch (EikoSettingsModel.selectedIfritGlamour)
                {
                    default:
                        if (EikoSettingsModel.Instance.SelectedIfritGlamour != IfritGlamour.None)
                            EikoSettingsModel.Instance.SelectedIfritGlamour = IfritGlamour.None;
                        break;
                }

                return;
            }

            if (Me.CurrentJob == ClassJobType.Arcanist)
            {
                switch (EikoSettingsModel.selectedGarudaGlamour)
                {
                    default:
                        if (EikoSettingsModel.Instance.SelectedGarudaGlamour != GarudaGlamour.EmeraldCarbuncle)
                            EikoSettingsModel.Instance.SelectedGarudaGlamour = GarudaGlamour.EmeraldCarbuncle;
                        break;
                }

                switch (EikoSettingsModel.selectedTitanGlamour)
                {
                    default:
                        if (EikoSettingsModel.Instance.SelectedTitanGlamour != TitanGlamour.TopazCarbuncle)
                            EikoSettingsModel.Instance.SelectedTitanGlamour = TitanGlamour.TopazCarbuncle;
                        break;
                }

                return;
            }

            if (Glamour == "Garuda")
            {
                switch (EikoSettingsModel.selectedGarudaGlamour)
                {
                    case GarudaGlamour.None:
                        ChatManager.SendChat("/egiglamour \"Garuda-Egi\"");
                        break;

                    case GarudaGlamour.EmeraldCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Garuda-Egi\" \"Emerald Carbuncle\"");
                        break;

                    case GarudaGlamour.TopazCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Garuda-Egi\" \"Topaz Carbuncle\"");
                        break;

                    case GarudaGlamour.RubyCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Garuda-Egi\" \"Ruby Carbuncle\"");
                        break;

                    default:
                        ChatManager.SendChat("/egiglamour \"Garuda-Egi\"");
                        break;
                }
                if (EikoSettingsModel.Instance.SelectedEikoSummon == EikoSummonMode.Garuda)
                {
                    PetManager.DoAction(Spells.Away.Name, Me);
                    Thread.Sleep(500);
                    await Summon();
                }
            }

            if (Glamour == "Titan")
            {
                switch (EikoSettingsModel.selectedTitanGlamour)
                {
                    case TitanGlamour.None:
                        ChatManager.SendChat("/egiglamour \"Titan-Egi\"");
                        break;

                    case TitanGlamour.EmeraldCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Titan-Egi\" \"Emerald Carbuncle\"");
                        break;

                    case TitanGlamour.TopazCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Titan-Egi\" \"Topaz Carbuncle\"");
                        break;

                    case TitanGlamour.RubyCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Titan-Egi\" \"Ruby Carbuncle\"");
                        break;

                    default:
                        ChatManager.SendChat("/egiglamour \"Titan-Egi\"");
                        break;
                }
                if (EikoSettingsModel.Instance.SelectedEikoSummon == EikoSummonMode.Titan)
                {
                    PetManager.DoAction(Spells.Away.Name, Me);
                    Thread.Sleep(500);
                    await Summon();
                }
            }

            if (Glamour == "Ifrit")
            {
                switch (EikoSettingsModel.selectedIfritGlamour)
                {
                    case IfritGlamour.None:
                        ChatManager.SendChat("/egiglamour \"Ifrit-Egi\"");
                        break;

                    case IfritGlamour.EmeraldCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Ifrit-Egi\" \"Emerald Carbuncle\"");
                        break;

                    case IfritGlamour.TopazCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Ifrit-Egi\" \"Topaz Carbuncle\"");
                        break;

                    case IfritGlamour.RubyCarbuncle:
                        ChatManager.SendChat("/egiglamour \"Ifrit-Egi\" \"Ruby Carbuncle\"");
                        break;

                    default:
                        ChatManager.SendChat("/egiglamour \"Ifrit-Egi\"");
                        break;
                }
                if (EikoSettingsModel.Instance.SelectedEikoSummon == EikoSummonMode.Ifrit)
                {
                    PetManager.DoAction(Spells.Away.Name, Me);
                    Thread.Sleep(500);
                    await Summon();
                }
            }
        }

        #endregion Misc
    }
}