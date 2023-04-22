using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Personal.Shared.Enums;

namespace Personal.Shared.Models;

public record Person : Entity
{

    [Required]
    [StringLength(150)]
    public string Name { get; set; }

    [DefaultValue(PersonType.Natural)]
    public PersonType Type { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }

    [JsonIgnore]
    public IEnumerable<Phone> Phones { get; set; }


}