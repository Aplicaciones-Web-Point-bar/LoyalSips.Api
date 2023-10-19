using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<UserResponse> SaveAsync(User user); //agregar una nueva categoria y devuelve un response osae la informacion dl estado de la operación
    Task<UserResponse> UpdateAsync(int id, User user); //modifica la categoria con un id y clase categoria dada, devuelve el estado de operación
    Task<UserResponse> DeleteAsync(int id); //elimina una categoria de la lista mediante el id, devuelve el estado de operación
}