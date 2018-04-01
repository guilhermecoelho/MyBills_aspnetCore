using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MyBills.Domain.Entities
{
    public class Bill
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Value")]
        public float Value { get; set; }

        [BsonElement("Date")]
        public DateTime DatePayed { get; set; }
    }
}
