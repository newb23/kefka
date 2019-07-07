using System;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using static ff14bot.Managers.ActionResourceManager.Samurai;
using static ff14bot.Managers.ActionResourceManager.Samurai.Iaijutsu;

namespace Kefka.Routine_Files.Cyan
{
    public static partial class CyanRotation
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
                    Logger.CyanLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentTPPercent >= MainSettingsModel.Instance.RestTpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            return false;
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (CyanSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await Enpi()) return true;
            if (await HissatsuGyoten()) return true;
            return await Hakaze();
        }

        public static async Task<bool> Heal()
        {
            if (await MercifulEyes()) return true;
            if (await Common_Utils.HpPotion()) return true;
            if (await SecondWind()) return true;
            return await Bloodbath();
        }

        public static async Task<bool> CombatBuff()
        {
            if (CyanSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await ManualMeditation()) return true;

            if (!CombatHelper.OnGcd || CombatHelper.GcdTimeRemaining < 1200) return false;

            if (await DpsPotion()) return true;
            if (await MeikyoShisui()) return true;
            if (await Hagakure()) return true;
            if (await HissatsuGuren()) return true;
            if (await Invigorate()) return true;
            if (await Common_Utils.Goad()) return true;
            if (await Feint()) return true;

            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await Interrupt()) return true;

            if (!CombatHelper.OnGcd || CombatHelper.GcdTimeRemaining < 1200) return false;

            if (await HissatsuSeigan()) return true;
            if (await HissatsuGuren()) return true;
            if (await HissatsuShinten()) return true;
            if (await HissatsuGyoten()) return true;
            if (await MeikyoShisui()) return true;
            return await Ageha();
        }

        public static async Task<bool> Combat()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (ActionManager.LastSpell != Spells.Iaijutsu || CombatHelper.LastSpell != Spells.Iaijutsu || Me.HasAura(Auras.Kaiten))
            {
                while (CyanSettingsModel.Instance.UseIaijutsu && MovementManager.IsMoving && SenCount() != 2 && ActionManager.CanCast(Spells.Iaijutsu, Target) && (ActionManager.LastSpell == Spells.HissatsuKaiten || CombatHelper.LastSpell == Spells.HissatsuKaiten || Me.HasAura(Auras.Kaiten)))
                {
                    return await Spells.Iaijutsu.Use(Target, true);
                }

                if (CyanSettingsModel.Instance.UseIaijutsu && SenCount() != 2 && ActionManager.CanCast(Spells.Iaijutsu, Target) && (ActionManager.LastSpell == Spells.HissatsuKaiten || CombatHelper.LastSpell == Spells.HissatsuKaiten || Me.HasAura(Auras.Kaiten)))
                {
                    return await Spells.Iaijutsu.Use(Target, true);
                }
            }

            if (CyanSettingsModel.Instance.UseAoE
                && Me.HasAura(Auras.Jinpu, true, 5000)
                && ActionManager.LastSpell != Spells.Jinpu
                && CombatHelper.LastSpell != Spells.Jinpu
                && Target.EnemiesInRange(8) >= CyanSettingsModel.Instance.MobCount
                && Me.CurrentTP > CyanSettingsModel.Instance.TpLimit)
            {
                if (CyanSettingsModel.Instance.UseIaijutsu && ActionManager.CanCast(Spells.Iaijutsu, Target) && (ActionManager.LastSpell == Spells.HissatsuKaiten || CombatHelper.LastSpell == Spells.HissatsuKaiten || Me.HasAura(Auras.Kaiten)))
                {
                    return await Spells.Iaijutsu.Use(Target, true);
                }
                if (await HissatsuGuren()) return true;
                if (await TenkaGoken()) return true;
                if (await HissatsuKyuten()) return true;
                if (await Oka()) return true;
                if (await Mangetsu()) return true;
                return await Fuga();
            }

            if (await HissatsuGuren()) return true;
            if (await MidareSetsugekka()) return true;
            if (await Higanbana()) return true;
            if (await ComboFinisher()) return true;
            if (await ComboSkill()) return true;
            return await Hakaze();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.MidareSetsugekka.Use(Target, true)) return true;
            if (await PvPSpells.HissatsuShinten.Use(Target, true)) return true;
            Logger.KefkaLog(ActionManager.ComboTimeLeft.ToString());
            if (await PvPSpells.MeikyoShisui.Use(Me, SenCount() < 3 && !Me.HasAura(PvPAuras.MeikyoShisui)
                && ActionManager.GetPvPComboCurrentAction(PvPCombos.YukikazeCombo) == PvPSpells.Hakaze
                && ActionManager.GetPvPComboCurrentAction(PvPCombos.GekkoCombo) == PvPSpells.Jinpu
                && ActionManager.GetPvPComboCurrentAction(PvPCombos.KashaCombo) == PvPSpells.Shifu)) return true;

            if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
            _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

            if (!Sen.HasFlag(Setsu))
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.YukikazeCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.YukikazeCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(2000);
                    return true;
                }
            }

            if (!Sen.HasFlag(Getsu) && Sen.HasFlag(Setsu))
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.GekkoCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.GekkoCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(2000);
                    return true;
                }
            }

            if (!Sen.HasFlag(Ka) && Sen.HasFlag(Getsu))
            {
                var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.KashaCombo);
                if (ActionManager.DoPvPCombo(PvPCombos.KashaCombo, Target))
                {
                    CombatHelper.LastSpell = tempCombatHelperLastSpell;
                    Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                    _pvpComboTimer = DateTime.Now.AddMilliseconds(2000);
                    return true;
                }
            }

            return false;
        }
    }
}