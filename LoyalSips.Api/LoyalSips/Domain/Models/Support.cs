namespace LoyalSips.Api.LoyalSips.Domain.Models;

public class Support
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    // al realizar una pregunta se necesitara de el nombre de usuario y la contraseña
    
    public int UserId { get; set; }
    
    //public User Password { get; set; }
    
}