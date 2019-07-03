using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class NaturesMinneTargetViewModel : BaseViewModel
    {
        private static NaturesMinneTargetViewModel _instance;
        public static NaturesMinneTargetViewModel Instance => _instance ?? (_instance = new NaturesMinneTargetViewModel());

        private static volatile BattleCharacter naturesMinneTarget;

        public BattleCharacter NaturesMinneTarget
        { get { return naturesMinneTarget; } set { naturesMinneTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> naturesMinneTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> NaturesMinneTargetCollection
        {
            get
            {
                return naturesMinneTargetCollection ?? (naturesMinneTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                naturesMinneTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearNaturesMinneTargetsList()
        {
            Logger.EdwardLog("No longer in party. Clearing NaturesMinne Targets.");
            naturesMinneTargetCollection?.Clear();
        }

        public void NaturesMinneTargetListUpdate()
        {
            if (naturesMinneTargetCollection != null && naturesMinneTargetCollection?.Count != 0)
            {
                foreach (var pm in naturesMinneTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.EdwardLog("{0} is no longer a valid target. Removing them from the NaturesMinne Target List.", pm.SafeName());
                    naturesMinneTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && x.Type == GameObjectType.Pc
                && !x.IsMe))
            {
                if (naturesMinneTargetCollection != null)
                {
                    if (!naturesMinneTargetCollection.Contains(pm)) Logger.EdwardLog("Adding {0} to the NaturesMinne Target List.", pm.SafeName());
                    if (!naturesMinneTargetCollection.Contains(pm))
                        naturesMinneTargetCollection?.Add(pm);
                }
            }
        }
    }
}