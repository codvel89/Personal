using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Enums;

public enum DebtMotionType
{
    [Display(Name = "Pagar")]
    Pay,

    [Display(Name = "Cargar")]
    Charge
}