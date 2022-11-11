using DocumentApp.Data;
using MongoDB.Driver;

namespace DocumentApp.Services
{
    public class MongoDBConnection
    {
        IMongoDatabase _database;
        public MongoDBConnection()
        {
            var client = new MongoClient("mongodb://localhost");
            _database = client.GetDatabase("DocumentApp");
        }

        #region AddToDb
        public void AddToDataBase(Customer customer)
        {
            var collection = _database.GetCollection<Customer>("CustomerCollection");
            collection.InsertOne(customer);
        }

        public void AddToDataBase(Projecter projecter)
        {
            var collection = _database.GetCollection<Projecter>("ProjecterCollection");
            collection.InsertOne(projecter);
        }

        public void AddToDataBase(Developer developer)
        {
            var collection = _database.GetCollection<Developer>("DeveloperCollection");
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
            var filter = Builders<Customer>.Filter.Eq("Login", login);
            var collection = _database.GetCollection<Customer>("CustomerCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        public Projecter FindProjecterByLogin(string login)
        {
            var filter = Builders<Projecter>.Filter.Eq("Login", login);
            var collection = _database.GetCollection<Projecter>("ProjecterCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        public Developer FindDeveloperByLogin(string login)
        {
            var filter = Builders<Developer>.Filter.Eq("Login", login);
            var collection = _database.GetCollection<Developer>("DeveloperCollection");
            return collection.Find(filter).FirstOrDefault();
        }

        #endregion

        public void UpdateCustomer(Customer user)
        {
            var filter = Builders<Customer>.Filter.Eq("Login", user.Login);
            var collection = _database.GetCollection<Customer>("CustomerCollection");
            collection.ReplaceOne(filter, user);
        }

        public void UpdateDeveloper(Developer user)
        {
            var filter = Builders<Developer>.Filter.Eq("Login", user.Login);
            var collection = _database.GetCollection<Developer>("DeveloperCollection");
            collection.ReplaceOne(filter, user);
        }

        public void UpdateDeveloper(Projecter user)
        {
            var filter = Builders<Projecter>.Filter.Eq("Login", user.Login);
            var collection = _database.GetCollection<Projecter>("ProjecterCollection");
            collection.ReplaceOne(filter, user);
        }

        public IMongoCollection<User> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("DocumentApp");

            return database.GetCollection<User>("UserCollection");
        }
    }
}
