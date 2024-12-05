using Heron.MudCalendar;
using ScarletPigsWebsite.Data.Models.JSON;
using ScarletPigsWebsite.Data.Models.ModLists;
using System.Text.Json.Serialization;

namespace ScarletPigsWebsite.Data.Models.Events
{
    public class Event
    {
        [JsonConverter(typeof(AutoNumberToStringConverter))]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public EventType EventType { get; set; }
        [JsonIgnore]
        public string Author { get; set; }
        [JsonPropertyName("creatorDiscordUsername")]
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("lastModified")]
        public DateTime LastUpdatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [JsonIgnore]
        public ModList Modset { get; set; }

        public CalendarEvent ToCalendarEvent()
        {
            return new CalendarEvent(this);
        }
    }

    public class CalendarEvent : CalendarItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ModList Modset { get; set; }

        public string ApiId { get; set; }

        public CalendarEvent(Event apievent)
        {
            ApiId = apievent.Id;

            Name = apievent.Name;
            Description = apievent.Description;
            EventType = apievent.EventType;
            Author = apievent.Author;
            CreatedAt = apievent.CreatedAt;
            LastUpdatedAt = apievent.LastUpdatedAt;
            StartTime = apievent.StartTime;
            EndTime = apievent.EndTime;
            Modset = apievent.Modset;

            if (Modset == null)
            {
                Modset = new ModList();
            }
            if (EventType == null)
            {
                EventType = new EventType();
            }

            // Set the calendar item properties
            Text = Name;
            Start = StartTime;
            End = EndTime;
            AllDay = false;
        }
    }
}
