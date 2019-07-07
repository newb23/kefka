using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Input;

namespace Kefka.ViewModels
{
    public class CleansesViewModel : BaseViewModel
    {
        private static CleansesViewModel _instance;
        public static CleansesViewModel Instance => _instance ?? (_instance = new CleansesViewModel());

        private ThreadSafeObservableCollection<Cleanse> _guiCleansesList;

        public ThreadSafeObservableCollection<Cleanse> GuiCleansesList
        {
            get
            {
                return _guiCleansesList ?? (_guiCleansesList = new ThreadSafeObservableCollection<Cleanse>(GetInitialCleansesList));
            }
            set
            {
                _guiCleansesList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<Cleanse> GetInitialCleansesList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/";
                var CleansesDir = settingsDir + "Cleanses.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                if (File.Exists(CleansesDir))
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<Cleanse>>(File.ReadAllText(CleansesDir));

                return new ThreadSafeObservableCollection<Cleanse>();
            }
        }

        internal void Save()
        {
            var CleansesDir = @"Settings/" + Me.Name + "/Kefka/Cleanses.json";
            var data = JsonConvert.SerializeObject(GuiCleansesList, Formatting.Indented);
            File.WriteAllText(CleansesDir, data);
        }

        public ICommand Remove => new DelegateCommand<Cleanse>(RemoveCleanse);

        private void RemoveCleanse(Cleanse spell)
        {
            if (spell == null)
                return;

            Logger.KefkaLog(@"Removing {0} from the Cleanse List.", spell.SpellName);

            if (GuiCleansesList.All(r => r.SpellId != spell.SpellId))
                return;

            var cleanse = GuiCleansesList.FirstOrDefault(r => r.SpellId == spell.SpellId);

            GuiCleansesList.Remove(cleanse);
            Save();
        }

        public ICommand Add => new DelegateCommand<Status>(AddCleanse);

        private void AddCleanse(Status spell)
        {
            if (spell == null)
                return;

            if (GuiCleansesList.Any(r => r.SpellId == spell.Id))
                return;

            Logger.KefkaLog(@"Adding {0} to the Cleanse List.", spell.Name);

            var newSpell = new Cleanse
            {
                SpellName = spell.Name,
                SpellId = spell.Id,
                Leeches = false,
                Esuna = false,
                ExaltedDetriment = false,
            };

            GuiCleansesList.Add(newSpell);
            Save();
        }

        private static readonly ThreadSafeObservableCollection<Status> StatusList = new ThreadSafeObservableCollection<Status>(InitialStatusList);

        private static IEnumerable<Status> InitialStatusList
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                const string resourceName = "Kefka.Resources.StatusList.json";

                string result;

                using (var stream = assembly.GetManifestResourceStream(resourceName))

                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<Status>>(result);
            }
        }

        public ICommand Search => new DelegateCommand<string>(SearchStatusList);

        private void SearchStatusList(string text)
        {
            SearchList.Clear();

            var statusList = StatusList.Where(r => r.Name.ToLower().Contains(text.ToLower()));

            foreach (var entry in statusList)
            {
                SearchList.Add(entry);
            }
        }

        public ThreadSafeObservableCollection<Status> SearchList { get; set; } = new ThreadSafeObservableCollection<Status>();
    }
}