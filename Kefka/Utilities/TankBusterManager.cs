using System.Collections.Generic;
using Kefka.ViewModels;

namespace Kefka.Utilities
{
    public static class TankBusterManager
    {
        public static HashSet<uint> Awareness = new HashSet<uint>();
        public static HashSet<uint> Bulwark = new HashSet<uint>();
        public static HashSet<uint> Convalescence = new HashSet<uint>();
        public static HashSet<uint> DivineVeil = new HashSet<uint>();
        public static HashSet<uint> Foresight = new HashSet<uint>();
        public static HashSet<uint> HallowedGround = new HashSet<uint>();
        public static HashSet<uint> Rampart = new HashSet<uint>();
        public static HashSet<uint> Sentinel = new HashSet<uint>();
        public static HashSet<uint> Sheltron = new HashSet<uint>();

        public static HashSet<uint> ThrillofBattle = new HashSet<uint>();
        public static HashSet<uint> Holmgang = new HashSet<uint>();
        public static HashSet<uint> Vengeance = new HashSet<uint>();
        public static HashSet<uint> Equilibrium = new HashSet<uint>();
        public static HashSet<uint> RawIntuition = new HashSet<uint>();
        public static HashSet<uint> Anticipation = new HashSet<uint>();
        public static HashSet<uint> Reprisal = new HashSet<uint>();

        public static HashSet<uint> ShadowWall = new HashSet<uint>();
        public static HashSet<uint> DarkMind = new HashSet<uint>();
        public static HashSet<uint> BlackestNight = new HashSet<uint>();
        public static HashSet<uint> LivingDead = new HashSet<uint>();

        public static HashSet<uint> Palisade = new HashSet<uint>();

        public static void ResetTankBusters()
        {
            var awareness = new HashSet<uint>();
            var bulwark = new HashSet<uint>();
            var convalescence = new HashSet<uint>();
            var divineVeil = new HashSet<uint>();
            var foresight = new HashSet<uint>();
            var hallowGround = new HashSet<uint>();
            var rampart = new HashSet<uint>();
            var sentinel = new HashSet<uint>();
            var sheltron = new HashSet<uint>();

            var thrillOfBattle = new HashSet<uint>();
            var holmgang = new HashSet<uint>();
            var vengeance = new HashSet<uint>();
            var equilibrium = new HashSet<uint>();
            var rawIntuition = new HashSet<uint>();
            var anticipation = new HashSet<uint>();
            var reprisal = new HashSet<uint>();

            var shadowWall = new HashSet<uint>();
            var darkMind = new HashSet<uint>();
            var blackestNight = new HashSet<uint>();
            var livingDead = new HashSet<uint>();

            var palisade = new HashSet<uint>();

            foreach (var tankBuster in TankBustersViewModel.Instance.GuiTankBustersList)
            {
                var id = tankBuster.SpellId;

                if (tankBuster.Awareness)
                    awareness.Add(id);

                if (tankBuster.Bulwark)
                    bulwark.Add(id);

                if (tankBuster.Convalescence)
                    convalescence.Add(id);

                if (tankBuster.DivineVeil)
                    divineVeil.Add(id);

                if (tankBuster.Foresight)
                    foresight.Add(id);

                if (tankBuster.HallowedGround)
                    hallowGround.Add(id);

                if (tankBuster.Rampart)
                    rampart.Add(id);

                if (tankBuster.Sentinel)
                    sentinel.Add(id);

                if (tankBuster.Sheltron)
                    sheltron.Add(id);

                if (tankBuster.ThrillofBattle)
                    thrillOfBattle.Add(id);

                if (tankBuster.Holmgang)
                    holmgang.Add(id);

                if (tankBuster.Vengeance)
                    vengeance.Add(id);

                if (tankBuster.RawIntuition)
                    rawIntuition.Add(id);

                if (tankBuster.Equilibrium)
                    equilibrium.Add(id);

                if (tankBuster.Anticipation)
                    anticipation.Add(id);

                if (tankBuster.Anticipation)
                    reprisal.Add(id);

                if (tankBuster.ShadowWall)
                    shadowWall.Add(id);

                if (tankBuster.DarkMind)
                    darkMind.Add(id);

                if (tankBuster.BlackestNight)
                    darkMind.Add(id);

                if (tankBuster.LivingDead)
                    livingDead.Add(id);

                if (tankBuster.Palisade)
                    palisade.Add(id);
            }

            Awareness = awareness;
            Bulwark = bulwark;
            Convalescence = convalescence;
            DivineVeil = divineVeil;
            Foresight = foresight;
            HallowedGround = hallowGround;
            Rampart = rampart;
            Sentinel = sentinel;
            Sheltron = sheltron;

            ThrillofBattle = thrillOfBattle;
            Holmgang = holmgang;
            Vengeance = vengeance;
            Equilibrium = equilibrium;
            RawIntuition = rawIntuition;
            Anticipation = anticipation;
            Reprisal = reprisal;

            ShadowWall = shadowWall;
            DarkMind = darkMind;
            BlackestNight = blackestNight;
            LivingDead = livingDead;

            Palisade = palisade;
        }
    }
}