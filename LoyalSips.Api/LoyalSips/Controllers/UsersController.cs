using AutoMapper;
using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Resources;
using LoyalSips.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LoyalSips.Api.LoyalSips.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<UserResource>> GetAllAsync()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>,
            IEnumerable<UserResource>>(users);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
    {
        //verifica si los datos recibidos de resource cumplen las reglas.
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        //mapea el java saveCategoryResource a un objeto CategoryLL
        var user = _mapper.Map<SaveUserResource, User>(resource);
        
        //agrega la categoria mediante en categoryService, si falla da el mensaje de estado, o en que se incumplio
        var result = await _userService.SaveAsync(user);
        if (!result.Success)
            return BadRequest(result.Message);
        
        //mapea el objeto CategoryLL a el json CategoryResource
        var userResource = _mapper.Map<User,
            UserResource>(result.Resource);
        
        //muestra la respuesta de OK(200) y la categoria creada en JSON
        return Ok(userResource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var user = _mapper.Map<SaveUserResource,
            User>(resource);
        var result = await _userService.UpdateAsync(id, user);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var userResource = _mapper.Map<User,
            UserResource>(result.Resource);
        return Ok(userResource);
    }
    
    
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _userService.DeleteAsync(id);
        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User,
            UserResource>(result.Resource);
        return Ok(userResource);
    }
}