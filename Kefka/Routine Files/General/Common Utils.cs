using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Directors;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.Freya;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using Kefka.ViewModels.Openers;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.General
{
    internal static class Common_Utils
    {
        private static IEnumerable<BattleCharacter> Enemies
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>()
                        .Where(u => u?.Distance(Me) <= 25 && u.ValidAttackUnit());
            }
        }

        private static IEnumerable<BattleCharacter> Allies
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>()
                        .Where(u => u?.Distance(Me) <= 25 && u.ValidAlly());
            }
        }

        public static bool ValidAttackUnit(this GameObject unit)
        {
            if (unit == null || !unit.IsValid)
                return false;

            if (!unit.CanAttack)
                return false;

            if (!unit.IsTargetable)
                return false;

            return unit.CurrentHealth > 0;
        }

        public static bool ValidAlly(this GameObject unit)
        {
            if (unit == null || !unit.IsValid)
                return false;

            if (unit.CanAttack)
                return false;

            if (!unit.IsTargetable)
                return false;

            return unit.CurrentHealth > 0;
        }

        public static int EnemiesInRange(this GameObject unit, int range)
        {
            try
            {
                return Enemies.Count() > 1 ? Enemies.Count(u => u.Distance(unit) <= range && u.IsValid) : 0;
            }
            catch (Exception e)
            {
                Logger.KefkaLog(e.ToString());
                throw;
            }
        }

        public static int AlliesInRange(this GameObject unit, int range)
        {
            return Allies.Count() > 1 ? Allies.Count(u => u.Distance(unit) <= range && u.IsValid) : 0;
        }

        public static bool BeingTargeted(this GameObject unit)
        {
            return Enemies.Any(u => u.TargetGameObject == unit);
        }

        public static bool TargetDistance(this LocalPlayer cp, float range, bool useMinRange = true)
        {
            return useMinRange
                ? cp.HasTarget &&
                  cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach >= range
                : cp.HasTarget &&
                  cp.Distance2D(cp.CurrentTarget) - cp.CombatReach - cp.CurrentTarget.CombatReach <= range;
        }

        internal static bool IsWithin(this double num, int min, int max)
        {
            return num > min && num < max;
        }

        internal static async Task<bool> HpPotion()
        {
            if (!MainSettingsModel.Instance.UseHpPotions || Me.CurrentHealthPercent > MainSettingsModel.Instance.PotionHpPct) return false;

            uint[] potionIds = { 4551, 4552, 4553, 4554, 4559, 4560, 13637, 20309 };

            var potList = InventoryManager.FilledSlots.Where(r => r.Item.EquipmentCatagory == ItemUiCategory.Medicine && potionIds.Contains(r.Item.Id));
            var bagSlots = potList as IList<BagSlot> ?? potList.ToList();

            IOrderedEnumerable<BagSlot> potionSelection = null;

            if (MainSettingsModel.Instance.SelectedPotion == HpPotionSelection.Lowest)
                potionSelection = bagSlots.OrderBy(r => r.RawItemId);

            if (MainSettingsModel.Instance.SelectedPotion == HpPotionSelection.Highest)
                potionSelection = bagSlots.OrderByDescending(r => r.RawItemId);

            var potion = potionSelection?.FirstOrDefault();
            if (potion == null || !potion.CanUse())
                return false;

            return await Items.UsePotion(potion.Item, true);
        }

        internal static TimeSpan InstanceTimeRemaining;
        private static InstanceContentDirector _instanceContentDirector;

        internal static bool InActiveInstance()
        {
            if (!DutyManager.InInstance)
                return false;

            if (DirectorManager.ActiveDirector == null || DirectorManager.ActiveDirector.GetType() != typeof(InstanceContentDirector))
                return false;

            if(_instanceContentDirector == null || !_instanceContentDirector.IsValid)
                _instanceContentDirector = DirectorManager.ActiveDirector as InstanceContentDirector;

            TimeSpan instanceTimeRemainingVar;
            try
            {
                instanceTimeRemainingVar = _instanceContentDirector.TimeLeftInDungeon;
            }
            catch (Exception)
            {
                instanceTimeRemainingVar = TimeSpan.Zero;
            }
            InstanceTimeRemaining = instanceTimeRemainingVar;
            return instanceTimeRemainingVar > TimeSpan.FromSeconds(5);
        }

        #region Goad Manager

        public static IEnumerable<BattleCharacter> PartyMembers
        {
            get
            {
                return
                    PartyManager.VisibleMembers
                        .Select(pm => pm.GameObject as BattleCharacter)
                        .Where(pm => pm.IsTargetable);
            }
        }

        public static IEnumerable<BattleCharacter> GoadManager
        {
            get
            {
                return
                    GameObjectManager.GetObjectsOfType<BattleCharacter>(true)
                        .Where(
                            gm =>
                                PartyMembers.Contains(gm) && gm.Type == GameObjectType.Pc && gm.CurrentTP <= MainSettingsModel.Instance.GoadTp
                                && gm.InCombat
                                && gm.IsAlive
                                && !gm.IsHealer()
                                && gm.CurrentJob != ClassJobType.Arcanist &&
                                gm.CurrentJob != ClassJobType.Summoner &&
                                gm.CurrentJob != ClassJobType.Thaumaturge &&
                                gm.CurrentJob != ClassJobType.BlackMage &&
                                gm.CurrentJob != ClassJobType.RedMage)
                        .OrderByDescending(TpScore);
            }
        }

        private static int TpScore(BattleCharacter c)
        {
            var score = 0;

            if (c.IsTank())
            {
                score += 100;
            }
            else if (c.CurrentTP <= MainSettingsModel.Instance.GoadTp)
            {
                score += 120;
            }

            return score;
        }

        internal static async Task<bool> Goad()
        {
            if (!PartyManager.IsInParty || MainSettingsModel.Instance.UseManualGoad) return false;

            var autoGoadtarget = GoadManager.FirstOrDefault();
            var selectedGoadTarget = GoadTargetViewModel.Instance.GoadTarget;

            if (selectedGoadTarget.AllyIsValid() && MainSettingsModel.Instance.UseGoadTarget && selectedGoadTarget.CurrentTP > MainSettingsModel.Instance.GoadTp)
            {
                return await Spells.Goad.CastBuff(selectedGoadTarget, true, Auras.Goad);
            }

            if (!MainSettingsModel.Instance.UseGoadTarget && autoGoadtarget.AllyIsValid())
            {
                return await Spells.Goad.CastBuff(autoGoadtarget, true, Auras.Goad);
            }

            return await Spells.Goad.CastBuff(autoGoadtarget, MainSettingsModel.Instance.UseGoadTarget && !selectedGoadTarget.AllyIsValid(), Auras.Goad);
        }

        #endregion Goad Manager

        internal static async Task<bool> Opener()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            #region RoutineSwitch

            ThreadSafeObservableCollection<OpenerSpellInfo> openerList = null;

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    openerList = Barret_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Beatrix":
                    openerList = Beatrix_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Cecil":
                    openerList = Cecil_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Cyan":
                    openerList = Cyan_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Edward":
                    openerList = Edward_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Eiko":
                    openerList = Eiko_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Elayne":
                    openerList = Elayne_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Freya":
                    openerList = Freya_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Paine":
                    openerList = Paine_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Sabin":
                    openerList = Sabin_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Shadow":
                    openerList = Shadow_OpenerViewModel.Instance.GuiOpenerList;
                    break;

                case "Vivi":
                    openerList = Vivi_OpenerViewModel.Instance.GuiOpenerList;
                    break;
            }

            #endregion RoutineSwitch

            if (openerList != null)
            {
                var openerQueue = new Queue<OpenerSpellInfo>(openerList);

                if (openerQueue.Count == 0)
                {
                    Logger.KefkaLog(@"Opener queue is empty, please use the Reset Opener button to reset!");
                    openerQueue.Clear();
                    OpenerManager.ResetOpeners();
                    return false;
                }

                while (Target != null && openerQueue.Count > 0)
                {
                    var nextOpener = openerQueue.Peek();
                    Logger.KefkaLog(@"Next Opener Skill: {0}", nextOpener.SpellName);

                    if (nextOpener.SpellName.Contains("Delay"))
                    {
                        var waitTime = TimeSpan.FromSeconds(nextOpener.SpellId).Duration();

                        await Coroutine.Wait(waitTime, () => false);

                        openerQueue.Dequeue();
                        continue;
                    }

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

                    #region Routine Nuance Catches

                    switch (MainSettingsModel.Instance.CurrentRoutine)
                    {
                        case "Barret":
                            break;

                        case "Beatrix":
                            break;

                        case "Cecil":
                            break;

                        case "Cyan":
                            break;

                        case "Edward":
                            if (openerSpell == Spells.PitchPerfect)
                            {
                                await Coroutine.Wait((int)CombatHelper.GcdTimeRemaining, () => ActionResourceManager.Bard.Repertoire == 3);

                                if (ActionResourceManager.Bard.Repertoire != 3)
                                {
                                    openerQueue.Dequeue();
                                    continue;
                                }

                                if (await Spells.PitchPerfect.Use(Target, true))
                                {
                                    openerQueue.Dequeue();
                                    continue;
                                }
                            }
                            break;

                        case "Eiko":
                            break;

                        case "Elayne":
                            if (openerSpell == Spells.Verfire || openerSpell == Spells.Verstone)
                            {
                                await Coroutine.Wait((int)CombatHelper.GcdTimeRemaining, () => Me.HasAura(Auras.VerfireReady) || Me.HasAura(Auras.VerstoneReady));

                                if (!Me.HasAura(Auras.VerfireReady) && !Me.HasAura(Auras.VerstoneReady))
                                {
                                    openerQueue.Dequeue();
                                    continue;
                                }

                                if (Me.HasAura(Auras.VerfireReady))
                                {
                                    if (await Spells.Verfire.Use(Target, true))
                                    {
                                        openerQueue.Dequeue();
                                        continue;
                                    }
                                }

                                if (Me.HasAura(Auras.VerstoneReady))
                                {
                                    if (await Spells.Verstone.Use(Target, true))
                                    {
                                        openerQueue.Dequeue();
                                        continue;
                                    }
                                }
                            }
                            break;

                        case "Freya":
                            if (openerSpell == Spells.DragonSight)
                            {
                                if (await FreyaRotation.DragonSightOpener())
                                {
                                    openerQueue.Dequeue();
                                    continue;
                                }
                            }
                            break;

                        case "Paine":
                            break;

                        case "Sabin":
                            break;

                        case "Shadow":
                            break;

                        case "Vivi":
                            break;
                    }

                    #endregion Routine Nuance Catches

                    if (openerSpell?.Range == 0 && openerSpell.SpellType != SpellType.Weaponskill)
                    {
                        if (await openerSpell.UseOpenerSpell(Me, true))
                        {
                            Logger.KefkaLog("We're inside of the Regular Spell (ME) Section.");
                            openerQueue.Dequeue();
                            continue;
                        }
                    }

                    if (await openerSpell.UseOpenerSpell(Target, true))
                    {
                        Logger.KefkaLog("We're inside of the Regular Spell (TARGET) Section.");
                        openerQueue.Dequeue();
                    }

                    await Coroutine.Yield();
                }

                Logger.KefkaLog(@"Opener has completed, or was interrupted!");
                Core.OverlayManager.AddToast(() => "Opener Complete!", TimeSpan.FromMilliseconds(750), MainSettingsModel.Instance.ToastColor(true), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                openerQueue.Clear();
            }
            OpenerManager.ResetOpeners();
            return false;
        }
    }
}