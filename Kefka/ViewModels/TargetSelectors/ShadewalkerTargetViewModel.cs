using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using System.Linq;

namespace Kefka.ViewModels
{
    internal class ShadewalkerTargetViewModel : BaseViewModel
    {
        private static ShadewalkerTargetViewModel _instance;
        public static ShadewalkerTargetViewModel Instance => _instance ?? (_instance = new ShadewalkerTargetViewModel());

        private static volatile BattleCharacter shadewalkerTarget;

        public BattleCharacter ShadewalkerTarget
        { get { return shadewalkerTarget; } set { shadewalkerTarget = value; OnPropertyChanged(); } }

        private static ThreadSafeObservableCollection<BattleCharacter> shadewalkerTargetCollection;

        public ThreadSafeObservableCollection<BattleCharacter> ShadewalkerTargetCollection
        {
            get
            {
                return shadewalkerTargetCollection ?? (shadewalkerTargetCollection = new ThreadSafeObservableCollection<BattleCharacter>());
            }
            set
            {
                shadewalkerTargetCollection = value;
                OnPropertyChanged();
            }
        }

        public void ClearShadewalkerTargetsList()
        {
            Logger.ShadowLog("No longer in party. Clearing Shadewalker Targets.");
            shadewalkerTargetCollection?.Clear();
        }

        public void ShadewalkerTargetListUpdate()
        {
            if (shadewalkerTargetCollection != null && shadewalkerTargetCollection?.Count != 0)
            {
                foreach (var pm in shadewalkerTargetCollection?.Where(x => !x.AllyIsValid()))
                {
                    Logger.ShadowLog("{0} is no longer a valid target. Removing them from the Shadewalker Target List.", pm.SafeName());
                    shadewalkerTargetCollection?.Remove(pm);
                }
            }

            foreach (var pm in PartyManager.VisibleMembers.Select(x => x.GameObject as BattleCharacter).Where(x => x != null
                && x.AllyIsValid()
                && x.Type == GameObjectType.Pc
                && x.IsTank()
                && !x.IsMe))
            {
                if (shadewalkerTargetCollection != null)
                {
                    if (!shadewalkerTargetCollection.Contains(pm)) Logger.ShadowLog("Adding {0} to the Shadewalker Target List.", pm.SafeName());
                    if (!shadewalkerTargetCollection.Contains(pm))
                        shadewalkerTargetCollection?.Add(pm);
                }
            }
        }
    }
}