using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Enums;

public enum DebtStatus
{
    [Display(Name = "Nuevo")]
    New,

    [Display(Name = "En Progreso")]
    InProgress,
    
    [Display(Name = "Suspendido")]
    Suspended,

    [Display(Name = "Finalizado")]
    Finalized
}