using LoyalSips.Api.LoyalSips.Domain.Models;

namespace LoyalSips.Api.LoyalSips.Domain.Repositories;

public interface IInventoryRepository
{
    // listar todos los productos del inventario
    Task<IEnumerable<Inventory>> ListAsync();
    
    // agregar un nuevo producto al inventario
    Task AddAsync(Inventory inventory);
    
    // eliminar un producto del inventario
    void RemoveProduct(Inventory inventory);
    
    // encontrar un producto por su id
    Task<Inventory> FindByIdAsync(int id);
    
    // encontrar un producto por su nombre
    Task<Inventory> FindByInventoryNameAsync(string inventoryName);
    
    // actualizar el precio de un producto del inventario
    void Update(Inventory inventory);
    
    
    // encontrar un producto por categoria
    Task<List<Inventory>> FindByInventoryCategoryAsync(string inventoryCategory);
    
    // encontrar un producto por su contenido neto
    Task<Inventory> FindByInventoryNetContentAsync(int inventoryNetContent);
    
    
    
}