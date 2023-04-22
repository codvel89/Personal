using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Personal.Shared.Enums;

namespace Personal.Shared.Models;

public record User : Entity
{

    [StringLength(100)]
    public string Email { get; set; }

    [DataType(DataType.Text)]
    public string Description { get; set; }
    
    public Guid? Person { get; set; }
    
    [DefaultValue(UserState.Enabled)]
    public UserState State { get; set; }
    
    [DefaultValue(UserType.External)]
    public UserType Type { get; set; }

    [StringLength(64)]
    public string Password { get; set; }

}