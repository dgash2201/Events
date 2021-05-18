using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Events.Data.Models
{
    public class Event
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [BsonElement("place")]
        [Display(Name = "Место проведения")]
        public string Place { get; set; }
        
        [BsonElement("start")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Start { get; set; }

        [BsonElement("end")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime End { get; set; }

        [BsonElement("sport")]
        [Display(Name = "Место проведения")]
        public string Sport { get; set; }

        [BsonElement("participants")]
        public string[] Sportsmen { get; set; }

        [BsonElement("judges")]
        public string[] Judges { get; set; }
    }
}
