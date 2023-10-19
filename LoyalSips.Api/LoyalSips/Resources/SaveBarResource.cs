using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SaveBarResource
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(700)]
    public string Logo { get; set; }
    
    [Required]
    public int UserId { get; set; }
}