using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace  LoyalSips.Api.LoyalSips.Persistence.Repositories;

public class BarRepository : BaseRepository, IBarRepository
{
    public BarRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bar>> ListAsync()
    {
        return await _context.Pubs
            .Include(p=>p.Owner)
            .ToListAsync();
    }

    public async Task AddAsync(Bar bar)
    {
        await _context.Pubs.AddAsync(bar);
    }

    public async Task<Bar> FindByIdAsync(int barId)
    {
        return await _context.Pubs
            .Include(p => p.Owner)
            .FirstOrDefaultAsync(p => p.Id == barId);
    }

    public void Update(Bar bar)
    {
        _context.Pubs.Update(bar);
    }

    public void Remove(Bar bar)
    {
        _context.Pubs.Remove(bar);
    }
}