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
    public class TankBustersViewModel : BaseViewModel
    {
        private static TankBustersViewModel _instance;
        public static TankBustersViewModel Instance => _instance ?? (_instance = new TankBustersViewModel());

        private ThreadSafeObservableCollection<TankBuster> _guiTankBustersList;

        public ThreadSafeObservableCollection<TankBuster> GuiTankBustersList
        {
            get
            {
                return _guiTankBustersList ?? (_guiTankBustersList = new ThreadSafeObservableCollection<TankBuster>(GetInitialTankBustersList));
            }
            set
            {
                _guiTankBustersList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<TankBuster> GetInitialTankBustersList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/";
                var tankBustersDir = settingsDir + "TankBusters.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                if (File.Exists(tankBustersDir))
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<TankBuster>>(File.ReadAllText(tankBustersDir));

                return new ThreadSafeObservableCollection<TankBuster>();
            }
        }

        internal void Save()
        {
            var tankBustersDir = @"Settings/" + Me.Name + "/Kefka/TankBusters.json";
            var data = JsonConvert.SerializeObject(GuiTankBustersList, Formatting.Indented);
            File.WriteAllText(tankBustersDir, data);
            TankBusterManager.ResetTankBusters();
        }

        public ICommand Remove => new DelegateCommand<TankBuster>(RemoveTankBuster);

        private void RemoveTankBuster(TankBuster spell)
        {
            if (spell == null)
                return;

            Logger.KefkaLog(@"Removing {0} from the Tankbuster List.", spell.SpellName);

            if (GuiTankBustersList.All(r => r.SpellId != spell.SpellId))
                return;

            var tankBuster = GuiTankBustersList.FirstOrDefault(r => r.SpellId == spell.SpellId);

            GuiTankBustersList.Remove(tankBuster);
            Save();
        }

        public ICommand Add => new DelegateCommand<Action>(AddTankBuster);

        private void AddTankBuster(Action spell)
        {
            if (spell == null)
                return;

            if (GuiTankBustersList.Any(r => r.SpellId == spell.Id))
                return;

            Logger.KefkaLog(@"Adding {0} to the Tankbuster List.", spell.Name);

            var newSpell = new TankBuster
            {
                SpellName = spell.Name,
                SpellId = spell.Id,
                Convalescence = false,
                Awareness = false,
                DivineVeil = false,
                Sheltron = false,
                HallowedGround = false,
                Sentinel = false,
                Foresight = false,
                Bulwark = false,
                Rampart = false,
                ThrillofBattle = false,
                Holmgang = false,
                Vengeance = false,
                Equilibrium = false,
                RawIntuition = false,
                Anticipation = false,
                ShadowWall = false,
                DarkMind = false,
                BlackestNight = false,
                LivingDead = false,
                Palisade = false
            };

            GuiTankBustersList.Add(newSpell);
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