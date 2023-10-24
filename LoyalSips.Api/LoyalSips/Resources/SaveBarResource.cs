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
    public List<string> Fotos { get; set; }
    
    [Required]
    public int Puntaje { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Ubicacion { get; set; }
    
    [Required]
    public int OwnerId { get; set; }
}