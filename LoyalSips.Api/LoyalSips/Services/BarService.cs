using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class BarService : IBarService
{
    private readonly IBarRepository _barRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public BarService(IBarRepository barRepository,IUnitOfWork unitOfWork)
    {
        _barRepository = barRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Bar>> ListAsync()
    {
        return await _barRepository.ListAsync();
    }
    public async Task<Bar> ListByIdAsync(int id)
    {
        return await _barRepository.FindByIdAsync(id);;
    }

    public async Task<BarResponse> SaveAsync(Bar bar)
    {
 
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
        


        // Modify Fields
        existingBar.Name = bar.Name;
        existingBar.Description = bar.Description;
        existingBar.Logo = bar.Logo;
        existingBar.Fotos = bar.Fotos;
        existingBar.Puntaje = bar.Puntaje;
        existingBar.Ubicacion = bar.Ubicacion;
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
            return new BarResponse($"An error occurred while deleting the bar: {e.Message}");
        }
    }
}