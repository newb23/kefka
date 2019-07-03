namespace Kefka.Models
{
    public class IgnoreTarget
    {
        public IgnoreTarget(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public uint Id { get; set; }
        public string Name { get; set; }
    }
}