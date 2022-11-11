using DocumentApp.Data;
using MongoDB.Driver;

namespace DocumentApp.Services
{
    public class MongoDBConnection
    {


        #region AddToDb
        public void AddToDataBase(Customer customer)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Customer>("CustomerCollection");
            collection.InsertOne(customer);
        }

        public void AddToDataBase(Projecter projecter)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Projecter>("ProjecterCollection");
            collection.InsertOne(projecter);
        }

        public void AddToDataBase(Developer developer)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            collection.InsertOne(developer);
        }

        #endregion


        #region FindInDb
        public User? FindByLogin(string login)
        {
            var log1 = FindCustomerByLogin(login);
            var log2 = FindDeveloperByLogin(login);
            var log3 = FindProjecterByLogin(login);

            if(log1 != null)
            {
                return log1;
            }
            if (log2 != null)
            {
                return log2;
            }
            if (log3 != null)
            {
                return log3;
            }
            return null;
        }

        public Customer FindCustomerByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = Builders<Customer>.Filter.Eq("Login", login);
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Customer>("CustomerCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        public Projecter FindProjecterByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = Builders<Projecter>.Filter.Eq("Login", login);
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Projecter>("ProjecterCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        public Developer FindDeveloperByLogin(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = Builders<Developer>.Filter.Eq("Login", login);
            var database = client.GetDatabase("DocumentApp");
            var collection = database.GetCollection<Developer>("DeveloperCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        #endregion


        public IMongoCollection<User> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");

            return database.GetCollection<User>("UserCollection");
        }
    }
}
