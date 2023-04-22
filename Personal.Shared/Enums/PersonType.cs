using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Enums;

public enum PersonType
{
    [Display(Name = "Natural")]
    Natural,
    
    [Display(Name = "Jurídica")]
    Legal
}