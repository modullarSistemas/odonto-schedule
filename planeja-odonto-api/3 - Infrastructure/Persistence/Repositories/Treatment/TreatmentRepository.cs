using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        public TreatmentRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Treatment>> ListAsync()
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y=>y.ProcedureType)
                                  .Include(y=>y.Procedures)
                                    .ThenInclude(x=>x.Prothesis)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .Where(x => x.Pacient.Id == id)
                                 .AsNoTracking()
                                 .ToListAsync();

        }
        public async Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                    .ThenInclude(y => y.ProcedureType)
                                  .Include(y => y.Procedures)
                                    .ThenInclude(x => x.Prothesis)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .Where(x => x.Pacient.FranchiseId == id)
                                 .ToListAsync();
        }

        public async Task AddAsync(Treatment franchisee)
        {
            await _context.Treatments.AddAsync(franchisee);
        }

        public async Task<Treatment> FindByIdAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Procedures)
                                 .Include(x => x.Installments)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Treatment> FindByIdTrackingAsync(int id)
        {
            return await _context.Treatments
                                 .Include(x => x.Procedures)
                                 .Include(x => x.Pacient)
                                 .Include(x => x.Installments)
                                 .FirstOrDefaultAsync(x => x.Id == id);
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
