using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;
using PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories.Scheduling
{
    public class EvaluationSchedulingRepository : BaseRepository, IEvaluationSchedulingRepository
    {
        public EvaluationSchedulingRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }


        public async Task<IEnumerable<EvaluationScheduling>> ListByFranchiseIdAsync(int id)
        {
            return await _context.EvaluationSchedulings
                     .AsNoTracking()
                     .Where(x => x.FranchiseId == id)
                     .ToListAsync();
        }


        public async Task AddAsync(EvaluationScheduling scheduling)
        {
            await _context.EvaluationSchedulings.AddAsync(scheduling);
        }

        public async Task<EvaluationScheduling> FindByIdAsync(int id)
        {
            return await _context.EvaluationSchedulings
                .FirstOrDefaultAsync(x=>x.Id == id);
        }


        public  Task<EvaluationScheduling> CheckDateAvailability(EvaluationScheduling newScheduling)
        {
            return  _context.EvaluationSchedulings
                .FirstOrDefaultAsync(x => newScheduling.StartDate >= x.StartDate
                                     &&   newScheduling.StartDate <= x.EndDate
                                     &&   x.FranchiseId ==  newScheduling.FranchiseId);
        }

        public void Update(EvaluationScheduling scheduling)
        {
            _context.EvaluationSchedulings.Update(scheduling);
        }

        public void Remove(EvaluationScheduling scheduling)
        {
            _context.EvaluationSchedulings.Remove(scheduling);
        }


    }
}
