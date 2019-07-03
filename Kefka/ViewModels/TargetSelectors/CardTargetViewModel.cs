using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class CardTargetViewModel : BaseViewModel
    {
        private static CardTargetViewModel _instance;
        public static CardTargetViewModel Instance => _instance ?? (_instance = new CardTargetViewModel());

        private static volatile BattleCharacter cardTarget;

        public BattleCharacter CardTarget
        { get { return cardTarget; } set { cardTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> cardTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> CardTargetCollection
        {
            get
            {
                return cardTargetCollection ?? (cardTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                cardTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearCardTargetsList()
        {
            Logger.RemielLog("No longer in party. Clearing Card Targets.");
            cardTargetCollection?.Clear();
        }

        public void CardTargetListUpdate()
        {
            if (cardTargetCollection != null && cardTargetCollection?.Count != 0)
            {
                foreach (var pm in cardTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.RemielLog("{0} is no longer a valid target. Removing them from the Card Target List.", pm.SafeName());
                    cardTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null && x.AllyIsValid()))
            {
                if (cardTargetCollection != null)
                {
                    if (!cardTargetCollection.Contains(pm))
                    {
                        Logger.RemielLog("Adding {0} to the Card Target List.", pm.SafeName());
                    }
                    if (!cardTargetCollection.Contains(pm))
                        cardTargetCollection?.Add(pm);
                }
            }
        }
    }
}