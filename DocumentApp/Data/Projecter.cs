using DocumentApp.Enums;
using System.IO;

namespace DocumentApp.Data
{
    public class Projecter : User
    {
        public Projecter(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role) : base(login, password, firstName, lastName, email, telephone, role)
        {
        }

        public Projecter(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role,
            string projectOrganisation, string oGRN, string iNN, string kPP, string adress, string director, string mainEngineer)
            : base(login, password, firstName, lastName, email, telephone, role)
        {
            ProjectOrganisation = projectOrganisation;
            OGRN = oGRN;
            INN = iNN;
            KPP = kPP;
            Adress = adress;
            Director = director;
            MainEngineer = mainEngineer;
        }

        public string ProjectOrganisation { get; set; }

        public string OGRN { get; set; }

        public string INN { get; set; }

        public string KPP { get; set; }

        public string Adress { get; set; }

        public string Director { get; set; }

        public string MainEngineer { get; set; }
    }
}
