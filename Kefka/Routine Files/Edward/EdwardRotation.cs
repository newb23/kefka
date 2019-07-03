using System;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using System.Threading.Tasks;

namespace Kefka.Routine_Files.Edward
{
    public partial class EdwardRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent < MainSettingsModel.Instance.RestTpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.EdwardLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            return await Peloton();
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (EdwardSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (Me.ClassLevel == 1 || Me.HasAura(Auras.StraightShot, true, 6000))
                return await Spells.HeavyShot.Use(Target, true);

            return await Spells.StraightShot.CastBuff(Target, true, Auras.StraightShot);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await SecondWind()) return true;
            if (CombatHelper.GcdTimeRemaining < 300) return false;
            if (await Palisade()) return true;
            return await NaturesMinne();
        }

        public static async Task<bool> CombatBuff()
        {
            if (EdwardSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await Sing()) return true;
            if (await FoeRequiem()) return true;
            if (await DpsPotion()) return true;
            if (await RagingStrikes()) return true;
            if (await Barrage()) return true;
            if (await Invigorate()) return true;
            if (await Tactician()) return true;
            if (await Refresh()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await RoD_BL()) return true;
            if (await BluntArrow()) return true;
            if (CombatHelper.GcdTimeRemaining < 300) return false;

            if (await PitchPerfect()) return true;
            //if (await Paean()) return true;
            if (await MiserysEnd()) return true;
            if (await RepellingShot()) return true;
            if (await Sidewinder()) return true;
            return await EmpyrealArrow();
        }

        public static async Task<bool> Combat()
        {
            if (CombatHelper.LastSpell == Spells.Barrage && Me.ClassLevel >= Spells.EmpyrealArrow.LevelAcquired)
            {
                if (await RefulgentArrow()) return true;
                return await EmpyrealArrow();
            }

            if (await MultiDoT()) return true;
            if (await DotSnapshot()) return true;
            if (EdwardSettingsModel.Instance.UseAoEBeforeDoTs)
                if (await AoE()) return true;
            if (await RefulgentArrow()) return true;
            if (await StraightShot()) return true;
            if (await Windbite()) return true;
            if (await VenomousBite()) return true;
            if (await AoE()) return true;
            return await HeavyShot();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.TheWanderersMinuet.Use(Target, true)) return true;

            if (await PvPSpells.ArmysPaeon.Use(Target, true)) return true;

            if (await PvPSpells.BluntArrow.Use(Target, !EdwardSettingsModel.Instance.PvPManualBluntArrow)) return true;
            
            if (await PvPSpells.Barrage.Use(Me, ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.ArmysPaeon && Me.CurrentTP > 250))
                return await PvPSpells.EmpyrealArrow.Use(Target, true);
            
            if (await PvPSpells.PitchPerfect.Use(Target, ActionResourceManager.Bard.ActiveSong == ActionResourceManager.Bard.BardSong.WanderersMinuet && (ActionResourceManager.Bard.Repertoire == 3) || ActionResourceManager.Bard.Timer.TotalMilliseconds < 3000)) return true;

            if (await PvPSpells.EmpyrealArrow.Use(Target, Me.CurrentTP > 250)) return true;

            if (await PvPSpells.Bloodletter.Use(Target, true)) return true;

            if (await PvPSpells.Sidewinder.Use(Target, Target.HasAura(PvPAuras.CausticBite) && Target.HasAura(PvPAuras.StormBite))) return true;

            if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
            _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

            if ((!Target.HasAura(PvPAuras.CausticBite) || !Target.HasAura(PvPAuras.StormBite)))
                if (ActionManager.DoPvPCombo(PvPCombos.StormbiteCombo, Target))
                {
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(1700);
                    return true;
                }

            if (ActionManager.DoPvPCombo(PvPCombos.StraightShotCombo, Target))
            {
                _pvpComboTimer = DateTime.Now.AddMilliseconds(1700);
                return true;
            }
            return false;
        }
    }
}