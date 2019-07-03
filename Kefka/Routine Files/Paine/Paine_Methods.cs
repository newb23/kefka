using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using Kefka.ViewModels.Openers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.Paine
{
    public static partial class PaineRotation
    {
        private static int OverpowerPullCount = 0;
        private static DateTime overpowerLimiter;
        internal static int ButchersCount;
        internal static int FellCleaveCount = 0;

        #region Class Spells

        private static async Task<bool> OverpowerSpam()
        {
            if (Control.ModifierKeys == Keys.None || !WindowCheck.ApplicationIsActivated()) return false;
            if (Keyboard.IsKeyDown(PaineHotkeysModel.Instance.OverpowerSpamKey))
                await Spells.Overpower.Use(Target, true);
            return false;
        }

        private static async Task<bool> HeavySwing()
        {
            return await Spells.HeavySwing.Use(Target, true);
        }

        private static async Task<bool> SkullSunder()
        {
            if (!PaineSettingsModel.Instance.MainTank || await KefkaEnmityManager.EnmityDifference() >= PaineSettingsModel.Instance.ButchersBlockCount) return false;

            if (CombatHelper.LastSpell != Spells.HeavySwing && ActionManager.LastSpell != Spells.HeavySwing) return false;

            return await Spells.SkullSunder.Use(Target, true);
        }

        private static async Task<bool> ButchersBlock()
        {
            if (CombatHelper.LastSpell != Spells.SkullSunder || ActionManager.LastSpell != Spells.SkullSunder) return false;

            return await Spells.ButchersBlock.Use(Target, true);
        }

        private static async Task<bool> Maim()
        {
            if (CombatHelper.LastSpell != Spells.HeavySwing && ActionManager.LastSpell != Spells.HeavySwing) return false;

            if (Me.ClassLevel < 38 && !Target.HasAura(Auras.Maim, true, 4500))
                return await Spells.Maim.CastDot(Target, true, Auras.Maim);
            if (Me.ClassLevel >= 38)
                return await Spells.Maim.CastDot(Target, (await KefkaEnmityManager.EnmityDifference() >= PaineSettingsModel.Instance.ButchersBlockCount && PaineSettingsModel.Instance.MainTank) || ((!Me.HasAura(Auras.StormsEye, true, PaineSettingsModel.Instance.StormsEyeRefresh) || (Me.HasAura(Auras.Berserk) && !Me.HasAura(Auras.StormsEye, true, PaineSettingsModel.Instance.StormsEyeRefreshBerserk))) && Me.ClassLevel >= 50), Auras.Maim);

            return false;
        }

        private static async Task<bool> StormsPath()
        {
            if (CombatHelper.LastSpell != Spells.Maim && ActionManager.LastSpell != Spells.Maim) return false;

            return await Spells.StormsPath.Use(Target, Me.HasAura(Auras.StormsEye, true, PaineSettingsModel.Instance.StormsEyeRefresh) || Me.ClassLevel < 50);
        }

        private static async Task<bool> StormsEye()
        {
            if (CombatHelper.LastSpell != Spells.Maim && ActionManager.LastSpell != Spells.Maim) return false;
            
            return await Spells.StormsEye.CastBuff(Target, ((!Me.HasAura(Auras.StormsEye, true, PaineSettingsModel.Instance.StormsEyeRefresh) || (Me.HasAura(Auras.Berserk) && !Me.HasAura(Auras.StormsEye, true, PaineSettingsModel.Instance.StormsEyeRefreshBerserk))) || (!PaineSettingsModel.Instance.UseButchersBlock && !PaineSettingsModel.Instance.UseStormsPath)), Auras.StormsEye);
        }

        public static async Task<bool> Overpower()
        {
            if (Target == null || !Target.CanAttack || Me.HasAura(Auras.Berserk) || CombatHelper.LastSpell == Spells.HeavySwing || CombatHelper.LastSpell == Spells.SkullSunder || CombatHelper.LastSpell == Spells.Maim || Me.EnemiesInRange(8) < PaineSettingsModel.Instance.OverpowerMinMobs)
                return false;

            if (OverpowerPullCount < PaineSettingsModel.Instance.OverpowerPullCount - 1)
            {
                if (await Spells.Overpower.Use(Target, true))
                {
                    OverpowerPullCount++;
                    return true;
                }
            }

            if (PaineSettingsModel.Instance.OverpowerRefreshTime == 0 || DateTime.Now < overpowerLimiter) return false;

            if (await Spells.Overpower.Use(Target, true))
            {
                overpowerLimiter = DateTime.Now.Add(TimeSpan.FromMilliseconds(PaineSettingsModel.Instance.OverpowerRefreshTime));
                return true;
            }
            return false;
        }

        private static async Task<bool> Tomahawk()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (Target.Distance(Me) - Target.CombatReach <= 5) return false;

            return await Spells.Tomahawk.Use(Target, PaineSettingsModel.Instance.UseTomahawk);
        }

        private static async Task<bool> Berserk()
        {
            return await Spells.Berserk.CastBuff(Me, PaineSettingsModel.Instance.UseBuffs
                && (ActionManager.CanCast(Spells.Infuriate, Me) || Me.ClassLevel < 50 || PaineSettingsModel.Instance.InfuriateWithoutBerserk)
                && (ActionResourceManager.Warrior.BeastGauge == 100 || Me.ClassLevel < 30 || !PaineSettingsModel.Instance.UseDeliverance)
                && (CombatHelper.LastSpell == Spells.HeavySwing || ActionManager.LastSpell == Spells.HeavySwing), Auras.Berserk);
        }

        private static async Task<bool> InnerBeast()
        {
            if (!PaineSettingsModel.Instance.UseInnerBeast || ActionResourceManager.Warrior.BeastGauge < 50 || !Me.HasAura(Auras.Defiance)) return false;

            return await Spells.InnerBeast.CastBuff(Target, ActionResourceManager.Warrior.BeastGauge >= 90 || (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseInnerBeast &&
                Me.CurrentHealthPercent <= PaineSettingsModel.Instance.InnerBeastHpPct), /* PaineSettingsModel.Instance.UseShitButton || */Auras.InnerBeast);
        }

        private static async Task<bool> Unchained()
        {
            return await Spells.Unchained.CastBuff(Me, PaineSettingsModel.Instance.UseBuffs && !PaineSettingsModel.Instance.UseDeliverance && (Me.HasAura(Auras.Berserk) || Me.HasAura(Auras.InnerRelease)), Auras.Unchained);
        }

        private static async Task<bool> SteelCyclone()
        {
            if (PaineSettingsModel.Instance.UseDeliverance) return false;

            return await Spells.SteelCyclone.Use(Me, ActionResourceManager.Warrior.BeastGauge >= 50 && Me.EnemiesInRange(5) >= PaineSettingsModel.Instance.AoEMinEnemies);
        }

        private static async Task<bool> Infuriate()
        {
            if (Me.ClassLevel < 70)
            return await Spells.Infuriate.CastBuff(Me, PaineSettingsModel.Instance.UseBuffs &&
                (Me.HasAura(Auras.Berserk) || PaineSettingsModel.Instance.InfuriateWithoutBerserk) && 
                ActionResourceManager.Warrior.BeastGauge <= 50, Auras.Infuriated);

            return await Spells.Infuriate.CastBuff(Me, !Me.HasAura(Auras.InnerRelease) && ActionResourceManager.Warrior.BeastGauge <= 50);
        }

        private static async Task<bool> FellCleave()
        {
            if (Me.ClassLevel < 70)
            {
                if ((ActionResourceManager.Warrior.BeastGauge < 50 && !Me.HasAura(Auras.Berserk)) || ActionResourceManager.Warrior.BeastGauge < 25) return false;

                if (!Me.HasAura(Auras.Berserk) && Spells.Berserk.Cooldown.TotalMilliseconds < PaineSettingsModel.Instance.FellCleaveBerserkMinCD) return false;

                if (await Spells.FellCleave.Use(Target, true))
                {
                    FellCleaveCount++;
                    return true;
                }
                return false;
            }

            if (FellCleaveCount == 2) FellCleaveCount = 0;

            if (await Spells.FellCleave.Use(Target, Me.HasAura(Auras.InnerRelease) || ActionResourceManager.Warrior.BeastGauge == 100 || (FellCleaveCount == 1 && ActionResourceManager.Warrior.BeastGauge == 50)))
            {
                FellCleaveCount++;
                return true;
            }
            return false;
        }

        private static async Task<bool> Equilibrium()
        {
            return await Spells.Equilibrium.Use(Me, PaineSettingsModel.Instance.UseEquilibrium && ((Me.HasAura(Auras.Deliverance) && Me.CurrentTP <= 750) || (Me.HasAura(Auras.Defiance) && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.EquilibriumHpPct)));
        }

        private static async Task<bool> Decimate()
        {
            return await Spells.Decimate.Use(Me, ((ActionResourceManager.Warrior.BeastGauge >= 50 && Me.HasAura(Auras.Berserk)) || Me.HasAura(Auras.InnerRelease)) && Me.EnemiesInRange(5) >= PaineSettingsModel.Instance.AoEMinEnemies);
        }

        private static async Task<bool> RawIntuition(BattleCharacter tar)
        {
            var hasSpellRawIntuition = TankBusterManager.RawIntuition.Contains(tar.CastingSpellId);

            return await Spells.RawIntuition.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseRawIntuition &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.RawIntuitionHpPct) || hasSpellRawIntuition)), /*PaineSettingsModel.Instance.UseShitButton ||*/ Auras.RawIntuition);
        }

        private static async Task<bool> Vengeance(BattleCharacter tar)
        {
            var hasSpellVengeance = TankBusterManager.Vengeance.Contains(tar.CastingSpellId);

            return await Spells.Vengeance.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseVengeance &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.VengeanceHpPct) || hasSpellVengeance)), /*PaineSettingsModel.Instance.UseShitButton ||*/ Auras.Vengeance);
        }

        private static async Task<bool> ThrillOfBattle(BattleCharacter tar)
        {
            var hasSpellThrillofBattle = TankBusterManager.ThrillofBattle.Contains(tar.CastingSpellId);

            return await Spells.ThrillofBattle.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseThrillofBattle &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.ThrillofBattleHpPct) || hasSpellThrillofBattle)), /*PaineSettingsModel.Instance.UseShitButton ||*/ Auras.ThrillofBattle);
        }

        private static async Task<bool> Holmgang(BattleCharacter tar)
        {
            var hasSpellHolmgang = TankBusterManager.Holmgang.Contains(tar.CastingSpellId);

            return await Spells.Holmgang.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseHolmgang &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.HolmgangHpPct) || hasSpellHolmgang)), /*PaineSettingsModel.Instance.UseShitButton ||*/ Auras.Holmgang);
        }

        private static async Task<bool> Onslaught()
        {
            if (!PaineSettingsModel.Instance.UseOnslaught || Target == null || !Target.CanAttack) return false;

            if (ActionResourceManager.Warrior.BeastGauge < 20 && !Me.HasAura(Auras.InnerRelease)) return false;

            if (Me.HasAura(Auras.Berserk)) return false;

            if (Target.Distance(Me) > 20) return false;

            if (!Me.InCombat || (PaineSettingsModel.Instance.MainTank && await KefkaEnmityManager.EnmityDifference() < PaineSettingsModel.Instance.ButchersBlockCount) || (Target.Distance(Me) - Target.CombatReach < 3 && Me.HasAura(Auras.InnerRelease)))
                return await Spells.Onslaught.Use(Target, !((Character)Target).IsCasting);

            return await Spells.Onslaught.Use(Target, ActionResourceManager.Warrior.BeastGauge >= 90 && Spells.Berserk.Cooldown.TotalMilliseconds >= 8000 && !((Character)Target).IsCasting);
        }

        private static async Task<bool> Upheaval()
        {
            if (!PaineSettingsModel.Instance.UseUpheaval || Target == null || !Target.CanAttack) return false;

            if (ActionResourceManager.Warrior.BeastGauge < 20 && !Me.HasAura(Auras.InnerRelease)) return false;

            if (PaineSettingsModel.Instance.MainTank && await KefkaEnmityManager.EnmityDifference() < PaineSettingsModel.Instance.ButchersBlockCount)
                return await Spells.Upheaval.Use(Target, true);

            if (Me.ClassLevel < 70 && (Spells.Berserk.Cooldown.TotalMilliseconds <= 25000 || Spells.InnerRelease.Cooldown.TotalMilliseconds <= 25000) && PaineSettingsModel.Instance.UseBuffs) return false;

            return await Spells.Upheaval.Use(Target, (ActionResourceManager.Warrior.BeastGauge >= 80) || 
                (Me.HasAura(Auras.InnerRelease) && (CombatHelper.LastSpell == Spells.FellCleave || ActionManager.LastSpell == Spells.FellCleave)) || 
                (Me.HasAura(Auras.Berserk) && (CombatHelper.LastSpell == Spells.StormsPath || ActionManager.LastSpell == Spells.StormsPath)));
        }

        private static async Task<bool> ShakeItOff()
        {
            return await Spells.ShakeitOff.Use(Me, true);
        }

        private static async Task<bool> InnerRelease()
        {
            return await Spells.InnerRelease.CastBuff(Me, PaineSettingsModel.Instance.UseBuffs && (Me.HasAura(Auras.Deliverance) || Me.HasAura(Auras.Defiance)) && Me.HasAura(Auras.StormsEye), Auras.InnerRelease);
        }

        #endregion Class Spells

        #region Role Actions

        //Defensive
        private static async Task<bool> Rampart(BattleCharacter tar)
        {
            var hasSpellRampart = TankBusterManager.Rampart.Contains(tar.CastingSpellId);

            return await Spells.Rampart.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseRampart &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.RampartHpPct) || hasSpellRampart)), /* PaineSettingsModel.Instance.UseShitButton || */Auras.Rampart);
        }

        private static async Task<bool> LowBlow()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (PaineSettingsModel.Instance.UseManualInterrupt) return false;

            if (PaineSettingsModel.Instance.UseInterruptList && Target.CanStun())
                return await Spells.LowBlow.Use(Target, true);

            return await Spells.LowBlow.Use(Target, !PaineSettingsModel.Instance.UseInterruptList && CombatHelper.LastSpell != Spells.LowBlow && ((Character)Target).IsCasting);
        }

        private static async Task<bool> Provoke()
        {
            return await Spells.Provoke.Use(Target, true);
        }

        //Defensive
        private static async Task<bool> Anticipation(BattleCharacter tar)
        {
            var hasSpellAnticipation = TankBusterManager.Anticipation.Contains(tar.CastingSpellId);
            return await Spells.Anticipation.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseAnticipation &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.AnticipationHpPct) || hasSpellAnticipation)), Auras.Anticipation);
        }

        //Defensive
        private static async Task<bool> Reprisal(BattleCharacter tar)
        {
            var hasSpellReprisal = TankBusterManager.Reprisal.Contains(tar.CastingSpellId);

            return await Spells.Reprisal.CastDot(tar, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseReprisal &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.ReprisalHpPct) || hasSpellReprisal)), /* PaineSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensives
        private static async Task<bool> Awareness(BattleCharacter tar)
        {
            var hasSpellAwareness = TankBusterManager.Awareness.Contains(tar.CastingSpellId);

            return await Spells.Awareness.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseAwareness &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.AwarenessHpPct) || hasSpellAwareness)), /* PaineSettingsModel.Instance.UseShitButton || */Auras.Awareness);
        }

        //Defensive
        private static async Task<bool> Convalescence(BattleCharacter tar)
        {
            var hasSpellConvalescence = TankBusterManager.Convalescence.Contains(tar.CastingSpellId);

            return await Spells.Convalescence.CastBuff(Me, (PaineSettingsModel.Instance.UseDefensives && PaineSettingsModel.Instance.UseConvalescence &&
                ((!PaineSettingsModel.Instance.UseBusterDefense && Me.CurrentHealthPercent <= PaineSettingsModel.Instance.ConvalescenceHpPct) || hasSpellConvalescence)), /* PaineSettingsModel.Instance.UseShitButton || */Auras.Convalescence);
        }

        private static async Task<bool> Interject()
        {
            if (Target == null || !Target.CanAttack) return false;

            if (PaineSettingsModel.Instance.UseManualInterrupt) return false;

            if (PaineSettingsModel.Instance.UseInterruptList && Target.CanSilence())
                return await Spells.LowBlow.Use(Target, !PaineSettingsModel.Instance.UseInterruptList && ((Character)Target).IsCasting);

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

            foreach (var item in Paine_OpenerViewModel.Instance.GuiOpenerList.Where(x => x.IsItem))
            {
                Logger.KefkaLog(item.SpellName + @" Is loaded in the Queue.");

                var useableItem = InventoryManager.FilledSlots.FirstOrDefault(a => a.Item.Id == item.SpellId);

                if (useableItem == null || !useableItem.IsValid || !useableItem.CanUse())
                {
                    Logger.KefkaLog(item.SpellName + @" is on cooldown. Skipping Opener.");
                    PaineSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            foreach (var spell in Paine_OpenerViewModel.Instance.GuiOpenerList.Where(x => !x.IsItem && !x.IsPet && x.SpellId != Spells.Infuriate.Id))
            {
                Logger.KefkaLog(spell.SpellName + @" Is loaded in the Queue.");

                var openerSpell = DataManager.GetSpellData(spell.SpellId);

                if (openerSpell.Cooldown.TotalMilliseconds > 0)
                {
                    Logger.KefkaLog(spell.SpellName + @" is on cooldown. Skipping Opener.");
                    PaineSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            foreach (var petSpell in Paine_OpenerViewModel.Instance.GuiOpenerList.Where(x => !x.IsItem && x.IsPet))
            {
                Logger.KefkaLog(petSpell.SpellName + @" Is loaded in the Queue.");

                var petOpenerSpell = DataManager.GetPetSpellData(petSpell.SpellName);

                if (petOpenerSpell.Cooldown.TotalMilliseconds > 0)
                {
                    Logger.KefkaLog(petSpell.SpellName + @" is on cooldown. Skipping Opener.");
                    PaineSettingsModel.Instance.UseOpener = false;
                    return await Combat();
                }
            }

            Logger.KefkaLog("We made it through the Opener pre-checks!");

            var openerQueue = new Queue<OpenerSpellInfo>(Paine_OpenerViewModel.Instance.GuiOpenerList);

            if (openerQueue.Count == 0)
            {
                Logger.KefkaLog(@"Opener queue is empty, please use the Reset Opener button to reset!");
                openerQueue.Clear();
                PaineSettingsModel.Instance.UseOpener = false;
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
            PaineSettingsModel.Instance.UseOpener = false;
            return await Combat();
        }

        private static async Task<bool> Stance()
        {
            if (!PaineSettingsModel.Instance.UseDeliverance)
            {
                if (Me.HasAura(Auras.Defiance)) return false;

                if (ButchersCount != 0)
                    ButchersCount = 0;

                return await Spells.Defiance.CastBuff(Me, true, Auras.Defiance);
            }
                

            if (PaineSettingsModel.Instance.UseDeliverance)
            {
                if (ButchersCount == 0)
                    ButchersCount = PaineSettingsModel.Instance.ButchersBlockCount + 1;

                if (Me.HasAura(Auras.Defiance) && Me.ClassLevel < 52)
                    return await Spells.Defiance.CastBuff(Me, true, Auras.Defiance);

                return await Spells.Deliverance.CastBuff(Me, !Me.HasAura(Auras.Deliverance), Auras.Deliverance);
            }
                

            return false;
        }

        private static async Task CountCheck()
        {
            if (PaineSettingsModel.Instance.MainTank && !Me.InCombat)
            {
                OverpowerPullCount = 0;
            }
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !PaineSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
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

        internal static async Task<bool> Swap()
        {
            if (!PaineSettingsModel.Instance.Swap) return false;

            var OtherTank = HealManager.FirstOrDefault(hm => hm.IsTank() && !hm.IsMe);

            if (OtherTank == null)
            {
                PaineSettingsModel.Instance.Swap = false;
                return false;
            }

            if (GameObjectManager.Attackers.Any(r => r.TargetGameObject == OtherTank))
            {
                var provokeTarget = GameObjectManager.Attackers.FirstOrDefault(r => r.Distance(Me) <= 25 && r.TargetGameObject == OtherTank);

                if (provokeTarget != null)
                {
                    if (await Spells.Provoke.Use(provokeTarget, true))
                    {
                        Logger.PaineLog(@"====> Provoking {0} to Pull Aggro From {1}", provokeTarget.Name, OtherTank.Name);

                        PaineSettingsModel.Instance.Swap = false;
                        ButchersCount = 0;
                        if (PaineSettingsModel.Instance.ButchersBlockCount == 0) ButchersCount = -1;
                        return true;
                    }
                }
            }

            if (GameObjectManager.Attackers.Any(r => r.TargetGameObject == Me))
            {
                if (await Shirk(OtherTank))
                {
                    Logger.PaineLog(@"====> Shirking to {0} to lose Aggro from {1}", OtherTank.Name, Target.Name);
                }
                if (GameObjectManager.Attackers.Any(r => r.TargetGameObject == Me)) return false;

                PaineSettingsModel.Instance.Swap = false;
                return true;
            }

            return false;
        }

        private static async Task<bool> Defensives()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            var tar = Me.CurrentTarget as BattleCharacter;

            if (await Holmgang(tar)) return true;
            if (await Convalescence(tar)) return true;
            if (await Rampart(tar)) return true;
            if (await Anticipation(tar)) return true;
            if (await RawIntuition(tar)) return true;
            if (await Vengeance(tar)) return true;
            if (await ThrillOfBattle(tar)) return true;
            if (await Awareness(tar)) return true;
            if (await InnerBeast()) return true;

            return false;
        }

        #endregion Misc
    }
}