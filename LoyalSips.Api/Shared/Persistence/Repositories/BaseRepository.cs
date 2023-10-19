using LearningCenter2.API.Shared.Persistence.Contexts;

namespace LearningCenter2.API.Shared.Persistence.Repositories;
public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}