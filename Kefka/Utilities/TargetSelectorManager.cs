using System;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;
using Kefka.Routine_Files.General;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;

namespace Kefka.Utilities
{
    internal class TargetSelectorManager
    {
        private static uint partyMembers;

        private static DateTime pulseLimiter;

        public static bool PulseCheck(int time)
        {
            if (DateTime.Now < pulseLimiter) return false;
            if (DateTime.Now > pulseLimiter)
                pulseLimiter = DateTime.Now.Add(TimeSpan.FromSeconds(time));

            return true;
        }

        public static void UpdatePartyMembers()
        {
            if (!QuestLogManager.InCutscene && Core.Me.AllyIsValid() || (DutyManager.InInstance && Common_Utils.InActiveInstance()))
            {
                if (PartyManager.NumMembers != partyMembers || partyMembers == 0 || PulseCheck(10))
                {
                    TargetSelectorRefresh();
                }
            }
            else
            {
                if (partyMembers != 0 && ((!DutyManager.InInstance && !PartyManager.IsInParty) || (DutyManager.InInstance && !Common_Utils.InActiveInstance())))
                {
                    TargetSelectorClear();
                }
            }
        }

        private static void TargetSelectorRefresh()
        {
            switch (Core.Me.CurrentJob)
            {
                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    NaturesMinneTargetViewModel.Instance.NaturesMinneTargetListUpdate();
                    PalisadeTargetViewModel.Instance.PalisadeTargetListUpdate();
                    partyMembers = PartyManager.NumMembers;
                    break;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    DragonSightTargetViewModel.Instance.DragonSightTargetListUpdate();
                    partyMembers = PartyManager.NumMembers;
                    break;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    GoadTargetViewModel.Instance.GoadTargetListUpdate();
                    ShadewalkerTargetViewModel.Instance.ShadewalkerTargetListUpdate();
                    SmokeScreenTargetViewModel.Instance.SmokeScreenTargetListUpdate();
                    partyMembers = PartyManager.NumMembers;
                    break;

                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    CoverTargetViewModel.Instance.CoverTargetListUpdate();
                    ClemencyTargetViewModel.Instance.ClemencyTargetListUpdate();
                    partyMembers = PartyManager.NumMembers;
                    break;

                case ClassJobType.Astrologian:
                    CardTargetViewModel.Instance.CardTargetListUpdate();
                    partyMembers = PartyManager.NumMembers;
                    break;

                default:
                    return;
            }
        }

        private static void TargetSelectorClear()
        {
            switch (Core.Me.CurrentJob)
            {
                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    NaturesMinneTargetViewModel.Instance.ClearNaturesMinneTargetsList();
                    PalisadeTargetViewModel.Instance.ClearPalisadeTargetsList();
                    partyMembers = 0;
                    break;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    DragonSightTargetViewModel.Instance.ClearDragonSightTargetsList();
                    partyMembers = 0;
                    break;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    GoadTargetViewModel.Instance.ClearGoadTargetsList();
                    ShadewalkerTargetViewModel.Instance.ClearShadewalkerTargetsList();
                    SmokeScreenTargetViewModel.Instance.ClearSmokeScreenTargetsList();
                    partyMembers = 0;
                    break;

                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    CoverTargetViewModel.Instance.ClearCoverTargetsList();
                    ClemencyTargetViewModel.Instance.ClearClemencyTargetsList();
                    partyMembers = 0;
                    break;

                case ClassJobType.Astrologian:
                    CardTargetViewModel.Instance.ClearCardTargetsList();
                    partyMembers = 0;
                    break;

                default:
                    return;
            }
        }
    }
}