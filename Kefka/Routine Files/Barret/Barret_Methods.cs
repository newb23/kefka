using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using static Kefka.Utilities.Constants;
using Kefka.Models;
using Kefka.Routine_Files.General;
using Kefka.Utilities;
using Kefka.Utilities.Extensions;
using Kefka.ViewModels;
using static Kefka.Utilities.Extensions.GameObjectExtensions;
using Auras = Kefka.Routine_Files.General.Auras;

namespace Kefka.Routine_Files.Barret
{
    public static partial class BarretRotation
    {
        private static int AmmunitionLoadedStacks => ActionResourceManager.Machinist.Ammo;
        private static bool AmmunitionLoaded => ActionResourceManager.Machinist.Ammo > 0;
        private static bool Overheated => ActionResourceManager.Machinist.Heat == 100 && ActionResourceManager.Machinist.Timer.TotalMilliseconds > 0;
        private static bool UseWildfire => BarretSettingsModel.Instance.UseWildfire && Target.HealthCheck(false) && Target.TimeToDeathCheck();

        private static bool WFMessage;

        private static async Task<bool> ManualFlamethrower()
        {
            if (Spells.Flamethrower.Cooldown != TimeSpan.Zero) return false;

            if (Control.ModifierKeys == Keys.None || !WindowCheck.ApplicationIsActivated()) return false;
            if (Keyboard.IsKeyDown(BarretHotkeysModel.Instance.ForceOverheatKey))
                {
                    await Spells.Flamethrower.Use(Me, true);

                    while (!Overheated)
                    {
                        await Coroutine.Wait(250, () => Overheated);
                        await Coroutine.Yield();
                    }
                }
            return false;
        }

        private static async Task<bool> Overdrive()
        {
            var canCast = Spells.RookOverdrive.Cooldown == TimeSpan.Zero && Spells.BishopOverdrive.Cooldown == TimeSpan.Zero;
            if (!canCast) return false;

            if (Control.ModifierKeys != Keys.None && WindowCheck.ApplicationIsActivated())
                if (Keyboard.IsKeyDown(BarretHotkeysModel.Instance.OverdriveKey))
                    while (!Me.HasAura(Auras.TurretReset))
                    {
                        if (PetManager.ActivePetType == PetType.Rook_Autoturret)
                            await Spells.RookOverdrive.Use(Target, true);

                        await Spells.BishopOverdrive.Use(Target, true);

                        await Coroutine.Wait(250, () => !Me.HasAura(Auras.TurretReset));
                        await Coroutine.Yield();
                    }

            return false;
        }

        private static async Task<bool> SplitShot()
        {
            return await Spells.SplitShot.Use(Target, true);
        }

        private static async Task<bool> SlugShot()
        {
            return await Spells.SlugShot.Use(Target, Me.HasAura(Auras.EnhancedSlugShot));
        }

        private static async Task<bool> QuickReload()
        {
            if (Target == null || !Target.CanAttack) return false;

            return await Spells.QuickReload.Use(Me, AmmunitionLoadedStacks < 3
                && ActionResourceManager.Machinist.GaussBarrel
                && (ActionResourceManager.Machinist.Heat > 60 || Me.ClassLevel < Spells.GaussBarrel.LevelAcquired)
                && Me.HasAura(Auras.HotShot, true, BarretSettingsModel.Instance.HotShotRfsh)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Reload()
        {
            return await Spells.Reload.Use(Me, BarretSettingsModel.Instance.UseCooldowns
                && (Spells.Wildfire.Cooldown.TotalMilliseconds >= BarretSettingsModel.Instance.WfBuffDelay || Me.ClassLevel < 37)
                && CombatHelper.LastSpell != Spells.QuickReload
                && !AmmunitionLoaded
                && (Me.HasAura(Auras.HotShot, true, 18000) || Me.ClassLevel < 30)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> HotShot()
        {
            return await Spells.HotShot.CastBuff(Target, !Me.HasAura(Auras.HotShot, true, BarretSettingsModel.Instance.HotShotRfsh) && CombatHelper.LastSpell != Spells.HotShot, Auras.HotShot, BarretSettingsModel.Instance.HotShotRfsh);
        }

        private static async Task<bool> Heartbreak()
        {
            return await Spells.Heartbreak.Use(Target, BarretSettingsModel.Instance.UseHeartBreak);
        }

        private static async Task<bool> Wildfire()
        {
            if (Target == null || !Target.CanAttack || !BarretSettingsModel.Instance.UseWildfire)
                return false;

            if (BarretSettingsModel.Instance.UseWildfireWithOverheatOnly && !Overheated) return false;

            return await Spells.Wildfire.CastDot(Target, BarretSettingsModel.Instance.UseCooldowns
                && Me.HasAura(Auras.HotShot)
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.Wildfire);
        }

        private static async Task<bool> ReassembleUnderLevel35()
        {
            return await Spells.Reassemble.Use(Me, Me.ClassLevel < 35 && Me.HasAura(Auras.EnhancedSlugShot) && AmmunitionLoaded);
        }

        private static async Task<bool> Blank()
        {
            return await Spells.Blank.Use(Target, BarretSettingsModel.Instance.UseBlank && (Spells.Wildfire.Cooldown.TotalMilliseconds >= BarretSettingsModel.Instance.WfProcDelay || !BarretSettingsModel.Instance.UseCooldowns) && Me.TargetDistance(5, false) && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Peloton()
        {
            return await Spells.Peloton.Use(Me, BarretSettingsModel.Instance.UsePeloton
                && !Me.InCombat
                && !Me.HasAura(Auras.Sprint)
                && !Me.HasAura(Auras.Peloton)
                && Target == null
                && Me.EnemiesInRange(20) == 0
                && MovementManager.IsMoving);
        }

        private static async Task<bool> SecondWind()
        {
            return await Spells.SecondWind.Use(Me, Me.CurrentHealthPercent < BarretSettingsModel.Instance.SecondWindHpPct);
        }

        private static async Task<bool> RapidFire()
        {
            return await Spells.RapidFire.CastBuff(Me, Overheated
                && BarretSettingsModel.Instance.UseBuffs
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck(), Auras.RapidFire);
        }

        private static async Task<bool> HeadGraze()
        {
            if (BarretSettingsModel.Instance.UseManualInterrupt || Me.ClassLevel < 34) return false;

            if (Target.CanSilence() && BarretSettingsModel.Instance.UseInterruptList)
                return await Spells.HeadGraze.Use(Target, true);

            return Target != null && await Spells.HeadGraze.Use(Target, !BarretSettingsModel.Instance.UseInterruptList);
        }

        private static async Task<bool> CleanShot()
        {
            if (Target == null || !Target.CanAttack || !Me.HasAura(Auras.CleanerShot)) return false;

            if (await Spells.Reassemble.CastBuff(Me, BarretSettingsModel.Instance.UseCooldowns && BarretSettingsModel.Instance.UseBuffs && Spells.Wildfire.Cooldown.TotalMilliseconds > BarretSettingsModel.Instance.WfProcDelay && Target.HealthCheck(false) && Target.TimeToDeathCheck(), Auras.Reassembled))
            {
                await Coroutine.Wait(3000, () => ActionManager.CanCast(Spells.CleanShot.LocalizedName, Target));
                return await Spells.CleanShot.Use(Target, true);
            }

            if (AmmunitionLoaded && !Me.HasAura(Auras.EnhancedSlugShot))
                return await Spells.SplitShot.Use(Target, true);

            if (Me.HasAura(Auras.EnhancedSlugShot) || !AmmunitionLoaded)
                return await Spells.CleanShot.Use(Target, true);

            return await Spells.CleanShot.Use(Target, Spells.Wildfire.Cooldown.TotalMilliseconds >= BarretSettingsModel.Instance.WfProcDelay || !BarretSettingsModel.Instance.UseCooldowns);
        }

        private static async Task<bool> GaussBarrel()
        {
            return await Spells.GaussBarrel.Use(Me, (BarretSettingsModel.Instance.UseGaussBarrel && !ActionResourceManager.Machinist.GaussBarrel) || (!BarretSettingsModel.Instance.UseGaussBarrel && ActionResourceManager.Machinist.GaussBarrel));
        }

        private static async Task<bool> GaussRound()
        {
            return await Spells.GaussRound.Use(Target, (Spells.Wildfire.Cooldown.TotalMilliseconds >= BarretSettingsModel.Instance.WfProcDelay || !BarretSettingsModel.Instance.UseCooldowns) && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Cooldown()
        {
            if (Overheated && !Core.Player.HasAura(Auras.EnhancedSlugShot) && !Core.Player.HasAura(Auras.CleanerShot) && ActionResourceManager.Machinist.Ammo < 2)
            {
                return await Spells.Cooldown.Use(Target, true);
            }

            if (!Overheated && ActionResourceManager.Machinist.Heat >= BarretSettingsModel.Instance.CooldownThreshold && 
                (!ActionManager.CanCast(Spells.BarrelStabilizer, Core.Player) || !UseWildfire || Spells.Wildfire.Cooldown.TotalMilliseconds > 3000))
            {
                return await Spells.Cooldown.Use(Target, true);
            }

            return false;
        }

        private static async Task<bool> BarrelStabilizer()
        {
            return await Spells.BarrelStabilizer.Use(Me, (ActionResourceManager.Machinist.GaussBarrel || ActionManager.LastSpell == Spells.GaussBarrel || CombatHelper.LastSpell == Spells.GaussBarrel) && ActionResourceManager.Machinist.Heat < 20);
        }

        private static async Task<bool> Hypercharge()
        {
            return await Spells.Hypercharge.Use(Me, BarretSettingsModel.Instance.UseHypercharge
                && Me.Pet != null
                && CombatHelper.LastSpell != Spells.RookOverdrive
                && CombatHelper.LastSpell != Spells.BishopOverdrive
                && Spells.Wildfire.Cooldown.TotalMilliseconds >= BarretSettingsModel.Instance.WfBuffDelay && Target.HealthCheck(false) && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Ricochet()
        {
            return await Spells.Ricochet.Use(Target, Overheated
                && BarretSettingsModel.Instance.UseCooldowns
                && AmmunitionLoaded
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> Invigorate()
        {
            return await Spells.Invigorate.Use(Me, Me.CurrentTPPercent <= 50) && Target.HealthCheck(false) && Target.TimeToDeathCheck();
        }

        private static async Task<bool> Tactician()
        {
            if (!BarretSettingsModel.Instance.UseTactician || ActionManager.LastSpell == Spells.Refresh || CombatHelper.LastSpell == Spells.Refresh) return false;

            if (PartyManager.IsInParty && PartyMembers.Count(pm => pm.IsAlive && pm.CurrentTPPercent <= BarretSettingsModel.Instance.TacticianTpPct) >= BarretSettingsModel.Instance.TacticianMemberCount)
                return await Spells.Tactician.Use(Me, Target.HealthCheck(false) && Target.TimeToDeathCheck());

            return await Spells.Tactician.Use(Me, Target.HealthCheck(false) && Target.TimeToDeathCheck() && GameObjectManager.Attackers.Any(a => a.TargetCharacter == Me));
        }

        private static async Task<bool> Refresh()
        {
            if (!BarretSettingsModel.Instance.UseRefresh || ActionManager.LastSpell == Spells.Tactician || CombatHelper.LastSpell == Spells.Tactician) return false;

            if (PartyManager.IsInParty && PartyMembers.Count(pm => pm.IsHealer() && pm.IsAlive && pm.CurrentManaPercent <= BarretSettingsModel.Instance.RefreshMpPct) >= BarretSettingsModel.Instance.RefreshMemberCount)
                return await Spells.Refresh.Use(Me, Target.HealthCheck(false) && Target.TimeToDeathCheck());

            return await Spells.Refresh.Use(Me, Target.HealthCheck(false) && Target.TimeToDeathCheck() && GameObjectManager.Attackers.Any(a => a.TargetCharacter == Me));
        }

        private static async Task<bool> Flamethrower()
        {
            if (ActionResourceManager.Machinist.Heat >= 100 || MovementManager.IsMoving || Spells.BarrelStabilizer.Cooldown == TimeSpan.Zero || !BarretSettingsModel.Instance.UseFlamethrower) return false;

            if (Spells.BarrelStabilizer.Cooldown.TotalMilliseconds < 23000 && UseWildfire && Spells.Wildfire.Cooldown.TotalMilliseconds < 3000)
            {
                if (WFMessage == false)
                {
                    ToastManager.AddToast("ST Flamethrower coming in ~3 seconds!", TimeSpan.FromMilliseconds(1500), MainSettingsModel.Instance.ToastColor(false), Colors.White, new FontFamily("High Tower Text Italic"), new FontWeight(), 52);
                    WFMessage = true;
                }

                if (await Spells.Flamethrower.Use(Me, Spells.BarrelStabilizer.Cooldown.TotalMilliseconds < 20000))
                {
                    await Coroutine.Wait(3000, () => Core.Player.HasAura(Auras.Flamethrower) && (ActionResourceManager.Machinist.Heat == 100 || ActionResourceManager.Machinist.Timer.TotalMilliseconds > 0));
                    WFMessage = true;
                    return true;
                }
                return false;
            }
            return false;
        }

        #region Misc

        // 3666 = Rook
        // 3667 = Bishop

        private static async Task<bool> AutoTurret()
        {
            if (!BarretSettingsModel.Instance.UseAutoTurret || Target == null || !Target.CanAttack) return false;

            if ((!Target.TimeToDeathCheck() || !Target.HealthCheck(false)) && PetManager.ActivePetType == PetType.Rook_Autoturret)
            {
                await Spells.RookOverdrive.Use(Target, !Me.Pet.HasAura(Auras.Hypercharge));
            }

            switch (BarretSettingsModel.Instance.Turret)
            {
                case TurretMode.Manual:
                    return false;

                case TurretMode.Auto:
                    if (await Spells.RookAutoturret.Use(Me, Target?.EnemiesInRange(8) < BarretSettingsModel.Instance.TurretMobCount && (Me.Pet == null || Me.Pet != null && Me.Pet.NpcId == 3667 || (Me.Pet == null || Me.Pet != null && Me.Pet.NpcId == 3667) && Me.Pet != null && Me.Pet.Distance2D(Target) - Me.CurrentTarget.CombatReach - Me.Pet.CombatReach > 20))) return true;
                    return await Spells.BishopAutoturret.Use(Target, Target?.EnemiesInRange(8) >= BarretSettingsModel.Instance.TurretMobCount && (Me.Pet == null || Me.Pet != null && Me.Pet.NpcId == 3666 || (Me.Pet == null || Me.Pet != null && Me.Pet.NpcId == 3666) && Me.Pet != null && Me.Pet.Distance2D(Target) - Me.CurrentTarget.CombatReach - Me.Pet.CombatReach > 20));

                case TurretMode.RookAutoturret:
                    return await Spells.RookAutoturret.Use(Me, Me.Pet == null || Me.Pet.NpcId == 3667 || Me.Pet.Distance2D(Me.CurrentTarget) - Me.CurrentTarget.CombatReach - Me.Pet.CombatReach > 20);

                case TurretMode.BishopAutoturret:
                    return await Spells.BishopAutoturret.Use(Target, Me.Pet == null || Me.Pet.NpcId == 3666 || (Me.Pet.NpcId == 3666 && BarretSettingsModel.Instance.UseAoE) || Me.Pet.Distance2D(Me.CurrentTarget) - Me.CurrentTarget.CombatReach - Me.Pet.CombatReach > 20);
            }
            return false;
        }

        private static async Task<bool> DpsPotion()
        {
            if (Target == null || !Target.CanAttack || !BarretSettingsModel.Instance.UseDpsPotion)
            {
                return false;
            }

            var dpsPotion = InventoryManager.FilledSlots.FirstOrDefault(p => p?.Item != null && p.EnglishName == DPS_PotionViewModel.Instance.SelectedPotion?.EnglishName);

            if (dpsPotion == null) return false;

            return await Items.UsePotion(dpsPotion.Item, true);
        }

        private static async Task<bool> AoE()
        {
            if (Target == null || !Target.CanAttack || !BarretSettingsModel.Instance.UseAoE ||
                Target?.EnemiesInRange(5) < BarretSettingsModel.Instance.MobCount)
                return false;

            if ((!Target.TimeToDeathCheck() || !Target.HealthCheck(false)) && PetManager.ActivePetType == PetType.Bishop_Autoturret)
                await Spells.BishopOverdrive.Use(Me, !Me.Pet.HasAura(Auras.Hypercharge));

            if (await Spells.Flamethrower.Use(Me, BarretSettingsModel.Instance.UseFlamethrower && ActionResourceManager.Machinist.Heat < 100))
            {
                await Coroutine.Wait(2500, () => Me.HasAura(Auras.Flamethrower));
                while (ActionResourceManager.Machinist.Timer == TimeSpan.Zero && Me.HasAura(Auras.Flamethrower))
                {
                    await Coroutine.Yield();
                }
            }

            return await Spells.SpreadShot.Use(Target, Me.CurrentTP > BarretSettingsModel.Instance.TpLimit
                && Target.HealthCheck(false)
                && Target.TimeToDeathCheck());
        }

        private static async Task<bool> RendMind()
        {
            if (Target == null
                || !Target.CanAttack
                || !BarretSettingsModel.Instance.UseDismantleMind
                || BarretSettingsModel.Instance.DismantleMindMode == BarretDismantleMindSelection.None
                || !Target.HealthCheck(false)
                || !Target.TimeToDeathCheck())
                return false;

            switch (BarretSettingsModel.Instance.DismantleMindMode)
            {
                case BarretDismantleMindSelection.Dismantle:
                    return await Spells.Dismantle.Use(Target, true);
            }

            return false;
        }

        #endregion Misc
    }
}