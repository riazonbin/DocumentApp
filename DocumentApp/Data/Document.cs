using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocumentApp.Data
{
    public class Document
    {
        [BsonId]
        public string Id { get; set; }
        public string? Name { get; set; }
        public bool isRequired = false;
        public byte[]? data;
    }
}
