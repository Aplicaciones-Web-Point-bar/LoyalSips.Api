using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IPointRepository
{
    Task<IEnumerable<Point>> ListAsync(); //recuperar lista de objetos
    
    Task<Point?> FindByIdAsync(int id); //buscar un usuario en la lista por su id
    
    void Update(Point point); //metodo para actualizar punto un bar 


    Task AddAsync(Point point);
}