using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PubsController : ControllerBase
{
    private readonly IBarService _barService;
    private readonly IMapper _mapper;

    public PubsController(IBarService barService, IMapper mapper)
    {
        _barService = barService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<BarResource>> GetAllAsync()
    {
        var pubs = await _barService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Bar>,
            IEnumerable<BarResource>>(pubs);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveBarResource resource)
    {
        //verifica si los datos recibidos de resource cumplen las reglas.
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        //mapea el java saveCategoryResource a un objeto CategoryLL
        var bar = _mapper.Map<SaveBarResource,
            Bar>(resource);
        
        //agrega la categoria mediante en categoryService, si falla da el mensaje de estado, o en que se incumplio
        var result = await _barService.SaveAsync(bar);
        if (!result.Success)
            return BadRequest(result.Message);
        
        //mapea el objeto CategoryLL a el json CategoryResource
        var barResource = _mapper.Map<Bar,
            BarResource>(result.Resource);
        
        //muestra la respuesta de OK(200) y la categoria creada en JSON
        return Ok(barResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveBarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var bar = _mapper.Map<SaveBarResource,
            Bar>(resource);
        var result = await _barService.UpdateAsync(id, bar);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var barResource = _mapper.Map<Bar,
            BarResource>(result.Resource);
        return Ok(barResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _barService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var barResource = _mapper.Map<Bar,
            BarResource>(result.Resource);
        return Ok(barResource);
    }
}