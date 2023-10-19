using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IUserRepository //contrato o interfaz para que una clase deba seguirlo si desea actuar como un repositorio.
{
    Task<IEnumerable<User>> ListAsync(); //recuperar lista de objetos
    Task AddAsync(User user); //agregar un usuario a la lista 
    Task<User> FindByIdAsync(int id); //buscar un usuario en la lista por su id
    void Update(User user); //metodo para actualizar un usuario 
    void Remove(User user); //metodo para eliminar un usuario
}