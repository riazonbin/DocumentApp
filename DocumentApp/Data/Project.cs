using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Data
{
    public class Project
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public ObjectId CustomerId { get; set; }

        public ObjectId DeveloperId { get; set; }

        public ObjectId ProjecterId { get; set; }
    }
}
