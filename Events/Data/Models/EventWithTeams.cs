using MongoDB.Bson.Serialization.Attributes;

namespace Events.Data.Models
{
    public class EventWithTeams : Event
    {
        [BsonElement("teams")]
        public string[] Teams { get; set; }
    }
}
