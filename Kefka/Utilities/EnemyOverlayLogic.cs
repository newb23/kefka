using ff14bot;
using ff14bot.Enums;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Utilities
{
    public static class EnemyOverlayLogic
    {
        public static readonly List<EnemyInfo> EnemyOverlayInfos;

        private static List<BattleCharacter> MonitoredEnemies
        {
            get;
            set;
        }

        static EnemyOverlayLogic()
        {
            EnemyOverlayInfos = new List<EnemyInfo>();
            MonitoredEnemies = new List<BattleCharacter>();
        }

        public static void UpdateEnemyInfo()
        {
            ThreadSafeObservableCollection<EnemyInfo> collectionEnemyOverlyInfo;

            if (!Core.Me.InCombat)
            {
                if (EnemyOverlayInfos != null && EnemyOverlayInfos.Count > 0)
                {
                    EnemyOverlayInfos.Clear();
                    collectionEnemyOverlyInfo = new ThreadSafeObservableCollection<EnemyInfo>(EnemyOverlayInfos);
                    EnemyOverlayViewModel.Instance.EnemyInfoCollection = collectionEnemyOverlyInfo;
                }

                return;
            }

            try
            {
                MonitoredEnemies = PartyManager.IsInParty ? (from r in GameObjectManager.GetObjectsOfType<BattleCharacter>()
                                                             where r.TaggerType == 2
                                                             select r).ToList() : GameObjectManager.Attackers.ToList();
            }
            catch (Exception exception)
            {
                Logging.Write(exception);
            }

            foreach (var monitoredEnemy in MonitoredEnemies)
            {
                Aura aura1 = null;
                Aura aura2 = null;
                Aura aura3 = null;
                foreach (var characterAura in monitoredEnemy.CharacterAuras)
                {
                    if (characterAura.CasterId == Core.Me.ObjectId)
                    {
                        switch (Core.Me.CurrentJob)
                        {
                            case ClassJobType.Arcanist:
                            case ClassJobType.Summoner:
                            case ClassJobType.Scholar:
                                switch (characterAura.Id)
                                {
                                    case Auras.Bio:
                                    case Auras.BioIII:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.BioII:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.Miasma:
                                    case Auras.MiasmaIII:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Archer:
                            case ClassJobType.Bard:
                                switch (characterAura.Id)
                                {
                                    case Auras.VenomousBite:
                                    case Auras.CausticBite:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.Windbite:
                                    case Auras.StormBite:
                                        aura2 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Conjurer:
                            case ClassJobType.WhiteMage:
                                switch (characterAura.Id)
                                {
                                    case Auras.Aero:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.AeroII:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.AeroIII:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Gladiator:
                            case ClassJobType.Paladin:
                                switch (characterAura.Id)
                                {
                                    case Auras.GoringBlade:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.StrengthDown:
                                        aura2 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Lancer:
                            case ClassJobType.Dragoon:
                                switch (characterAura.Id)
                                {
                                    case Auras.Phlebotomize:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.Disembowel:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.ChaosThrust:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Marauder:
                            case ClassJobType.Warrior:
                                switch (characterAura.Id)
                                {
                                    case Auras.StormsEye:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.StormsPath:
                                        aura2 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Pugilist:
                            case ClassJobType.Monk:
                                switch (characterAura.Id)
                                {
                                    case Auras.TouchofDeath:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.Demolish:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.DragonKick:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Rogue:
                            case ClassJobType.Ninja:
                                switch (characterAura.Id)
                                {
                                    case Auras.ShadowFang:
                                        aura1 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Thaumaturge:
                            case ClassJobType.BlackMage:
                                switch (characterAura.Id)
                                {
                                    case Auras.Thunder:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.ThunderII:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.ThunderIII:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Machinist:
                                switch (characterAura.Id)
                                {
                                    case Auras.Wildfire:
                                        aura1 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.DarkKnight:
                                switch (characterAura.Id)
                                {
                                    case Auras.Scourge:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.Delirium:
                                        aura2 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Astrologian:
                                switch (characterAura.Id)
                                {
                                    case Auras.Combust:
                                        aura1 = characterAura;
                                        break;

                                    case Auras.CombustII:
                                        aura2 = characterAura;
                                        break;

                                    case Auras.Heavy:
                                        aura3 = characterAura;
                                        break;
                                }
                                break;

                            case ClassJobType.Samurai:
                                switch (characterAura.Id)
                                {
                                    case Auras.Higanbana:
                                        aura1 = characterAura;
                                        break;
                                }
                                break;
                        }
                    }
                }
                if (EnemyOverlayInfos.Any(r => r.Unit == monitoredEnemy))
                {
                    var target = EnemyOverlayInfos.FirstOrDefault(r => r.Unit == monitoredEnemy);
                    if (target != null)
                    {
                        if (target.NeedToTarget)
                        {
                            target.Unit.Target();
                            target.NeedToTarget = false;
                        }
                        target.Aura1TimeLeft = aura1?.TimespanLeft.Seconds ?? 0;
                        target.Aura2TimeLeft = aura2?.TimespanLeft.Seconds ?? 0;
                        target.Aura3TimeLeft = aura3?.TimespanLeft.Seconds ?? 0;
                        if (target.Unit.CurrentHealthPercent > target.LastTickHealthPct + 5)
                        {
                            target.CombatStart = DateTime.Now;
                            target.StartHealth = target.Unit.CurrentHealth;
                        }
                        var startHealth = target.StartHealth - monitoredEnemy.CurrentHealth;
                        var timeSpan = DateTime.Now - target.CombatStart;
                        target.CurrentDps = (int)(startHealth / timeSpan.TotalSeconds);
                        target.LastTickHealthPct = target.Unit.CurrentHealthPercent;
                        target.CurrentlyTargeting = Core.Me.HasTarget && Core.Me.CurrentTarget == monitoredEnemy;

                        if (((100 - target.LastTickHealthPct) / 100) != 0)
                        {
                            var timeSinceStart = DateTime.Now.Subtract(target.CombatStart);
                            var totalTime = TimeSpan.FromSeconds(timeSinceStart.TotalSeconds / ((100 - target.LastTickHealthPct) / 100));
                            var timeLeft = totalTime - timeSinceStart;

                            target.TimeToDeath = (int)timeLeft.TotalSeconds;
                        }
                    }
                }
                else
                {
                    var enemyInfo = new EnemyInfo
                    {
                        Unit = monitoredEnemy,
                        CombatStart = DateTime.Now,
                        StartHealth = monitoredEnemy.CurrentHealth,
                        LastTickHealthPct = monitoredEnemy.CurrentHealth,
                        Aura1TimeLeft = aura1?.TimespanLeft.Seconds ?? 0,
                        Aura2TimeLeft = aura2?.TimespanLeft.Seconds ?? 0,
                        Aura3TimeLeft = aura3?.TimespanLeft.Seconds ?? 0,
                        CurrentlyTargeting = Core.Me.HasTarget && Core.Me.CurrentTarget == monitoredEnemy,
                        TimeToDeath = 0
                    };
                    EnemyOverlayInfos.Add(enemyInfo);
                }
            }

            var removeEnemyArray = (
                from r in EnemyOverlayInfos
                where !MonitoredEnemies.Contains(r.Unit) || r.Unit.IsDead || !r.Unit.IsValid
                select r).ToArray();

            foreach (var enemy in removeEnemyArray)
            {
                EnemyOverlayInfos.Remove(enemy);
            }

            collectionEnemyOverlyInfo = new ThreadSafeObservableCollection<EnemyInfo>(EnemyOverlayInfos);
            EnemyOverlayViewModel.Instance.EnemyInfoCollection = collectionEnemyOverlyInfo;
        }
    }
}