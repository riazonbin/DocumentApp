using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Data
{
    public class Document
    {
        public Document()
        {
            IsApproved = false;
            IsRequired = false;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string FileName { get; set; }
        public bool IsRequired;
        public bool IsApproved;
        public byte[]? data;
    }
}
