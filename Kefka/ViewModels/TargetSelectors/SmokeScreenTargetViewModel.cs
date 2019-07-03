using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class SmokeScreenTargetViewModel : BaseViewModel
    {
        private static SmokeScreenTargetViewModel _instance;
        public static SmokeScreenTargetViewModel Instance => _instance ?? (_instance = new SmokeScreenTargetViewModel());

        private static volatile BattleCharacter smokeScreenTarget;

        public BattleCharacter SmokeScreenTarget
        { get { return smokeScreenTarget; } set { smokeScreenTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> smokeScreenTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> SmokeScreenTargetCollection
        {
            get
            {
                return smokeScreenTargetCollection ?? (smokeScreenTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                smokeScreenTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearSmokeScreenTargetsList()
        {
            Logger.ShadowLog("No longer in party. Clearing SmokeScreen Targets.");
            smokeScreenTargetCollection?.Clear();
        }

        public void SmokeScreenTargetListUpdate()
        {
            if (smokeScreenTargetCollection != null && smokeScreenTargetCollection?.Count != 0)
            {
                foreach (var pm in smokeScreenTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.ShadowLog("{0} is no longer a valid target. Removing them from the SmokeScreen Target List.", pm.SafeName());
                    smokeScreenTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && x.Type == GameObjectType.Pc
                && x.IsTank()
                && !x.IsMe))
            {
                if (smokeScreenTargetCollection != null)
                {
                    if (!smokeScreenTargetCollection.Contains(pm)) Logger.ShadowLog("Adding {0} to the SmokeScreen Target List.", pm.SafeName());
                    if (!smokeScreenTargetCollection.Contains(pm))
                        smokeScreenTargetCollection?.Add(pm);
                }
            }
        }
    }
}