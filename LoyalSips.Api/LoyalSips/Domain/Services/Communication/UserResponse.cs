using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}