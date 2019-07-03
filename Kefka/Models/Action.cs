namespace Kefka.Models
{
    public class Action
    {
        public Action(uint id, string name, bool isPet, bool isItem, int classJob)
        {
            Id = id;
            Name = name;
            IsPet = isPet;
            IsItem = isItem;
            HasClassJob = classJob >= 0;
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public bool IsPet { get; set; }
        public bool IsItem { get; set; }
        public bool HasClassJob { get; set; }
    }
}