namespace LoyalSips.Api.LoyalSips.Resources;

public class SupportResource
{
    //lo que muestra en el swagger/ el orden
    //debe estar igual que la clase definida
    //inicialmente
    
    public int Id { get; set; }
    public string Description { get; set; }
    public UserResource User { get; set; }
    
}