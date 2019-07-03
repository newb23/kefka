using Kefka.Models;
using Kefka.Utilities;

namespace Kefka.ViewModels
{
    public class EnemyOverlayViewModel : BaseViewModel
    {
        private static EnemyOverlayViewModel _instance;
        public static EnemyOverlayViewModel Instance => _instance ?? (_instance = new EnemyOverlayViewModel());

        public MainSettingsModel Settings => MainSettingsModel.Instance;

        private ThreadSafeObservableCollection<EnemyInfo> enemyInfo;

        public ThreadSafeObservableCollection<EnemyInfo> EnemyInfoCollection
        {
            get
            {
                return enemyInfo ?? (enemyInfo = new ThreadSafeObservableCollection<EnemyInfo>());
            }
            set
            {
                enemyInfo = value;
                OnPropertyChanged();
            }
        }
    }
}