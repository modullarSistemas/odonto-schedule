using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class ProcedureRepository : BaseRepository, IProcedureRepository
    {
        public ProcedureRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Procedure>> ListAsync()
        {
            return await _context.Procedures
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task<IEnumerable<Procedure>> ListByTreatmentIdAsync(int treatmentId)
        {
            return await _context.Procedures
                                 .Where(x=>x.TreatmentId == treatmentId)
                                 .AsNoTracking()
                                 .ToListAsync()
                                 ;
        }

        public async Task AddAsync(Procedure franchisee)
        {
         var result  =    await _context.Procedures.AddAsync(franchisee);
        }

        public async Task<Procedure> FindByIdAsync(int id)
        {
            return await _context.Procedures.FindAsync(id);
        }

        public void Update(Procedure franchisee)
        {
            _context.Procedures.Update(franchisee);
        }

        public void Remove(Procedure franchisee)
        {
            _context.Procedures.Remove(franchisee);
        }
    }
}
