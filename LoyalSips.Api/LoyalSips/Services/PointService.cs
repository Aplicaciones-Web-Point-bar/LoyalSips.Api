using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class PointService : IPointService
{
    
    private readonly IPointRepository _pointRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PointService(IPointRepository pointRepository, IUnitOfWork unitOfWork)
    {
        _pointRepository = pointRepository;
        _unitOfWork = unitOfWork;

    }
    
    public async Task<IEnumerable<Point>> ListAsync()
    
    {
        return await _pointRepository.ListAsync();
    }

    public async Task<PointResponse> UpdateAsync(int id, Point point)
    {
        //Fix the file
        var existingPoint = await _pointRepository.FindByIdAsync(id);
        if (existingPoint == null)
            return new PointResponse("User not found.");
        existingPoint.Sale = point.Sale;
        existingPoint.Total = point.Total;
        existingPoint.Description = point.Description;
        existingPoint.OwnerId = point.OwnerId;
        try
        {
            _pointRepository.Update(existingPoint);
            await _unitOfWork.CompleteAsync();
            return new PointResponse(existingPoint);
        }
        catch (Exception e)
        {
            return new PointResponse($"An error occurred while updating the category:{e.Message}");
        }
    }


    public async Task<PointResponse> SaveAsync(Point point)
    {
        try
        {
            await _pointRepository.AddAsync(point);
            await _unitOfWork.CompleteAsync();
            return new PointResponse(point);
        }
        catch (Exception e)
        {
            return new PointResponse($"An error occurred while saving the support: {e.Message}");
        }
    }

    
    
    
    
    
}