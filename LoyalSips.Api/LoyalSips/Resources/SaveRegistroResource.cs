using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SaveRegistroResource
{
    [Required]
    public int puntosGanados { get; set; }
    
    [Required]
    public int BarId { get; set; }
    
    [Required]
    public int UserId { get; set; }
}