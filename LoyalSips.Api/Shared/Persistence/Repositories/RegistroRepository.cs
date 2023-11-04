using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.API.Shared.Persistence.Repositories;

public class RegistroRepository : BaseRepository, IRegistroPointRepository
{
    public RegistroRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<RegistroPoint>> ListAsync()
    {
        return await _context.RegistroPoints
            .Include(p=>p.Bar)
            .Include(p=>p.User)
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
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}