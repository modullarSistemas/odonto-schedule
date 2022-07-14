using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories.Scheduling
{
    public class ProcedureSchedulingRepository : BaseRepository, IProcedureSchedulingRepository
    {
        public ProcedureSchedulingRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }



        public async Task<IEnumerable<ProcedureScheduling>> ListByDentistIdAsync(int id)
        {
            return await _context.ProcedureSchedulings
                     .AsNoTracking()
                     .Include(x => x.Pacient)
                     .Include(y => y.Dentist)
                     .Include(x => x.ProcedureType)
                     .Where(x=>x.Dentist.Id == id)
                     .ToListAsync();
        }

        public async Task<IEnumerable<ProcedureScheduling>> ListByFranchiseIdAsync(int id)
        {
            return await _context.ProcedureSchedulings
                     .AsNoTracking()
                     .Include(x=>x.Pacient)
                     .Include(y=>y.Dentist)
                     .Include(x=>x.ProcedureType)
                     .Where(x => x.Pacient.FranchiseId == id)
                     .ToListAsync();
        }

        public async Task<IEnumerable<ProcedureScheduling>> ListAsync()
        {
            return await _context.ProcedureSchedulings
                                 .AsNoTracking()
                                 .Include(x => x.Pacient)
                                 .Include(y => y.Dentist)
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(ProcedureScheduling scheduling)
        {
            await _context.ProcedureSchedulings.AddAsync(scheduling);
        }

        public async Task<ProcedureScheduling> FindByIdAsync(int id)
        {
            return await _context.ProcedureSchedulings
                .Include(x=>x.Dentist)
                .Include(x=>x.Pacient)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }


        public  Task<ProcedureScheduling> CheckDateAvailability(ProcedureScheduling newScheduling)
        {
            return  _context.ProcedureSchedulings
                .Include(x=>x.Dentist)
                .FirstOrDefaultAsync(x => newScheduling.StartDate >= x.StartDate
                                     &&   newScheduling.StartDate <= x.EndDate
                                     &&   x.DentistId ==  newScheduling.DentistId);
        }

        public void Update(ProcedureScheduling scheduling)
        {
            _context.ProcedureSchedulings.Update(scheduling);
        }

        public void Remove(ProcedureScheduling scheduling)
        {
            _context.ProcedureSchedulings.Remove(scheduling);
        }


    }
}
