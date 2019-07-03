using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Input;

namespace Kefka.ViewModels
{
    public class HealBustersViewModel : BaseViewModel
    {
        private static HealBustersViewModel _instance;
        public static HealBustersViewModel Instance => _instance ?? (_instance = new HealBustersViewModel());

        private ThreadSafeObservableCollection<HealBuster> _guiHealBustersList;

        public ThreadSafeObservableCollection<HealBuster> GuiHealBustersList
        {
            get
            {
                return _guiHealBustersList ?? (_guiHealBustersList = new ThreadSafeObservableCollection<HealBuster>(GetInitialHealBustersList));
            }
            set
            {
                _guiHealBustersList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<HealBuster> GetInitialHealBustersList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/";
                var HealBustersDir = settingsDir + "HealBusters.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                if (File.Exists(HealBustersDir))
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<HealBuster>>(File.ReadAllText(HealBustersDir));

                return new ThreadSafeObservableCollection<HealBuster>();
            }
        }

        internal void Save()
        {
            var HealBustersDir = @"Settings/" + Me.Name + "/Kefka/HealBusters.json";
            var data = JsonConvert.SerializeObject(GuiHealBustersList, Formatting.Indented);
            File.WriteAllText(HealBustersDir, data);
            HealBusterManager.ResetHealBusters();
        }

        public ICommand Remove => new DelegateCommand<HealBuster>(RemoveHealBuster);

        private void RemoveHealBuster(HealBuster spell)
        {
            if (spell == null)
                return;

            Logger.KefkaLog(@"Removing {0} from the Healbuster List.", spell.SpellName);

            if (GuiHealBustersList.All(r => r.SpellId != spell.SpellId))
                return;

            var HealBuster = GuiHealBustersList.FirstOrDefault(r => r.SpellId == spell.SpellId);

            GuiHealBustersList.Remove(HealBuster);
            Save();
        }

        public ICommand Add => new DelegateCommand<Action>(AddHealBuster);

        private void AddHealBuster(Action spell)
        {
            if (spell == null)
                return;

            if (GuiHealBustersList.Any(r => r.SpellId == spell.Id))
                return;

            Logger.KefkaLog(@"Adding {0} to the Healbuster List.", spell.Name);

            var newSpell = new HealBuster
            {
                SpellName = spell.Name,
                SpellId = spell.Id,
                Medica = false,
                MedicaII = false,
                Benediction = false,
                Tetragrammaton = false,
                DivineBenison = false,
                PlenaryIndulgence = false,
                CureII = false,
                Asylum = false,
                Adloquium = false,
                Excogitation = false,
                Aetherpact = false,
                Succor = false,
                SacredSoil = false,
                Lustrate = false,
                Rouse = false,
                BeneficII = false,
                AspectedBenefic = false,
                EssentialDignity = false,
                AspectedHelios = false,
                CollectiveUnconscious = false
            };

            GuiHealBustersList.Add(newSpell);
            Save();
        }

        private static readonly ThreadSafeObservableCollection<Action> ActionList = new ThreadSafeObservableCollection<Action>(InitialActionList);

        private static IEnumerable<Action> InitialActionList
        {
            get
            {
                var actionListDir = @"Settings/" + Me.Name + "/Kefka/ActionList.json";

                //ToDo: Figure out a better solution for auto-XIVDB downloading.

                var json = new WebClient().DownloadString("https://api.xivdb.com/action?columns=id,name,classjob");

                var tempActionCollection = JsonConvert.DeserializeObject<ThreadSafeObservableCollection<Action>>(json);

                var data = JsonConvert.SerializeObject(tempActionCollection, Formatting.Indented);
                File.WriteAllText(actionListDir, data);

                var tempCollection = new ThreadSafeObservableCollection<Action>();

                foreach (var action in tempActionCollection)
                {
                    if (!action.HasClassJob && !action.Name.Any(x => char.IsLetter(x) && !(x >= 63 && x <= 126)))
                    {
                        tempCollection.Add(action);
                    }
                }

                var jsonString = JsonConvert.SerializeObject(tempCollection);

                return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<Action>>(jsonString);
            }
        }

        public ICommand Search => new DelegateCommand<string>(SearchActionList);

        private void SearchActionList(string text)
        {
            SearchList.Clear();

            var actionList = ActionList.Where(r => r.Name.ToLower().Contains(text.ToLower()));

            foreach (var entry in actionList)
            {
                SearchList.Add(entry);
            }
        }

        public ThreadSafeObservableCollection<Action> SearchList { get; set; } = new ThreadSafeObservableCollection<Action>();
    }
}