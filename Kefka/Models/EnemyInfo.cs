using ff14bot.Objects;
using Kefka.Commands;
using System;
using System.Windows.Input;

namespace Kefka.Models
{
    public class EnemyInfo
    {
        public int Aura1TimeLeft
        {
            get;
            set;
        }

        public int Aura2TimeLeft
        {
            get;
            set;
        }

        public int Aura3TimeLeft
        {
            get;
            set;
        }

        public int Aura4TimeLeft
        {
            get;
            set;
        }

        public DateTime CombatStart
        {
            get;
            set;
        }

        public double CurrentDps
        {
            get;
            set;
        }

        public bool CurrentlyTargeting
        {
            get;
            set;
        }

        public float LastTickHealthPct
        {
            get;
            set;
        }

        public bool NeedToTarget
        {
            get;
            set;
        }

        public uint StartHealth
        {
            get;
            set;
        }

        public int TimeToDeath
        {
            get;
            set;
        }

        public MainSettingsModel Settings => MainSettingsModel.Instance;

        public ICommand TargetCommand => new DelegateCommand(Target);

        public BattleCharacter Unit
        {
            get;
            set;
        }

        private void Target()
        {
            NeedToTarget = true;
        }
    }
}