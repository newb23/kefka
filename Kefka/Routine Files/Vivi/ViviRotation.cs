using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using static Kefka.Utilities.Constants;
using System.Threading.Tasks;

namespace Kefka.Routine_Files.Vivi
{
    public static partial class ViviRotation
    {
        public static async Task<bool> Rest()
        {
            await Heal();
            if (!WorldManager.InSanctuary && !Me.HasAura(Auras.Sprint) && BotManager.Current.IsAutonomous)
            {
                if (Me.CurrentHealthPercent < MainSettingsModel.Instance.RestHpPct)
                {
                    if (MovementManager.IsMoving)
                    {
                        Navigator.PlayerMover.MoveStop();
                    }
                    Logger.ViviLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            if (EnochianActive && StackTimer < 3000)
            {
                return await Spells.Transpose.Use(Me, true);
            }

            return await Transpose();
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (ViviSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (Me.ClassLevel >= 40)
            {
                await Spells.BlizzardIII.Use(Target, true);
                return await Spells.BlizzardIV.Use(Target, true);
            }

            if (Me.ClassLevel >= 34)
                return await Spells.FireIII.Use(Target, true);

            if (Me.ClassLevel >= 2)
                return await Spells.Fire.Use(Target, true);

            return await Spells.Blizzard.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            return await Drain();
        }

        public static async Task<bool> CombatBuff()
        {
            if (ViviSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (await DpsPotion()) return true;
            if (await Enochian()) return true;
            if (await LeyLines()) return true;
            if (await Triplecast()) return true;
            if (await Manaward()) return true;
            if (await Swiftcast()) return true;
            if (await Sharpcast()) return true;
            if (await Convert()) return true;
            if (await Diversion()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            return false;
        }

        public static async Task<bool> Combat()
        {
            if (ViviSettingsModel.Instance.UseAoE && Target?.EnemiesInRange(8) >= ViviSettingsModel.Instance.MobCount)
            { return await AoERotation(); }

            if (await Drain()) return true;
            if (await Scathe()) return true;
            if (await Foul()) return true;
            if (await Transpose()) return true;

            if (await BlizzardIII()) return true;
            if (ActionManager.LastSpell == Spells.BlizzardIII || CombatHelper.LastSpell == Spells.BlizzardIII)
            {
                await Coroutine.Wait(ViviSettingsModel.Instance.MpTickMaxDelay, () => Me.CurrentManaPercent >= ViviSettingsModel.Instance.MpMinPct);
            }

            if (await Thunder()) return true;

            if (await BlizzardIV()) return true;
            if (ActionManager.LastSpell == Spells.BlizzardIV || CombatHelper.LastSpell == Spells.BlizzardIV)
            {
                await Coroutine.Wait(ViviSettingsModel.Instance.MpTickMaxDelay, () => Me.CurrentManaPercent >= ViviSettingsModel.Instance.MpMinPct);
            }

            if (await FireIII()) return true;
            if (await FireIV()) return true;
            if (await Fire()) return true;
            return await Blizzard();
        }

        public static async Task<bool> PVPRotation()

        {
            return false;
        }
    }
}