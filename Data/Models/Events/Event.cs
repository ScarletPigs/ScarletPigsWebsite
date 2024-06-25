using ScarletPigsWebsite.Data.Models.Modsets;

namespace ScarletPigsWebsite.Data.Models.Events
{
    public class Event
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Modset Modset { get; set; }

        public Event()
        {
            Name = "";
            Description = "";
            EventType = new EventType();
            Author = "";
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            Modset = new Modset();
        }
    }
}
