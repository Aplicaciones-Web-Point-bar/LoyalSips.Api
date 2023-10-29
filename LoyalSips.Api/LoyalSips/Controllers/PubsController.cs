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
    [HttpGet("{id}")]
    public async Task<BarResource> GetAllAsyncId(int id)
    {
        var pubs = await _barService.ListByIdAsync(id);
        var resources = _mapper.Map<Bar,
            BarResource>(pubs);
        return resources;
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]
        SaveBarResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var tutorial = _mapper.Map<SaveBarResource,
            Bar>(resource);
        
        var result = await _barService.SaveAsync(tutorial);
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tutorialResource = _mapper.Map<Bar,
            BarResource>(result.Resource);
        
        return Ok(tutorialResource);
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