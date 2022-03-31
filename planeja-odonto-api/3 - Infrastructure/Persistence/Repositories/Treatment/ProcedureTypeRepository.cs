using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class ProcedureTypeRepository : BaseRepository, IProcedureTypeRepository
    {
        public ProcedureTypeRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<ProcedureType>> ListAsync()
        {
            return await _context.ProcedureTypes
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(ProcedureType franchisee)
        {
            await _context.ProcedureTypes.AddAsync(franchisee);
        }

        public async Task<ProcedureType> FindByIdAsync(int id)
        {
            return await _context.ProcedureTypes.FindAsync(id);
        }

        public void Update(ProcedureType franchisee)
        {
            _context.ProcedureTypes.Update(franchisee);
        }

        public void Remove(ProcedureType franchisee)
        {
            _context.ProcedureTypes.Remove(franchisee);
        }
    }
}
