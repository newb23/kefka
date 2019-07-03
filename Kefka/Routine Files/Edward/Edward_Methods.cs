using System;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Edward
{
    public static partial class EdwardRotation
    {
        private static int Repertoire => ActionResourceManager.Bard.Repertoire;
        private static TimeSpan SongTimer => ActionResourceManager.Bard.Timer;
        private static DateTime _dotRefreshLimiter;

        private static int AuraCount
        {
            get
            {
                var aura = ((BattleCharacter)Target)?.CharacterAuras?.ToArray();
                var value = aura?.Length ?? 0;
                return value;
            }
        }

        private static uint WindbiteAura()
        {
            return Me.ClassLevel >= 64 ? Auras.StormBite : Auras.Windbite;
        }

        private static uint VenomousBiteAura()
        {
            return Me.ClassLevel >= 64 ? Auras.CausticBite : Auras.VenomousBite;
        }

        private static async Task<bool> HeavyShot()
        {
            return await Spells.HeavyShot.Use(Target, (!Me.HasAura(Auras.Barrage) && CombatHelper.LastSpell != Spells.Barrage) || Me.ClassLevel < 54);
        }

        private static async Task<bool> StraightShot()
        {
            if (ActionManager.CanCast(Spells.RefulgentArrow, Me)) return false;

            return await Spells.StraightShot.CastBuff(Target, (!Me.HasAura(Auras.StraightShot, true, 6000) || (Me.HasAura(Auras.StraighterShot) && Me.ClassLevel < 70))
                && CombatHelper.LastSpell != Spells.StraightShot
                && ActionManager.LastSpell != Spells.StraightShot
                && CombatHelper.LastSpell != Spells.Barrage
                && !Me.HasAura(Auras.Barrage), Auras.StraightShot, 15000);
        }

        private static async Task<bool> VenomousBite()
        {
            if (!EdwardSettingsModel.Instance.UseDots || CombatHelper.LastSpell == Spells.VenomousBite || ActionManager.LastSpell == Spells.VenomousBite || Me.HasAura(Auras.Barrage)) return false;

            return await Spells.VenomousBite.CastDot(Target, !Target.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh) && AuraCount < 29 && Target.HealthCheck(true) && Target.TimeToDeathCheck(), VenomousBiteAura(), 14000);
        }

        private static async Task<bool> MiserysEnd()
        {
            return await Spells.MiserysEnd.Use(Target, EdwardSettingsModel.Instance.UseMiserysEnd && Target?.CurrentHealthPercent <= 20);
        }

        private static async Task<bool> RepellingShot()
        {
            return await Spells.RepellingShot.Use(Target, EdwardSettingsModel.Instance.UseRepellingShot && Me.TargetDistance(5, false) && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Windbite()
        {
            if (!EdwardSettingsModel.Instance.UseDots || CombatHelper.LastSpell == Spells.Windbite || ActionManager.LastSpell == Spells.Windbite || Me.HasAura(Auras.Barrage)) return false;

            return await Spells.Windbite.CastDot(Target, !Target.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh) && AuraCount < 29 && Target.HealthCheck(true) && Target.TimeToDeathCheck(), WindbiteAura(), 14000);
        }

        private static async Task<bool> BluntArrow()
        {
            if (Target == null || !Target.CanAttack || EdwardSettingsModel.Instance.UseManualInterrupt || Me.ClassLevel < 42) return false;

            if (EdwardSettingsModel.Instance.UseInterruptList && Target.CanSilence())
                return await Spells.BluntArrow.Use(Target, true);

            return await Spells.BluntArrow.Use(Target, !EdwardSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, CombatHelper.OnGcd && Me.CurrentTPPercent <= 50) && Target.HealthCheck(false) && Target.TimeToDeathCheck();
        }

        private static async Task<bool> Tactician()
        {
            if (!EdwardSettingsModel.Instance.UseTactician || !PartyManager.IsInParty || !Target.HealthCheck(false) || !Target.TimeToDeathCheck() || ActionManager.LastSpell == Spells.Refresh || CombatHelper.LastSpell == Spells.Refresh) return false;

            if (PartyMembers.Count(pm => pm.IsAlive && pm.IsPhysical() && pm.CurrentTPPercent <= EdwardSettingsModel.Instance.TacticianTpPct) >= EdwardSettingsModel.Instance.TacticianMemberCount)
                return await Spells.Tactician.Use(Me, true);

            return await Spells.Tactician.Use(Me, await KefkaEnmityManager.TargetingMeCount() > 0);
        }

        private static async Task<bool> Refresh()
        {
            if (!EdwardSettingsModel.Instance.UseRefresh || !PartyManager.IsInParty || !Target.HealthCheck(false) || !Target.TimeToDeathCheck() || ActionManager.LastSpell == Spells.Tactician || CombatHelper.LastSpell == Spells.Tactician) return false;

            if (PartyMembers.Count(pm => pm.IsCaster() && pm.IsAlive && pm.CurrentManaPercent <= EdwardSettingsModel.Instance.RefreshMpPct) >= EdwardSettingsModel.Instance.RefreshMemberCount)
                return await Spells.Refresh.Use(Me, true);

            return await Spells.Refresh.Use(Me, await KefkaEnmityManager.TargetingMeCount() > 0);
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, Me.CurrentHealthPercent <= EdwardSettingsModel.Instance.SecondWindHpPct);
        }

        private static async Task<bool> PitchPerfect()
        {
            return await Spells.PitchPerfect.Use(Target, Repertoire == EdwardSettingsModel.Instance.RepertoireCount || SongTimer.Seconds < 2);
        }

        private static async Task<bool> RagingStrikes()
        {
            return await Spells.RagingStrikes.CastBuff(Me, EdwardSettingsModel.Instance.UseBuffs && 
                (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet
                    || (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.MagesBallad
                    && EdwardSettingsModel.Instance.UseAoE
                    && Target?.EnemiesInRange(8) >= EdwardSettingsModel.Instance.MobCount
                    && Me.CurrentTP >= EdwardSettingsModel.Instance.TpLimit))
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.RagingStrikes);
        }

        private static async Task<bool> Barrage()
        {
            if (!EdwardSettingsModel.Instance.UseBuffs || ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon) return false;

            if (!Me.HasAura(Auras.RagingStrikes) && Spells.RagingStrikes.Cooldown.TotalMilliseconds < 5000) return false;

            if (Me.ClassLevel < Spells.EmpyrealArrow.LevelAcquired)
                return await Spells.Barrage.CastBuff(Me, true, Auras.Barrage);

            if (Me.HasAura(Auras.StraighterShot))
            {
                if (Me.ClassLevel >= Spells.RefulgentArrow.LevelAcquired && Target.HealthCheck(false) && Target.TimeToDeathCheck())
                {
                    if (ActionManager.CanCast(Spells.RefulgentArrow, Target) || ActionManager.CanCast(Spells.EmpyrealArrow, Target))
                    {
                        await Spells.Barrage.CastBuff(Me, true, Auras.Barrage);
                        if (await RefulgentArrow()) return true;
                        return await EmpyrealArrow();
                    }
                }
            }

            if (Spells.EmpyrealArrow.Cooldown.TotalMilliseconds > 0) return false;

            if (await Spells.Barrage.CastBuff(Me, Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.Barrage))
            {
                if (await RefulgentArrow()) return true;
                return await Spells.EmpyrealArrow.Use(Target, true);
            }

            return false;
        }

        private static async Task<bool> RefulgentArrow()
        {
            if (Target == null || !Target.CanAttack || Me.ClassLevel < 70)
                return false;

            if ((Target.HealthCheck(false) && Target.TimeToDeathCheck()) || Me.HasAura(Auras.Barrage))
            {
                return await Spells.RefulgentArrow.Use(Target, Spells.Barrage.Cooldown.TotalMilliseconds > 8000 || Me.HasAura(Auras.Barrage));
            }
            return false;
        }

        private static async Task<bool> EmpyrealArrow()
        {
            if (Target == null || !Target.CanAttack || Me.ClassLevel < Spells.EmpyrealArrow.LevelAcquired || !Target.HealthCheck(false) || !Target.TimeToDeathCheck() || Spells.Barrage.Cooldown.TotalMilliseconds.IsWithin(0001, 1000)
                || (EdwardSettingsModel.Instance.UseSongs && (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.None && Me.ClassLevel > 29)))
                return false;

            if (ActionManager.LastSpell == Spells.HeavyShot || CombatHelper.LastSpell == Spells.Barrage)
                await Coroutine.Wait(250, () => Me.HasAura(Auras.StraighterShot));

            if (Me.HasAura(Auras.StraighterShot) && Me.ClassLevel >= Spells.RefulgentArrow.LevelAcquired) return false;

            if (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.MagesBallad && ActionManager.CanCast(Spells.Bloodletter, Target)) return false;

            return await Spells.EmpyrealArrow.Use(Target, Me.HasAura(Auras.Barrage) || ActionResourceManager.Bard.ActiveSong != ActionResourceManager.Bard.BardSong.ArmysPaeon || ActionResourceManager.Bard.Timer.TotalMilliseconds > 14000);
        }

        private static int EmboldenStacks
        {
            get
            {
                var aura = Me.GetAuraById(Auras.Embolden);
                var value = aura?.Value ?? 0;
                return (int)value;
            }
        }

        private static async Task<bool> DotSnapshot()
        {
            if (Target == null || !Target.CanAttack || CombatHelper.LastSpell == Spells.IronJaws || ActionManager.LastSpell == Spells.IronJaws || Me.HasAura(Auras.Barrage))
                return false;

            uint[] critBuffList = { Auras.ChainStratagem, Auras.BattleLitany, Auras.TheSpear };
            uint[] buffList = { Auras.RagingStrikes, Auras.Brotherhood, Auras.Embolden, Auras.TheBalance };

            if (DateTime.Now >= _dotRefreshLimiter)
            {
                if (critBuffList.Any(aura => Me.Auras.Any((myAura => myAura.Id == aura && Me.HasAura(aura, false) && !Me.HasAura(aura, false, 4000) || (myAura.Id == Auras.Embolden && Me.HasAura(Auras.Embolden) && EmboldenStacks == 5)))))
                    if (await Spells.IronJaws.CastDot(Target, true))
                    {
                        _dotRefreshLimiter = DateTime.Now.AddSeconds(25);
                        return true;
                    }

                if (buffList.Any(aura => Me.Auras.Any((myAura => (myAura.Id == aura && Me.HasAura(aura, false) && !Me.HasAura(aura, false, 4000) && (!Target.HasAura(WindbiteAura(), true, 10000) || !Target.HasAura(WindbiteAura(), true, 10000)))))))
                    if (await Spells.IronJaws.CastDot(Target, true))
                    {
                        _dotRefreshLimiter = DateTime.Now.AddSeconds(25);
                        return true;
                    }
            }

            if (await Spells.IronJaws.CastDot(Target, EdwardSettingsModel.Instance.UseDots
                && Target.HasAura(WindbiteAura())
                && Target.HasAura(VenomousBiteAura())
                && (!Target.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh) || !Target.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh))
                && Target.HealthCheck(true)
                && Target.TimeToDeathCheck(), WindbiteAura(), EdwardSettingsModel.Instance.WindBiteRfsh))
            {
                _dotRefreshLimiter = DateTime.Now.AddSeconds(25);
                return true;
            }

            return false;
        }

        private static async Task<bool> Sidewinder()
        {
            return await Spells.Sidewinder.Use(Target, EdwardSettingsModel.Instance.UseSidewinder && Target.HasAura(WindbiteAura()) && Target.HasAura(VenomousBiteAura()) && !Me.HasAura(Auras.Barrage));
        }

        private static async Task<bool> Peloton()
        {
            return await Spells.Peloton.Use(Me, EdwardSettingsModel.Instance.UsePeloton && !Me.HasAura(Auras.Peloton));
        }

        #region Misc

        private static async Task<bool> NaturesMinne()
        {
            if (EdwardSettingsModel.Instance.UseManualNaturesMinne) return false;

            var autoNaturesMinneTarget = PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null
            && x.Type == GameObjectType.Pc
            && x.InCombat
            && x.IsAlive
            && x.CurrentHealthPercent <= EdwardSettingsModel.Instance.NaturesMinneHpPct);

            var selectedNaturesMinneTarget = NaturesMinneTargetViewModel.Instance.NaturesMinneTarget;

            if (selectedNaturesMinneTarget.AllyIsValid() && EdwardSettingsModel.Instance.UseTargetNaturesMinne && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.NaturesNaturesMinne.Use(selectedNaturesMinneTarget, true);
            }

            if (!EdwardSettingsModel.Instance.UseTargetNaturesMinne && autoNaturesMinneTarget.AllyIsValid() && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.NaturesNaturesMinne.Use(autoNaturesMinneTarget, true);
            }

            return await Spells.NaturesNaturesMinne.Use(autoNaturesMinneTarget, EdwardSettingsModel.Instance.UseTargetNaturesMinne && !selectedNaturesMinneTarget.AllyIsValid());
        }

        private static async Task<bool> Palisade()
        {
            if (EdwardSettingsModel.Instance.UseManualPalisade) return false;

            if (EdwardSettingsModel.Instance.UseBusterPalisade)
            {
                var tar = Target as BattleCharacter;
                if (tar == null) return false;

                var tarCastingPalisadeBuster = TankBusterManager.Palisade.Contains(tar.CastingSpellId);
                var busterTarget = tar.TargetCharacter;

                return await Spells.Palisade.Use(busterTarget, tarCastingPalisadeBuster);
            }

            var autoPalisadeTarget = PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null
            && x.Type == GameObjectType.Pc
            && x.InCombat
            && x.IsAlive
            && x.CurrentHealthPercent <= EdwardSettingsModel.Instance.PalisadeHpPct);

            var selectedPalisadeTarget = PalisadeTargetViewModel.Instance.PalisadeTarget;

            if (selectedPalisadeTarget.AllyIsValid() && EdwardSettingsModel.Instance.UseTargetPalisade && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Palisade.Use(selectedPalisadeTarget, true);
            }

            if (!EdwardSettingsModel.Instance.UseTargetPalisade && autoPalisadeTarget.AllyIsValid() && Target.HealthCheck(false) && Target.TimeToDeathCheck())
            {
                return await Spells.Palisade.Use(autoPalisadeTarget, true);
            }

            return await Spells.Palisade.Use(autoPalisadeTarget, EdwardSettingsModel.Instance.UseTargetPalisade && !selectedPalisadeTarget.AllyIsValid());
        }

        private static async Task<bool> AoE()
        {
            if (Target == null || !Target.CanAttack || !EdwardSettingsModel.Instance.UseAoE)
                return false;

            return await Spells.QuickNock.Use(Target, Target?.Distance() <= 8 && Target?.EnemiesInRange(5) >= EdwardSettingsModel.Instance.MobCount && Me.CurrentTP >= EdwardSettingsModel.Instance.TpLimit);
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !EdwardSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        private static async Task<bool> RoD_BL()
        {
            if (Target == null || !Target.CanAttack || Me.HasAura(Auras.Barrage)) return false;

            if (EdwardSettingsModel.Instance.UseRainofDeath && Target?.EnemiesInRange(8) >= EdwardSettingsModel.Instance.RoDMobCount)
            {
                return await Spells.RainofDeath.Use(Target, true);
            }

            return await Spells.Bloodletter.Use(Target, true);
        }

        private static async Task<bool> Paean()
        {
            if (!EdwardSettingsModel.Instance.UsePaean) return false;

            if (!PartyManager.IsInParty) return false;

            BattleCharacter target = (BattleCharacter)PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null &&
                x.Type == GameObjectType.Pc &&
                x.CurrentJob == ClassJobType.Warrior &&
                (x.HasAura(Auras.Pacification) || !x.HasAura(Auras.Berserk, false, 10000)) &&
                x.InCombat &&
                x.IsAlive);

            if (target != null)
            {
                return await Spells.WardensPaean.Use(target, true);
            }
            return false;
        }

        private static async Task<bool> FoeRequiem()
        {
            return await Spells.FoeRequiem.Use(Me, EdwardSettingsModel.Instance.UseFoeRequiem
                && !Me.HasAura(Auras.FoeRequiem, true)
                && Me.CurrentManaPercent >= EdwardSettingsModel.Instance.FoesMpRfsh
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Sing()
        {
            var songSung = CombatHelper.LastSpell == Spells.WanderersMinuet || CombatHelper.LastSpell == Spells.ArmysPaeon || CombatHelper.LastSpell == Spells.MagesBallad;

            if (Target == null || !Target.CanAttack || songSung || !EdwardSettingsModel.Instance.UseSongs)
                return false;

            if (EdwardSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(8) >= EdwardSettingsModel.Instance.MobCount && Me.CurrentTP >= EdwardSettingsModel.Instance.TpLimit)
            {
                if (await Spells.MagesBallad.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero || (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon && ActionResourceManager.Bard.Timer.TotalMilliseconds < 10000)))
                {
                    await RagingStrikes();
                    return true;
                }

                if (await Spells.WanderersMinuet.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero || ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon))
                    return true;

                if (await Spells.ArmysPaeon.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero && Spells.MagesBallad.Cooldown.Milliseconds > 0))
                    return true;
            }

            if (await Spells.WanderersMinuet.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero || (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon && ActionResourceManager.Bard.Timer.TotalMilliseconds < 10000)))
            {
                await RagingStrikes();
                return true;
            }

            if (await Spells.MagesBallad.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero || ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon))
                return true;

            if (await Spells.ArmysPaeon.Use(Target, ActionResourceManager.Bard.Timer == TimeSpan.Zero && Spells.MagesBallad.Cooldown.Milliseconds > 0))
                return true;

            if (await Troubadour()) return true;

            return await Spells.BattleVoice.Use(Me, EdwardSettingsModel.Instance.UseBattleVoice
                && (ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.MagesBallad || ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet));
        }

        private static async Task<bool> Troubadour()
        {
            if (Target == null || !Target.CanAttack || !EdwardSettingsModel.Instance.UseTroubadour || ActionResourceManager.Bard.Timer == TimeSpan.Zero)
                return false;

            switch (EdwardSettingsModel.Instance.TroubadourSongSelection)
            {
                case TroubadourSongSelection.Minuet:
                    return await Spells.Troubadour.Use(Me, ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet);

                case TroubadourSongSelection.Ballad:
                    return await Spells.Troubadour.Use(Me, ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.MagesBallad);

                case TroubadourSongSelection.Paeon:
                    return await Spells.Troubadour.Use(Me, ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon);

                case TroubadourSongSelection.None:
                    return false;

                default:
                    return false;
            }
        }

        private static bool NeedsDoTs(this GameObject unit)
        {
            if (unit == null || !unit.IsValid || !unit.CanAttack)
            {
                return false;
            }

            return !unit.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh + EdwardSettingsModel.Instance.MultiDoTTargetMax * 750) || !unit.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh + EdwardSettingsModel.Instance.MultiDoTTargetMax * 750);
        }

        private static bool DotTargetCount()
        {
            var count = GameObjectManager.Attackers.Count(target => target.HasAura(VenomousBiteAura(), true) || target.HasAura(WindbiteAura(), true));

            return count < EdwardSettingsModel.Instance.MultiDoTTargetMax;
        }

        private static IEnumerable<BattleCharacter> MultiDoTManager
        {
            get
            {
                return GameObjectManager.Attackers.Where(target =>
                                target.InCombat
                                && target.IsAlive
                                && target.NeedsDoTs()
                                && Target.HealthCheck(true) && Target.TimeToDeathCheck())
                        .OrderByDescending(Score);
            }
        }

        private static int Score(BattleCharacter t)
        {
            var score = 0;

            if (!t.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh))
                score += 100;

            if (!t.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh))
                score += 100;

            if (t.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh) && !t.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh))
                score += 100;

            if (t.HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh) && !t.HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh))
                score += 100;

            if (!t.HasAura(VenomousBiteAura(), true) && !t.HasAura(WindbiteAura(), true) && !DotTargetCount())
                score -= 1000;

            return score;
        }

        private static async Task<bool> MultiDoT()
        {
            if (!EdwardSettingsModel.Instance.UseMultiDoT || !EdwardSettingsModel.Instance.UseDots) return false;

            if (!MultiDoTManager.FirstOrDefault().HasAura(VenomousBiteAura(), true) && !MultiDoTManager.FirstOrDefault().HasAura(WindbiteAura(), true) && !DotTargetCount())
                return false;

            if (MultiDoTManager.FirstOrDefault().HasAura(VenomousBiteAura(), true) && MultiDoTManager.FirstOrDefault().HasAura(WindbiteAura(), true))
                return await Spells.IronJaws.Use(MultiDoTManager.FirstOrDefault(), true);

            if (await Spells.Windbite.CastDot(MultiDoTManager.FirstOrDefault(), CombatHelper.LastSpell != Spells.Windbite && ActionManager.LastSpell != Spells.Windbite && !MultiDoTManager.FirstOrDefault().HasAura(WindbiteAura(), true, EdwardSettingsModel.Instance.WindBiteRfsh), WindbiteAura(), 14000)) return true;

            return await Spells.VenomousBite.CastDot(MultiDoTManager.FirstOrDefault(), CombatHelper.LastSpell != Spells.VenomousBite && ActionManager.LastSpell != Spells.VenomousBite && !MultiDoTManager.FirstOrDefault().HasAura(VenomousBiteAura(), true, EdwardSettingsModel.Instance.VenomBiteRfsh), VenomousBiteAura(), 14000);
        }

        #endregion Misc
    }
}