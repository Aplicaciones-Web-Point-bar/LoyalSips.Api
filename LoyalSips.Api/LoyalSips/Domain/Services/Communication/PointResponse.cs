using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class PointResponse : BaseResponse<Point>
{
    public PointResponse(string message) : base(message)
    {
        
    }
    
    public PointResponse(Point resource) : base(resource)
    {
        
    }
}