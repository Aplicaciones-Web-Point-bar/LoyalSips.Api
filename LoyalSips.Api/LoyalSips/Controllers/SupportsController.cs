using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]

public class SupportsController : ControllerBase
{
    private readonly ISupportService _supportService;
    private readonly IMapper _mapper;
    
    public SupportsController(ISupportService supportService, IMapper mapper)
    {
        _supportService = supportService;
        _mapper = mapper;
    }
    
    //obtiene todos los supports
    [HttpGet]
    
    public async Task<IEnumerable<SupportResource>> GetAllAsync()
    {
        var supports = await _supportService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Support>, IEnumerable<SupportResource>>(supports);
        return resources;
    }
    
    
    // add informacion es decir un añade un support
    [HttpPost]
    
    public async Task<IActionResult> PostAsync([FromBody] 
        SaveSupportResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var support = _mapper.Map<SaveSupportResource,
            Support>(resource);
        
        var result = await _supportService.SaveAsync(support);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var supportResource = _mapper.Map<Support,
            SupportResource>(result.Resource);
        
        return Ok(supportResource);
    }
    
    // elimina un support por su ID
    [HttpDelete("{id}")]
    
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _supportService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var supportResource = _mapper.Map<Support,
            SupportResource>(result.Resource);
        
        return Ok(supportResource);
    }
    
}