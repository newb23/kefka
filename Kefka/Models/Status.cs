namespace Kefka.Models
{
    public class Status
    {
        public Status(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public uint Id { get; set; }
        public string Name { get; set; }
    }
}