using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.API.Shared.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services.Communication;

public class InventoryResponse : BaseResponse<Inventory>
{
    public InventoryResponse(string message) : base(message)
    {
    }

    public InventoryResponse(Inventory resource) : base(resource)
    {
    }
}