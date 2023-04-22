using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Personal.Shared.Enums;

namespace Personal.Shared.Models;

public record Debt : Entity
{

    [Required]
    [ForeignKey(nameof(Owner))]
    public Guid OwnerId { get; set; }
    
    [JsonIgnore]
    public virtual User Owner { get; set; }

    [Required]
    [ForeignKey(nameof(Creditor))]
    public Guid CreditorId { get; set; }
    
    [JsonIgnore]
    public virtual Person Creditor { get; set; }

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string Description { get; set; }

    [DataType("DECIMAL(9,2)")]
    public decimal Balance { get; set; }

    [DataType(DataType.Date)]
    public DateOnly InitialDate { get; set; }

    [DefaultValue(DebtStatus.New)]
    public DebtStatus Status { get; set; }



}