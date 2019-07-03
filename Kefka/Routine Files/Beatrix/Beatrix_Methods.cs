using Buddy.Coroutines;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.ViewModels;
using Kefka.ViewModels.Openers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Beatrix
{
    public static partial class BeatrixRotation
    {
        internal static int RageofHaloneCount;
        internal static int FlashCount = 0;
        public static int CurrentEnemyCount;

        private static async Task<bool> ShieldLob()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (Target.Distance(Me) - Target.CombatReach <= 5) return false;

            return await Spells.ShieldLob.Use(Target, BeatrixSettingsModel.Instance.UseShieldLob);
        }

        private static async Task<bool> FastBlade()
        {
            if (Me.HasAura(Auras.Requiescat, true, 1000)) return false;

            return await Spells.FastBlade.Use(Target, true);
        }

        private static async Task<bool> SavageBlade()
        {
            if (!BeatrixSettingsModel.Instance.MainTank || (CombatHelper.LastSpell != Spells.FastBlade && ActionManager.LastSpell != Spells.FastBlade)) return false;

            if (await KefkaEnmityManager.EnmityDifference() >= BeatrixSettingsModel.Instance.RageofHaloneCount && Me.ClassLevel >= 54) return false;

            return await Spells.SavageBlade.Use(Target, true);
        }

        private static async Task<bool> RageOfHalone()
        {
            if (Me.ClassLevel < 26 || (CombatHelper.LastSpell != Spells.SavageBlade && ActionManager.LastSpell != Spells.SavageBlade)) return false;

            return await Spells.RageofHalone.Use(Target, true);
        }

        private static async Task<bool> RiotBlade()
        {
            if ((CombatHelper.LastSpell != Spells.FastBlade && ActionManager.LastSpell != Spells.FastBlade)) return false;

            if (await KefkaEnmityManager.EnmityDifference() < BeatrixSettingsModel.Instance.RageofHaloneCount && BeatrixSettingsModel.Instance.MainTank) return false;

            return await Spells.RiotBlade.Use(Target, (!Target.HasAura(Auras.GoringBlade, true, 6000) && Me.ClassLevel >= 54 && Target.HealthCheck(false) && Target.TimeToDeathCheck()) || (Me.ClassLevel >= 60));
        }

        private static async Task<bool> GoringBlade()
        {
            if (!Target.HealthCheck(false) || !Target.TimeToDeathCheck()) return false;

            if (CombatHelper.LastSpell != Spells.RiotBlade && ActionManager.LastSpell != Spells.RiotBlade) return false;

            return await Spells.GoringBlade.Use(Target, !Target.HasAura(Auras.GoringBlade, true, 6000));
        }

        private static async Task<bool> RoyalAuthority()
        {
            if (CombatHelper.LastSpell != Spells.RiotBlade && ActionManager.LastSpell != Spells.RiotBlade) return false;

            return await Spells.RoyalAuthority.Use(Target, true);
        }

        private static async Task<bool> ShieldBash()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (BeatrixSettingsModel.Instance.UseManualInterrupt) return false;

            if (BeatrixSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.ShieldBash.Use(Target, true);

            return await Spells.ShieldBash.Use(Target, !BeatrixSettingsModel.Instance.UseInterruptList && CombatHelper.LastSpell != Spells.ShieldBash && ((Character)Target).IsCasting);
        }

        private static async Task<bool> HolySpirit()
        {
            if (!BeatrixSettingsModel.Instance.UseRequiescat) return false;

            return await Spells.HolySpirit.Use(Target, Me.HasAura(Auras.Requiescat, true, 1000));
        }

        private static async Task<bool> ShieldSwipe()
        {
            return await Spells.ShieldSwipe.Use(Target, true);
        }

        private static async Task<bool> SpiritsWithin()
        {
            if ((Spells.FightorFlight.Cooldown.TotalMilliseconds < 20000 && BeatrixSettingsModel.Instance.UseFightorFlight) && (await KefkaEnmityManager.EnmityDifference() > BeatrixSettingsModel.Instance.RageofHaloneCount || Me.ClassLevel < 54)) return false;

            return await Spells.SpiritsWithin.Use(Target, true);
        }

        private static async Task<bool> CircleOfScorn()
        {
            if (!Target.HealthCheck(false) || !Target.TimeToDeathCheck()) return false;

            if ((Spells.FightorFlight.Cooldown.TotalMilliseconds < 20000 && BeatrixSettingsModel.Instance.UseFightorFlight) && (await KefkaEnmityManager.EnmityDifference() > BeatrixSettingsModel.Instance.RageofHaloneCount || Me.ClassLevel < 54)) return false;

            return await Spells.CircleofScorn.Use(Me, Target.Distance(Me) < 5);
        }

        private static async Task<bool> Flash()
        {
            if (!BeatrixSettingsModel.Instance.UseFlash || !BeatrixSettingsModel.Instance.MainTank || CombatHelper.LastSpell == Spells.Flash || ActionManager.LastSpell == Spells.Flash) return false;

            if (Me.EnemiesInRange(5) < BeatrixSettingsModel.Instance.FlashMinEnemies || FlashCount > BeatrixSettingsModel.Instance.FlashCount) return false;

            if (await Spells.Flash.Use(Me, true))
            {
                FlashCount = FlashCount + 1;
                return true;
            }
            return false;
        }

        private static async Task<bool> TotalEclipse()
        {
            if (!BeatrixSettingsModel.Instance.UseTotalEclipse || Me.CurrentTPPercent < BeatrixSettingsModel.Instance.TotalEclipseTpPct || CombatHelper.LastSpell == Spells.TotalEclipse || ActionManager.LastSpell == Spells.TotalEclipse) return false;

            if (BeatrixSettingsModel.Instance.UseFlash && BeatrixSettingsModel.Instance.MainTank && FlashCount <= BeatrixSettingsModel.Instance.FlashCount) return false;

            if (CombatHelper.LastSpell != Spells.RoyalAuthority && ActionManager.LastSpell != Spells.RoyalAuthority && CombatHelper.LastSpell != Spells.GoringBlade && ActionManager.LastSpell != Spells.GoringBlade) return false;

            return await Spells.TotalEclipse.Use(Me, Me.EnemiesInRange(5) >= BeatrixSettingsModel.Instance.TotalEclipseMinEnemies);
        }

        private static async Task<bool> FightOrFlight()
        {
            if (Target == null || !Target.CanAttack || !Target.HealthCheck(false) || !Target.TimeToDeathCheck()) return false;

            if (!BeatrixSettingsModel.Instance.UseFightorFlight || Me.HasAura(Auras.Requiescat)) return false;

            return await Spells.FightorFlight.CastBuff(Me, (CombatHelper.LastSpell == Spells.RiotBlade && !Target.HasAura(Auras.GoringBlade, true, 4000) && Me.ClassLevel >= 54) || (Me.ClassLevel < 54 && CombatHelper.LastSpell == Spells.SavageBlade), Auras.FightorFlight);
        }

        private static async Task<bool> Requiescat()
        {
            if (!BeatrixSettingsModel.Instance.UseRequiescat || !Target.HealthCheck(false) || !Target.TimeToDeathCheck() || Me.CurrentManaPercent < 100) return false;

            return await Spells.Requiescat.CastBuff(Target, (!Me.HasAura(Auras.FightorFlight, true, 5000) || !BeatrixSettingsModel.Instance.UseFightorFlight) && CombatHelper.LastSpell == Spells.GoringBlade, Auras.Requiescat);
        }

        private static async Task<bool> Sheltron(BattleCharacter tar)
        {
            var hasSpellSheltron = TankBusterManager.Sheltron.Contains(tar.CastingSpellId);

            return await Spells.Sheltron.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseSheltron &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.SheltronHpPct) || hasSpellSheltron)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Sheltron);
        }

        private static async Task<bool> Cover()
        {
            if (BeatrixSettingsModel.Instance.UseManualCover) return false;

            var autoCoverTarget = PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null &&
                        x.Type == GameObjectType.Pc &&
                        x.IsAlive &&
                        x.TargetGameObject != null);

            var selectedCoverTarget = CoverTargetViewModel.Instance.CoverTarget;

            if (selectedCoverTarget.AllyIsValid() && BeatrixSettingsModel.Instance.UseCoverTarget)
            {
                return await Spells.Cover.CastDot(selectedCoverTarget, true, Auras.Covered);
            }

            if (!BeatrixSettingsModel.Instance.UseCoverTarget && autoCoverTarget.AllyIsValid())
            {
                return await Spells.Cover.CastDot(autoCoverTarget, true, Auras.Covered);
            }

            return await Spells.Cover.CastBuff(autoCoverTarget, BeatrixSettingsModel.Instance.UseCoverTarget && !selectedCoverTarget.AllyIsValid(), Auras.Covered);
        }

        private static async Task<bool> Clemency()
        {
            if (Target == null || BeatrixSettingsModel.Instance.UseManualClemency)
            {
                return false;
            }

            if (Me.HasAura(Auras.Requiescat) && !BeatrixSettingsModel.Instance.UseClemencyOverReq) return false;

            if (!PartyManager.IsInParty)
            {
                return await Spells.Clemency.Use(Me, Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ClemencyHpPct);
            }

            var autoClemencyTarget = (BattleCharacter)PartyManager.VisibleMembers.Select(x => x.GameObject as Character).FirstOrDefault(x => x != null &&
                x.Type == GameObjectType.Pc &&
                ((x.IsTank() && x.CurrentHealthPercent <= BeatrixSettingsModel.Instance.TankClemencyHpPct) ||
                (x.IsHealer() && x.CurrentHealthPercent <= BeatrixSettingsModel.Instance.HealerClemencyHpPct) ||
                (x.IsDps() && x.CurrentHealthPercent <= BeatrixSettingsModel.Instance.DpsClemencyHpPct) ||
                (x.IsMe && x.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ClemencyHpPct)) &&
                x.InCombat &&
                x.IsAlive);

            var selectedClemencyTarget = ClemencyTargetViewModel.Instance.ClemencyTarget;

            if (selectedClemencyTarget.AllyIsValid() && BeatrixSettingsModel.Instance.UseClemencyTarget && selectedClemencyTarget.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ClemencyHpPct)
            {
                return await Spells.Clemency.Use(selectedClemencyTarget, true);
            }

            if (!BeatrixSettingsModel.Instance.UseClemencyTarget && autoClemencyTarget.AllyIsValid() && autoClemencyTarget?.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ClemencyHpPct)
            {
                return await Spells.Clemency.Use(autoClemencyTarget, true);
            }

            return await Spells.Clemency.Use(autoClemencyTarget, BeatrixSettingsModel.Instance.UseClemencyTarget && !selectedClemencyTarget.AllyIsValid());
        }

        private static async Task<bool> Intervention()
        {
            var target = HealManager.FirstOrDefault(hm => hm.Distance2D(Me) <= 30 && hm.CurrentHealthPercent <= BeatrixSettingsModel.Instance.InterventionHpPct);
            return await Spells.Intervention.CastDot(Target, true, Auras.Intervention);
        }

        //Defensives
        private static async Task<bool> Bulwark(BattleCharacter tar)
        {
            var hasSpellBulwark = TankBusterManager.Bulwark.Contains(tar.CastingSpellId);

            return await Spells.Bulwark.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseBulwark && ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.BulwarkHpPct) || hasSpellBulwark)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Bulwark);
        }

        //Defensive
        private static async Task<bool> HallowedGround(BattleCharacter tar)
        {
            var hasSpellHallowedGround = TankBusterManager.HallowedGround.Contains(tar.CastingSpellId);

            return await Spells.HallowedGround.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseHallowedGround &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.HallowedGroundHpPct) || hasSpellHallowedGround)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.HallowedGround);
        }

        //Defensives
        private static async Task<bool> Sentinel(BattleCharacter tar)
        {
            var hasSpellSentinel = TankBusterManager.Sentinel.Contains(tar.CastingSpellId);

            return await Spells.Sentinel.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseSentinel &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.SentinelHpPct) || hasSpellSentinel)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Sentinel);
        }

        //Defensives
        private static async Task<bool> DivineVeil(BattleCharacter tar)
        {
            var hasSpellDivineVeil = TankBusterManager.DivineVeil.Contains(tar.CastingSpellId);

            return await Spells.DivineVeil.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseDivineVeil &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.DivineVeilHpPct) || hasSpellDivineVeil)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.DivineVeil);
        }

        #region Role Actions

        //Defensive
        private static async Task<bool> Rampart(BattleCharacter tar)
        {
            var hasSpellRampart = TankBusterManager.Rampart.Contains(tar.CastingSpellId);

            return await Spells.Rampart.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseRampart &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.RampartHpPct) || hasSpellRampart)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Rampart);
        }

        private static async Task<bool> LowBlow()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (BeatrixSettingsModel.Instance.UseManualInterrupt) return false;

            if (BeatrixSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LowBlow.Use(Target, true);

            return await Spells.LowBlow.Use(Target, !BeatrixSettingsModel.Instance.UseInterruptList && CombatHelper.LastSpell != Spells.LowBlow && ((Character)Target).IsCasting);
        }

        private static async Task<bool> Provoke()
        {
            if (!BeatrixSettingsModel.Instance.MainTank || await KefkaEnmityManager.EnmityDifference() >= 0) return false;

            return await Spells.Provoke.Use(Target, true);
        }

        //Defensive
        private static async Task<bool> Anticipation(BattleCharacter tar)
        {
            var hasSpellAnticipation = TankBusterManager.Anticipation.Contains(tar.CastingSpellId);
            return await Spells.Anticipation.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseAnticipation &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.AnticipationHpPct) || hasSpellAnticipation)), Auras.Anticipation);
        }

        //Defensive
        private static async Task<bool> Reprisal(BattleCharacter tar)
        {
            var hasSpellReprisal = TankBusterManager.Reprisal.Contains(tar.CastingSpellId);

            return await Spells.Reprisal.CastDot(tar, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseReprisal &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ReprisalHpPct) || hasSpellReprisal)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensives
        private static async Task<bool> Awareness(BattleCharacter tar)
        {
            var hasSpellAwareness = TankBusterManager.Awareness.Contains(tar.CastingSpellId);

            return await Spells.Awareness.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseAwareness &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.AwarenessHpPct) || hasSpellAwareness)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensive
        private static async Task<bool> Convalescence(BattleCharacter tar)
        {
            var hasSpellConvalescence = TankBusterManager.Convalescence.Contains(tar.CastingSpellId);

            return await Spells.Convalescence.CastBuff(Me, (BeatrixSettingsModel.Instance.UseDefensives && BeatrixSettingsModel.Instance.UseConvalescence &&
                ((!BeatrixSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= BeatrixSettingsModel.Instance.ConvalescenceHpPct) || hasSpellConvalescence)), /* BeatrixSettingsModel.Instance.UseShitButton || */Auras.Convalescence);
        }

        private static async Task<bool> Interject()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (BeatrixSettingsModel.Instance.UseManualInterrupt) return false;

            if (BeatrixSettingsModel.Instance.UseInterruptList && Target.CanSilence())
                return await Spells.Interject.Use(Target, !BeatrixSettingsModel.Instance.UseInterruptList && ((Character)Target).IsCasting);

            return await Spells.Interject.Use(Target, true);
        }

        private static async Task<bool> Ultimatum()
        {
            return await Spells.Ultimatum.Use(Me, true);
        }

        private static async Task<bool> Shirk(GameObject tar)
        {
            return await Spells.Shirk.Use(tar, true);
        }

        #endregion Role Actions

        #region Misc

        private static async Task<bool> AutoStance()
        {
            if (!BeatrixSettingsModel.Instance.UseSwordOath)
            {
                if (Me.HasAura(Auras.ShieldOath)) return false;

                return await Spells.ShieldOath.CastBuff(Me, true, Auras.ShieldOath);
            }

            if (BeatrixSettingsModel.Instance.UseSwordOath)
            {
                if (Me.HasAura(Auras.ShieldOath) && Me.ClassLevel < 35)
                    return await Spells.ShieldOath.Use(Me, true);

                if (Me.HasAura(Auras.SwordOath) || Me.HasAura(Auras.CNSwordOath) || Me.ClassLevel < 35) return false;

                if (!Me.HasAura(Auras.SwordOath) && !Me.HasAura(Auras.CNSwordOath))
                    return await Spells.SwordOath.CastBuff(Me, true, Auras.SwordOath);
            }

            return false;
        }

        private static async Task<bool> Defensives()
        {
            if (Target == null || !Target.CanAttack)
            {
                return false;
            }

            var tar = Me.CurrentTarget as BattleCharacter;

            if (await HallowedGround(tar)) return true;
            if (await DivineVeil(tar)) return true;
            if (await Sheltron(tar)) return true;
            if (await Convalescence(tar)) return true;
            if (await Rampart(tar)) return true;
            if (await Anticipation(tar)) return true;
            if (await Bulwark(tar)) return true;
            if (await Sentinel(tar)) return true;
            if (await Awareness(tar)) return true;

            return false;
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !BeatrixSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        internal static async Task<bool> Swap()
        {
            if (!BeatrixSettingsModel.Instance.Swap) return false;

            var OtherTank = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

            if (OtherTank == null)
            {
                BeatrixSettingsModel.Instance.Swap = false;
                return false;
            }

            if (!BeatrixSettingsModel.Instance.MainTank)
            {
                var provokeTarget = OtherTank.TargetGameObject;

                if (provokeTarget != null)
                {
                    if (await Spells.Provoke.Use(provokeTarget, true))
                    {
                        Logger.BeatrixLog(@"====> Provoking {0} to Pull Aggro From {1}", provokeTarget.Name, OtherTank.Name);
                        BeatrixSettingsModel.Instance.MainTank = true;
                        BeatrixSettingsModel.Instance.Swap = false;
                        return true;
                    }
                }
            }

            if (BeatrixSettingsModel.Instance.MainTank)
            {
                if (await Shirk(OtherTank))
                {
                    Logger.BeatrixLog(@"====> Shirking to {0} to lose Aggro from {1}", OtherTank.Name, Target.Name);
                    BeatrixSettingsModel.Instance.MainTank = false;
                    BeatrixSettingsModel.Instance.Swap = false;
                    return true;
                }
            }
            return false;
        }

        private static async Task<bool> ExProvoke()
        {
            if (Target == null || !Target.CanAttack || !BeatrixSettingsModel.Instance.UseProvoke || CombatHelper.LastSpell == Spells.Flash)
                return false;

            if (!PartyManager.IsInParty)
                return false;

            if (BeatrixSettingsModel.Instance.MainTank)
            {
                if (GameObjectManager.Attackers.Count(r => r.Distance(Me) <= 5 && r.TargetGameObject == HealManager.FirstOrDefault(hm => hm.BeingTargeted() && !hm.IsMe) && (!r.TargetGameObject.HasAura(Auras.ShieldOath) && !r.TargetGameObject.HasAura(Auras.Defiance) && !r.TargetGameObject.HasAura(Auras.Grit))) > 1)
                {
                    if (await Ultimatum())
                    {
                        Logger.BeatrixLog(@"====> Ultimatum used to regain Aggro");
                        FlashCount = 0;
                    }
                }
                var provokeTarget = GameObjectManager.Attackers.FirstOrDefault(r => r.Distance(Me) <= 25 && r.TargetGameObject == HealManager.FirstOrDefault(hm => hm.BeingTargeted() && !hm.IsMe) && (!r.TargetGameObject.HasAura(Auras.ShieldOath) && !r.TargetGameObject.HasAura(Auras.Defiance) && !r.TargetGameObject.HasAura(Auras.Grit)));

                if (provokeTarget != null)
                {
                    if (await Spells.Provoke.Use(provokeTarget, true))
                    {
                        Logger.BeatrixLog(@"====> Provoking {0} to Pull Aggro From {1}", provokeTarget.Name, provokeTarget.TargetGameObject.Name);
                        if (provokeTarget?.Distance(Me) > 5 && BeatrixSettingsModel.Instance.UseShieldLob)
                        {
                            Logger.BeatrixLog(@"====> Sheild Lobbing {0} to Pull Aggro From {1}", provokeTarget.Name, provokeTarget.TargetGameObject.Name);
                            return await Spells.ShieldLob.Use(provokeTarget, true);
                        }
                        return true;
                    }
                }
            }
            if (!BeatrixSettingsModel.Instance.MainTank)
            {
                var OtherTank = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

                if (OtherTank == null)
                {
                    return false;
                }

                if (await Shirk(OtherTank))
                {
                    Logger.BeatrixLog(@"====> Shirking Aggro from {0} to Main Tank, {1}", Target.Name, OtherTank.SafeName());
                    return true;
                }
            }
            return false;
        }

        private static async Task FlashCountReset()
        {
            if (CurrentEnemyCount < GameObjectManager.Attackers.Count(r => r.InCombat)) FlashCount = 0;
            CurrentEnemyCount = GameObjectManager.Attackers.Count(r => r.InCombat);
        }
        #endregion Misc
    }
}