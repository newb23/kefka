using System.Collections.Generic;
using System.Linq;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Utilities
{
    internal static class Group
    {
        static Group()
        {
            DeadAllies = new List<Character>();
            Tanks = new List<Character>();
            AlliesWithin30 = new List<Character>();
            AlliesWithin15 = new List<Character>();
            AlliesWithin10 = new List<Character>();
        }

        private static readonly uint[] PetIds = { 1398, 1399, 1400, 1401, 1402, 1403, 1404, 5478 };
        internal static readonly List<Character> DeadAllies;
        internal static readonly List<Character> Tanks;
        internal static readonly List<Character> AlliesWithin30;
        internal static readonly List<Character> AlliesWithin15;
        internal static readonly List<Character> AlliesWithin10;

        public static IEnumerable<Character> Pets
        {
            get
            {
                return GameObjectManager.GetObjectsByNPCIds<GameObject>(PetIds).Where(r =>
                {
                    if (!r.IsTargetable || !r.InLineOfSight())
                    {
                        return false;
                    }
                    return r.Distance(Me) <= 30;
                }).Select(r => r as Character);
            }
        }

        public static IEnumerable<Character> AllianceMembers
        {
            get
            {
                return GameObjectManager.GetObjectsOfType<BattleCharacter>().Where(r =>
                {
                    if (r.Type == GameObjectType.Pc || !r.IsTargetable)
                    {
                        return false;
                    }
                    return r.InLineOfSight() && r.Distance(Me) <= 30;
                });
            }
        }

        public static void UpdateAllies()
        {
            DeadAllies.Clear();
            Tanks.Clear();
            AlliesWithin30.Clear();
            AlliesWithin15.Clear();
            AlliesWithin10.Clear();

            #region GC Duty Check

            if (!PartyManager.IsInParty)
            {
                if (RaptureAtkUnitManager.Controls.All(r => r.Name != "GcArmyOrder"))
                {
                    InGcInstance = false;
                }
                else
                {
                    InGcInstance = true;
                    foreach (var battleCharacter in
                        from r in GameObjectManager.GetObjectsOfType<BattleCharacter>()
                        where !r.CanAttack
                        select r)
                    {
                        if (!battleCharacter.IsTargetable || !battleCharacter.InLineOfSight())
                        {
                            continue;
                        }
                        if (battleCharacter.CurrentHealth > 0)
                        {
                            if (battleCharacter.IsTank())
                            {
                                Tanks.Add(battleCharacter);
                            }
                            var distance = battleCharacter.Distance(Core.Me);
                            if (distance <= 30)
                            {
                                AlliesWithin30.Add(battleCharacter);
                            }
                            if (distance <= 15)
                            {
                                AlliesWithin15.Add(battleCharacter);
                            }
                            if (distance <= 10)
                            {
                                AlliesWithin10.Add(battleCharacter);
                            }
                            AlliesWithin30.Add(Me);
                            AlliesWithin15.Add(Me);
                            AlliesWithin10.Add(Me);
                        }
                        else
                        {
                            DeadAllies.Add(battleCharacter);
                        }
                    }
                }
            }

            #endregion GC Duty Check

            if (!PartyManager.IsInParty) { return; }

            foreach (var battleCharacter in
            from r in PartyManager.VisibleMembers
            select r.BattleCharacter)
            {
                if (battleCharacter == null || !battleCharacter.IsTargetable || !battleCharacter.InLineOfSight() || battleCharacter.Icon == PlayerIcon.Viewing_Cutscene)
                {
                    continue;
                }
                if (battleCharacter.CurrentHealth > 0)
                {
                    if (WorldManager.InPvP && battleCharacter.HasAura(Auras.PvPMounted))
                    {
                        continue;
                    }
                    if (battleCharacter.IsTank())
                    {
                        Tanks.Add(battleCharacter);
                    }
                    var distance = battleCharacter.Distance(Core.Me);
                    if (distance <= 30)
                    {
                        AlliesWithin30.Add(battleCharacter);
                    }
                    if (distance <= 15)
                    {
                        AlliesWithin15.Add(battleCharacter);
                    }
                    if (distance > 10)
                    {
                        continue;
                    }
                    AlliesWithin10.Add(battleCharacter);
                }
                else
                {
                    DeadAllies.Add(battleCharacter);
                }
            }
        }
    }
}