using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface ISupportRepository
{
    Task<IEnumerable<Support>> ListAsync(); //recuperar lista de objetos | recupera los atributos de la clase support
    Task AddAsync(Support support); //agregar un soporte a la lista | agrega una pregunta que un usuario hizo
    
    Task<Support> FindByIdAsync(int id); //buscar un soporte en la lista por su id | busca una pregunta que un usuario hizo
    
    void Remove(Support support); //metodo para eliminar un soporte | elimina una pregunta que un usuario hizo
    
}