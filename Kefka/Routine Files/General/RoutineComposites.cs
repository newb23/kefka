using System;
using System.Linq;
using Kefka.Models;
using Kefka.Routine_Files.Barret;
using Kefka.Routine_Files.Beatrix;
using Kefka.Routine_Files.Cecil;
using Kefka.Routine_Files.Cyan;
using Kefka.Routine_Files.Edward;
using Kefka.Routine_Files.Eiko;
using Kefka.Routine_Files.Elayne;
using Kefka.Routine_Files.Freya;
using Kefka.Routine_Files.General;
using Kefka.Routine_Files.Paine;
using Kefka.Routine_Files.Remiel;
using Kefka.Routine_Files.Sabin;
using Kefka.Routine_Files.Shadow;
using Kefka.Routine_Files.Vivi;
using Kefka.Utilities;
using System.Threading.Tasks;
using Buddy.Coroutines;
using ff14bot.Behavior;
using ff14bot.Managers;
using ff14bot.Objects;
using Kefka.Routine_Files.Mikoto;
using Kefka.Routine_Files.Surito;
using static Kefka.Routine_Files.Ability;
using static Kefka.Utilities.Constants;
using static Kefka.Utilities.Extensions.GameObjectExtensions;

namespace Kefka.Routine_Files
{
    internal class RoutineComposites : Rotation
    {
        internal static BattleCharacter HealTarget()
        {
            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Mikoto":
                    return HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= MikotoSettingsModel.Instance.CureHpPct);

                case "Remiel":
                    return HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= RemielSettingsModel.Instance.BeneficHpPct);

                case "Surito":
                    return HealManager.FirstOrDefault(hm => hm.CurrentHealthPercent <= SuritoSettingsModel.Instance.PhysickHpPct);
            }
            return null;
        }

        public override async Task<bool> Rest()
        {
            if (!Common_Utils.InActiveInstance()) return false;

            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            Logger.DebugLog("Pulsing Rest");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.Rest();

                case "Beatrix":
                    return await BeatrixRotation.Rest();

                case "Cecil":
                    return await CecilRotation.Rest();

                case "Cyan":
                    return await CyanRotation.Rest();

                case "Edward":
                    return await EdwardRotation.Rest();

                case "Eiko":
                    return await EikoRotation.Rest();

                case "Elayne":
                    return await ElayneRotation.Rest();

                case "Freya":
                    return await FreyaRotation.Rest();

                case "Mikoto":
                    return await MikotoRotation.Rest();

                case "Paine":
                    return await PaineRotation.Rest();

                case "Remiel":
                    return await RemielRotation.Rest();

                case "Sabin":
                    return await SabinRotation.Rest();

                case "Shadow":
                    return await ShadowRotation.Rest();

                case "Surito":
                    return await SuritoRotation.Rest();

                case "Vivi":
                    return await ViviRotation.Rest();
            }

            return false;
        }

        public override async Task<bool> PreCombat()
        {
            if (!Common_Utils.InActiveInstance()) return false;

            if (OpenerEnabled) return await Pull();

            if (MainSettingsModel.Instance.UseAutoSprint && Target == null && Me.EnemiesInRange(20) == 0 && MovementManager.IsMoving)
                await Spells.Sprint.Use(Me, true);

            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            Logger.DebugLog("Pulsing Pre-combat");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.PreCombat();

                case "Beatrix":
                    return await BeatrixRotation.PreCombat();

                case "Cecil":
                    return await CecilRotation.PreCombat();

                case "Cyan":
                    return await CyanRotation.PreCombat();

                case "Edward":
                    return await EdwardRotation.PreCombat();

                case "Eiko":
                    return await EikoRotation.PreCombat();

                case "Elayne":
                    return await ElayneRotation.PreCombat();

                case "Freya":
                    return await FreyaRotation.PreCombat();

                case "Mikoto":
                    return await MikotoRotation.PreCombat();

                case "Paine":
                    return await PaineRotation.PreCombat();

                case "Remiel":
                    return await RemielRotation.PreCombat();

                case "Sabin":
                    return await SabinRotation.PreCombat();

                case "Shadow":
                    return await ShadowRotation.PreCombat();

                case "Surito":
                    return await SuritoRotation.PreCombat();

                case "Vivi":
                    return await ViviRotation.PreCombat();
            }

            return false;
        }

        public override async Task<bool> Pull()
        {
            if (!Common_Utils.InActiveInstance() || Target == null) return false;

            if (BotManager.Current.IsAutonomous && !ff14bot.Managers.RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement))
            {
                if (await Movement.MovementComposite().ExecuteCoroutine())
                    return false;
            }

            if (!OpenerEnabled)
            {
                if (Me.IsCasting)
                {
                    var waitUntilCombatTime = TimeSpan.FromMilliseconds(Math.Min(Me.SpellCastInfo.SpellData.AdjustedCastTime.TotalMilliseconds, 2500));

                    if (await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell))
                        await Coroutine.Wait(waitUntilCombatTime, () => Me.InCombat);
                    return true;
                }

                if (CombatHelper.LastSpell != null && CombatHelper.LastTarget != Me)
                {
                    await Heal();
                    await CombatBuff();
                    await Combat();
                    var waitUntilCombatTime = TimeSpan.FromMilliseconds(Math.Min(CombatHelper.LastSpell.AdjustedCastTime.TotalMilliseconds, 2500));

                    await Coroutine.Wait(waitUntilCombatTime, () => Me.InCombat);
                    return true;
                }
            }

            Logger.DebugLog("Pulsing Pull");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.Pull();

                case "Beatrix":
                    return await BeatrixRotation.Pull();

                case "Cecil":
                    return await CecilRotation.Pull();

                case "Cyan":
                    return await CyanRotation.Pull();

                case "Edward":
                    return await EdwardRotation.Pull();

                case "Eiko":
                    return await EikoRotation.Pull();

                case "Elayne":
                    return await ElayneRotation.Pull();

                case "Freya":
                    return await FreyaRotation.Pull();

                case "Mikoto":
                    return await MikotoRotation.Pull();

                case "Paine":
                    return await PaineRotation.Pull();

                case "Remiel":
                    return await RemielRotation.Pull();

                case "Sabin":
                    return await SabinRotation.Pull();

                case "Shadow":
                    return await ShadowRotation.Pull();

                case "Surito":
                    return await SuritoRotation.Pull();

                case "Vivi":
                    return await ViviRotation.Pull();
            }

            return false;
        }

        public override async Task<bool> Heal()
        {
            if (!Common_Utils.InActiveInstance()) return false;

            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            Logger.DebugLog("Pulsing Heal");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.Heal();

                case "Beatrix":
                    return await BeatrixRotation.Heal();

                case "Cecil":
                    return await CecilRotation.Heal();

                case "Cyan":
                    return await CyanRotation.Heal();

                case "Edward":
                    return await EdwardRotation.Heal();

                case "Eiko":
                    return await EikoRotation.Heal();

                case "Elayne":
                    return await ElayneRotation.Heal();

                case "Freya":
                    return await FreyaRotation.Heal();

                case "Mikoto":
                    return await MikotoRotation.Heal();

                case "Paine":
                    return await PaineRotation.Heal();

                case "Remiel":
                    return await RemielRotation.Heal();

                case "Sabin":
                    return await SabinRotation.Heal();

                case "Shadow":
                    return await ShadowRotation.Heal();

                case "Surito":
                    return await SuritoRotation.Heal();

                case "Vivi":
                    return await ViviRotation.Heal();
            }

            return false;
        }

        public override async Task<bool> CombatBuff()
        {
            if (!Common_Utils.InActiveInstance() || Target == null) return false;

            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            Logger.DebugLog("Pulsing CombatBuff");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.CombatBuff();

                case "Beatrix":
                    return await BeatrixRotation.CombatBuff();

                case "Cecil":
                    return await CecilRotation.CombatBuff();

                case "Cyan":
                    return await CyanRotation.CombatBuff();

                case "Edward":
                    return await EdwardRotation.CombatBuff();

                case "Eiko":
                    return await EikoRotation.CombatBuff();

                case "Elayne":
                    return await ElayneRotation.CombatBuff();

                case "Freya":
                    return await FreyaRotation.CombatBuff();

                case "Mikoto":
                    if (HealTarget() != null)
                        return await MikotoRotation.Heal();

                    return await MikotoRotation.CombatBuff();

                case "Paine":
                    return await PaineRotation.CombatBuff();

                case "Remiel":
                    if (HealTarget() != null)
                        return await RemielRotation.Heal();

                    return await RemielRotation.CombatBuff();

                case "Sabin":
                    return await SabinRotation.CombatBuff();

                case "Shadow":
                    return await ShadowRotation.CombatBuff();

                case "Surito":
                    if (HealTarget() != null)
                        return await SuritoRotation.Heal();

                    return await SuritoRotation.CombatBuff();

                case "Vivi":
                    return await ViviRotation.CombatBuff();
            }

            return false;
        }

        public override async Task<bool> Combat()
        {
            if (!Common_Utils.InActiveInstance() || Target == null) return false;

            if (BotManager.Current.IsAutonomous && !ff14bot.Managers.RoutineManager.IsAnyDisallowed(CapabilityFlags.Movement))
            {
                if (await Movement.MovementComposite().ExecuteCoroutine())
                    return false;
            }

            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            Logger.DebugLog("Pulsing Combat");

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.Combat();

                case "Beatrix":
                    return await BeatrixRotation.Combat();

                case "Cecil":
                    return await CecilRotation.Combat();

                case "Cyan":
                    return await CyanRotation.Combat();

                case "Edward":
                    return await EdwardRotation.Combat();

                case "Eiko":
                    return await EikoRotation.Combat();

                case "Elayne":
                    return await ElayneRotation.Combat();

                case "Freya":
                    return await FreyaRotation.Combat();

                case "Mikoto":
                    if (HealTarget() != null)
                        return await MikotoRotation.Heal();
                    return await MikotoRotation.Combat();

                case "Paine":
                    return await PaineRotation.Combat();

                case "Remiel":
                    if (HealTarget() != null)
                        return await MikotoRotation.Heal();
                    return await RemielRotation.Combat();

                case "Sabin":
                    return await SabinRotation.Combat();

                case "Shadow":
                    return await ShadowRotation.Combat();

                case "Surito":
                    if (HealTarget() != null)
                        return await MikotoRotation.Heal();
                    return await SuritoRotation.Combat();

                case "Vivi":
                    return await ViviRotation.Combat();
            }

            return false;
        }

        public override async Task<bool> PvP()
        {
            if (Me.IsCasting)
                return await DodgeManager.DodgeThis(Me.SpellCastInfo.SpellData, CurrentTarget, CastedAura, IsDot, IsBuff, IsHealingSpell);

            switch (MainSettingsModel.Instance.CurrentRoutine)
            {
                case "Barret":
                    return await BarretRotation.PVPRotation();

                case "Beatrix":
                    return await BeatrixRotation.PVPRotation();

                case "Cecil":
                    return await CecilRotation.PVPRotation();

                case "Cyan":
                    return await CyanRotation.PVPRotation();

                case "Edward":
                    return await EdwardRotation.PVPRotation();

                case "Eiko":
                    return await EikoRotation.PVPRotation();

                case "Elayne":
                    return await ElayneRotation.PVPRotation();

                case "Freya":
                    return await FreyaRotation.PVPRotation();

                case "Mikoto":
                    return await MikotoRotation.PVPRotation();

                case "Paine":
                    return await PaineRotation.PVPRotation();

                case "Remiel":
                    return await RemielRotation.PVPRotation();

                case "Sabin":
                    return await SabinRotation.PVPRotation();

                case "Shadow":
                    return await ShadowRotation.PVPRotation();

                case "Surito":
                    return await SuritoRotation.PVPRotation();

                case "Vivi":
                    return await ViviRotation.PVPRotation();
            }

            return false;
        }
    }
}