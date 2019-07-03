using System.Linq;
using System.Windows;
using System.Windows.Input;
using Kefka.Commands;
using Kefka.Models;
using Kefka.Utilities;

namespace Kefka.ViewModels
{
    internal class SpellLogViewModel : BaseViewModel
    {
        private static SpellLogViewModel _instance;
        public static SpellLogViewModel Instance => _instance ?? (_instance = new SpellLogViewModel());
        public ICommand TransferSpellToInterruptsCommand => new DelegateCommand<SpellInfo>(TransferSpellToInterrupts);
        public ICommand TransferSpellToTankbustersCommand => new DelegateCommand<SpellInfo>(TransferSpellToTankbusters);

        private static ThreadSafeObservableCollection<SpellInfo> spellLogCollection;

        public ThreadSafeObservableCollection<SpellInfo> SpellLogCollection
        {
            get
            {
                return spellLogCollection ?? (spellLogCollection = new ThreadSafeObservableCollection<SpellInfo>());
            }
            set
            {
                spellLogCollection = value;
                OnPropertyChanged();
            }
        }

        public void LogSpell(string npcName, uint npcId, string spellName, uint spellId)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if (spellLogCollection.Count > 300)
                {
                    spellLogCollection.RemoveAt(0);
                }
                spellLogCollection.Add(new SpellInfo
                {
                    NpcName = npcName,
                    NpcId = npcId,
                    SpellName = spellName,
                    SpellId = spellId
                });
            });
        }

        private void TransferSpellToInterrupts(SpellInfo spell)
        {
            if (spell == null)
                return;

            if (InterruptViewModel.Instance.GuiInterruptsList.Any(r => r.SpellId == spell.SpellId))
                return;

            Logger.KefkaLog(@"Adding {0} to the Interrupt List.", spell.SpellName);

            var newSpell = new SpellInfo { CanStun = true, CanSilence = false, SpellId = spell.SpellId, SpellName = spell.SpellName };

            InterruptViewModel.Instance.GuiInterruptsList.Add(newSpell);
            InterruptViewModel.Instance.Save();
        }

        private void TransferSpellToTankbusters(SpellInfo spell)

        {
            if (spell == null)
                return;

            if (TankBustersViewModel.Instance.GuiTankBustersList.Any(r => r.SpellId == spell.SpellId))
                return;

            Logger.KefkaLog(@"Adding {0} to the Tankbuster List.", spell.SpellName);

            var newSpell = new TankBuster
            {
                SpellName = spell.SpellName,
                SpellId = spell.SpellId,
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
                ShadowWall = false,
                DarkMind = false,
                LivingDead = false
            };

            TankBustersViewModel.Instance.GuiTankBustersList.Add(newSpell);
            TankBustersViewModel.Instance.Save();
        }

        private void TransferSpellToCleanses(SpellInfo spell)

        {
            if (spell == null)
                return;

            if (CleansesViewModel.Instance.GuiCleansesList.Any(r => r.SpellId == spell.SpellId))
                return;

            Logger.KefkaLog(@"Adding {0} to the Cleanse List.", spell.SpellName);

            var newSpell = new Cleanse
            {
                SpellName = spell.SpellName,
                SpellId = spell.SpellId,
                Leeches = false,
                Esuna = false,
                ExaltedDetriment = false
            };

            CleansesViewModel.Instance.GuiCleansesList.Add(newSpell);
            CleansesViewModel.Instance.Save();
        }
    }
}