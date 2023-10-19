using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IBarRepository //contrato o interfaz para que una clase deba seguirlo si desea actuar como un repositorio.
{
    Task<IEnumerable<Bar>> ListAsync(); //recuperar lista de objetos
    Task AddAsync(Bar bar); //agregar un bar a la lista 
    Task<Bar> FindByIdAsync(int id); //buscar un bar en la lista por su id
    void Update(Bar bar); //metodo para actualizar un bar 
    void Remove(Bar bar); //metodo para eliminar un bar
}