namespace ScarletPigsWebsite.Data.Models.Modsets
{
    public class Modset
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public List<Mod> Mods { get; set; }

        public Modset()
        {
            Name = "";
            Description = "";
            Author = "";
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
            Mods = new List<Mod>();
        }
    }
}
