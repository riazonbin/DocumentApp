using DocumentApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Data
{
    public class Customer : User
    {
        public Customer()
        {
        }

        public Customer(string login, string password, string email, string telephone, RolesEnum role)
            : base(login, password, email, telephone, role)
        {
        }

        public Customer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role)
            : base(login, password, email, telephone, role)
        {
        }

        [Required]
        public string Department { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
