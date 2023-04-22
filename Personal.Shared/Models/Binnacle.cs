using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personal.Shared.Models;

public class Binnacle
{
    
    [Key]
    public Guid Id { get; set; }

    public DateTime TimeOff { get; set; }
    
    [Required]
    public Guid User{ get; set; }

    [StringLength(50)]
    public string Type { get; set; }
    
    [Required]
    public Guid Entity { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Action { get; set; }
    
    [Required]
    [DefaultValue("")]
    [DataType(DataType.Text)]
    public string Message { get; set; }

}