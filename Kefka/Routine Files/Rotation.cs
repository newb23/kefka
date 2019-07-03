using System.Threading.Tasks;

namespace Kefka.Routine_Files
{
    public interface IRotation
    {
        Task<bool> Rest();

        Task<bool> PreCombat();

        Task<bool> Pull();

        Task<bool> Heal();

        Task<bool> CombatBuff();

        Task<bool> Combat();

        Task<bool> PvP();
    }

    public abstract class Rotation : IRotation
    {
        public abstract Task<bool> Rest();

        public abstract Task<bool> PreCombat();

        public abstract Task<bool> Pull();

        public abstract Task<bool> Heal();

        public abstract Task<bool> CombatBuff();

        public abstract Task<bool> Combat();

        public abstract Task<bool> PvP();
    }
}