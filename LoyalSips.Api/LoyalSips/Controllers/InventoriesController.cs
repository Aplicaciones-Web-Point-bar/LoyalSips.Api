using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]

public class InventoriesController : ControllerBase
{
    
    private readonly IInventoryService _inventoryService;
    private readonly IMapper _mapper;
    
    public InventoriesController(IInventoryService inventoryService, IMapper mapper)
    {
        _inventoryService = inventoryService;
        _mapper = mapper;
    }
    
    /*agregamos metodo GET (lo que se muestra en el swagger)*/
    [HttpGet]
    public async Task<IEnumerable<InventoryResource>> GetAllAsync()
    {
        var inventories = await _inventoryService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryResource>>(inventories);
        return resources;
    }
    
    [HttpGet("{id}")]

    public async Task<InventoryResource> GetAllAsyncId(int id)
    {
        var inventories = await _inventoryService.ListByIdAsync(id);
        var resources = _mapper.Map<Inventory, InventoryResource>(inventories);
        return resources;
    }
    
    /*agregamos metodo POST (lo que se muestra en el swagger)*/
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveInventoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var inventory = _mapper.Map<SaveInventoryResource, Inventory>(resource);

        var result = await _inventoryService.SaveAsync(inventory);

        if (!result.Success)
            return BadRequest(result.Message);

        var inventoryResource = _mapper.Map<Inventory, InventoryResource>(result.Resource);

        return Ok(inventoryResource);
    }
    
    /* Agregamos el metodo PUT (lo que se muestra en el swagger) */
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveInventoryResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var inventory = _mapper.Map<SaveInventoryResource, Inventory>(resource);
        var result = await _inventoryService.UpdateAsync(id, inventory);

        if (!result.Success)
            return BadRequest(result.Message);

        var inventoryResource = _mapper.Map<Inventory, InventoryResource>(result.Resource);
        return Ok(inventoryResource);
    }
    
    /* Agregamos el metodo DELETE (lo que se muestra en el swagger) */
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _inventoryService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var inventoryResource = _mapper.Map<Inventory, InventoryResource>(result.Resource);
        return Ok(inventoryResource);
    }
    
}