using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;

namespace Kefka.Routine_Files.General
{
    internal class DodgeManager
    {
        internal static async Task<bool> DodgeThis(SpellData ability, GameObject tar, uint aura, bool isDot, bool isBuff, bool isHealingSpell)
        {
            if (ability == null || tar == null || (ability.SpellType != SpellType.Ability && ability.SpellType != SpellType.Spell && ability.SpellType != SpellType.Weaponskill))
                return false;

            if (Me.IsCasting && Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds > Math.Max(MainSettingsModel.Instance.LagAdjust, 500))
            {
                if (!tar.IsTargetable || !tar.IsValid || MovementManager.IsMoving)
                {
                    ActionManager.StopCasting();
                    return false;
                }

                // Stop casting if the enemy is dead and we're not casting a healing spell
                if (tar.MaxHealth > 0 && tar.CurrentHealth < 1 && !isHealingSpell)
                {
                    Logger.KefkaLog("Target is dead. Stopping Cast.");
                    ActionManager.StopCasting();
                    return false;
                }

                //Stop Casting for... stuff
                switch (MainSettingsModel.Instance.CurrentRoutine)
                {
                    case "Mikoto":
                        if (Ability.CurrentHealTarget != null && !isHealingSpell && Me.ClassLevel >= Spells.Cure.LevelAcquired)
                        {
                            Logger.MikotoLog($@"====> Stopping {ability.Name} as {RoutineComposites.HealTarget().SafeName()} needs heals!");
                            ActionManager.StopCasting();
                            return false;
                        }

                        if (Ability.CurrentHealTarget == null) break;

                        if (MikotoSettingsModel.Instance.AutoStopHeal && Ability.CurrentHealTarget.CurrentHealthPercent >= MikotoSettingsModel.Instance.StopHealHpPct && isHealingSpell &&
                            ability != Spells.Esuna && ability != Spells.Protect && ability != Spells.Medica && ability != Spells.MedicaII)
                        {
                            Logger.MikotoLog($@"====> Stopping {ability.Name} as {Ability.CurrentHealTarget.Name}'s HP is above {MikotoSettingsModel.Instance.StopHealHpPct}%.");
                            ActionManager.StopCasting();
                            Ability.IsHealingSpell = false;
                            Ability.CurrentHealTarget = null;

                            return true;
                        }
                        break;

                    case "Remiel":
                        if (Ability.CurrentHealTarget != null && !isHealingSpell && Me.ClassLevel >= Spells.Benefic.LevelAcquired)
                        {
                            Logger.RemielLog($@"====> Stopping {ability.Name} as {RoutineComposites.HealTarget().SafeName()} needs heals!");
                            ActionManager.StopCasting();
                            return false;
                        }

                        if (Ability.CurrentHealTarget == null) break;

                        if (RemielSettingsModel.Instance.AutoStopHeal && Ability.CurrentHealTarget.CurrentHealthPercent >= RemielSettingsModel.Instance.StopHealHpPct && isHealingSpell &&
                            ability != Spells.Esuna && ability != Spells.Protect && ability != Spells.Helios && ability != Spells.AspectedHelios)
                        {
                            Logger.RemielLog($@"====> Stopping {ability.Name} as {Ability.CurrentHealTarget.Name}'s HP is above {RemielSettingsModel.Instance.StopHealHpPct}%.");
                            ActionManager.StopCasting();
                            Ability.IsHealingSpell = false;
                            Ability.CurrentHealTarget = null;

                            return true;
                        }
                        break;

                    case "Surito":
                        if (Ability.CurrentHealTarget != null && !isHealingSpell && Me.ClassLevel >= Spells.Physick.LevelAcquired)
                        {
                            Logger.SuritoLog($@"====> Stopping {ability.Name} as {RoutineComposites.HealTarget().SafeName()} needs heals!");
                            ActionManager.StopCasting();
                            return false;
                        }

                        if (Ability.CurrentHealTarget == null) break;

                        if (SuritoSettingsModel.Instance.AutoStopHeal && Ability.CurrentHealTarget.CurrentHealthPercent >= SuritoSettingsModel.Instance.StopHealHpPct && isHealingSpell &&
                            ability != Spells.Adloquium && ability != Spells.Esuna && ability != Spells.Protect && ability != Spells.Succor && ability != Spells.Summon && ability != Spells.SummonII)
                        {
                            Logger.SuritoLog($@"====> Stopping {ability.Name} as {Ability.CurrentHealTarget.Name}'s HP is above {SuritoSettingsModel.Instance.StopHealHpPct}%.");
                            ActionManager.StopCasting();
                            Ability.IsHealingSpell = false;
                            Ability.CurrentHealTarget = null;

                            return true;
                        }
                        break;
                }

                if (MovementManager.IsMoving)
                {
                    ActionManager.StopCasting();
                    if (Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds <= Math.Max(MainSettingsModel.Instance.LagAdjust, 500))
                    {
                        Logger.KefkaLog(ability.LocalizedName + @" should have gone off properly. Assuming as such.");
                        // Fill variables
                        Ability.IsHealingSpell = false;
                        Ability.CurrentHealTarget = null;
                        Logger.CastMessage(ability.LocalizedName, tar.SafeName());
                        CombatHelper.LastSpell = ability;
                        CombatHelper.LastTarget = tar;
                        await CombatHelper.SleepForLag();
                        await Coroutine.Wait(2500, () => !Me.SpellCastInfo.IsCasting);
                        return true;
                    }
                    return false;
                }
                //Logger.KefkaLog(ability.Name + " has: " + Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds + "ms remaining on its cast time.");
                return false;
            }

            if (ability.BaseCastTime == TimeSpan.Zero || Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds <= Math.Max(MainSettingsModel.Instance.LagAdjust, 500))
            {
                #region IsDot
                //ToDo: See if performance gets hit again after this change 0.0.42
                if (isDot)
                {
                    var auraCheck = new Stopwatch();
                    auraCheck.Start();
                    if (await Coroutine.Wait((int)ability.AdjustedCastTime.TotalMilliseconds + MainSettingsModel.Instance.AuraCheckAdjust, () => !tar.IsValid || aura == 0 || tar.HasAura(aura, true) || MovementManager.IsMoving))
                    {
                        if (ability.AdjustedCastTime <= TimeSpan.Zero || Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds <= Math.Max(MainSettingsModel.Instance.LagAdjust, 500))
                        {
                            Logger.CastMessage(ability.LocalizedName, tar.SafeName());

                            Ability.IsDot = false;
                            CombatHelper.LastSpell = ability;
                            CombatHelper.LastTarget = tar;
                            auraCheck.Stop();
                            return true;
                        }
                    }

                    auraCheck.Stop();
                    return false;
                }
                #endregion IsDot
                #region IsBuff
                if (isBuff)
                {
                    var auraCheck = new Stopwatch();
                    auraCheck.Start();

                    if (await Coroutine.Wait((int)ability.AdjustedCastTime.TotalMilliseconds + MainSettingsModel.Instance.AuraCheckAdjust, () => !tar.IsValid || aura == 0 || Me.HasAura(aura, true) || MovementManager.IsMoving))
                    {
                        if (ability.AdjustedCastTime <= TimeSpan.Zero || Me.SpellCastInfo.RemainingCastTime.TotalMilliseconds <= Math.Max(MainSettingsModel.Instance.LagAdjust, 500))
                        {
                            Logger.CastMessage(ability.LocalizedName, tar.SafeName());

                            Ability.IsBuff = false;
                            CombatHelper.LastSpell = ability;
                            CombatHelper.LastTarget = tar;
                            auraCheck.Stop();
                            return true;
                        }
                    }

                    auraCheck.Stop();
                    return false;
                }
                #endregion IsBuff

                Logger.CastMessage(ability.LocalizedName, tar.SafeName());
                CombatHelper.LastSpell = ability;
                CombatHelper.LastTarget = tar;
                await CombatHelper.SleepForLag();
                await Coroutine.Wait(2500, () => !Me.SpellCastInfo.IsCasting);
                return true;
            }

            return false;
        }
    }
}