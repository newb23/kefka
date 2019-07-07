using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;
using RoutineManager = ff14bot.Managers.RoutineManager;

namespace Kefka.Routine_Files
{
    public static class Ability
    {
        internal static bool IsHealingSpell, IsDot, IsBuff;
        private static DateTime _facingLimiter;

        internal static bool OpenerEnabled => BarretSettingsModel.Instance.UseOpener
                                             || BeatrixSettingsModel.Instance.UseOpener
                                             || CecilSettingsModel.Instance.UseOpener
                                             || CyanSettingsModel.Instance.UseOpener
                                             || EdwardSettingsModel.Instance.UseOpener
                                             || EikoSettingsModel.Instance.UseOpener
                                             || ElayneSettingsModel.Instance.UseOpener
                                             || FreyaSettingsModel.Instance.UseOpener
                                             || PaineSettingsModel.Instance.UseOpener
                                             || SabinSettingsModel.Instance.UseOpener
                                             || ShadowSettingsModel.Instance.UseOpener
                                             || ViviSettingsModel.Instance.UseOpener;

        internal static BattleCharacter CurrentHealTarget;
        internal static GameObject CurrentTarget;
        internal static uint CastedAura;

        #region CommonCast

        //Used to cast a spell with nothing but a successful cast check.
        public static async Task<bool> Use(this SpellData ability, GameObject tar, bool reqs, bool HealSpell = false)
        {
            CurrentTarget = tar;
            CastedAura = 0;
            IsDot = false;
            IsBuff = false;
            IsHealingSpell = HealSpell;
            if (HealSpell == true)
            {
                CurrentHealTarget = (BattleCharacter)tar;
                CurrentTarget = Me.CurrentTarget;
            }

            if (tar == null) return false;

            return await DoAction(ability, tar, reqs, 0);
        }

        //Used to check Target for an aura after cast.
        public static async Task<bool> CastDot(this SpellData ability, GameObject tar, bool reqs, uint aura = 0, int refreshtime = 0)
        {
            CurrentTarget = tar;
            CastedAura = aura;
            IsDot = true;
            IsBuff = false;
            IsHealingSpell = false;
            CurrentHealTarget = null;

            if (tar == null || (IgnoreTargetManager.IgnoreTargets.Contains(tar.NpcId) && MainSettingsModel.Instance.IgnoreTargetDoTs)) return false;

            return await DoAction(ability, tar, reqs, aura);
        }

        //Used to check Player for an aura after cast.
        public static async Task<bool> CastBuff(this SpellData ability, GameObject tar, bool reqs, uint aura = 0, int refreshtime = 0)
        {
            CurrentTarget = tar;
            CastedAura = aura;
            IsDot = false;
            IsBuff = true;
            IsHealingSpell = false;
            CurrentHealTarget = null;

            if (tar == null) return false;

            return await DoAction(ability, tar, reqs, aura);
        }

        //Used to cast a healing spell.
        public static async Task<bool> CastHeal(this SpellData ability, GameObject tar, bool reqs, uint aura = 0, int refreshtime = 0)
        {
            CurrentTarget = Me.CurrentTarget;
            CastedAura = aura;
            IsDot = false;
            IsBuff = false;
            IsHealingSpell = true;
            CurrentHealTarget = (BattleCharacter)tar;

            if (tar == null) return false;

            return await DoAction(ability, tar, reqs, aura);
        }

        public static async Task<bool> UseOpenerSpell(this SpellData ability, GameObject tar, bool reqs)
        {
            return await OpenerDoAction(ability, tar, reqs);
        }

        private static async Task<bool> OpenerDoAction(SpellData ability, GameObject tar, bool reqs)
        {
            var spellCheck = await SpellCheck(ability, tar, reqs);

            if (tar == null || !tar.IsValid || !spellCheck)
                return false;

            var swiftCast = Me.HasAura(Auras.Swiftcast);

            if (ability.GroundTarget)
            {
                var currentLoc = tar.Location;

                await Coroutine.Sleep(50);

                if (currentLoc != tar.Location)
                {
                    return false;
                }

                if (!ActionManager.DoActionLocation(ability.Id, tar.Location))
                    return false;
            }
            else
            {
                if (!ActionManager.DoAction(ability, tar))
                    return false;
            }

            if (ability.AdjustedCastTime > TimeSpan.Zero)
                await Coroutine.Wait(1000, () => Me.IsCasting);

            var abilityTime = new Stopwatch();

            //Setting up a variable because adjusted cast time can change after the spell has started casting.
            var adjustedCastSpeed = ability.AdjustedCastTime.TotalMilliseconds;

            while (Me.IsCasting)
            {
                //Logger.KefkaLog(@"Adjusted cast speed of current spell is: {0}", adjustedCastSpeed);

                if (!abilityTime.IsRunning)
                    abilityTime.Start();

                if (!tar.IsTargetable || !tar.IsValid)
                {
                    ActionManager.StopCasting();
                    abilityTime.Stop();
                    return false;
                }

                if (MovementManager.IsMoving)
                {
                    ActionManager.StopCasting();
                    abilityTime.Stop();
                    return false;
                }

                // Stop casting if the enemy is dead and we're not casting a res
                if (tar.CurrentHealth < 1)
                {
                    ActionManager.StopCasting();
                    abilityTime.Stop();
                    return false;
                }

                if (MovementManager.IsMoving)
                {
                    ActionManager.StopCasting();
                    abilityTime.Stop();
                    if (abilityTime.ElapsedMilliseconds + 500 >= adjustedCastSpeed)
                    {
                        Logger.KefkaLog(ability.LocalizedName + @" should have gone off properly. Assuming as such.");
                        // Fill variables
                        CombatHelper.LastSpell = ability; CombatHelper.LastTarget = tar;
                        Logger.ViviLog(@"====> {0} on {1}", ability.LocalizedName, tar.SafeName());
                        return true;
                    }

                    return false;
                }

                await Coroutine.Yield();
            }

            abilityTime.Stop();

            if (!swiftCast && abilityTime.ElapsedMilliseconds + 100 < adjustedCastSpeed && !ViviSettingsModel.Instance.UseOpener)
            {
                return false;
            }

            CombatHelper.LastSpell = ability; CombatHelper.LastTarget = tar;
            Logger.KefkaLog(@"====> {0} on {1}", ability.LocalizedName, tar.SafeName());

            await CombatHelper.SleepForLag();
            return true;
        }

        private static async Task<bool> DoAction(SpellData ability, GameObject tar, bool reqs, uint aura)
        {
            var spellCheck = await SpellCheck(ability, tar, reqs);

            if (tar == null || !tar.IsValid || !spellCheck)
                return false;

            if (ability.GroundTarget)
            {
                var currentLoc = tar.Location;

                await Coroutine.Sleep(50);

                if (currentLoc != tar.Location)
                {
                    return false;
                }

                if (!ActionManager.DoActionLocation(ability.Id, tar.Location))
                    return false;
            }
            else
            {
                if (!ActionManager.DoAction(ability, tar))
                    return false;
            }

            if (ability.AdjustedCastTime.Milliseconds > 0)
            {
                await Coroutine.Wait(1000, () => Me.IsCasting);
            }

            if (OpenerEnabled) return true;

            return await DodgeManager.DodgeThis(ability, tar, aura, IsDot, IsBuff, IsHealingSpell);
        }

        private static async Task<bool> SpellCheck(SpellData ability, GameObject tar, bool reqs)
        {
            uint[] roleSkills = { 7560, 7563, 7564, 7565, 7566, 7545, 7542, 7543, 7546, 7547, 7548, 7549, 7863,
                7541, 7544, 7531, 7532, 7533, 7534, 7535, 7536, 7537, 7538, 7539, 7540, 7567, 7568, 7569, 7570,
                7571, 7572, 7558, 7559, 7561, 7562, 7550, 7551, 7552, 7553, 7554, 7555, 7556, 7557 };

            if (tar == null || !ActionManager.HasSpell(ability.LocalizedName) || (Me.ClassLevel < ability.LevelAcquired && !roleSkills.Contains(ability.Id)))
                return false;

            if (BotManager.Current.IsAutonomous && !RoutineManager.IsAnyDisallowed(CapabilityFlags.Facing) && DateTime.Now > _facingLimiter && Target != null && !Me.IsFacing(Target))
            {
                _facingLimiter = DateTime.Now.AddSeconds(1);
                tar.Face();
            }

            if (!MainSettingsModel.Instance.UseCastorQueue)
                if (!ActionManager.CanCast(ability, tar))
                    return false;

            if (MainSettingsModel.Instance.UseCastorQueue)
                if (!ActionManager.CanCastOrQueue(ability, tar))
                    return false;

            if (ability.Cooldown != TimeSpan.Zero)
                return false;

            if (!MovementManager.IsMoving || ability.AdjustedCastTime <= TimeSpan.Zero) return reqs;

            if (!BotManager.Current.IsAutonomous) return false;

            Navigator.PlayerMover.MoveStop();
            return reqs;
        }

        public static async Task<bool> CancelAura(uint aura, string auraname)
        {
            if (Core.Me.HasAura(aura))
            {
                Logger.CastMessage("Cancel Aura ", auraname);
                ChatManager.SendChat("/statusoff " + '"' + auraname + '"');
                await Coroutine.Yield();
                return true;
            }
            return false;
        }

        #endregion CommonCast
    }
}