using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class SupportService :ISupportService
{
    private readonly ISupportRepository _supportRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public SupportService(ISupportRepository supportRepository,IUnitOfWork unitOfWork)
    {
        _supportRepository = supportRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Support>> ListAsync()
    {
        return await _supportRepository.ListAsync();
    }

    public async Task<SupportResponse> SaveAsync(Support support)
    {
        
        try
        {
            await _supportRepository.AddAsync(support);
            await _unitOfWork.CompleteAsync();
            return new SupportResponse(support);
        }
        catch (Exception e)
        {
            return new SupportResponse($"An error occurred while saving the support: {e.Message}");
        }
    }

    public async Task<SupportResponse> DeleteAsync(int id)
    {
        var existingSupport = await _supportRepository.FindByIdAsync(id);
        
        if (existingSupport == null)
            return new SupportResponse("Support not found.");

        try
        {
            _supportRepository.Remove(existingSupport);
            await _unitOfWork.CompleteAsync();
            return new SupportResponse(existingSupport);
        }
        catch (Exception e)
        {
            return new SupportResponse($"An error occurred while saving the support: {e.Message}");
        }
    }
}