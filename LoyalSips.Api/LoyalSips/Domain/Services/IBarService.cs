using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communucation;

public interface IBarService
{
    Task<IEnumerable<Bar>> ListAsync();
    Task<CategoryResponse> SaveAsync(Bar category); //agregar una nueva categoria y devuelve un response osae la informacion dl estado de la operación
    Task<CategoryResponse> UpdateAsync(int id, Bar category); //modifica la categoria con un id y clase categoria dada, devuelve el estado de operación
    Task<CategoryResponse> DeleteAsync(int id); //elimina una categoria de la lista mediante el id, devuelve el estado de operación
}
