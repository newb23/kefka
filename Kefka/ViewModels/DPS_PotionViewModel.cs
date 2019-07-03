using System.Collections.Generic;
using System.Linq;
using ff14bot.Enums;
using ff14bot.Managers;
using Kefka.Utilities;

namespace Kefka.ViewModels
{
    public class DPS_PotionViewModel : BaseViewModel
    {
        private static DPS_PotionViewModel _instance;
        public static DPS_PotionViewModel Instance => _instance ?? (_instance = new DPS_PotionViewModel());

        private volatile BagSlot selectedPotion;

        public BagSlot SelectedPotion
        {
            get { return selectedPotion; }

            set
            {
                selectedPotion = value;
                Logger.KefkaLog("Selected {0} as your Non-Opener DPS potion.", SelectedPotion.Item.CurrentLocaleName);
                OnPropertyChanged();
            }
        }

        private ThreadSafeObservableCollection<BagSlot> _guiPotionList;

        public ThreadSafeObservableCollection<BagSlot> GuiPotionList
        {
            get
            {
                return _guiPotionList ?? (_guiPotionList = new ThreadSafeObservableCollection<BagSlot>(PotionList));
            }
            set
            {
                //todo Check on this to see if it updates when the inventory changes
                //_guiPotionList = new ThreadSafeObservableCollection<BagSlot>(PotionList);
                _guiPotionList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<BagSlot> PotionList
        {
            get
            {
                var useableItem = InventoryManager.FilledSlots.Where(a => a.Item != null
                    && a.Item.EquipmentCatagory == ItemUiCategory.Medicine
                    && (a.Item.EnglishName.Contains("Strength")
                    || a.Item.EnglishName.Contains("Dexterity")
                    || a.Item.EnglishName.Contains("Vitality")
                    || a.Item.EnglishName.Contains("Intelligence")
                    || a.Item.EnglishName.Contains("Mind")));

                return useableItem;
            }
        }

        #region SelfDeclaredJson

        //private static IEnumerable<PotionInfo> PotionList
        //{
        //    get
        //    {
        //        var assembly = Assembly.GetExecutingAssembly();
        //        const string resourceName = "Kefka.Resources.DPS_Potions.json";

        //        string result;

        //        using (var stream = assembly.GetManifestResourceStream(resourceName))

        //        using (var reader = new StreamReader(stream))
        //        {
        //            result = reader.ReadToEnd();
        //        }

        //        return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<PotionInfo>>(result);
        //    }
        //}

        #endregion SelfDeclaredJson
    }
}