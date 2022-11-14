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
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Формат ОГРН : 13 цифр!")]
        public string OGRN { get; set; }

        [Required]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Формат ИНН : 12 цифр!")]
        public string INN { get; set; }

        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Формат КПП : 9 цифр!")]
        public string KPP { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string Chief {  get; set; }


    }
}
