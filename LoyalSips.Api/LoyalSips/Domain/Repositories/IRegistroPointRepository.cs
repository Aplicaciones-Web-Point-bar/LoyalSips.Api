using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IRegistroPointRepository
{
    Task<IEnumerable<RegistroPoint>> ListAsync();
    
    Task AddAsync(RegistroPoint registroPoint);
    
    Task<RegistroPoint> FindByIdAsync(int id);
}