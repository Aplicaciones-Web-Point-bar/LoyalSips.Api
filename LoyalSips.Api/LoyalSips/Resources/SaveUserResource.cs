using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(20)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string email { get; set; }
    
    [Required]
    [MaxLength(30)]
    [MinLength(5)]
    public string Password { get; set; }
}