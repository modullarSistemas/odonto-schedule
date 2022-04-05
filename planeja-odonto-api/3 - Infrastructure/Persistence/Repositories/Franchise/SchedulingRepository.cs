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

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class SchedulingRepository : BaseRepository, ISchedulingRepository
    {
        public SchedulingRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }



        public async Task<IEnumerable<Scheduling>> ListByDentistIdAsync(int id)
        {
            return await _context.Schedulings
                     .AsNoTracking()
                     .Include(x => x.Pacient)
                     .Include(y => y.Dentist)
                     .Include(x => x.ProcedureType)
                     .Where(x=>x.Dentist.UserId == id)
                     .ToListAsync();
        }

        public async Task<IEnumerable<Scheduling>> ListByFranchiseIdAsync(int id)
        {
            return await _context.Schedulings
                     .AsNoTracking()
                     .Include(x=>x.Pacient)
                     .Include(y=>y.Dentist)
                     .Include(x=>x.ProcedureType)
                     .Where(x => x.Pacient.FranchiseId == id)
                     .ToListAsync();
        }

        public async Task<IEnumerable<Scheduling>> ListAsync()
        {
            return await _context.Schedulings
                                 .AsNoTracking()
                                 .Include(x => x.Pacient)
                                 .Include(y => y.Dentist)
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
            return await _context.Schedulings
                .Include(x=>x.Dentist)
                .Include(x=>x.Pacient)
                .FirstOrDefaultAsync(x=>x.Id == id);
        }


        public  Task<Scheduling> CheckDateAvailability(Scheduling newScheduling)
        {
            return  _context.Schedulings
                .Include(x=>x.Dentist)
                .FirstOrDefaultAsync(x => newScheduling.StartDate >= x.StartDate
                                     &&   newScheduling.StartDate <= x.EndDate
                                     &&   x.DentistId ==  newScheduling.DentistId);
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
