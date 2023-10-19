using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class BarResponse : BaseResponse<Bar>
{
    public BarResponse(string message) : base(message)
    {
    }

    public BarResponse(Bar resource) : base(resource)
    {
    }
}