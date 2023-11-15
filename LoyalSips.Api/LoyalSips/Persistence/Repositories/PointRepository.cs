using LoyalSips.Api.LoyalSips.Domain.Models;
using LoyalSips.Api.LoyalSips.Domain.Repositories;
using LoyalSips.Api.Shared.Persistence.Contexts;
using LoyalSips.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoyalSips.Api.LoyalSips.Persistence.Repositories;

public class PointRepository : BaseRepository, IPointRepository
{
    public PointRepository(AppDbContext context) : base(context)
     {
     }
    
    public async Task<IEnumerable<Point>> ListAsync()
    {
        return await _context.Points.ToListAsync();
    }
    
    public async Task<Point> FindByIdAsync(int id)
    {
        return await _context.Points.FindAsync(id);
    }

    public async Task AddAsync(Point point)
        {
            await _context.Points.AddAsync(point);
        }
    
    
    
    public void Update(Point point)
    {
        _context.Points.Update(point);
    }

    
}