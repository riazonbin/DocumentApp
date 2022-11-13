using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Data
{
    public class Project
    {
        public Project(ObjectId customerId, ObjectId developerId, ObjectId projecterId)
        {
            CustomerId = customerId;
            DeveloperId = developerId;
            ProjecterId = projecterId;
            CreatedDate = DateTime.Now;
        }

        public Project()
        {
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedDate { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public List<Document> ProjecterDocuments { get; set; } = new List<Document>();

        public Form Form { get; set; }

        public ObjectId CustomerId { get; set; }

        public ObjectId DeveloperId { get; set; }

        public ObjectId ProjecterId { get; set; }

        public string ProjectDepartment { get; set; }
    }
}
