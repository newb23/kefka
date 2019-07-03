using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class PalisadeTargetViewModel : BaseViewModel
    {
        private static PalisadeTargetViewModel _instance;
        public static PalisadeTargetViewModel Instance => _instance ?? (_instance = new PalisadeTargetViewModel());

        private static volatile BattleCharacter palisadeTarget;

        public BattleCharacter PalisadeTarget
        { get { return palisadeTarget; } set { palisadeTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> palisadeTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> PalisadeTargetCollection
        {
            get
            {
                return palisadeTargetCollection ?? (palisadeTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                palisadeTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearPalisadeTargetsList()
        {
            Logger.KefkaLog("No longer in party. Clearing Palisade Targets.");
            palisadeTargetCollection?.Clear();
        }

        public void PalisadeTargetListUpdate()
        {
            if (palisadeTargetCollection != null && palisadeTargetCollection?.Count != 0)
            {
                foreach (var pm in palisadeTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.KefkaLog("{0} is no longer a valid target. Removing them from the Palisade Target List.", pm.SafeName());
                    palisadeTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && x.Type == GameObjectType.Pc
                && x.IsTank()))
            {
                if (palisadeTargetCollection != null)
                {
                    if (!palisadeTargetCollection.Contains(pm)) Logger.KefkaLog("Adding {0} to the Palisade Target List.", pm.SafeName());
                    if (!palisadeTargetCollection.Contains(pm))
                        palisadeTargetCollection?.Add(pm);
                }
            }
        }
    }
}