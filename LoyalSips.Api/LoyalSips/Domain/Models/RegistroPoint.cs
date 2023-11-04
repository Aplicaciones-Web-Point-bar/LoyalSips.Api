namespace LoyalSips.Api.LoyalSips.Domain.Models;

public class RegistroPoint
{
    public int Id { get; set; } 
    
    public int puntosGanados { get; set; }
    
    public int BarId { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public Bar Bar  { get; set; }
}