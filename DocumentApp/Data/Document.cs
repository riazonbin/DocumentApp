using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Data
{
    public class Document
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Name { get; set; }
        public string FileName { get; set; }
        public bool IsRequired = false;
        public bool IsApproved = false;
        public byte[]? data;
    }
}
