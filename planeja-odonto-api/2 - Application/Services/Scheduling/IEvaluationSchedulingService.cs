using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;

namespace PlanejaOdonto.Api.Application.Services.Scheduling
{
    public interface IEvaluationSchedulingService
    {
        Task<IEnumerable<EvaluationScheduling>> ListByFranchiseIdAsync(int id);
        Task<EvaluationSchedulingResponse> SaveAsync(EvaluationScheduling category);
        Task<EvaluationSchedulingResponse> UpdateStatus(int id, SchedulingStatus status);
        Task<EvaluationSchedulingResponse> UpdateAsync(int id, EvaluationScheduling category);
        Task<EvaluationSchedulingResponse> DeleteAsync(int id);
    }
}
