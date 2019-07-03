using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class CoverTargetViewModel : BaseViewModel
    {
        private static CoverTargetViewModel _instance;
        public static CoverTargetViewModel Instance => _instance ?? (_instance = new CoverTargetViewModel());

        private volatile BattleCharacter coverTarget;

        public BattleCharacter CoverTarget
        { get { return coverTarget; } set { coverTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> coverTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> CoverTargetCollection
        {
            get
            {
                return coverTargetCollection ?? (coverTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                coverTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearCoverTargetsList()
        {
            Logger.BeatrixLog("No longer in party. Clearing Cover Targets.");
            coverTargetCollection?.Clear();
        }

        public void CoverTargetListUpdate()
        {
            if (coverTargetCollection != null && coverTargetCollection?.Count != 0)
            {
                foreach (var pm in coverTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.BeatrixLog("{0} is no longer a valid target. Removing them from the Cover Target List.", pm.SafeName());
                    coverTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && !x.IsMe))
            {
                if (coverTargetCollection != null)
                {
                    if (!coverTargetCollection.Contains(pm)) Logger.BeatrixLog("Adding {0} to the Cover Target List.", pm.SafeName());
                    if (!coverTargetCollection.Contains(pm))
                        coverTargetCollection?.Add(pm);
                }
            }
        }
    }
}