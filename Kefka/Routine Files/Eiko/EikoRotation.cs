using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Managers;
using ff14bot.Navigation;
using ff14bot.Objects;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using static Kefka.Utilities.Constants;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Eiko
{
    public static partial class EikoRotation
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
                    Logger.EikoLog(@"Taking a quick breather...");
                    await Coroutine.Wait(5000, () => Me.CurrentHealthPercent >= MainSettingsModel.Instance.RestHpPct || Me.CurrentManaPercent >= MainSettingsModel.Instance.RestMpPct || Me.InCombat);
                    return true;
                }
            }
            return false;
        }

        public static async Task<bool> PreCombat()
        {
            {
                if (await Spells.Aetherflow.Use(Me, EikoSettingsModel.Instance.UseAetherflow && AetherflowStacks == 0 && AetherialStacks == 0)) return true;
                if (await Summon()) return true;
                return await Heel();
            }
        }

        public static async Task<bool> Pull()
        {
            if (Target == null || !Target.CanAttack)
                return false;

            if (EikoSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }

            if (Me.Pet != null && PetManager.PetMode != PetMode.Obey)
                PetManager.DoAction(Spells.Obey.LocalizedName, Target);

            if (Me.ClassLevel >= 26)
            {
                return await Spells.BioII.CastDot(Target, EikoSettingsModel.Instance.UseDoTs);
            }

            if (Me.ClassLevel >= 38)
            {
                return await Spells.RuinII.Use(Target, true);
            }

            return await Spells.Ruin.Use(Target, true);
        }

        public static async Task<bool> Heal()
        {
            if (await Common_Utils.HpPotion()) return true;
            if (await Drain()) return true;
            if (await Resurrection()) return true;
            if (await Sustain()) return true;
            return await Physick();
        }

        public static async Task<bool> CombatBuff()
        {
            if (EikoSettingsModel.Instance.UseOpener)
            {
                return await Common_Utils.Opener();
            }
            if (await DpsPotion()) return true;
            if (await Aetherflow()) return true;
            if (await Summon()) return true;
            if (await LucidDreaming()) return true;
            if (await ManaShift()) return true;
            return await OffGcd();
        }

        private static async Task<bool> OffGcd()
        {
            if (await SummonBahamut()) return true;
            if (await EnkindleBahamut()) return true;
            if (await PetActions()) return true;
            return await Heel();
        }

        public static async Task<bool> Combat()
        {
            var auraCount = (Target as BattleCharacter)?.CharacterAuras.Count();

            if (await Summon()) return true;
            if (await Shadowflare()) return true;
            if (await DreadwyrmTrance()) return true;
            if (await Fester()) return true;
            if (await Bane()) return true;
            if (await Painflare()) return true;
            if (await Aetherflow()) return true;
            if (await Deathflare()) return true;
            if (await EnergyDrain()) return true;

            if (auraCount < 30)
            {
                if (await Tridisaster_SingleTarget()) return true;
                if (await Tridisaster_AoE()) return true;
                if (await Bio()) return true;
                if (await Miasma()) return true;
            }

            if (await RuinIV()) return true;
            if (await RuinII()) return true;
            //if (await RuinIII()) return true;
            return await Ruin();
        }

        public static async Task<bool> PVPRotation()
        {
            return false;
        }
    }
}