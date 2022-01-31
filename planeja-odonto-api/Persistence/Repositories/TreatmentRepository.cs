using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using PlanejaOdonto.Api.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class TreatmentRepository : BaseRepository, ITreatmentRepository
    {
        public TreatmentRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Treatment>> ListAsync()
        {
            return await _context.Treatments
                                 .Include(x=>x.Installments)
                                 .Include(y=>y.Procedures)
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Treatment franchisee)
        {
            await _context.Treatments.AddAsync(franchisee);
        }

        public async Task<Treatment> FindByIdAsync(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public void Update(Treatment franchisee)
        {
            _context.Treatments.Update(franchisee);
        }

        public void Remove(Treatment franchisee)
        {
            _context.Treatments.Remove(franchisee);
        }
    }
}
