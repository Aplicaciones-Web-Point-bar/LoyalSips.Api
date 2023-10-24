namespace LoyalSips.Api.LoyalSips.Resources;

public class BarResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public UserResource Owner { get; set; }
}