using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class InventoryService : IInventoryService
{
    private readonly IBarRepository _barRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork, IBarRepository barRepository)
    {
        _inventoryRepository = inventoryRepository;
        _barRepository = barRepository;
        _unitOfWork = unitOfWork;
        
    }
    
    
    // reglas de negocio  o logica de negocio
    
    // lista los productos del inventario
    public async Task<IEnumerable<Inventory>> ListAsync()
    {
        return await _inventoryRepository.ListAsync();
    }
    
    public async Task<Inventory> ListByIdAsync(int id)
    {
        return await _inventoryRepository.FindByIdAsync(id);
    }

    // añade productos al inventario con validacion de pormedio
    public async Task<InventoryResponse> SaveAsync(Inventory inventory)
    {
        // no se permite que se añadan productos con la combinacion de nombre, categoria y netContent
        var existingName = await _inventoryRepository.FindByInventoryNameAsync(inventory.Name);
        var existingCategory = await _inventoryRepository.FindByInventoryCategoryAsync(inventory.Category);
        var existingNetContent = await _inventoryRepository.FindByInventoryNetContentAsync(inventory.netContent);
        var existingBar = await _barRepository.FindByIdAsync(inventory.BarId);
        
        if (existingBar == null)
            return new InventoryResponse($"Invalid Bar 2{inventory.BarId}");
        
        if (existingName != null && existingCategory != null && existingNetContent != null)
            return new InventoryResponse("Ya existe un producto con ese nombre, categoria y netContent");

        try
        {
            await _inventoryRepository.AddAsync(inventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(inventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while saving the inventory: {e.Message}");

        }
        
    }
    
    /*
    // lista productos por su nombre
    public async Task<Inventory> ListByNameAsync(string inventoryName)
    {
        // retornar un producto por su nombre
        return await _inventoryRepository.FindByInventoryNameAsync(inventoryName);
    }*/
    
    public async Task<InventoryResponse> UpdateAsync(int id, Inventory inventory)
    {
        var existingInventory = await _inventoryRepository.FindByIdAsync(id);
        if (existingInventory == null)
            return new InventoryResponse("Inventory not found.");
        
        // validate BarId
        var existingBar = await _barRepository.FindByIdAsync(inventory.BarId);
        
        if (existingBar == null)
            return new InventoryResponse($"Invalid Bar");
        
        existingInventory.Name = inventory.Name;
        existingInventory.Category = inventory.Category;
        existingInventory.netContent = inventory.netContent;
        existingInventory.Price = inventory.Price;
        existingInventory.Quantity = inventory.Quantity;
        
        try
        {
            _inventoryRepository.Update(existingInventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(existingInventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while updating the inventory:{e.Message}");
        }
    }
    
    
    public async Task<InventoryResponse> DeleteAsync(int id)
    {
        var existingInventory = await _inventoryRepository.FindByIdAsync(id);
        if (existingInventory == null)
            return new InventoryResponse("Inventory not found.");
        try
        {
            _inventoryRepository.RemoveProduct(existingInventory);
            await _unitOfWork.CompleteAsync();
            return new InventoryResponse(existingInventory);
        }
        catch (Exception e)
        {
            return new InventoryResponse($"An error occurred while deleting the inventory:{e.Message}");
        }
    }


}