using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Personal.Shared.Enums;

namespace Personal.Shared.Models;

public record Phone : Entity
{

    [ForeignKey(nameof(Person))]
    public Guid PersonId { get; set; }
    
    [JsonIgnore]
    public Person Person { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8)]
    public string Number { get; set; }

    [DefaultValue(PhoneCompany.Claro)]
    public PhoneCompany Company { get; set; }


}