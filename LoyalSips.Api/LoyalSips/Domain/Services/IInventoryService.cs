using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface IInventoryService
{
    // listar todos los productos del inventario
    Task<IEnumerable<Inventory>> ListAsync();
    
    // agregar un nuevo producto al inventario
    Task<InventoryResponse> SaveAsync(Inventory inventory);
    
    // eliminar un producto del inventario
    Task<InventoryResponse> DeleteAsync(int id);
    
    // listar un producto por su nombre
    Task<Inventory> ListByNameAsync(string inventoryName);
    
}