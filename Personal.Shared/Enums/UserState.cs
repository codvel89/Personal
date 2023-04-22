using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Enums;

public enum UserState
{
    [Display(Name = "Habilitado")]
    Enabled,
    
    [Display(Name = "Desabilitado")]
    Disabled,
    
    [Display(Name = "Suspendido")]
    Suspended,
    
    [Display(Name = "En Recuperación")]
    Recovery,

    [Display(Name = "Primer Uso")]
    FirstUse
}