using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Domain.Services;

public interface IPointService
{
    Task<IEnumerable<Point>> ListAsync();
    
    Task<PointResponse> UpdateAsync(int id, Point point); //actualiza el puntaje
    Task<PointResponse> SaveAsync(Point point);
}