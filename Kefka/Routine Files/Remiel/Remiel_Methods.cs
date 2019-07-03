using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Routine_Files.General;
using System.Linq;
using System.Threading.Tasks;
using Kefka.Models;
using Kefka.Utilities;
using Kefka.ViewModels;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Remiel
{
    internal partial class RemielRotation
    {
        internal static string DrawnCard;
        internal static string HeldCard;
        internal static string RoyalRoadEffect;
        internal static string CurrentArcana;
        internal static bool NewCard;
        
        public static int HighestHealSetting => RemielSettingsModel.Instance.BeneficHpPct / RemielSettingsModel.Instance.Benefic2HpPct;
        public static int HighestFloorSetting => RemielSettingsModel.Instance.AspectedBeneficFloorPct / RemielSettingsModel.Instance.Benefic2HpPct;

        internal static BattleCharacter CardTarget;

        private static async Task<bool> Malefic()
        {
            if (!RemielSettingsModel.Instance.UseMalefic || Target == null || !Target.CanAttack) return false;

            return await Spells.Malefic.Use(Target, true);
        }
        //TODO: Create a work around for the Health increase delay of heals
        private static async Task<bool> Benefic()
        {
            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BeneficHpPct);

            if (target == null) return false;

            if (target.IsTank())
            {
                if (RemielSettingsModel.Instance.AspectedBeneficFloorTanks && target.HasAura(Auras.AspectedBenefic) && target.CurrentHealthPercent > RemielSettingsModel.Instance.AspectedBeneficFloorPct) return false;

                return await Spells.Benefic.Use(target, true, true);
            }

            if (target.IsHealer())
            {
                if (RemielSettingsModel.Instance.AspectedBeneficFloorHealers && target.HasAura(Auras.AspectedBenefic) && target.CurrentHealthPercent > RemielSettingsModel.Instance.AspectedBeneficFloorPct) return false;

                return await Spells.Benefic.Use(target, true, true);
            }

            if (!target.IsDps()) return false;

            if (RemielSettingsModel.Instance.AspectedBeneficFloorDps && target.HasAura(Auras.AspectedBenefic) && target.CurrentHealthPercent > RemielSettingsModel.Instance.AspectedBeneficFloorPct) return false;

            return await Spells.Benefic.Use(target, true, true);
        }

        private static async Task<bool> BeneficII()
        {
            if (!RemielSettingsModel.Instance.UseBenefic2) return false;

            var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.Benefic2HpPct);

            if (target == null) return false;

            return await Spells.BeneficII.Use(target, true, true);

        }

        private static async Task<bool> Combust()
        {
            if (Target == null || !Target.CanAttack || !RemielSettingsModel.Instance.UseCombust) return false;

            return await Spells.Combust.CastDot(Target, !Target.HasAura(Auras.Combust, true, RemielSettingsModel.Instance.CombustRfsh)
                && !Target.HasAura(Auras.CombustII, true, RemielSettingsModel.Instance.CombustRfsh)
                && Target.HealthCheck(true)
                && Target.TimeToDeathCheck(), Auras.Combust);
        }

        private static async Task<bool> Lightspeed()
        {
            if (!RemielSettingsModel.Instance.UseLightspeed) return false;

            return await Spells.Lightspeed.CastBuff(Me, HealManager.Count(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.LightspeedHpPct) >= RemielSettingsModel.Instance.LightspeedPlayerCount, Auras.Lightspeed);
        }

        private static async Task<bool> Helios()
        {
            if (!RemielSettingsModel.Instance.UseHelios) return false;

            if (HealManager.Count(hm =>
                    hm.Distance2D(Me) <= 15 &&
                    hm.CurrentHealthPercent <= RemielSettingsModel.Instance.HeliosHpPct) >= RemielSettingsModel.Instance.HeliosPlayerCount &&
                RemielSettingsModel.Instance.UseHelios)
            {
                return await Spells.Helios.Use(Me, true, true);
            }
            return false;
        }

        private static async Task<bool> Ascend()
        {
            if (!RemielSettingsModel.Instance.UseAscend) return false;

            if (!HealManager.Any(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BeneficHpPct))
            {
                var target = ResManager.FirstOrDefault(pm => pm.IsDead
                 && !pm.HasAura(Auras.Raise)
                 && !pm.HasAura(Auras.Raise2));

                if (target != null &&
                    ActionManager.CanCast(Spells.Ascend, target))
                {
                    if (RemielSettingsModel.Instance.UseSwiftcastAscend && ActionManager.CanCast(Spells.Swiftcast, Me))
                        await Spells.Swiftcast.CastBuff(Me, true, Auras.Swiftcast);

                    return await Spells.Ascend.Use(target, true, true);
                }
            }
            return false;
        }

        private static async Task<bool> EssentialDignity()
        {
            if (!RemielSettingsModel.Instance.UseEssentialDignity) return false;

            var target = HealManager.FirstOrDefault(hm => (hm.IsTank() || !RemielSettingsModel.Instance.UseEssentialDignityOnTankOnly) &&
                hm.CurrentHealthPercent <= RemielSettingsModel.Instance.EssentialDignityHpPct);

            if (target != null)
            {
                return await Spells.EssentialDignity.Use(target, true);
            }

            return false;
        }

        private static async Task<bool> AspectedBenefic()
        {
            if (RemielSettingsModel.Instance.UseAspectedBeneficWithDiurnal && Me.HasAura(Auras.DiurnalSect))
            {
                if (!Me.InCombat) return false;

                var target = HealManager.FirstOrDefault(hm => (!hm.HasAura(Auras.AspectedBenefic) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.DiurnalAspectedBeneficHpPct) ||
                (!hm.HasAura(Auras.AspectedBenefic, true, 4000) && hm.InCombat &&
                ((hm.IsTank() && RemielSettingsModel.Instance.KeepDiurnalAspectedBeneficOnTanks) ||
                (hm.IsHealer() && RemielSettingsModel.Instance.KeepDiurnalAspectedBeneficOnHealers) ||
                (hm.IsDps() && RemielSettingsModel.Instance.KeepDiurnalAspectedBeneficOnDps))));

                if (target == null) return false;

                if (target.IsTank() && RemielSettingsModel.Instance.DiurnalAspectedBeneficTanks)
                {
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.AspectedBenefic);
                }

                if (target.IsHealer() && RemielSettingsModel.Instance.DiurnalAspectedBeneficHealers)
                {
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.AspectedBenefic);
                }

                if (target.IsDps() && RemielSettingsModel.Instance.DiurnalAspectedBeneficDps)
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.AspectedBenefic);

                return false;
            }

            if (RemielSettingsModel.Instance.UseAspectedBeneficWithNocturnal && Me.HasAura(Auras.NocturnalSect))
            {
                var target = HealManager.FirstOrDefault(hm => (!hm.HasAura(Auras.NocturnalField) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.NocturnalAspectedBeneficHpPct) ||
            (!hm.HasAura(Auras.NocturnalField, true, 4000) && hm.InCombat &&
            ((hm.IsTank() && RemielSettingsModel.Instance.KeepNocturnalAspectedBeneficOnTanks) ||
            (hm.IsHealer() && RemielSettingsModel.Instance.KeepNocturnalAspectedBeneficOnHealers) ||
            (hm.IsDps() && RemielSettingsModel.Instance.KeepNocturnalAspectedBeneficOnDps))));

                if (target == null) return false;

                if (target.IsTank() && RemielSettingsModel.Instance.NocturnalAspectedBeneficTanks)
                {
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.NocturnalField);
                }

                if (target.IsHealer() && RemielSettingsModel.Instance.NocturnalAspectedBeneficHealers)
                {
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.NocturnalField);
                }

                if (target.IsDps() && RemielSettingsModel.Instance.NocturnalAspectedBeneficDps)
                    return await Spells.AspectedBenefic.CastBuff(target, true, Auras.NocturnalField);

                return false;
            }
            return false;
        }

        private static async Task<bool> AspectedHelios()
        {
            if (ActionManager.LastSpell == Spells.AspectedHelios || CombatHelper.LastSpell == Spells.AspectedHelios) return false;

            if (RemielSettingsModel.Instance.UseDiurnalAspectedHelios && Me.HasAura(Auras.DiurnalSect))
            {
                if (HealManager.Count(hm =>
                        hm.Distance(Me) <= 15 &&
                        hm.CurrentHealthPercent <= RemielSettingsModel.Instance.DiurnalAspectedHeliosHpPct &&
                        !hm.HasAura(Auras.AspectedHelios)) >= RemielSettingsModel.Instance.DiurnalAspectedHeliosPlayerCount)
                {
                    return await Spells.AspectedHelios.Use(Me, true, true);
                }
            }

            if (RemielSettingsModel.Instance.UseNocturnalAspectedHelios && Me.HasAura(Auras.NocturnalSect))
            {
                if (HealManager.Count(hm =>
                    hm.Distance(Me) <= 15 &&
                    hm.CurrentHealthPercent <= RemielSettingsModel.Instance.NocturnalAspectedHeliosHpPct &&
                    !hm.HasAura(Auras.NocturnalField)) >= RemielSettingsModel.Instance.NocturnalAspectedHeliosPlayerCount)
                {
                    return await Spells.AspectedHelios.Use(Me, true, true);
                }
            }
            return false;
        }

        private static async Task<bool> Synastry()
        {
            if (!RemielSettingsModel.Instance.UseSynastry) return false;

            var target = HealManager.FirstOrDefault(hm => (hm.IsTank() || !RemielSettingsModel.Instance.UseSynastryOnTankOnly) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.SynastryHpPct);

            return await Spells.Synastry.CastBuff(target, true, Auras.Synastry);
        }

        private static async Task<bool> Gravity()
        {
            if (!RemielSettingsModel.Instance.UseGravity || Target == null || !Target.CanAttack) return false;

            if (Me.CurrentManaPercent < RemielSettingsModel.Instance.GravityMinMpPct || Target.EnemiesInRange(5) < RemielSettingsModel.Instance.GravityMinTargets) return false;

            return await Spells.Gravity.Use(Target, true);
        }

        private static async Task<bool> TimeDilation()
        {
            if (!RemielSettingsModel.Instance.UseTimeDilation) return false;

            var target = HealManager.FirstOrDefault(pm => pm.IsAlive);

            if (RemielSettingsModel.Instance.UseTimeDilationAfterTankDiurnalBenefic && Me.HasAura(Auras.DiurnalSect))
            {
                target = HealManager.FirstOrDefault(hm => hm.IsTank() && hm.HasAura(Auras.AspectedBenefic));
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterBole)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheBole, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterBalance)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheBalance, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterArrow)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheArrow, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterSpear)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheSpear, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterSpire)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheSpire, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterEwer)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.TheEwer, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }

            if (RemielSettingsModel.Instance.UseTimeDilationAfterSynastry)
            {
                target = HealManager.FirstOrDefault(hm => hm.HasAura(Auras.Synastry, true) && !hm.IsMe);
                if (target != null)
                {
                    return await Spells.TimeDilation.Use(target, true);
                }
            }
            return false;
        }

        private static async Task<bool> CollectiveUnconscious()
        {
            if (!RemielSettingsModel.Instance.UseCollectiveUnconscious) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.CollectiveUnconsciousHpPct) >= RemielSettingsModel.Instance.CollectiveUnconsciousPlayerCount)
            {
                return await Spells.CollectiveUnconscious.CastBuff(Me, Me.AlliesInRange(6) >= RemielSettingsModel.Instance.CollectiveUnconsciousPlayerCount, Auras.CollectiveUnconscious);
            }
            return false;
        }

        private static async Task<bool> CelestialOpposition()
        {
            if (!RemielSettingsModel.Instance.UseCelestialOpposition) return false;

            if (RemielSettingsModel.Instance.UseCelestialOppositionAfterCollectiveUnconsciousness && Me.HasAura(Auras.CollectiveUnconscious))
            {
                //Todo: Determine The Correct Of The Three Different CollectiveUnconscious Auras
                if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.CollectiveUnconscious, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                    return await Spells.CelestialOpposition.Use(Me, true);
            }

            if (RemielSettingsModel.Instance.UseCelestialOppositionAfterLucidDreaming && Me.HasAura(Auras.LucidDreaming))
            {
                return await Spells.CelestialOpposition.Use(Me, true);
            }

            if (RemielSettingsModel.Instance.UseCelestialOppositionAfterExpandedCard)
            {
                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterBoleExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheBole, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }

                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterBalanceExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheBalance, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }

                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterArrowExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheArrow, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }

                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterSpearExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheSpear, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }

                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterSpireExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheSpire, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }

                if (RemielSettingsModel.Instance.UseCelestialOppositionAfterEwerExpanded)
                {
                    if (HealManager.Count(hm => hm.Distance2D(Me) <= 10 && hm.HasAura(Auras.TheEwer, true)) >= RemielSettingsModel.Instance.CelestialOppositionPlayerCount)
                        return await Spells.CelestialOpposition.Use(Me, true);
                }
            }
            return false;
        }

        private static async Task<bool> EarthlyStar()
        {
            if (!RemielSettingsModel.Instance.UseEarthlyStar) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.EarthlyStarHpPct) >= RemielSettingsModel.Instance.EarthlyStarPlayerCount)
            {
                var target = HealManager.FirstOrDefault(hm => hm.AlliesInRange(10) >= RemielSettingsModel.Instance.EarthlyStarPlayerCount);

                if (target != null)
                    return await Spells.EarthlyStar.Use(target, true);
            }

            if (RemielSettingsModel.Instance.UseEarthlyStarForDamage)
            {
                if (Target == null || !Target.CanAttack) return false;

                return await Spells.EarthlyStar.Use(Target, Target.EnemiesInRange(10) >= RemielSettingsModel.Instance.EarthlyStarPlayerCount);
            }

            return false;
        }

        private static async Task<bool> SleeveDraw()
        {
            if (!RemielSettingsModel.Instance.UseSleeveDraw) return false;

            if (await Spells.SleeveDraw.Use(Me, true))
            {
                NewCard = true;
                return true;
            }
            return false;
        }

        private static async Task<bool> Healbusters()
        {
            if (Target == null || !Target.CanAttack)
            {
                return false;
            }

            var tar = Me.CurrentTarget as BattleCharacter;

            var hasSpellBeneficII = HealBusterManager.BeneficII.Contains(tar.CastingSpellId);
            var hasSpellAspectedBenefic = HealBusterManager.AspectedBenefic.Contains(tar.CastingSpellId);
            var hasSpellEssentialDignity = HealBusterManager.EssentialDignity.Contains(tar.CastingSpellId);
            var hasSpellAspectedHelios = HealBusterManager.AspectedHelios.Contains(tar.CastingSpellId);
            var hasSpellCollectiveUnconscious = HealBusterManager.CollectiveUnconscious.Contains(tar.CastingSpellId);

            if (hasSpellBeneficII) return await Spells.BeneficII.CastHeal(tar.TargetCharacter, true);
            if (hasSpellAspectedBenefic) return await Spells.AspectedBenefic.CastHeal(tar.TargetCharacter, true);
            if (hasSpellEssentialDignity) return await Spells.EssentialDignity.CastHeal(tar.TargetCharacter, true);
            if (await Spells.AspectedHelios.CastHeal(Me, hasSpellAspectedHelios)) return true;
            if (await Spells.CollectiveUnconscious.CastHeal(Me, hasSpellCollectiveUnconscious)) return true;

            return false;
        }

        #region Role Actions

        private static async Task<bool> ClericStance()
        {
            return await Spells.ClericStance.CastBuff(Me, HealManager.All(hm => hm.CurrentHealthPercent > RemielSettingsModel.Instance.BeneficHpPct) && Me.CurrentManaPercent >= RemielSettingsModel.Instance.DamageMinMpPct, Auras.ClericStance);
        }

        private static async Task<bool> Break()
        {
            if (Target == null || !Target.CanAttack || ActionManager.HasSpell("Break")) return false;

            return await Spells.Break.CastDot(Target, true, Auras.Heavy);
        }

        private static async Task<bool> Protect()
        {
            if (!RemielSettingsModel.Instance.UseProtect) return false;

            if (PartyManager.IsInParty)
                if (CombatHelper.LastSpell == Spells.Protect
                || ActionManager.LastSpell == Spells.Protect
                || !RemielSettingsModel.Instance.UseProtectInCombat && PartyMembers.Any(pm => pm.InCombat)
                || PartyMembers.Any(pm => pm.Icon == PlayerIcon.Viewing_Cutscene)
                || HealManager.All(hm => hm.HasAura(Auras.Protect))
                || HealManager.Any(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BeneficHpPct
                || hm.IsDead)) return false;

            var target = HealManager.FirstOrDefault(hm => !hm.HasAura(Auras.Protect));

            if (target == null) return false;

            return await Spells.Protect.CastBuff(target, CombatHelper.LastSpell != Spells.Protect, Auras.Protect);
        }

        private static async Task<bool> Esuna()
        {
            if (!RemielSettingsModel.Instance.UseCleanse || HealManager.Any(hm => hm.CurrentHealthPercent < RemielSettingsModel.Instance.CleanseHP)) return false;

            return await CleanseManager.DoCleanses();
        }

        private static async Task<bool> LucidDreaming()
        {
            if (!RemielSettingsModel.Instance.UseLucidDreaming) return false;

            return await Spells.LucidDreaming.Use(Me, Me.CurrentManaPercent <= RemielSettingsModel.Instance.LucidDreamingMpPct);
        }

        private static async Task<bool> EyeForAnEye()
        {
            if (!RemielSettingsModel.Instance.UseEyeforanEye) return false;

            var target = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.HasAura(Auras.EyeforanEye) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.EyeforanEyeHpPct);

            if (target == null)
            {
                target = HealManager.FirstOrDefault(hm => !hm.IsMe && !hm.HasAura(Auras.EyeforanEye) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.EyeforanEyeHpPct);
            }

            if (target == null) return false;

            return await Spells.EyeforanEye.Use(target, true);
        }

        private static async Task<bool> Largesse()
        {
            if (!RemielSettingsModel.Instance.UseLargesse) return false;

            if (HealManager.Count(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.LargesseHpPct) < RemielSettingsModel.Instance.LargessePlayerCount && !RemielSettingsModel.Instance.UseLargesseOnTankOnly) return false;

            if (RemielSettingsModel.Instance.UseLargesseOnTankOnly && !HealManager.Any(hm => hm.IsTank() && hm.CurrentHealthPercent < RemielSettingsModel.Instance.LargesseHpPct)) return false;

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
        private static async Task<bool> SectSwitch()
        {
            if (!PartyManager.IsInParty || !PartyMembers.Any(pm => !pm.IsMe && pm.IsHealer()))
            {
                switch (RemielSettingsModel.Instance.SelectedSectMode)
                {
                    case SoloSectMode.None:
                        break;

                    case SoloSectMode.Nocturnal:
                        if (!Me.HasAura(Auras.NocturnalSect))
                        {
                            return await Spells.NocturnalSect.CastBuff(Me, true, Auras.NocturnalSect);
                        }
                        break;

                    case SoloSectMode.Diurnal:
                        if (!Me.HasAura(Auras.DiurnalSect))
                        {
                            return await Spells.DiurnalSect.CastBuff(Me, true, Auras.DiurnalSect);
                        }
                        break;
                }
            }

            if (!Me.HasAura(Auras.DiurnalSect) && PartyMembers.Any(pm => pm.CurrentJob == ClassJobType.Scholar || !pm.IsMe && pm.HasAura(Auras.NocturnalSect)))
            {
                return await Spells.DiurnalSect.CastBuff(Me, true, Auras.DiurnalSect);
            }

            if (!Me.HasAura(Auras.NocturnalSect) && PartyMembers.Any(pm => pm.CurrentJob == ClassJobType.WhiteMage || !pm.IsMe && pm.HasAura(Auras.DiurnalSect)))
            {
                return await Spells.NocturnalSect.CastBuff(Me, true, Auras.NocturnalSect);
            }

            return false;
        }

        private static async Task<BattleCharacter> CardTargeter()
        {
            var autoCardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsDps() || PartyMembers.All(pm => !pm.IsDps())));
            var selectedCardTarget = CardTargetViewModel.Instance.CardTarget;

            if (RoyalRoadEffect == "Shared")
            {
                autoCardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsDps() || PartyMembers.All(pm => !pm.IsDps())) &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
            }

            if (selectedCardTarget == null) return autoCardTarget;

            return selectedCardTarget;
        }

        private static async Task CardCheck()
        {
            if (DrawnCard != ActionResourceManager.Astrologian.Cards.GetValue(0).ToString())
            {
                DrawnCard = ActionResourceManager.Astrologian.Cards.GetValue(0).ToString();
                Logger.RemielLog("Drawn Card = " + DrawnCard);
                NewCard = true;
            }
            if (HeldCard != ActionResourceManager.Astrologian.Cards.GetValue(1).ToString())
            {
                HeldCard = ActionResourceManager.Astrologian.Cards.GetValue(1).ToString();
                Logger.RemielLog("Held Card = " + HeldCard);
            }
            if (RoyalRoadEffect != ActionResourceManager.Astrologian.Buff.ToString())
            {
                RoyalRoadEffect = ActionResourceManager.Astrologian.Buff.ToString();
                Logger.RemielLog("Royal Road = " + RoyalRoadEffect);
            }
            if (CurrentArcana != ActionResourceManager.Astrologian.Arcana.ToString())
            {
                CurrentArcana = ActionResourceManager.Astrologian.Arcana.ToString();
                Logger.RemielLog("Minor Arcana = " + CurrentArcana);
            }
        }

        #region Card Ability Methods
        private static async Task<bool> Draw()
        {
            if (await Spells.Draw.Use(Me, true))
            {
                NewCard = true;
                return true;
            }
            return false;
        }

        #region Method to Cast Each of the Cards
        private static async Task<bool> CastCard(SpellData CardToCast, GameObject tar)
        {
            if (ActionManager.DoAction(CardToCast, CardTarget))
            {
                NewCard = false;
                Logger.CastMessage(CardToCast.LocalizedName, CardTarget.SafeName());
                CombatHelper.LastSpell = CardToCast;
                CombatHelper.LastTarget = CardTarget;
                await CombatHelper.SleepForLag();
                return true;
            }
            return false;
        }
        #endregion Method to Cast Each of the Cards

        #region Logic for Casting Cards
        private static async Task<bool> UseCard()
        {
            if (!Me.InCombat) return false;

            switch (RoyalRoadEffect)
            {
                #region Casting W/O RR Effect
                case "None":
                    if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                    switch (DrawnCard)
                    {
                        case "Balance":                            
                            CardTarget = await CardTargeter();
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheBalance, CardTarget);

                        case "Bole":
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheBole, CardTarget);

                        case "Arrow":
                            CardTarget = await CardTargeter();
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheArrow, CardTarget);

                        case "Spear":
                            CardTarget = await CardTargeter();
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheSpear, CardTarget);

                        case "Ewer":
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheEwer, CardTarget);

                        case "Spire":
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner && hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                            if (CardTarget == null)
                                break;

                            return await CastCard(Spells.TheSpire, CardTarget);
                    }
                    break;
                #endregion Casting W/O RR Effect
                #region Casting W/ Enhanced RR
                case "Potency":
                    switch (DrawnCard)
                    {
                        case "Balance":
                            if (RemielSettingsModel.Instance.EnhancedBalance)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBalance, CardTarget);
                            }
                            break;

                        case "Bole":
                            if (RemielSettingsModel.Instance.EnhancedBole)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBole, CardTarget);
                            }
                            break;

                        case "Arrow":
                            if (RemielSettingsModel.Instance.EnhancedArrow)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheArrow, CardTarget);
                            }
                            break;

                        case "Spear":
                            if (RemielSettingsModel.Instance.EnhancedSpear)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpear, CardTarget);
                            }
                            break;

                        case "Ewer":
                            if (RemielSettingsModel.Instance.EnhancedEwer)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheEwer, CardTarget);
                            }
                            break;

                        case "Spire":
                            if (RemielSettingsModel.Instance.EnhancedSpire)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner && hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpire, CardTarget);
                            }
                            break;
                    }
                    break;
                #endregion Casting W/ Enhanced RR
                #region Casting W/ Extended RR
                case "Duration":
                    switch (DrawnCard)
                    {
                        case "Balance":
                            if (RemielSettingsModel.Instance.ExtendedBalance)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBalance, CardTarget);
                            }
                            break;

                        case "Bole":
                            if (RemielSettingsModel.Instance.ExtendedBole)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBole, CardTarget);
                            }
                            break;

                        case "Arrow":
                            if (RemielSettingsModel.Instance.ExtendedArrow)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheArrow, CardTarget);
                            }
                            break;

                        case "Spear":
                            if (RemielSettingsModel.Instance.ExtendedSpear)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpear, CardTarget);
                            }
                            break;

                        case "Ewer":
                            if (RemielSettingsModel.Instance.ExtendedEwer)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheEwer, CardTarget);
                            }
                            break;

                        case "Spire":
                            if (RemielSettingsModel.Instance.ExtendedSpire)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner && hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpire, CardTarget);
                            }
                            break;
                    }
                    break;
                #endregion Casting W/ Extended RR
                #region Casting W/ Expanded RR
                case "Shared":
                    switch (DrawnCard)
                    {
                        case "Balance":
                            if (RemielSettingsModel.Instance.ExpandedBalance)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBalance, CardTarget);
                            }
                            break;

                        case "Bole":
                            if (RemielSettingsModel.Instance.ExpandedBole)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheBole, CardTarget);
                            }
                            break;

                        case "Arrow":
                            if (RemielSettingsModel.Instance.ExpandedArrow)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheArrow, CardTarget);
                            }
                            break;

                        case "Spear":
                            if (RemielSettingsModel.Instance.ExpandedSpear)
                            {
                                CardTarget = await CardTargeter();
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpear, CardTarget);
                            }
                            break;

                        case "Ewer":
                            if (RemielSettingsModel.Instance.ExpandedEwer)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && hm2.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheEwer, CardTarget);
                            }
                            break;

                        case "Spire":
                            if (RemielSettingsModel.Instance.ExpandedSpire)
                            {
                                CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner && hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent >= RemielSettingsModel.Instance.SpireTpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && hm2.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                                if (CardTarget == null)
                                    break;

                                return await CastCard(Spells.TheSpire, CardTarget);
                            }
                            break;
                    }
                    break;
                    #endregion Casting W/ Expanded RR
            }
            return false;
        }
        #endregion Logic for Casting Cards

        #region Royal Road Method
        private static async Task<bool> RoyalRoad()
        {
            await CardCheck();

            switch (DrawnCard)
            {
                case "None":
                    return false;

                case "Balance":
                    if (RemielSettingsModel.Instance.RoyalRoadEnhanced && (RemielSettingsModel.Instance.RoyalRoadBalance || HeldCard == "Balance" || HeldCard == "Spear")) break;
                    return false;

                case "Bole":
                    if (RemielSettingsModel.Instance.RoyalRoadEnhanced && RemielSettingsModel.Instance.RoyalRoadBole) break;
                    return false;

                case "Arrow":
                    if (RemielSettingsModel.Instance.RoyalRoadExtended && RemielSettingsModel.Instance.RoyalRoadArrow) break;
                    return false;

                case "Spear":
                    if (RemielSettingsModel.Instance.RoyalRoadExtended && (RemielSettingsModel.Instance.RoyalRoadSpear || HeldCard == "Balance" || HeldCard == "Spear")) break;
                    return false;

                case "Ewer":
                    if (HealManager.Count() < RemielSettingsModel.Instance.ExpandedPlayerCount) return false;
                    if (RemielSettingsModel.Instance.RoyalRoadExpanded && RemielSettingsModel.Instance.RoyalRoadEwer) break;
                    return false;

                case "Spire":
                    if (HealManager.Count() < RemielSettingsModel.Instance.ExpandedPlayerCount) return false;
                    if (RemielSettingsModel.Instance.RoyalRoadExpanded && RemielSettingsModel.Instance.RoyalRoadSpire) break;
                    return false;
            }
            if (await Spells.RoyalRoad.Use(Me, true))
            {
                NewCard = false;
                return true;
            }
            return false;
        }
        #endregion Royal Road Method

        #region Spread Method
        private static async Task<bool> Spread()
        {
            await CardCheck();

            switch (HeldCard)
            {
                #region Drawn to Held Logic
                case "None":
                    switch (DrawnCard)
                    {
                        case "None":
                            return false;

                        case "Balance":
                            if (!RemielSettingsModel.Instance.SpreadBalance) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;

                        case "Bole":
                            if (!RemielSettingsModel.Instance.SpreadBole) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;

                        case "Arrow":
                            if (!RemielSettingsModel.Instance.SpreadArrow) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;

                        case "Spear":
                            if (!RemielSettingsModel.Instance.SpreadSpear) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;

                        case "Ewer":
                            if (!RemielSettingsModel.Instance.SpreadEwer) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;

                        case "Spire":
                            if (!RemielSettingsModel.Instance.SpreadSpire) return false;
                            CardTarget = Me;
                            NewCard = false;
                            break;
                    }
                    break;
                #endregion Drawn to Held Logic

                #region Cast Held Card Logic
                    //TODO: Fix not casting spread card on occasion until the next drawn card
                #region Balance
                case "Balance":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedBalance) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedBalance) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedBalance) return false;
                            CardTarget = await CardTargeter();
                            break;
                    }
                    break;
                #endregion Balance
                #region Bole
                case "Bole":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedBole) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedBole) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct);
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedBole) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && (!RemielSettingsModel.Instance.BoleTank || hm.IsTank()) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && (hm2.IsTank() || !RemielSettingsModel.Instance.BoleTank) && hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BoleHpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                            break;
                    }
                    break;
                #endregion Bole
                #region Arrow
                case "Arrow":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedArrow) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedArrow) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedArrow) return false;
                            CardTarget = await CardTargeter();
                            break;
                    }
                    break;
                #endregion Arrow
                #region Spear
                case "Spear":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedSpear) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedSpear) return false;
                            CardTarget = await CardTargeter();
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedSpear) return false;
                            CardTarget = await CardTargeter();
                            break;
                    }
                    break;
                #endregion Spear
                #region Ewer
                case "Ewer":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat &&
                                (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedEwer) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat &&
                                (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedEwer) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat &&
                                (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct);
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedEwer) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat &&
                                (hm.IsHealer() || (!RemielSettingsModel.Instance.EwerHealer && (hm.CurrentJob == ClassJobType.Summoner || hm.CurrentJob == ClassJobType.BlackMage))) && hm.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && hm2.CurrentManaPercent <= RemielSettingsModel.Instance.EwerMpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                            break;
                    }
                    break;
                #endregion Ewer
                #region Spire
                case "Spire":
                    if (!Me.InCombat) return false;

                    switch (RoyalRoadEffect)
                    {
                        case "None":
                            if (RemielSettingsModel.Instance.UseHeldAndRoyalRoad) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner || hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                            break;

                        case "Potency":
                            if (!RemielSettingsModel.Instance.EnhancedSpire) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner || hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                            break;

                        case "Duration":
                            if (!RemielSettingsModel.Instance.ExtendedSpire) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && (hm.CurrentJob != ClassJobType.Summoner || hm.CurrentJob != ClassJobType.BlackMage) && hm.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct);
                            break;

                        case "Shared":
                            if (!RemielSettingsModel.Instance.ExpandedSpire) return false;
                            CardTarget = HealManager.FirstOrDefault(hm => hm.InCombat && hm.IsDps() && hm.CurrentTPPercent >= RemielSettingsModel.Instance.SpireTpPct &&
                                (HealManager.Count(hm2 => hm2.Distance2D(hm) <= 15 && hm2.CurrentTPPercent <= RemielSettingsModel.Instance.SpireTpPct) >= RemielSettingsModel.Instance.ExpandedPlayerCount || !PartyManager.IsInParty));
                            break;
                    }
                    break;
                #endregion Spire
                #endregion Cast Held Card Logic
            }
            if (CardTarget == null) return false;

            if (await Spells.Spread.Use(CardTarget, true))
            {
                return true;
            }
            return false;
        }
        #endregion Spread Method

        #region Minor Arcana Method
        private static async Task<bool> MinorArcana()
        {
            if (Me.ClassLevel < 66) return false;

            await CardCheck();

            switch (CurrentArcana)
            {
                case "None":
                    if (await Spells.MinorArcana.Use(Me, true))
                    {
                        NewCard = false;
                        return true;
                    }
                    break;

                case "LadyofCrowns":
                    var target = HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.LadyofCrownsHpPct);

                    if (target == null) break;

                    if (await Spells.MinorArcana.Use(target, true))
                    {
                        return true;
                    }
                    break;

                case "LordofCrowns":
                    if (!Me.InCombat) break;

                    if (Target == null || !Target.CanAttack) break;

                    if (await Spells.MinorArcana.Use(Target, true))
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
        #endregion Minor Arcana

        private static async Task<bool> Redraw()
        {
            if (!RemielSettingsModel.Instance.UseRedraw) return false;

            if (await Spells.Redraw.Use(Me, true))
            {
                NewCard = false;
                return true;
            }
            return false;
        }

        #region Cast Trash Cards Method
        private static async Task<bool> CastTrash()
        {
            SpellData CardtoCast = null;
            switch (DrawnCard)
            {
                case "Balance":
                    CardTarget = await CardTargeter();
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheBalance;
                    break;

                case "Bole":
                    CardTarget = HealManager.FirstOrDefault(hm => hm.IsTank());
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheBole;
                    break;

                case "Arrow":
                    CardTarget = await CardTargeter();
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheArrow;
                    break;

                case "Spear":
                    CardTarget = await CardTargeter();
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheSpear;
                    break;

                case "Ewer":
                    CardTarget = HealManager.FirstOrDefault(hm => hm.CurrentManaPercent < 95);
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheEwer;
                    break;

                case "Spire":
                    CardTarget = HealManager.FirstOrDefault(hm => hm.CurrentTPPercent < 95);
                    if (CardTarget == null) CardTarget = Me;

                    CardtoCast = Spells.TheSpire;
                    break;
            }

            if (CardtoCast == null) return false;

            if (await CastCard(CardtoCast, CardTarget))
            {
                NewCard = false;
                return true;
            }

            return false;
        }
        #endregion Cast Trash Cards Method

        private static async Task<bool> Undraw()
        {
            if (!RemielSettingsModel.Instance.UseUndraw) return false;

            if (await Spells.Undraw.Use(Me, true))
            {
                NewCard = false;
                return true;
            }
            return false;
        }
        #endregion Card Ability Methods

        private static async Task<bool> Play()
        {
            if (!RemielSettingsModel.Instance.UseCards) return false;
            if (!Me.InCombat && (!RemielSettingsModel.Instance.UseCardPrepOutOfCombat || (RemielSettingsModel.Instance.UseCardPrepOutOfCombatOnlyInParty && !PartyManager.IsInParty))) return false;

            await CardCheck();
            if (DrawnCard == "None" && Spells.Draw.Cooldown.TotalMilliseconds <= 1000)
            {
                if (Me.ClassLevel >= 70 && HeldCard == "None" && RoyalRoadEffect == "None" && RemielSettingsModel.Instance.UseSleeveDraw)
                    return await SleeveDraw();

                return await Draw();
            }
            await CardCheck();

            if (RemielSettingsModel.Instance.OnlyDraw) return false;

            string Card = DrawnCard;
            CardTarget = null;

            #region Redraw First
            if (RemielSettingsModel.Instance.UseRedraw && Spells.Redraw.Cooldown.TotalMilliseconds == 0)
            {
                switch (DrawnCard)
                {
                    case "None":
                        break;

                    case "Balance":
                        if (RemielSettingsModel.Instance.RedrawBalance) return await Redraw();
                        break;

                    case "Bole":
                        if (RemielSettingsModel.Instance.RedrawBole) return await Redraw();
                        break;

                    case "Arrow":
                        if (RemielSettingsModel.Instance.RedrawArrow) return await Redraw();
                        break;

                    case "Spear":
                        if (RemielSettingsModel.Instance.RedrawSpear) return await Redraw();
                        break;

                    case "Ewer":
                        if (RemielSettingsModel.Instance.RedrawEwer) return await Redraw();
                        break;

                    case "Spire":
                        if (RemielSettingsModel.Instance.RedrawSpire) return await Redraw();
                        break;
                }
            }
            #endregion Redraw First
            await CardCheck();
            if (NewCard == true && DrawnCard != "None")
                if (await UseCard()) return true;

            await CardCheck();
            if (NewCard == true && DrawnCard != "None" && (RoyalRoadEffect == "None" || 
                ((DrawnCard == "Ewer" || DrawnCard == "Spire") &&  RoyalRoadEffect != "Shared" && HealManager.Count() >= RemielSettingsModel.Instance.ExpandedPlayerCount) || 
                ((DrawnCard != "Ewer" && DrawnCard != "Spire") && RoyalRoadEffect == "Shared" && HealManager.Count() < RemielSettingsModel.Instance.ExpandedPlayerCount)))
            {
                if (await RoyalRoad()) return true;
            }

            await CardCheck();
            if (RemielSettingsModel.Instance.UseSpread)
                if (await Spread()) return true;

            await CardCheck();
            if (NewCard == true && DrawnCard != "None")
                if (await Redraw()) return true;

            await CardCheck();
            if (NewCard == true && DrawnCard != "None")
                if (await MinorArcana()) return true;

            await CardCheck();
            if (NewCard == true && DrawnCard != "None" && RemielSettingsModel.Instance.CastTrashCards && RoyalRoadEffect == "None")
                if (await CastTrash()) return true;

            await CardCheck();
            if (NewCard == true && DrawnCard != "None" && (Spells.Redraw.Cooldown.TotalMilliseconds > 5000 || Me.ClassLevel < 45))
                if (await Undraw()) return true;

            return false;
        }
        #endregion Custom Spells
    }
}