using System.Collections.Generic;
using Kefka.ViewModels;

namespace Kefka.Utilities
{
    public static class HealBusterManager
    {
        public static HashSet<uint> CureII = new HashSet<uint>();
        public static HashSet<uint> Benediction = new HashSet<uint>();
        public static HashSet<uint> Tetragrammaton = new HashSet<uint>();
        public static HashSet<uint> DivineBenison = new HashSet<uint>();
        public static HashSet<uint> Medica = new HashSet<uint>();
        public static HashSet<uint> MedicaII = new HashSet<uint>();
        public static HashSet<uint> PlenaryIndulgence = new HashSet<uint>();
        public static HashSet<uint> Asylum = new HashSet<uint>();
        public static HashSet<uint> Adloquium = new HashSet<uint>();

        public static HashSet<uint> Excogitation = new HashSet<uint>();
        public static HashSet<uint> Aetherpact = new HashSet<uint>();
        public static HashSet<uint> Succor = new HashSet<uint>();
        public static HashSet<uint> SacredSoil = new HashSet<uint>();
        public static HashSet<uint> Lustrate = new HashSet<uint>();
        public static HashSet<uint> Rouse = new HashSet<uint>();

        public static HashSet<uint> AspectedBenefic = new HashSet<uint>();
        public static HashSet<uint> EssentialDignity = new HashSet<uint>();
        public static HashSet<uint> AspectedHelios = new HashSet<uint>();
        public static HashSet<uint> CollectiveUnconscious = new HashSet<uint>();

        public static HashSet<uint> BeneficII = new HashSet<uint>();

        public static void ResetHealBusters()
        {
            var cureII = new HashSet<uint>();
            var benediction = new HashSet<uint>();
            var tetragrammaton = new HashSet<uint>();
            var divineBenison = new HashSet<uint>();
            var medica = new HashSet<uint>();
            var medicaII = new HashSet<uint>();
            var plenaryIndulgence = new HashSet<uint>();
            var asylum = new HashSet<uint>();
            var adloquium = new HashSet<uint>();

            var excogitation = new HashSet<uint>();
            var aetherpact = new HashSet<uint>();
            var succor = new HashSet<uint>();
            var sacredSoil = new HashSet<uint>();
            var lustrate = new HashSet<uint>();
            var rouse = new HashSet<uint>();

            var aspectedBenefic = new HashSet<uint>();
            var essentialDignity = new HashSet<uint>();
            var aspectedHelios = new HashSet<uint>();
            var collectiveUnconscious = new HashSet<uint>();

            var beneficII = new HashSet<uint>();

            foreach (var HealBuster in HealBustersViewModel.Instance.GuiHealBustersList)
            {
                var id = HealBuster.SpellId;

                if (HealBuster.CureII)
                    cureII.Add(id);

                if (HealBuster.Benediction)
                    benediction.Add(id);

                if (HealBuster.Tetragrammaton)
                    tetragrammaton.Add(id);

                if (HealBuster.DivineBenison)
                    divineBenison.Add(id);

                if (HealBuster.Medica)
                    medica.Add(id);

                if (HealBuster.MedicaII)
                    medicaII.Add(id);

                if (HealBuster.PlenaryIndulgence)
                    plenaryIndulgence.Add(id);

                if (HealBuster.Asylum)
                    asylum.Add(id);

                if (HealBuster.Adloquium)
                    adloquium.Add(id);

                if (HealBuster.Excogitation)
                    excogitation.Add(id);

                if (HealBuster.Aetherpact)
                    aetherpact.Add(id);

                if (HealBuster.Succor)
                    succor.Add(id);

                if (HealBuster.SacredSoil)
                    sacredSoil.Add(id);

                if (HealBuster.Lustrate)
                    lustrate.Add(id);

                if (HealBuster.Rouse)
                    rouse.Add(id);

                if (HealBuster.AspectedBenefic)
                    aspectedBenefic.Add(id);

                if (HealBuster.EssentialDignity)
                    essentialDignity.Add(id);

                if (HealBuster.AspectedHelios)
                    essentialDignity.Add(id);

                if (HealBuster.CollectiveUnconscious)
                    collectiveUnconscious.Add(id);

                if (HealBuster.BeneficII)
                    beneficII.Add(id);
            }

            CureII = cureII;
            Benediction = benediction;
            Tetragrammaton = tetragrammaton;
            DivineBenison = divineBenison;
            Medica = medica;
            MedicaII = medicaII;
            PlenaryIndulgence = plenaryIndulgence;
            Asylum = asylum;

            Adloquium = adloquium;
            Excogitation = excogitation;
            Aetherpact = aetherpact;
            Succor = succor;
            SacredSoil = sacredSoil;
            Lustrate = lustrate;
            Rouse = rouse;

            AspectedBenefic = aspectedBenefic;
            EssentialDignity = essentialDignity;
            AspectedHelios = aspectedHelios;
            CollectiveUnconscious = collectiveUnconscious;
            BeneficII = beneficII;
        }
    }
}