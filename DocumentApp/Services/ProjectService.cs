using DocumentApp.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DocumentApp.Services
{
    public class ProjectService
    {
        IMongoDatabase _database;
        public ProjectService()
        {
            var client = new MongoClient("mongodb://localhost");
            _database = client.GetDatabase("DocumentApp");
        }

        public void AddToDataBase(Project project)
        {
            var collection = _database.GetCollection<Project>("ProjectCollection");
            collection.InsertOne(project);
        }
        public void UpdateProjectInDataBase(Project project)
        {
            var filter = Builders<Project>.Filter.Eq("_id", project.Id);
            var collection = _database.GetCollection<Project>("ProjectCollection");
            collection.ReplaceOne(filter, project);
        }

        public void AddToDataBase(Form form)
        {
            var collection = _database.GetCollection<Form>("FormCollection");
            collection.InsertOne(form);
        }

        public List<Project> GetAllProjects()
        {
            return _database.GetCollection<Project>("ProjectCollection").Find(new BsonDocument()).ToList();
        }

        public void AddDocumentToDataBase(Document doc)
        {
            var collection = _database.GetCollection<Document>("DocumentCollection");
            collection.InsertOne(doc);
        }

        public void AddDocsToDataBase(List<Document> docs)
        {
            var collection = _database.GetCollection<Document>("DocumentCollection");
            foreach(var doc in docs)
            {
                collection.InsertOne(doc);
            }
        }

        public void AddProjecterDocsToDataBase(List<Document> docs)
        {
            var collection = _database.GetCollection<Document>("ProjecterDocumentCollection");
            foreach (var doc in docs)
            {
                collection.InsertOne(doc);
            }
        }
    }
}
