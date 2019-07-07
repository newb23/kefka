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

namespace Kefka.Routine_Files.Elayne
{
    public static partial class ElayneRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent < MainSettingsModel.Instance.RestMpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.ElayneLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            {
                return await Pull();
            }
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (ElayneSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (Me.HasAura(Auras.VerstoneReady))
                return await Spells.Verstone.Use(Target, true);

            if (Me.HasAura(Auras.VerfireReady))
                return await Spells.Verfire.Use(Target, true);

            if (Me.HasAura(Auras.Dualcast))
            {
                await Veraero();
                return await Verthunder();
            }

            if (ElayneSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(8) >= ElayneSettingsModel.Instance.MobCount)
            {
                return await Spells.Scatter.Use(Target, true);
            }

            if (Me.ClassLevel < 2)
            {
                return await Spells.Riposte.Use(Target, true);
            }

            return await Spells.Jolt.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await Verraise()) return true;
            if (await Vercure()) return true;
            return await Drain();
        }

        public static async Task<bool> CombatBuff()
        {
            if (ElayneSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await Embolden()) return true;

            if (CombatHelper.GcdTimeRemaining < 1500) return false;

            if (await DpsPotion()) return true;
            if (await Acceleration()) return true;
            if (await Manafication()) return true;
            if (await LucidDreaming()) return true;
            if (await Diversion()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (CombatHelper.GcdTimeRemaining < 1500) return false;

            if (await ContreSixte()) return true;
            return await Fleche();
        }

        public static async Task<bool> Combat()
        {
            if (await Displacement()) return true;

            if (ElayneSettingsModel.Instance.UseAoE)
            {
                if (await CorpsaCorpsAoE()) return true;
                if (await Moulinet()) return true;
                if (await Scatter()) return true;
            }

            if (await CorpsaCorps()) return true;
            if (await Redoublement()) return true;
            if (await Zwerchhau()) return true;
            if (await Riposte()) return true;

            if (await Verholy()) return true;
            if (await Verflare()) return true;
            if (await Verstone()) return true;
            if (await Verfire()) return true;
            if (await Veraero()) return true;
            if (await Verthunder()) return true;
            if (await Impact()) return true;
            return await Jolt();
        }

        private static DateTime _pvpComboTimer, _pvpLimiterTimer;

        public static async Task<bool> PVPRotation()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (await PvPSpells.Monomachy.Use(Target, ActionResourceManager.RedMage.WhiteMana > 75 && ActionResourceManager.RedMage.BlackMana > 75)) return true;
            if (await PvPSpells.Corpsacorps.Use(Target, ActionResourceManager.RedMage.WhiteMana > 75 && ActionResourceManager.RedMage.BlackMana > 75)) return true;
            if (await PvPSpells.Displacement.Use(Target, CombatHelper.LastSpell == PvPSpells.EnchantedRedoublement && Me.TargetDistance(5, false))) return true;
            if (await PvPSpells.Verholy.Use(Target, true)) return true;

            if (Me.TargetDistance(5, false))
            {
                if (DateTime.Now < _pvpComboTimer || DateTime.Now < _pvpLimiterTimer) return false;
                _pvpLimiterTimer = DateTime.Now.AddMilliseconds(500);

                if (ActionResourceManager.RedMage.WhiteMana > 75 && ActionResourceManager.RedMage.BlackMana > 75
                      || ActionManager.GetPvPComboCurrentAction(PvPCombos.EnchantedRedoublementCombo) == PvPSpells.EnchantedZwerchhau
                      || ActionManager.GetPvPComboCurrentAction(PvPCombos.EnchantedRedoublementCombo) == PvPSpells.EnchantedRedoublement)
                {
                    var tempCombatHelperLastSpell = ActionManager.GetPvPComboCurrentAction(PvPCombos.EnchantedRedoublementCombo);
                    if (ActionManager.DoPvPCombo(PvPCombos.EnchantedRedoublementCombo, Target))
                    {
                        CombatHelper.LastSpell = tempCombatHelperLastSpell;
                        Logger.CastMessage(tempCombatHelperLastSpell.LocalizedName, Target.SafeName());
                        _pvpComboTimer = DateTime.Now.AddMilliseconds(1200);
                        return true;
                    }
                }
            }

            if (await PvPSpells.Impact.Use(Target, Me.CurrentManaPercent > 30)) return true;
            if (await PvPSpells.Veraero.Use(Target, ActionResourceManager.RedMage.WhiteMana < ActionResourceManager.RedMage.BlackMana)) return true;
            if (await PvPSpells.Verthunder.Use(Target, true)) return true;
            if (await PvPSpells.JoltII.Use(Target, !Me.HasAura(Auras.Dualcast) && Me.CurrentManaPercent > 30)) return true;
            if (await PvPSpells.Verstone.Use(Target, !Me.HasAura(Auras.Dualcast) && ActionResourceManager.RedMage.WhiteMana < ActionResourceManager.RedMage.BlackMana)) return true;
            return await PvPSpells.Verfire.Use(Target, !Me.HasAura(Auras.Dualcast));
        }
    }
}