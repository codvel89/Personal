using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Enums;

public enum UserType
{
    [Display(Name = "Interno")]
    Internal,

    [Display(Name = "Externo")]
    External
}