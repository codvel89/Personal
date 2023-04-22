using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Models;

public abstract record Entity
{
    [Key]
    public Guid Id { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}