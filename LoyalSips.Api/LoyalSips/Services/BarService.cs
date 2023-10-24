using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class BarService : IBarService
{
    private readonly IUserRepository _userRepository;
    private readonly IBarRepository _barRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public BarService(IUserRepository userRepository,IBarRepository barRepository,IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _barRepository = barRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Bar>> ListAsync()
    {
        return await _barRepository.ListAsync();
    }

    public async Task<BarResponse> SaveAsync(Bar bar)
    {
        // Validate CategoryId
        var existingUser = await _userRepository.FindByIdAsync(bar.OwnerId);
        if (existingUser == null)
            return new BarResponse($"Invalid Owner 2{bar.OwnerId}" );
        try
        {
            // Add bar
            await _barRepository.AddAsync(bar);

            // Complete Transaction
            await _unitOfWork.CompleteAsync();

            // Return response
            return new BarResponse(bar);
        }
        catch (Exception e)
        {
            // Error Handling
            return new BarResponse($"An error occurred while savingthe bar: {e.Message}");
        }
    }

    public async Task<BarResponse> UpdateAsync(int id, Bar bar)
    {
        var existingBar = await
            _barRepository.FindByIdAsync(id);

        // Validate Tutorial
        if (existingBar == null)
            return new BarResponse("bar not found.");
        
        // Validate OwnerId
        var existingUser = await
            _userRepository.FindByIdAsync(bar.OwnerId);
        if (existingUser == null)
            return new BarResponse("Invalid Owner");

        // Modify Fields
        existingBar.Name = bar.Name;
        existingBar.Description = bar.Description;
        existingBar.Logo = bar.Logo;
        try
        {
            _barRepository.Update(existingBar);
            await _unitOfWork.CompleteAsync();
            return new BarResponse(existingBar);

        }
        catch (Exception e)
        {
            // Error Handling
            return new BarResponse($"An error occurred while updatingthe bar: {e.Message}");
        }
    }

    public async Task<BarResponse> DeleteAsync(int id)
    {
        var existingBar = await
            _barRepository.FindByIdAsync(id);

        // Validate Tutorial
        if (existingBar == null)
            return new BarResponse("bar not found.");

        try
        {
            _barRepository.Remove(existingBar);
            await _unitOfWork.CompleteAsync();
            return new BarResponse(existingBar);

        }
        catch (Exception e)
        {
            // Error Handling
            return new BarResponse($"An error occurred while deletingthe bar: {e.Message}");
        }
    }
}