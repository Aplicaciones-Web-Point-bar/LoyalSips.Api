using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.LoyalSips.Persistence.Repositories;

public class RegistroRepository : BaseRepository, IRegistroPointRepository
{
    public RegistroRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RegistroPoint>> ListAsync()
    {
        return await _context.RegistroPoints
            .Include(p=>p.Bar)
            .ToListAsync();
    }

    public async Task AddAsync(RegistroPoint registroPoint)
    {
        await _context.RegistroPoints.AddAsync(registroPoint);
    }

    public async Task<RegistroPoint> FindByIdAsync(int id)
    {
        return await _context.RegistroPoints
            .Include(p => p.Bar)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}