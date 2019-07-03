using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using ff14bot;
using ff14bot.Objects; 
 using static Kefka.Utilities.Constants;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using Newtonsoft.Json;

namespace Kefka.ViewModels
{
    public class IgnoreTargetsViewModel : BaseViewModel
    {
        
        
        public ICommand Add => new DelegateCommand<IgnoreTargetInfo>(AddIgnore);
        public ICommand Remove => new DelegateCommand<IgnoreTargetInfo>(RemoveIgnore);

        private static IgnoreTargetsViewModel _instance;
        public static IgnoreTargetsViewModel Instance => _instance ?? (_instance = new IgnoreTargetsViewModel());

        private ThreadSafeObservableCollection<IgnoreTargetInfo> _guiIgnoreTargetsList;

        public ThreadSafeObservableCollection<IgnoreTargetInfo> GuiIgnoreTargetsList
        {
            get
            {
                return _guiIgnoreTargetsList ?? (_guiIgnoreTargetsList = new ThreadSafeObservableCollection<IgnoreTargetInfo>(GetInitialIgnoreTargetsList));
            }
            set
            {
                _guiIgnoreTargetsList = value;
                OnPropertyChanged();
            }
        }

        private static IEnumerable<IgnoreTargetInfo> GetInitialIgnoreTargetsList
        {
            get
            {
                var settingsDir = @"Settings/" + Me.Name + "/Kefka/";
                var ignoreTargetDir = settingsDir + "IgnoreTargets.json";

                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }

                if (File.Exists(ignoreTargetDir))
                    return JsonConvert.DeserializeObject<ThreadSafeObservableCollection<IgnoreTargetInfo>>(File.ReadAllText(ignoreTargetDir));

                return new ThreadSafeObservableCollection<IgnoreTargetInfo>();
            }
        }

        public void Save()
        {
            var ignoreTargetsDir = @"Settings/" + Me.Name + "/Kefka/IgnoreTargets.json";
            var data = JsonConvert.SerializeObject(GuiIgnoreTargetsList, Formatting.Indented);
            File.WriteAllText(ignoreTargetsDir, data);
            IgnoreTargetManager.ResetIgnoreTargets();
        }

        private void RemoveIgnore(IgnoreTargetInfo target)
        {
            GuiIgnoreTargetsList.Remove(target);
            Save();
        }

        private void AddIgnore(IgnoreTargetInfo target)
        {
            if (Target == null) return;

            var newIgnoreTarget = new IgnoreTargetInfo { IgnoreTargetName = Target.EnglishName, IgnoreTargetId = Target.NpcId };

            if (!GuiIgnoreTargetsList.Contains(newIgnoreTarget))
                GuiIgnoreTargetsList.Add(newIgnoreTarget);
            Save();
        }
    }
}