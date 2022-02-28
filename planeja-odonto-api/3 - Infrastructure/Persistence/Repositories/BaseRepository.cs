using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PlanejaOdontoDbContext _context;

        public BaseRepository(PlanejaOdontoDbContext context)
        {
            _context = context;
        }
    }
}

