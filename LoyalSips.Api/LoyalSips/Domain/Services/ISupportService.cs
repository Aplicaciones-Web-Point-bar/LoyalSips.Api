using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface ISupportService
{
    Task<IEnumerable<Support>> ListAsync();
    Task<SupportResponse> SaveAsync(Support support);  // agregar un nuevo soporte y devuelve un response osea la informacion dl estado de la operación
    Task<SupportResponse> DeleteAsync(int id); // elimina un soporte de la lista mediante el id, devuelve el estado de operación
}