namespace DmApi.Models
{
    public class Spell
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string School { get; set; }
        public string CastingTime { get; set; }
        public string Duration { get; set; }
        public bool Verbal { get; set; }
        public bool Somatic { get; set; }
        public string Materials { get; set; }
        public int Range { get; set; }
        public string Description { get; set; }
    }
}
