using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SaveSupportResource
{
    [Required]
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required]
    public int UserId { get; set; }
}