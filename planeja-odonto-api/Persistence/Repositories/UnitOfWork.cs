using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlanejaOdontoDbContext _context;

        public UnitOfWork(PlanejaOdontoDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
