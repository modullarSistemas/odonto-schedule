using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate
{
    public interface IEvaluationSchedulingRepository
    {
        Task<IEnumerable<EvaluationScheduling>> ListByFranchiseIdAsync(int id);
        Task<EvaluationScheduling> CheckDateAvailability(EvaluationScheduling newScheduling);
        Task AddAsync(EvaluationScheduling scheduling);
        Task<EvaluationScheduling> FindByIdAsync(int id);
        void Update(EvaluationScheduling scheduling);
        void Remove(EvaluationScheduling scheduling);

    }
}
