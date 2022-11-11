using DocumentApp.Enums;

namespace DocumentApp.Data
{
    public class Customer : User
    {
        public Customer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role,
            string department) : base(login, password, firstName, lastName, email, telephone, role)
        {
            Department = department;
        }

        public Customer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role)
            : base(login, password, firstName, lastName, email, telephone, role)
        {
        }

        public string Department { get; set; }
    }
}
