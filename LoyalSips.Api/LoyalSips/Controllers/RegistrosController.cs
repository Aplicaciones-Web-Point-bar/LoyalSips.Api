using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RegistrosController : ControllerBase
{
    private readonly IRegistroService _registroService;
    private readonly IMapper _mapper;

    public RegistrosController(IRegistroService registroService, IMapper mapper)
    {
        _registroService = registroService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<RegistroResource>> GetAllAsync()
    {
        var registroPoints = await _registroService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RegistroPoint>,
            IEnumerable<RegistroResource>>(registroPoints);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]
        SaveRegistroResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var registroPoint = _mapper.Map<SaveRegistroResource,
            RegistroPoint>(resource);
        
        var result = await _registroService.SaveAsync(registroPoint);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var registroResource = _mapper.Map<RegistroPoint,
            RegistroResource>(result.Resource);
        
        return Ok(registroResource);
    }
}