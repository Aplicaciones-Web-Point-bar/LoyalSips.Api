namespace LoyalSips.Api.LoyalSips.Domain.Models;

public class Bar
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }

    public List<string> Fotos { get; set; } = new List<string>();
    
    public int Puntaje { get; set; }
    
    public string Ubicacion { get; set; }
    
    public int OwnerId { get; set; }
    public User Owner { get; set; }
}