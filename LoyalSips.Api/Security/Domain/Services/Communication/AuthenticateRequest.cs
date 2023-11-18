using System.ComponentModel.DataAnnotations;

namespace LoyalSips.Api.Security.Domain.Services.Communication;

public class AuthenticateRequest
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}