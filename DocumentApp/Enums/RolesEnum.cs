using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocumentApp.Enums
{
    public enum RolesEnum
    {
        [Display(Name ="Заказчик")]
        Customer,
        [Display(Name = "Застройщик")]
        Developer,
        [Display(Name = "Проектировщик")]
        Projecter
    }
}
