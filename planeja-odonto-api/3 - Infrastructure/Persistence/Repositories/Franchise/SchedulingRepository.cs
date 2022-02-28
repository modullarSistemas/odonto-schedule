using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class SchedulingRepository : BaseRepository, ISchedulingRepository
    {
        public SchedulingRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Scheduling>> ListAsync()
        {
            return await _context.Schedulings
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Scheduling scheduling)
        {
            await _context.Schedulings.AddAsync(scheduling);
        }

        public async Task<Scheduling> FindByIdAsync(int id)
        {
            return await _context.Schedulings.FindAsync(id);
        }

        public void Update(Scheduling scheduling)
        {
            _context.Schedulings.Update(scheduling);
        }

        public void Remove(Scheduling scheduling)
        {
            _context.Schedulings.Remove(scheduling);
        }
    }
}
