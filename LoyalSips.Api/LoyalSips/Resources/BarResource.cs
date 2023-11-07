namespace LoyalSips.Api.LoyalSips.Resources;

public class BarResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public List<string> Fotos { get; set; }
    public int Puntaje { get; set; }
    public string Ubicacion { get; set; }
    public UserResource Owner { get; set; }
}