using System;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using static Kefka.Utilities.Constants;

namespace Kefka.ViewModels
{
    public class CecilPresetsViewModel : BaseViewModel
    {
        public ICommand LoadPreset1 => new DelegateCommand(Preset1);

        public ICommand LoadPreset2 => new DelegateCommand(Preset2);

        public ICommand LoadPreset3 => new DelegateCommand(Preset3);

        public ICommand LoadPreset4 => new DelegateCommand(Preset4);

        public ICommand LoadPreset5 => new DelegateCommand(Preset5);

        public ICommand LoadSettings => new DelegateCommand(Load);

        public ICommand SaveSettingsAs => new DelegateCommand(SaveAs);

        public ICommand SetPreset1 => new DelegateCommand(Preset1Set);

        public ICommand SetPreset2 => new DelegateCommand(Preset2Set);

        public ICommand SetPreset3 => new DelegateCommand(Preset3Set);

        public ICommand SetPreset4 => new DelegateCommand(Preset4Set);

        public ICommand SetPreset5 => new DelegateCommand(Preset5Set);

        public CecilSettingsModel Settings => CecilSettingsModel.Instance;

        public CecilPresetsSettingsModel Presets => CecilPresetsSettingsModel.Instance;

        private static string initPath = Path.Combine(Environment.CurrentDirectory, @"Settings\" + Me.Name + @"\Kefka\Routine Settings\Cecil");

        private void Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.Load(openFileDialog.FileName);
                Logger.KefkaLog("Loaded preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
        }

        private void Preset1Set()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presets.Preset1Path = openFileDialog.FileName;
                Presets.Preset1Name = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Logger.KefkaLog("Saved preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
            else
            {
                Presets.Preset1Path = null;
                Presets.Preset1Name = "Preset 1";
                Logger.KefkaLog("Reset preset 1.");
            }
        }

        public void Preset1()
        {
            if (File.Exists(Presets.Preset1Path))
            {
                Settings.Load(Presets.Preset1Path);
                Logger.KefkaLog("Loaded preset: {0}", Presets.Preset1Name);
            }
            else
            {
                Logger.KefkaLog("Preset {0} does not exist", Presets.Preset1Name);
            }
        }

        private void Preset2Set()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presets.Preset2Path = openFileDialog.FileName;
                Presets.Preset2Name = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Logger.KefkaLog("Saved preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
            else
            {
                Presets.Preset2Path = null;
                Presets.Preset2Name = "Preset 2";
                Logger.KefkaLog("Reset preset 2.");
            }
        }

        public void Preset2()
        {
            if (File.Exists(Presets.Preset2Path))
            {
                Settings.Load(Presets.Preset2Path);
                Logger.KefkaLog("Loaded preset: {0}", Presets.Preset2Name);
            }
            else
            {
                Logger.KefkaLog("Preset {0} does not exist", Presets.Preset2Name);
            }
        }

        private void Preset3Set()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presets.Preset3Path = openFileDialog.FileName;
                Presets.Preset3Name = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Logger.KefkaLog("Saved preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
            else
            {
                Presets.Preset3Path = null;
                Presets.Preset3Name = "Preset 3";
                Logger.KefkaLog("Reset preset 3.");
            }
        }

        public void Preset3()
        {
            if (File.Exists(Presets.Preset3Path))
            {
                Settings.Load(Presets.Preset3Path);
                Logger.KefkaLog("Loaded preset: {0}", Presets.Preset3Name);
            }
            else
            {
                Logger.KefkaLog("Preset {0} does not exist", Presets.Preset3Name);
            }
        }

        private void Preset4Set()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presets.Preset4Path = openFileDialog.FileName;
                Presets.Preset4Name = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Logger.KefkaLog("Saved preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
            else
            {
                Presets.Preset4Path = null;
                Presets.Preset4Name = "Preset 4";
                Logger.KefkaLog("Reset preset 4.");
            }
        }

        public void Preset4()
        {
            if (File.Exists(Presets.Preset4Path))
            {
                Settings.Load(Presets.Preset4Path);
                Logger.KefkaLog("Loaded preset: {0}", Presets.Preset4Name);
            }
            else
            {
                Logger.KefkaLog("Preset {0} does not exist", Presets.Preset4Name);
            }
        }

        private void Preset5Set()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Select File to set Preset to"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Presets.Preset5Path = openFileDialog.FileName;
                Presets.Preset5Name = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Logger.KefkaLog("Saved preset: {0}", Path.GetFileNameWithoutExtension(openFileDialog.FileName));
            }
            else
            {
                Presets.Preset5Path = null;
                Presets.Preset5Name = "Preset 5";
                Logger.KefkaLog("Reset preset 5.");
            }
        }

        public void Preset5()
        {
            if (File.Exists(Presets.Preset5Path))
            {
                Settings.Load(Presets.Preset5Path);
                Logger.KefkaLog("Loaded preset: {0}", Presets.Preset5Name);
            }
            else
            {
                Logger.KefkaLog("Preset {0} does not exist", Presets.Preset5Name);
            }
        }

        private void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "json files (*.json)|*.json",
                InitialDirectory = initPath,
                Title = @"Save Preset as..."
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Settings.SaveAs(saveFileDialog.FileName);
            }
            Logger.KefkaLog("Settings saved as preset: {0}", Path.GetFileNameWithoutExtension(saveFileDialog.FileName));
        }
    }
}