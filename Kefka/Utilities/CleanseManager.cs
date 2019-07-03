using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Constants;

namespace Kefka.Utilities
{
    public static class CleanseManager
    {
        public static GameObject CleanseTarget;

        public static float GetWeight(Character c)
        {
            float score;
            if (c.IsHealer())
            {
                score = 100f;
            }
            else
            {
                score = c.IsTank() ? 90f : 80f;
            }

            return score;
        }

        private static GameObject CheckParty()
        {
            IEnumerable<Character> characters = GameObjectExtensions.PartyMembers;
            var character = (
                from a in characters
                where a.NeedsCleanse()
                select a).OrderByDescending(GetWeight).FirstOrDefault();

            return character;
        }

        private static GameObject CheckSelf()
        {
            if (Me.NeedsCleanse())
            {
                return Me;
            }

            return null;
        }

        private static GameObject CheckPet()
        {
            if (Me.Pet != null)
            {
                var pet = Me.Pet;
                if (pet.NeedsCleanse())
                {
                    return pet;
                }
            }
            return null;
        }

        public static async Task<bool> DoCleanses()
        {
            CleanseTarget = CheckPet();
            if (!PartyManager.IsInParty)
            {
                CleanseTarget = CheckSelf();
            }
            else
            {
                CleanseTarget = CheckParty();
            }
            if (CleanseTarget != null)
            {
                return await Spells.Esuna.Use(CleanseTarget, true);
            }
            return false;
        }

        public static async Task<bool> PetCleanse()
        {
            CleanseTarget = CheckPet();
            if (!PartyManager.IsInParty)
            {
                CleanseTarget = CheckSelf();
            }
            else
            {
                CleanseTarget = CheckParty();
            }
            if (CleanseTarget != null)
            {
                return PetManager.DoAction(Spells.FeyCaress.LocalizedName, Me.Pet);
            }
            return false;
        }
    }
}