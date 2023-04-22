using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Personal.Shared.Enums;

namespace Personal.Shared.Models;

public record DebtMotion : Entity
{

    [ForeignKey(nameof(UserExecute))]
    public Guid UserExecuteId { get; set; }
    
    [JsonIgnore]
    public virtual User UserExecute { get; set; }

    [DataType(DataType.Date)]
    public DateOnly Date { get; set; }

    [DataType(DataType.Text)]
    public string Description { get; set; }

    [DefaultValue(DebtMotionType.Charge)]
    public DebtMotionType Type { get; set; }

    [DataType("DECIMAL(9,2)")]
    public decimal Amount { get; set; }

}