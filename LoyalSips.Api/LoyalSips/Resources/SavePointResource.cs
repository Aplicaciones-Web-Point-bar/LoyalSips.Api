

using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SavePointResource
{
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    public float Total { get; set; }
    
    
    [Required]
    public float Sale  { get; set; }
}