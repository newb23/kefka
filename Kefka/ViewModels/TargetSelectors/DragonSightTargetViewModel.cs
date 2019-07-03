using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class DragonSightTargetViewModel : BaseViewModel
    {
        private static DragonSightTargetViewModel _instance;
        public static DragonSightTargetViewModel Instance => _instance ?? (_instance = new DragonSightTargetViewModel());

        private static volatile BattleCharacter dragonSightTarget;

        public BattleCharacter DragonSightTarget
        { get { return dragonSightTarget; } set { dragonSightTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> dragonSightTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> DragonSightTargetCollection
        {
            get
            {
                return dragonSightTargetCollection ?? (dragonSightTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                dragonSightTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearDragonSightTargetsList()
        {
            Logger.FreyaLog("No longer in party. Clearing DragonSight Targets.");
            dragonSightTargetCollection?.Clear();
        }

        public void DragonSightTargetListUpdate()
        {
            if (dragonSightTargetCollection != null && dragonSightTargetCollection?.Count != 0)
            {
                foreach (var pm in dragonSightTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.FreyaLog("{0} is no longer a valid target. Removing them from the DragonSight Target List.", pm.SafeName());
                    dragonSightTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && x.Type == GameObjectType.Pc
                && !x.IsMe))
            {
                if (dragonSightTargetCollection != null)
                {
                    if (!dragonSightTargetCollection.Contains(pm)) Logger.FreyaLog("Adding {0} to the DragonSight Target List.", pm.SafeName());
                    if (!dragonSightTargetCollection.Contains(pm))
                        dragonSightTargetCollection?.Add(pm);
                }
            }
        }
    }
}