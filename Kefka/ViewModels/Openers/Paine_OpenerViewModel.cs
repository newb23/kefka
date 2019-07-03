using ff14bot;
using ff14bot.Objects; 
 using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Input;
using OpenerAction = Kefka.Models.Action;

namespace Kefka.ViewModels.Openers
{
    public class Paine_OpenerViewModel : BaseViewModel
    {
        
        private static Paine_OpenerViewModel _instance;
        public static Paine_OpenerViewModel Instance => _instance ?? (_instance = new Paine_OpenerViewModel());

        private ThreadSafeObservableCollection<OpenerSpellInfo> _guiOpenerList;

        public ICommand Save => new DelegateCommand(SaveOpener);
        public ICommand Add => new DelegateCommand<OpenerAction>(AddOpener);
        public ICommand Remove => new DelegateCommand<OpenerSpellInfo>(RemoveOpener);
        public ICommand Clear => new DelegateCommand(ClearOpener);
        public ICommand MoveOpenerUp => new DelegateCommand<OpenerSpellInfo>(MoveSelectionUp);
        public ICommand MoveOpenerDown => new DelegateCommand<OpenerSpellInfo>(MoveSelectionDown);
        public ICommand OpenerImportCommand => new DelegateCommand(OpenerImport);
        public ICommand OpenerExportCommand => new DelegateCommand(OpenerExport);

        public ThreadSafeObservableCollection<OpenerSpellInfo> GuiOpenerList
        {
            get
            {
                return _guiOpenerList ?? (_guiOpenerList = new ThreadSafeObservableCollection<OpenerSpellInfo>(GetInitialOpenerList));
            }
            set
            {
                _guiOpenerList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<OpenerSpellInfo> GetInitialOpenerList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/Openers/Paine/";
                var openerDir = settingsDir + "Paine_Opener.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                if (File.Exists(openerDir))
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<OpenerSpellInfo>>(File.ReadAllText(openerDir));

                return DefaultOpener;
            }
        }

        private static IEnumerable<OpenerSpellInfo> DefaultOpener
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                const string resourceName = "Kefka.Resources.DefaultOpeners.Paine_Opener.json";

                string result = null;

                using (var stream = assembly.GetManifestResourceStream(resourceName))

                    if (stream != null)
                        using (var reader = new StreamReader(stream))
                        {
                            result = reader.ReadToEnd();
                        }

                return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<OpenerSpellInfo>>(result);
            }
        }

        public void SaveOpener()
        {
            var OpenerDir = @"Settings/" + Me.Name + "/Kefka/Openers/Paine/Paine_Opener.json";
            var data = JsonConvert.SerializeObject(GuiOpenerList, Formatting.Indented);
            File.WriteAllText(OpenerDir, data);
        }

        private void AddOpener(OpenerAction spell)
        {
            if (spell == null)
                return;

            var newSpell = new OpenerSpellInfo { SpellId = spell.Id, SpellName = spell.Name, IsPet = spell.IsPet, IsItem = spell.IsItem };

            GuiOpenerList.Add(newSpell);
            SaveOpener();
        }

        private void RemoveOpener(OpenerSpellInfo spell)
        {
            if (spell == null)
                return;

            if (!GuiOpenerList.Contains(spell))
                return;

            GuiOpenerList.Remove(spell);
            SaveOpener();
        }

        private void ClearOpener()
        {
            GuiOpenerList.Clear();
            SaveOpener();
        }

        private void OpenerImport()
        {
            GuiOpenerList.Clear();
            OpenFileDialog openerImportDialog = new OpenFileDialog();

            openerImportDialog.CheckFileExists = true;
            if (openerImportDialog.ShowDialog() == DialogResult.OK)
            {
                if (openerImportDialog.FileName.Trim() != string.Empty)
                {
                    using (StreamReader r = new StreamReader(openerImportDialog.FileName))
                    {
                        var json = r.ReadToEnd();
                        foreach (var openerSpellInfo in JsonConvert.DeserializeObject<ThreadSafeObservableCollection<OpenerSpellInfo>>(json))
                            GuiOpenerList.Add(openerSpellInfo);
                    }
                }
            }

            SaveOpener();
        }

        public void OpenerExport()
        {
            SaveFileDialog openerExportDialog = new SaveFileDialog();
            openerExportDialog.Filter = @"Json (*.json)|*.json";
            openerExportDialog.DefaultExt = "json";
            openerExportDialog.AddExtension = true;

            openerExportDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openerExportDialog.FileName))
            {
                string exportedFilename = openerExportDialog.FileName;
                var exportedData = JsonConvert.SerializeObject(GuiOpenerList, Formatting.Indented);
                File.WriteAllText(exportedFilename, exportedData);
            }
        }

        private void MoveSelectionUp(OpenerSpellInfo spell)
        {
            if (spell == null)
                return;

            if (!GuiOpenerList.Contains(spell))
                return;

            if (GuiOpenerList.First() == spell)
                return;

            var index = GuiOpenerList.IndexOf(spell);

            GuiOpenerList.Move(index, index - 1);
            SaveOpener();
        }

        private void MoveSelectionDown(OpenerSpellInfo spell)
        {
            if (spell == null)
                return;

            if (!GuiOpenerList.Contains(spell))
                return;

            if (GuiOpenerList.Last() == spell)
                return;

            var index = GuiOpenerList.IndexOf(spell);

            GuiOpenerList.Move(index, index + 1);
            SaveOpener();
        }

        private static readonly ThreadSafeObservableCollection<OpenerAction> ActionList = new ThreadSafeObservableCollection<OpenerAction>(InitialActionList);

        private static IEnumerable<OpenerAction> InitialActionList
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                const string resourceName = "Kefka.Resources.OpenerActions.json";

                string result;

                using (var stream = assembly.GetManifestResourceStream(resourceName))

                using (var reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }

                return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<OpenerAction>>(result);
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

        public ThreadSafeObservableCollection<OpenerAction> SearchList { get; set; } = new ThreadSafeObservableCollection<OpenerAction>();
    }
}