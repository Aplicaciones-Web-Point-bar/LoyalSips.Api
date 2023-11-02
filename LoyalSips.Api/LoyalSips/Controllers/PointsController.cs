using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]

public class PointsController : ControllerBase
{
    private readonly IPointService _pointService;
    private readonly IMapper _mapper;
    
    public PointsController(IPointService pointService, IMapper mapper)
    {
        _pointService = pointService;
        _mapper = mapper;
    }
    
    
    //obtiene todos los supports
    [HttpGet]
    
    public async Task<IEnumerable<PointResource>> GetAllAsync()
    {
        var points = await _pointService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Point>, 
            IEnumerable<PointResource>>(points);
        return resources;
    }
    
    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePointResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var point = _mapper.Map<SavePointResource, Point>(resource);
        var result = await _pointService.SaveAsync(point);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var pointResource = _mapper.Map<Point,
            PointResource>(result.Resource);
        
        return Ok(pointResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePointResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var point = _mapper.Map<SavePointResource,
            Point>(resource);
        var result = await _pointService.UpdateAsync(id, point);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var pointResource = _mapper.Map<Point, PointResource>(result.Resource);
        return Ok(pointResource);
    }
}