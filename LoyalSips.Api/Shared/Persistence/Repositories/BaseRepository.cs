using LoyalSips.Api.Shared.Persistence.Contexts;

namespace LoyalSips.API.Shared.Persistence.Repositories;
public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}