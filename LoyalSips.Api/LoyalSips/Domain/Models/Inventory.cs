namespace LoyalSips.Api.LoyalSips.Domain.Models;

public class Inventory
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public int netContent { get; set; }
    public int Price { get; set; }
    
    public int PointOfProduct { get; set; }
    
    /* Para la conexion que r */
    public int BarId { get; set; }
    public Bar Bar { get; set; }
}