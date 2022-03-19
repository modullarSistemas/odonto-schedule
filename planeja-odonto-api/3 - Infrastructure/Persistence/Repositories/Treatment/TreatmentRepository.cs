using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class TreatmentRepository : BaseRepository, ITreatmentRepository
    {
        public TreatmentRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Treatment>> ListAsync()
        {
            return await _context.Treatments
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Where(x => x.PacientId == id)
                                 .ToListAsync();

        }
        public async Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Where(x => x.Pacient.FranchiseId == id)
                                 .ToListAsync();
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
