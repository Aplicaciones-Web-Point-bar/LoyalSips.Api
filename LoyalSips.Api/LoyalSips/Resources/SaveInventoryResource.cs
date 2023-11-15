using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.LoyalSips.Resources;

public class SaveInventoryResource
{
    /* lo que se muestra en el swagger como valores requeridos */
    /* Colocamos de acuerdo al enunciado, los datos que son requeridos */
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Category { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public int netContent { get; set; }
    
    [Required]
    public int Price { get; set; }
    
}