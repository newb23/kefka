using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class ClemencyTargetViewModel : BaseViewModel
    {
        private static ClemencyTargetViewModel _instance;
        public static ClemencyTargetViewModel Instance => _instance ?? (_instance = new ClemencyTargetViewModel());

        private volatile BattleCharacter clemencyTarget;

        public BattleCharacter ClemencyTarget
        { get { return clemencyTarget; } set { clemencyTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> clemencyTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> ClemencyTargetCollection
        {
            get
            {
                return clemencyTargetCollection ?? (clemencyTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                clemencyTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearClemencyTargetsList()
        {
            Logger.BeatrixLog("No longer in party. Clearing Clemency Targets.");
            clemencyTargetCollection?.Clear();
        }

        public void ClemencyTargetListUpdate()
        {
            if (clemencyTargetCollection != null && clemencyTargetCollection?.Count != 0)
            {
                foreach (var pm in clemencyTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.BeatrixLog("{0} is no longer a valid target. Removing them from the Clemency Target List.", pm.IsMe ? pm.SafeName() : pm.SafeName());
                    clemencyTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null && x.AllyIsValid()))
            {
                if (clemencyTargetCollection != null)
                {
                    if (!clemencyTargetCollection.Contains(pm))
                    {
                        Logger.BeatrixLog("Adding {0} to the Clemency Target List.", pm.IsMe ? pm.SafeName() : pm.SafeName());
                    }
                    if (!clemencyTargetCollection.Contains(pm))
                        clemencyTargetCollection?.Add(pm);
                }
            }
        }
    }
}