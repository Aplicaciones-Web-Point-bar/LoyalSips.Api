using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.LoyalSips.Persistence.Repositories;

public class InventoryRepository : BaseRepository, IInventoryRepository
{
    public InventoryRepository(AppDbContext context) : base(context)
    {
    }

    // list of all products
    public async Task<IEnumerable<Inventory>> ListAsync()
    {
        return await _context.Inventories.ToListAsync();
    }

    // add a new product to the inventory
    public async Task AddAsync(Inventory inventory)
    {
        await _context.Inventories.AddAsync(inventory);
    }

    // remove a product from the inventory
    public void RemoveProduct(Inventory inventory)
    {
        _context.Inventories.Remove(inventory);
    }

    // find a product by its id
    public async Task<Inventory> FindByIdAsync(int id)
    {
        return await _context.Inventories.FindAsync(id);
    }
    
    // find a product by its name
    public async Task<Inventory> FindByInventoryNameAsync(string inventoryName)
    {
        // No se permite que se registre 2 producto con el mismo nombre
        return await _context.Inventories.FirstOrDefaultAsync(p => p.Name == inventoryName);
    }

    // update the price of a product in the inventory
    public void Update(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
    }

    // find a product by category
    public Task<List<Inventory>> FindByInventoryCategoryAsync(string inventoryCategory)
    {
        return _context.Inventories.Where(p => p.Category == inventoryCategory).ToListAsync();
    }

    public Task<Inventory> FindByInventoryNetContentAsync(int inventoryNetContent)
    {
        return _context.Inventories.FirstOrDefaultAsync(p => p.netContent == inventoryNetContent);
    }
    
}