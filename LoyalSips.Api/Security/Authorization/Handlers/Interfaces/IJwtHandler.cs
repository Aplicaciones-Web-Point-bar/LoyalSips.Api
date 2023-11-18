using LoyalSips.Api.Security.Domain.Models;

namespace LoyalSips.Api.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}