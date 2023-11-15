using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.LoyalSips.Persistence.Repositories;

public class SupportRepository : BaseRepository, ISupportRepository
{
    public SupportRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Support>> ListAsync()
    {
        return await _context.Supports
            .Include(p=>p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Support support)
    {
        // de la base de datos en la entidad soporte se agrega un nuevo soporte
        await _context.Supports.AddAsync(support);
    }

    public async Task<Support> FindByIdAsync(int id)
    {
        // de la base de datos en la entidad soporte se busca un soporte por su id
        return await _context.Supports
            .Include(p=>p.User)
            .FirstOrDefaultAsync(p=>p.Id==id);
    }

    public void Remove(Support support)
    {
        // de la base de datos en la entidad soporte se elimina un soporte
        _context.Supports.Remove(support);
    }
}