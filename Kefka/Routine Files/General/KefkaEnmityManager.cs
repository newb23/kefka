using System;
using ff14bot;
using ff14bot.Offsets;
using ff14bot.Settings;
using Buddy.Coroutines;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using System.Threading.Tasks;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;

namespace Kefka.Routine_Files.General
{
    internal class KefkaEnmityManager
    {
        private static DateTime aoEEnmityLimiter = DateTime.Now;
        static int LastDifference = 0;

        internal static async Task<bool> EnmityLists()
        {
            // Current Target Emnity
            foreach (var guy in EnmityManager.TargetEnmityList)
            {
                try
                {
                    Logger.KefkaLog(guy.Object.SafeName() + " : " + guy.CurrentEnmity);
                }
                catch (Exception)
                {
                    Logger.KefkaLog("There was an error in Enmity.");
                }
            }

            // **SHOULD** be for all attackers in the attackers list emnity towards you.
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                try
                {
                    Logger.KefkaLog(guy.Object.SafeName() + " : " + guy.CurrentEnmity);
                }
                catch (Exception)
                {
                    Logger.KefkaLog("There was an error in Enmity.");
                }
            }
            return true;
        }

        internal static async Task<int> EnmityDifference()
        {
            int MyEnmity = 0;
            int HighestEnmity = 0;
            int enmityDifference = 0;
            foreach (var guy in EnmityManager.TargetEnmityList)
            {
                if (guy.Object.IsMe)
                {
                    MyEnmity = (int) guy.CurrentEnmity;
                }
                if (!guy.Object.IsMe)
                {
                    if (guy.CurrentEnmity > HighestEnmity)
                    HighestEnmity = (int)guy.CurrentEnmity;
                }
            }

            enmityDifference = MyEnmity - HighestEnmity;
            return enmityDifference;
        }

        internal static async Task<int> AoEEnmityDifference()
        {
            if (DateTime.Now < aoEEnmityLimiter) return LastDifference;
            aoEEnmityLimiter = DateTime.Now.AddSeconds(5);

            var StartingTarget = Target;
            int MyEnmity = 0;
            int HighestEnmity = 0;
            int LowestDifference = 0;
            int CurrentDifference = 0;
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                if (guy != null) guy.Object.Target();

                foreach (var guy2 in EnmityManager.TargetEnmityList)
                {
                    if (guy2.Object.IsMe)
                    {
                        MyEnmity = (int)guy2.CurrentEnmity;
                    }

                    if (!guy2.Object.IsMe)
                    {
                        if (guy2.CurrentEnmity > HighestEnmity)
                            HighestEnmity = (int)guy2.CurrentEnmity;
                    }
                    CurrentDifference = MyEnmity - HighestEnmity;
                }
                if (LowestDifference == 0 || LowestDifference > CurrentDifference)
                    LowestDifference = CurrentDifference;
            }
            
            if (StartingTarget != null)
            StartingTarget.Target();

            LastDifference = LowestDifference;
            return LowestDifference;
        }

        internal static async Task<bool> HaveTargetAggro()
        {
            int MyEnmity = 0;
            int HighestEnmity = 0;
            bool HaveEnmity = false;
            foreach (var guy in EnmityManager.TargetEnmityList)
            {
                if (guy.Object.IsMe)
                {
                    MyEnmity = (int)guy.CurrentEnmity;
                }
                if (!guy.Object.IsMe)
                {
                    if (guy.CurrentEnmity > HighestEnmity)
                        HighestEnmity = (int)guy.CurrentEnmity;
                }
            }

            if (MyEnmity >= HighestEnmity)
            {
                HaveEnmity = true;
            }

            return HaveEnmity;
        }

        internal static async Task<int> TargetingMeCount()
        {
            int EnemyCount = 0;
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                if (guy.CurrentEnmity == 100)
                    EnemyCount++;
            }
            return EnemyCount;
        }

        internal static async Task<int> TargetingOthersCount()
        {
            int EnemyCount = 0;
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                if (guy.CurrentEnmity < 100)
                    EnemyCount++;
            }
            return EnemyCount;
        }

        internal static async Task<bool> HaveAggro()
        {
            bool IGotAggro = true;
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                if (guy.CurrentEnmity < 100)
                    IGotAggro = false;
            }
            return IGotAggro;
        }

        internal static async Task<bool> NeedAggro()
        {
            bool LosingAggro = false;
            foreach (var guy in EnmityManager.AttackersEnmityList)
            {
                if (guy.CurrentEnmity < 100)
                    LosingAggro = true;
            }
            return LosingAggro;
        }
    }
}
