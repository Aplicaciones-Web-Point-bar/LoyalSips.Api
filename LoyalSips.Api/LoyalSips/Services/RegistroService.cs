using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.LoyalSips.Domain.Services;
using LoyalSips.Api.LoyalSips.Domain.Services.Communication;

namespace LoyalSips.Api.LoyalSips.Services;

public class RegistroService : IRegistroService
{
    private readonly IRegistroPointRepository _iRegistroPointRepository;
    private readonly IBarRepository _barRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistroService(IRegistroPointRepository iRegistroPointRepository, IBarRepository barRepository, IUnitOfWork unitOfWork)
    {
        _iRegistroPointRepository = iRegistroPointRepository;
        _barRepository = barRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RegistroPoint>> ListAsync()
    {
        return await _iRegistroPointRepository.ListAsync();
    }

    public async Task<RegistroResponse> SaveAsync(RegistroPoint registroPoint)
    {
        await _iRegistroPointRepository.AddAsync(registroPoint);
        await _unitOfWork.CompleteAsync();
        return new RegistroResponse(registroPoint);
    }

    public async Task<RegistroPoint> ListByIdAsync(int id)
    {
        return await _iRegistroPointRepository.FindByIdAsync(id);;
    }
}