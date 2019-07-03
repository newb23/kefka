using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using Kefka.ViewModels.Openers;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Cecil
{
    public static partial class CecilRotation
    {
        public static int CurrentEnemyCount;
        internal static int UnleashCount;
        internal static bool Recovering;

        private static async Task<bool> Grit()
        {
            return await Spells.Grit.Use(Me, (CecilSettingsModel.Instance.UseGrit && !Me.HasAura(Auras.Grit)) || (!CecilSettingsModel.Instance.UseGrit && Me.HasAura(Auras.Grit)));
        }

        private static async Task<bool> HardSlash()
        {
            return await Spells.HardSlash.Use(Target, true);
        }

        private static async Task<bool> SpinningSlash()
        {
            if (!CecilSettingsModel.Instance.MainTank || await KefkaEnmityManager.EnmityDifference() > CecilSettingsModel.Instance.PowerSlashCount) return false;

            if (CombatHelper.LastSpell != Spells.HardSlash && ActionManager.LastSpell != Spells.HardSlash) return false;

            return await Spells.SpinningSlash.Use(Target, true);
        }

        private static async Task<bool> PowerSlash()
        {
            if (CombatHelper.LastSpell != Spells.SpinningSlash && ActionManager.LastSpell != Spells.SpinningSlash) return false;

            return await Spells.PowerSlash.Use(Target, true);
        }

        private static async Task<bool> SyphonStrike()
        {
            if (CombatHelper.LastSpell != Spells.HardSlash && ActionManager.LastSpell != Spells.HardSlash) return false;

            if ((Me.ClassLevel >= 38 && await KefkaEnmityManager.EnmityDifference() < CecilSettingsModel.Instance.PowerSlashCount && CecilSettingsModel.Instance.MainTank) || (Me.ClassLevel < 38 && Me.CurrentManaPercent >= 65)) return false;

            return await Spells.SyphonStrike.Use(Target, true);
        }

        private static async Task<bool> Souleater()
        {
            return await Spells.Souleater.Use(Target, CombatHelper.LastSpell == Spells.SyphonStrike || ActionManager.LastSpell == Spells.SyphonStrike);
        }

        private static async Task<bool> Unleash()
        {
            if (!CecilSettingsModel.Instance.UseUnleash || !CecilSettingsModel.Instance.MainTank || CombatHelper.LastSpell == Spells.Unleash || ActionManager.LastSpell == Spells.Unleash) return false;

            if (Me.EnemiesInRange(5) < CecilSettingsModel.Instance.AoEMinEnemies || UnleashCount > CecilSettingsModel.Instance.UnleashCount) return false;

            if (await Spells.Unleash.Use(Me, true))
            {
                UnleashCount = UnleashCount + 1;
                return true;
            }
            return false;
        }

        private static async Task<bool> AbyssalDrain()
        {
            if (CecilSettingsModel.Instance.AoESpam && Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoESpamCount)
                return await Spells.AbyssalDrain.Use(Target, true);

            if (UnleashCount < CecilSettingsModel.Instance.UnleashCount && CecilSettingsModel.Instance.MainTank && CecilSettingsModel.Instance.UseUnleash && Me.EnemiesInRange(5) > CecilSettingsModel.Instance.AoEMinEnemies)
                return false;

            return await Spells.AbyssalDrain.Use(Target, Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies &&
                ((CombatHelper.LastSpell == Spells.PowerSlash || ActionManager.LastSpell == Spells.PowerSlash) ||
                (CombatHelper.LastSpell == Spells.Souleater || ActionManager.LastSpell == Spells.Souleater)));
        }

        private static async Task<bool> Unmend()
        {
            if (!CecilSettingsModel.Instance.UseUnmend || Target == null || !Target.CanAttack || Target.Distance(Me) - Target.CombatReach <= 5) return false;

            return await Spells.Unmend.Use(Target, true);
        }

        private static async Task<bool> BloodWeapon()
        {
            if (CecilSettingsModel.Instance.UseGrit || !CecilSettingsModel.Instance.UseBuffs || Me.CurrentManaPercent > CecilSettingsModel.Instance.BloodWeaponMpPct) return false;

            return await Spells.BloodWeapon.CastBuff(Me, true, Auras.BloodWeapon);
        }

        private static async Task<bool> BloodPrice()
        {
            if (!CecilSettingsModel.Instance.UseGrit || !CecilSettingsModel.Instance.UseBuffs) return false;

            return await Spells.BloodPrice.CastBuff(Me, Me.CurrentManaPercent <= CecilSettingsModel.Instance.BloodWeaponMpPct, Auras.BloodPrice);
        }

        private static async Task<bool> Darkside()
        {
            return await Spells.Darkside.Use(Me, !Me.HasAura(Auras.Darkside));
        }

        private static async Task<bool> DarkPassenger()
        {
            if (!CecilSettingsModel.Instance.UseDarkPassenger || Target == null || !Target.CanAttack) return false;

            return await Spells.DarkPassenger.Use(Target, Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies && Me.HasAura(Auras.DarkArts) && Target.Distance(Me) <= 10);
        }

        private static async Task<bool> DarkArts()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (!CecilSettingsModel.Instance.UseDarkArts || Me.HasAura(Auras.DarkArts)) return false;

            if (Me.CurrentManaPercent <= CecilSettingsModel.Instance.DarkArtsStopMpPct && (CombatHelper.LastSpell != Spells.SyphonStrike && ActionManager.LastSpell != Spells.SyphonStrike))
                Recovering = true;

            if (Me.CurrentManaPercent >= CecilSettingsModel.Instance.DarkArtsStartMpPct)
                Recovering = false;

            if (CecilSettingsModel.Instance.UseDABloodspiller && Me.ClassLevel >= 68 && ActionResourceManager.DarkKnight.BlackBlood >= 50)
                return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

            if (Recovering == false)
            {
                if (CecilSettingsModel.Instance.UseDASyphonStrike && ((CombatHelper.LastSpell == Spells.HardSlash || ActionManager.LastSpell == Spells.HardSlash) && CecilSettingsModel.Instance.PowerSlashCount > await KefkaEnmityManager.EnmityDifference()) && Me.CurrentManaPercent >= CecilSettingsModel.Instance.DASyphonStrikeMpPct)
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

                if (CecilSettingsModel.Instance.UseDASouleater && (CombatHelper.LastSpell == Spells.SyphonStrike || ActionManager.LastSpell == Spells.SyphonStrike))
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

                if (CecilSettingsModel.Instance.UseDarkPassenger && Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies && Spells.DarkPassenger.Cooldown.TotalMilliseconds < 2000)
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

                if (CecilSettingsModel.Instance.UseDAQuietus && Me.ClassLevel >= 64 && Me.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies && ActionResourceManager.DarkKnight.BlackBlood >= 50)
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

                if (CecilSettingsModel.Instance.UseDACarveandSpit && Spells.CarveandSpit.Cooldown.TotalMilliseconds < 2000 && (CecilSettingsModel.Instance.PowerSlashCount > await KefkaEnmityManager.EnmityDifference() || !CecilSettingsModel.Instance.MainTank))
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);

                if (CecilSettingsModel.Instance.UseDAAbyssalDrain && CecilSettingsModel.Instance.UseAbyssalDrain && Me.ClassLevel >= 56 && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.AbyssalDrainHpPct && Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies)
                    return await Spells.DarkArts.CastBuff(Me, true, Auras.DarkArts);
            }
            return false;
        }

        //Defensive
        private static async Task<bool> ShadowWall(BattleCharacter tar)
        {
            var hasSpellShadowWall = TankBusterManager.ShadowWall.Contains(tar.CastingSpellId);

            return await Spells.ShadowWall.CastBuff(Me, CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseShadowWall && ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.ShadowWallHpPct) || hasSpellShadowWall), Auras.ShadowWall);
        }

        //Defensive
        private static async Task<bool> DarkMind(BattleCharacter tar)
        {
            var hasSpellDarkMind = TankBusterManager.DarkMind.Contains(tar.CastingSpellId);

            return await Spells.DarkMind.CastBuff(Me, CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseDarkMind && ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.DarkMindHpPct) || hasSpellDarkMind), Auras.DarkMind);
        }

        private static async Task<bool> Delirium()
        {
            if (Me.ClassLevel < 52 || !CecilSettingsModel.Instance.UseBuffs) return false;

            if (ActionResourceManager.DarkKnight.BlackBlood < 50) return false;

            return await Spells.Delirium.Use(Me, Me.HasAura(Auras.BloodWeapon) || Me.HasAura(Auras.BloodPrice));
        }

        //Defensive
        private static async Task<bool> LivingDead(BattleCharacter tar)
        {
            var hasSpellLivingDead = TankBusterManager.LivingDead.Contains(tar.CastingSpellId);

            return await Spells.LivingDead.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseLivingDead && ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.LivingDeadHpPct) || hasSpellLivingDead)), Auras.LivingDead);
        }

        private static async Task<bool> SaltedEarth()
        {
            if (!CecilSettingsModel.Instance.UseSaltedEarth || Target == null || !Target.CanAttack) return false;

            return await Spells.SaltedEarth.CastBuff(Target, Target.Distance() <= 15 && (Target.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies || Target.IsBoss() || CecilSettingsModel.Instance.SingleTargetSaltedEarth) &&
                Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.SaltedEarth);
        }

        private static async Task<bool> Plunge()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (Target.Distance(Me) - Target.CombatReach > 15) return false;

            return await Spells.Plunge.Use(Target, CecilSettingsModel.Instance.UsePlunge && !((Character)Target).IsCasting);
        }

        private static async Task<bool> SoleSurvivor()
        {
            return await Spells.SoleSurvivor.CastDot(Target, CecilSettingsModel.Instance.UseSoleSurvivor && (Target?.CurrentHealthPercent <= 10 && !Target.TimeToDeathCheck()), Auras.AnotherVictim);
        }

        private static async Task<bool> CarveAndSpit()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (Me.ClassLevel < 60) return false;

            if (CecilSettingsModel.Instance.UseCarveandSpitMpRegen &&
                Recovering)
                return await Spells.CarveandSpit.Use(Target, true);

            if (Me.HasAura(Auras.DarkArts) &&
                ActionResourceManager.DarkKnight.BlackBlood < 40 &&
                (CombatHelper.LastSpell != Spells.SyphonStrike && ActionManager.LastSpell != Spells.SyphonStrike))
                return await Spells.CarveandSpit.Use(Target, true);

            return false;
        }

        private static async Task<bool> Quietus()
        {
            if (ActionResourceManager.DarkKnight.BlackBlood < 50) return false;

            if (!CecilSettingsModel.Instance.UseDAQuietus && Me.HasAura(Auras.DarkArts)) return false;

            return await Spells.Quietus.Use(Me, Me.EnemiesInRange(5) >= CecilSettingsModel.Instance.AoEMinEnemies);
        }

        private static async Task<bool> Bloodspiller()
        {
            if (ActionResourceManager.DarkKnight.BlackBlood < 50) return false;

            if (!CecilSettingsModel.Instance.UseDABloodspiller && Me.HasAura(Auras.DarkArts)) return false;

            if (CecilSettingsModel.Instance.UseDABloodspiller && !Me.HasAura(Auras.DarkArts)) return false;

            return await Spells.Bloodspiller.Use(Target, true);
        }

        private static async Task<bool> TheBlackestNight(BattleCharacter tar)
        {
            var hasSpellBlackestNight = TankBusterManager.BlackestNight.Contains(tar.CastingSpellId);

            return await Spells.BlackestNight.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseBlackestNight &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.BlackestNightHpPct) || hasSpellBlackestNight)), /* CecilSettingsModel.Instance.UseShitButton || */Auras.BlackestNight);
        }

        #region Role Actions

        //Defensive
        private static async Task<bool> Rampart(BattleCharacter tar)
        {
            var hasSpellRampart = TankBusterManager.Rampart.Contains(tar.CastingSpellId);

            return await Spells.Rampart.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseRampart &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.RampartHpPct) || hasSpellRampart)), /* CecilSettingsModel.Instance.UseShitButton || */Auras.Rampart);
        }

        private static async Task<bool> LowBlow()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (CecilSettingsModel.Instance.UseManualInterrupt) return false;

            if (CecilSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LowBlow.Use(Target, true);

            return await Spells.LowBlow.Use(Target, !CecilSettingsModel.Instance.UseInterruptList && CombatHelper.LastSpell != Spells.LowBlow && ((Character)Target).IsCasting);
        }

        private static async Task<bool> Provoke()
        {
            return await Spells.Provoke.Use(Target, true);
        }

        //Defensive
        private static async Task<bool> Anticipation(BattleCharacter tar)
        {
            var hasSpellAnticipation = TankBusterManager.Anticipation.Contains(tar.CastingSpellId);
            return await Spells.Anticipation.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseAnticipation &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.AnticipationHpPct) || hasSpellAnticipation)), Auras.Anticipation);
        }

        //Defensive
        private static async Task<bool> Reprisal(BattleCharacter tar)
        {
            var hasSpellReprisal = TankBusterManager.Reprisal.Contains(tar.CastingSpellId);

            return await Spells.Reprisal.CastDot(tar, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseReprisal &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && ((Character)Target).IsCasting) || hasSpellReprisal)), /* CecilSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensives
        private static async Task<bool> Awareness(BattleCharacter tar)
        {
            var hasSpellAwareness = TankBusterManager.Awareness.Contains(tar.CastingSpellId);

            return await Spells.Awareness.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseAwareness &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.AwarenessHpPct) || hasSpellAwareness)), /* CecilSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensive
        private static async Task<bool> Convalescence(BattleCharacter tar)
        {
            var hasSpellConvalescence = TankBusterManager.Convalescence.Contains(tar.CastingSpellId);

            return await Spells.Convalescence.CastBuff(Me, (CecilSettingsModel.Instance.UseDefensives && CecilSettingsModel.Instance.UseConvalescence &&
                ((!CecilSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= CecilSettingsModel.Instance.ConvalescenceHpPct) || hasSpellConvalescence)), /* CecilSettingsModel.Instance.UseShitButton || */Auras.Convalescence);
        }

        private static async Task<bool> Interject()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (CecilSettingsModel.Instance.UseManualInterrupt) return false;

            if (CecilSettingsModel.Instance.UseInterruptList && Target.CanSilence())
                return await Spells.LowBlow.Use(Target, !CecilSettingsModel.Instance.UseInterruptList && ((Character)Target).IsCasting);

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

        private static async Task<bool> Opener()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            foreach (var item in Cecil_OpenerViewModel.Instance.GuiOpenerList.Where(x => x.IsItem))
            {
                Logger.KefkaLog(item.SpellName + @" Is loaded in the Queue.");

                var useableItem = InventoryManager.FilledSlots.FirstOrDefault(a => a.Item.Id == item.SpellId);

                if (useableItem == null || !useableItem.IsValid || !useableItem.CanUse())
                {
                    Logger.KefkaLog(item.SpellName + @" is on cooldown. Skipping Opener.");
                    CecilSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            foreach (var spell in Cecil_OpenerViewModel.Instance.GuiOpenerList.Where(x => !x.IsItem && !x.IsPet))
            {
                Logger.KefkaLog(spell.SpellName + @" Is loaded in the Queue.");

                var openerSpell = DataManager.GetSpellData(spell.SpellId);

                if (openerSpell.Cooldown.TotalMilliseconds > 0)
                {
                    Logger.KefkaLog(spell.SpellName + @" is on cooldown. Skipping Opener.");
                    CecilSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            foreach (var petSpell in Cecil_OpenerViewModel.Instance.GuiOpenerList.Where(x => !x.IsItem && x.IsPet))
            {
                Logger.KefkaLog(petSpell.SpellName + @" Is loaded in the Queue.");

                var petOpenerSpell = DataManager.GetPetSpellData(petSpell.SpellName);

                if (petOpenerSpell.Cooldown.TotalMilliseconds > 0)
                {
                    Logger.KefkaLog(petSpell.SpellName + @" is on cooldown. Skipping Opener.");
                    CecilSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            Logger.KefkaLog("We made it through the Opener pre-checks!");

            var openerQueue = new Queue<OpenerSpellInfo>(Cecil_OpenerViewModel.Instance.GuiOpenerList);

            if (openerQueue.Count == 0)
            {
                Logger.KefkaLog(@"Opener queue is empty, please use the Reset Opener button to reset!");
                openerQueue.Clear();
                CecilSettingsModel.Instance.UseOpener = false;
                return await Combat();
            }

            while (Target != null && openerQueue.Count > 0)
            {
                var nextOpener = openerQueue.Peek();
                Logger.KefkaLog(@"Next Opener Skill: {0}", nextOpener.SpellName);

                if (nextOpener.IsItem)
                {
                    var openerItem = InventoryManager.FilledSlots.FirstOrDefault(r => r.RawItemId == nextOpener.SpellId);

                    if (await Items.UsePotion(openerItem.Item, true))
                    {
                        openerQueue.Dequeue();
                        continue;
                    }
                }

                if (nextOpener.IsPet)
                {
                    var petOpenerSpell = DataManager.GetPetSpellData(nextOpener.SpellName);

                    if (petOpenerSpell == null)
                    {
                        openerQueue.Dequeue();
                        continue;
                    }

                    if (PetManager.DoAction(petOpenerSpell.Name, Target))
                    {
                        Logger.KefkaLog("We're inside of the PetSpell Section.");
                        openerQueue.Dequeue();
                        continue;
                    }
                }

                var openerSpell = DataManager.GetSpellData(nextOpener.SpellId);
                await Coroutine.Wait(3000, () => ActionManager.CanCast(openerSpell, Target) || ActionManager.CanCast(openerSpell, Me));

                if (openerSpell == null)
                {
                    openerQueue.Dequeue();
                }

                if (openerSpell?.Range == 0)
                {
                    if (await openerSpell.Use(Me, true))
                    {
                        Logger.KefkaLog("We're inside of the Regular Spell (ME) Section.");
                        openerQueue.Dequeue();
                        continue;
                    }
                }

                if (await openerSpell.Use(Target, true))
                {
                    Logger.KefkaLog("We're inside of the Regular Spell (TARGET) Section.");
                    openerQueue.Dequeue();
                }

                await Coroutine.Yield();
            }

            Logger.KefkaLog(@"Opener has completed, or was interrupted!");
            Core.OverlayManager.AddToast(() => "Opener Complete!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
            openerQueue.Clear();
            CecilSettingsModel.Instance.UseOpener = false;
            return await Combat();
        }

        internal static async Task<bool> Swap()
        {
            if (!CecilSettingsModel.Instance.Swap) return false;

            var OtherTank = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

            if (OtherTank == null)
            {
                CecilSettingsModel.Instance.Swap = false;
                return false;
            }

            if (!CecilSettingsModel.Instance.MainTank)
            {
                var provokeTarget = OtherTank.TargetGameObject;

                if (provokeTarget != null)
                {
                    if (await Spells.Provoke.Use(provokeTarget, true))
                    {
                        Logger.CecilLog(@"====> Provoking {0} to Pull Aggro From {1}", provokeTarget.Name, OtherTank.Name);
                        CecilSettingsModel.Instance.MainTank = true;
                        CecilSettingsModel.Instance.Swap = false;
                        return true;
                    }
                }
            }

            if (CecilSettingsModel.Instance.MainTank)
            {
                if (await Shirk(OtherTank))
                {
                    Logger.CecilLog(@"====> Shirking to {0} to lose Aggro from {1}", OtherTank.Name, Target.Name);
                    CecilSettingsModel.Instance.MainTank = false;
                    CecilSettingsModel.Instance.Swap = false;
                    return true;
                }
            }
            return false;
        }

        private static async Task<bool> ExProvoke()
        {
            if (Target == null || !Target.CanAttack || !CecilSettingsModel.Instance.UseProvoke)
                return false;

            if (!PartyManager.IsInParty)
                return false;

            if (CecilSettingsModel.Instance.MainTank)
            {
                if (GameObjectManager.Attackers.Count(r => r.Distance(Me) <= 5 && r.TargetGameObject == HealManager.FirstOrDefault(hm => hm.BeingTargeted() && !hm.IsMe && !hm.IsTank())) > 1)
                {
                    if (await Ultimatum())
                    {
                        Logger.CecilLog(@"====> Ultimatum used to regain Aggro");
                        Logger.CecilLog(@"====> Unleashing to establish Aggro");
                        return await Spells.Unleash.Use(Me, true);
                    }
                }

                var provokeTarget = GameObjectManager.Attackers.FirstOrDefault(r => r.Distance(Me) <= 25 && r.TargetGameObject == HealManager.FirstOrDefault(hm => hm.BeingTargeted() && !hm.IsMe && !hm.IsTank()));

                if (provokeTarget != null)
                {
                    if (await Spells.Provoke.Use(provokeTarget, true))
                    {
                        Logger.CecilLog(@"====> Provoking {0} to Pull Aggro From {1}", provokeTarget.Name, provokeTarget.TargetGameObject.Name);
                        if (provokeTarget?.Distance(Me) > 5 && CecilSettingsModel.Instance.UseUnmend)
                        {
                            Logger.CecilLog(@"====> Unmending {0} to Pull Aggro From {1}", provokeTarget.Name, provokeTarget.TargetGameObject.Name);
                            return await Spells.Unmend.Use(provokeTarget, true);
                        }
                        return true;
                    }
                }
            }

            if (!CecilSettingsModel.Instance.MainTank)
            {
                var OtherTank = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

                if (OtherTank == null)
                {
                    return false;
                }

                if (await Shirk(OtherTank))
                {
                    Logger.CecilLog(@"====> Shirking Aggro from {0} to Main Tank, {1}", Target.Name, OtherTank.SafeName());
                    return true;
                }
            }
            return false;
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !CecilSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        private static async Task<bool> Defensives()
        {
            if (Target == null || !Target.CanAttack)
            {
                return false;
            }

            var tar = Me.CurrentTarget as BattleCharacter;

            if (await LivingDead(tar)) return true;
            if (await TheBlackestNight(tar)) return true;
            if (await Convalescence(tar)) return true;
            if (await Rampart(tar)) return true;
            if (await Anticipation(tar)) return true;
            if (await ShadowWall(tar)) return true;
            if (await DarkMind(tar)) return true;
            if (await Awareness(tar)) return true;

            return false;
        }

        private static async Task UnleashCountReset()
        {
            if (CurrentEnemyCount < GameObjectManager.Attackers.Count(r => r.InCombat)) UnleashCount = 0;
            CurrentEnemyCount = GameObjectManager.Attackers.Count(r => r.InCombat);
        }
        #endregion Misc
    }
}