using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class SupportResponse : BaseResponse<Support>
{
    public SupportResponse(string message) : base(message)
    {
        
    }
    
    public SupportResponse(Support resource) : base(resource)
    {
        
    }
}