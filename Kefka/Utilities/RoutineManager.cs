using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ff14bot.Enums;
using ff14bot.Helpers;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files;
using System.Windows.Media;

namespace Kefka.Utilities
{
    internal class RoutineManager
    {
        #region Class Handlers

        private static IRotation rotation;

        public static IRotation Rotation => rotation ?? (rotation = GetRotation(Me.CurrentJob));

        public static ClassJobType currentClass;

        public static ClassJobType CurrentClass
        {
            get
            {
                if (currentClass == Me.CurrentJob)
                    return currentClass;

                currentClass = Me.CurrentJob;
                rotation = GetRotation(currentClass);
                return currentClass;
            }
        }

        public static IRotation GetRotation(ClassJobType ClassJob)
        {
            FormManager.ClassChange();

            switch (ClassJob)
            {
                case ClassJobType.Arcanist:
                case ClassJobType.Summoner:
                    MainSettingsModel.Instance.CurrentRoutine = "Eiko";
                    break;

                case ClassJobType.Scholar:
                    MainSettingsModel.Instance.CurrentRoutine = "Surito";
                    break;

                case ClassJobType.Archer:
                case ClassJobType.Bard:
                    MainSettingsModel.Instance.CurrentRoutine = "Edward";
                    break;

                case ClassJobType.Gladiator:
                case ClassJobType.Paladin:
                    MainSettingsModel.Instance.CurrentRoutine = "Beatrix";
                    break;

                case ClassJobType.Lancer:
                case ClassJobType.Dragoon:
                    MainSettingsModel.Instance.CurrentRoutine = "Freya";
                    break;

                case ClassJobType.Conjurer:
                case ClassJobType.WhiteMage:
                    MainSettingsModel.Instance.CurrentRoutine = "Mikoto";
                    break;

                case ClassJobType.Marauder:
                case ClassJobType.Warrior:
                    MainSettingsModel.Instance.CurrentRoutine = "Paine";
                    break;

                case ClassJobType.Pugilist:
                case ClassJobType.Monk:
                    MainSettingsModel.Instance.CurrentRoutine = "Sabin";
                    break;

                case ClassJobType.Rogue:
                case ClassJobType.Ninja:
                    MainSettingsModel.Instance.CurrentRoutine = "Shadow";
                    break;

                case ClassJobType.Thaumaturge:
                case ClassJobType.BlackMage:
                    MainSettingsModel.Instance.CurrentRoutine = "Vivi";
                    break;

                case ClassJobType.Machinist:
                    MainSettingsModel.Instance.CurrentRoutine = "Barret";
                    break;

                case ClassJobType.DarkKnight:
                    MainSettingsModel.Instance.CurrentRoutine = "Cecil";
                    break;

                case ClassJobType.Astrologian:
                    MainSettingsModel.Instance.CurrentRoutine = "Remiel";
                    break;

                case ClassJobType.RedMage:
                    MainSettingsModel.Instance.CurrentRoutine = "Elayne";
                    break;

                case ClassJobType.Samurai:
                    MainSettingsModel.Instance.CurrentRoutine = "Cyan";
                    break;

                default:
                    MainSettingsModel.Instance.CurrentRoutine = "";
                    return null;
            }

            Logger.KefkaLog(@"Loading: {0} : {1}", currentClass, Me.ClassLevel);
            return new RoutineComposites();
        }

        #endregion Class Handlers
    }
}