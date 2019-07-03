using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Kefka.Utilities
{
    public static class CombatHelper
    {
        public static double GCD { get; set; }
        public static double GcdTimeRemaining => GCD_Selection();
        public static bool OnGcd => GcdTimeRemaining > MainSettingsModel.Instance.LagAdjust;
        private static DateTime LastSpellTime;

        private static double GCD_Selection()
        {
            switch (Me.CurrentJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Summoner:
                    GCD = Spells.Ruin?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Ruin.Cooldown.TotalMilliseconds;

                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    GCD = Spells.HeavyShot?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.HeavyShot.Cooldown.TotalMilliseconds;

                case ClassJobType.Conjurer:
                    GCD = Spells.Cure?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Cure.Cooldown.TotalMilliseconds;

                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    GCD = Spells.FastBlade?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.FastBlade.Cooldown.TotalMilliseconds;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    GCD = Spells.HeavyThrust?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.HeavyThrust.Cooldown.TotalMilliseconds;

                case ClassJobType.Warrior:
                case ClassJobType.Marauder:
                    GCD = Spells.HeavySwing?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.HeavySwing.Cooldown.TotalMilliseconds;

                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                    GCD = Spells.Bootshine?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Bootshine.Cooldown.TotalMilliseconds;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    GCD = Spells.SpinningEdge?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.SpinningEdge.Cooldown.TotalMilliseconds;

                case ClassJobType.Thaumaturge:
                case ClassJobType.BlackMage:
                    GCD = Spells.Blizzard?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Blizzard.Cooldown.TotalMilliseconds;

                case ClassJobType.Astrologian:
                    GCD = Spells.Malefic?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Malefic.Cooldown.TotalMilliseconds;

                case ClassJobType.DarkKnight:
                    GCD = Spells.HardSlash?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.HardSlash.Cooldown.TotalMilliseconds;

                case ClassJobType.Machinist:
                    GCD = Spells.SplitShot?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.SplitShot.Cooldown.TotalMilliseconds;

                case ClassJobType.Scholar:
                    GCD = Spells.Physick?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Physick.Cooldown.TotalMilliseconds;

                case ClassJobType.WhiteMage:
                    GCD = Spells.Cure?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Cure.Cooldown.TotalMilliseconds;

                case ClassJobType.RedMage:
                    GCD = Spells.Jolt?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Jolt.Cooldown.TotalMilliseconds;

                case ClassJobType.Samurai:
                    GCD = Spells.Hakaze?.AdjustedCooldown.TotalMilliseconds / 1000 ?? 0;
                    return Spells.Hakaze.Cooldown.TotalMilliseconds;

                default:
                    throw new NotImplementedException();
            }
        }

        public static SpellData LastSpell;
        public static GameObject LastTarget;
        public static SpellData LastTargetSpell;

        public static Queue<SpellData> CombatQueue = new Queue<SpellData>();

        public static readonly Stopwatch CombatTime = new Stopwatch();

        public static async Task<bool> SleepForLag()
        {
            await Coroutine.Sleep(MainSettingsModel.Instance.LagAdjust + 50);
            return true;
        }

        public static void ResetLastUsed()
        {
            if (DateTime.Now < LastSpellTime) return;
            LastSpellTime = DateTime.Now.AddSeconds(10);

            if (LastSpell != null
                && !Me.IsCasting
                && !Me.InCombat
                && (Target == null || Target != LastTarget || GameObjectManager.Attackers == null || GameObjectManager.NumberOfAttackers <= 0))
            {
                LastSpell = null;
            }
        }
    }
}