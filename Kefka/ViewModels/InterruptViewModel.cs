using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Input;
using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using Newtonsoft.Json;
using Action = Kefka.Models.Action;

namespace Kefka.ViewModels
{
    public class InterruptViewModel : BaseViewModel
    {
        private static InterruptViewModel _instance;
        public static InterruptViewModel Instance => _instance ?? (_instance = new InterruptViewModel());

        private ThreadSafeObservableCollection<SpellInfo> _guiInterruptsList;

        public ThreadSafeObservableCollection<SpellInfo> GuiInterruptsList
        {
            get
            {
                return _guiInterruptsList ?? (_guiInterruptsList = new ThreadSafeObservableCollection<SpellInfo>(GetInitialInterruptsList));
            }
            set
            {
                _guiInterruptsList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<SpellInfo> GetInitialInterruptsList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/";
                var interruptDir = settingsDir + "Interrupts.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                //Logger.KefkaLog("Beginning Interrupt Import.");

                if (File.Exists(interruptDir))
                {
                    //Logger.KefkaLog("User Interrupts Exist - Importing...");
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<SpellInfo>>(File.ReadAllText(interruptDir));
                }

                return DefaultInteruptList;
            }
        }

        private static IEnumerable<SpellInfo> DefaultInteruptList
        {
            get
            {
                //Logger.KefkaLog("User Interrupt list not found. Loading Default.");

                var assembly = Assembly.GetExecutingAssembly();
                const string resourceName = "Kefka.Resources.Interrupts.json";

                string result = null;

                using (var stream = assembly.GetManifestResourceStream(resourceName))

                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            // Logger.KefkaLog("Retrieving Default Interrupt List.");
                            result = reader.ReadToEnd();
                        }

                return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<SpellInfo>>(result);
            }
        }

        public void Save()
        {
            var interruptsDir = @"Settings/" + Me.Name + "/Kefka/Interrupts.json";
            var data = JsonConvert.SerializeObject(GuiInterruptsList, Formatting.Indented);
            File.WriteAllText(interruptsDir, data);
            InterruptManager.ResetInterrupts();
        }

        public ICommand Remove => new DelegateCommand<SpellInfo>(RemoveInterrupt);

        private void RemoveInterrupt(SpellInfo spell)
        {
            if (spell == null)
                return;

            if (!GuiInterruptsList.Contains(spell))
                return;

            Logger.KefkaLog(@"Removing {0} from the Interrupt List.", spell.SpellName);

            GuiInterruptsList.Remove(spell);
            Save();
        }

        public ICommand Add => new DelegateCommand<Action>(AddInterrupt);

        private void AddInterrupt(Action spell)
        {
            if (spell == null)
                return;

            Logger.KefkaLog(@"Adding {0} to the Interrupt List.", spell.Name);

            var newSpell = new SpellInfo { CanStun = true, CanSilence = false, SpellId = spell.Id, SpellName = spell.Name };

            GuiInterruptsList.Add(newSpell);
            Save();
        }

        private static readonly ThreadSafeObservableCollection<Action> ActionList = new ThreadSafeObservableCollection<Action>(InitialActionList);

        private static IEnumerable<Action> InitialActionList
        {
            get
            {
                var actionListDir = @"Settings/" + Me.Name + "/Kefka/ActionList.json";

                //ToDo: Figure out a better solution for auto-XIVDB downloading.
                if (File.Exists(actionListDir))
                {
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<Action>>(File.ReadAllText(actionListDir));
                }

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