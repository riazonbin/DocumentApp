using DocumentApp.Enums;

namespace DocumentApp.Data
{
    public class Developer : User
    {
        public Developer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role) 
            : base(login, password, firstName, lastName, email, telephone, role)
        {
        }

        public Developer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role,
            string developerOrganisation, string oGRN, string iNN, string kPP, string adress, string chief) 
            : base(login, password, firstName, lastName, email, telephone, role)
        {
            DeveloperOrganisation = developerOrganisation;
            OGRN = oGRN;
            INN = iNN;
            KPP = kPP;
            Adress = adress;
            Chief = chief;
        }

        public string DeveloperOrganisation { get; set; }

        public string OGRN { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public string Adress { get; set; }

        public string Chief {  get; set; }


    }
}
