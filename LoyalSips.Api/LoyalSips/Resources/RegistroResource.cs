namespace LoyalSips.Api.LoyalSips.Resources;

public class RegistroResource
{
    public int Id { get; set; } 
    public int puntosGanados { get; set; }
    public UserResource User { get; set; }
    public BarResource Bar  { get; set; }
}