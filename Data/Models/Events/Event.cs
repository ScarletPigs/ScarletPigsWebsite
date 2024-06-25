using Heron.MudCalendar;
using ScarletPigsWebsite.Data.Models.Modsets;
using System.Text.Json.Serialization;

namespace ScarletPigsWebsite.Data.Models.Events
{
    public class Event : CalendarItem
    {
        public new string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Modset Modset { get; set; }

        [JsonIgnore]
        public new string Text
        {
            get => Name;
            set => Name = value;
        }

        [JsonIgnore]
        public new DateTime Start
        {
            get => StartTime;
            set => StartTime = value;
        }

        [JsonIgnore]
        public new DateTime End
        {
            get => EndTime;
            set => EndTime = value;
        }

        public new bool AllDay { get; set; } = false;

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
