using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class GoadTargetViewModel : BaseViewModel
    {
        private static GoadTargetViewModel _instance;
        public static GoadTargetViewModel Instance => _instance ?? (_instance = new GoadTargetViewModel());

        private static volatile BattleCharacter goadTarget;

        public BattleCharacter GoadTarget
        { get { return goadTarget; } set { goadTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> goadTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> GoadTargetCollection
        {
            get
            {
                return goadTargetCollection ?? (goadTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                goadTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearGoadTargetsList()
        {
            Logger.KefkaLog("No longer in party. Clearing Goad Targets.");
            goadTargetCollection?.Clear();
        }

        public void GoadTargetListUpdate()
        {
            if (goadTargetCollection != null && goadTargetCollection?.Count != 0)
            {
                foreach (var pm in goadTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.KefkaLog("{0} is no longer a valid target. Removing them from the Goad Target List.", pm.SafeName());
                    goadTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null &&
                x.AllyIsValid() &&
                x.Type == GameObjectType.Pc &&
                (x.CurrentJob == ClassJobType.Marauder || x.CurrentJob == ClassJobType.Warrior ||
                x.CurrentJob == ClassJobType.Gladiator || x.CurrentJob == ClassJobType.Paladin ||
                x.CurrentJob == ClassJobType.Archer || x.CurrentJob == ClassJobType.Bard ||
                x.CurrentJob == ClassJobType.Lancer || x.CurrentJob == ClassJobType.Dragoon ||
                x.CurrentJob == ClassJobType.Pugilist || x.CurrentJob == ClassJobType.Monk ||
                x.CurrentJob == ClassJobType.Rogue || x.CurrentJob == ClassJobType.Ninja ||
                x.CurrentJob == ClassJobType.Machinist || x.CurrentJob == ClassJobType.DarkKnight) &&
                !x.IsMe))
            {
                if (goadTargetCollection != null)
                {
                    if (!goadTargetCollection.Contains(pm)) Logger.KefkaLog("Adding {0} to the Goad Target List.", pm.SafeName());
                    if (!goadTargetCollection.Contains(pm))
                        goadTargetCollection?.Add(pm);
                }
            }
        }
    }
}