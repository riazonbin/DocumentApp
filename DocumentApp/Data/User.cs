using DocumentApp.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Data
{
    public class User
    {
        public User(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role)
        {
            Login = login;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Telephone = telephone;
            Role = role;
        }

        public User()
        {

        }

        [BsonId]
        public ObjectId Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public RolesEnum Role { get; set; }
    }
}
