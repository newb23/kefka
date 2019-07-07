using System;
using ff14bot.Behavior;
using ff14bot.Enums;
using ff14bot.Objects;
using Kefka.Utilities.Extensions;
using TreeSharp;
using static Kefka.Utilities.Constants;

namespace Kefka.Routine_Files.General
{
    internal class Movement
    {
        internal static Composite MovementComposite()
        {
            double pullRange = 3;

            if (Me.IsHealer() || (Me.IsRangedDps() && (Me.CurrentJob != ClassJobType.RedMage || Me.ClassLevel >= 2)))
                pullRange = 20;

            return new PrioritySelector(ctx => Target as BattleCharacter,
                new Decorator(ctx => ctx != null, new PrioritySelector(
                    CommonBehaviors.MoveToLos(target => Target),
                    CommonBehaviors.MoveAndStop(target => Target.Location, Math.Max(Target.CombatReach, Me.CombatReach) + (float)pullRange, true))));
        }
    }
}