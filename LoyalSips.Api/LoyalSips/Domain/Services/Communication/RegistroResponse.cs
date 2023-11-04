using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class RegistroResponse: BaseResponse<RegistroPoint>
{
    public RegistroResponse(string message) : base(message)
    {
    }

    public RegistroResponse(RegistroPoint resource) : base(resource)
    {
    }
}