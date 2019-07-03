using System;
using ff14bot.Enums;
using static Kefka.Utilities.Constants;
using Kefka.Models;

namespace Kefka.Utilities
{
    internal class HotkeyManager
    {
        #region Class Handlers

        public static void RegisterHotkeys()
        {
            try
            {
                MainHotkeysModel.Instance.RegisterAll();

                switch (Me.CurrentJob)
                {
                    case ClassJobType.Gladiator:
                    case ClassJobType.Paladin:
                        BeatrixHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Marauder:
                    case ClassJobType.Warrior:
                        PaineHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Archer:
                    case ClassJobType.Bard:
                        EdwardHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Thaumaturge:
                    case ClassJobType.BlackMage:
                        ViviHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Pugilist:
                    case ClassJobType.Monk:
                        SabinHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Lancer:
                    case ClassJobType.Dragoon:
                        FreyaHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Conjurer:
                    case ClassJobType.WhiteMage:
                        MikotoHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Arcanist:
                    case ClassJobType.Summoner:
                        EikoHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Scholar:
                        SuritoHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Rogue:
                    case ClassJobType.Ninja:
                        ShadowHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Machinist:
                        BarretHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.DarkKnight:
                        CecilHotkeysModel.Instance.RegisterAll();
                        break;

                    case ClassJobType.Astrologian:
                        RemielHotkeysModel.Instance.RegisterAll();
                        return;

                    case ClassJobType.RedMage:
                        ElayneHotkeysModel.Instance.RegisterAll();
                        return;

                    case ClassJobType.Samurai:
                        CyanHotkeysModel.Instance.RegisterAll();
                        return;

                    case ClassJobType.Adventurer:
                    case ClassJobType.Carpenter:
                    case ClassJobType.Blacksmith:
                    case ClassJobType.Armorer:
                    case ClassJobType.Goldsmith:
                    case ClassJobType.Leatherworker:
                    case ClassJobType.Weaver:
                    case ClassJobType.Alchemist:
                    case ClassJobType.Culinarian:
                    case ClassJobType.Miner:
                    case ClassJobType.Botanist:
                    case ClassJobType.Fisher:
                        UnregisterAllHotkeys();
                        return;

                    default:
                        UnregisterAllHotkeys();
                        return;
                }
            }
            catch (Exception e)
            {
                Logger.KefkaLog(e.ToString());
            }
        }

        public static void UnregisterAllHotkeys()
        {
            try
            {
                BarretHotkeysModel.Instance.UnregisterAll();
                BeatrixHotkeysModel.Instance.UnregisterAll();
                CecilHotkeysModel.Instance.UnregisterAll();
                CyanHotkeysModel.Instance.UnregisterAll();
                EdwardHotkeysModel.Instance.UnregisterAll();
                EikoHotkeysModel.Instance.UnregisterAll();
                ElayneHotkeysModel.Instance.UnregisterAll();
                FreyaHotkeysModel.Instance.UnregisterAll();
                MikotoHotkeysModel.Instance.UnregisterAll();
                PaineHotkeysModel.Instance.UnregisterAll();
                RemielHotkeysModel.Instance.UnregisterAll();
                SabinHotkeysModel.Instance.UnregisterAll();
                ShadowHotkeysModel.Instance.UnregisterAll();
                SuritoHotkeysModel.Instance.UnregisterAll();
                ViviHotkeysModel.Instance.UnregisterAll();
                MainHotkeysModel.Instance.UnregisterAll();
            }
            catch (Exception e)
            {
                Logger.KefkaLog(e.ToString());
            }
        }

        #endregion Class Handlers
    }
}