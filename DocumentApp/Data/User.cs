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

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage ="Not correct email!")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[1-9]\d{3}\d{3}\d{4}$", ErrorMessage = "Неверный формат номера телефона!")]
        public string Telephone { get; set; }

        [Required]
        public RolesEnum Role { get; set; }
    }
}
