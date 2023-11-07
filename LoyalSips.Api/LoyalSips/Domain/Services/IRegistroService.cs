using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface IRegistroService
{
    Task<IEnumerable<RegistroPoint>> ListAsync();
    
    Task<RegistroResponse> SaveAsync(RegistroPoint registroPoint);
    
    Task<RegistroPoint> ListByIdAsync(int id);
}