using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface IBarService
{
    Task<IEnumerable<Bar>> ListAsync();
    Task<BarResponse> SaveAsync(Bar bar); //agregar una nueva categoria y devuelve un response osea la informacion de el estado de la operación
    Task<BarResponse> UpdateAsync(int id, Bar bar); //modifica la categoria con un id y clase categoria dada, devuelve el estado de operación
    Task<BarResponse> DeleteAsync(int id); //elimina una categoria de la lista mediante el id, devuelve el estado de operación
}
