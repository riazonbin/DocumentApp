using DocumentApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Data
{
    public class Developer : User
    {
        public Developer()
        {
        }

        public Developer(string login, string password, string email, string telephone, RolesEnum role) : 
            base(login, password, email, telephone, role)
        {
        }

        public Developer(string login, string password, string firstName, string lastName, string email, string telephone, RolesEnum role,
            string developerOrganisation, string oGRN, string iNN, string kPP, string adress, string chief) 
            : base(login, password, email, telephone, role)
        {
            DeveloperOrganisation = developerOrganisation;
            OGRN = oGRN;
            INN = iNN;
            KPP = kPP;
            Adress = adress;
            Chief = chief;
        }

        [Required]
        public string DeveloperOrganisation { get; set; }

        [Required]
        public string OGRN { get; set; }

        [Required]
        public string INN { get; set; }

        [Required]
        public string KPP { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Chief {  get; set; }


    }
}
