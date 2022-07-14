using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;

namespace PlanejaOdonto.Api.Application.Services.Scheduling
{
    public interface IProcedureSchedulingService
    {
        Task<IEnumerable<ProcedureScheduling>> ListByDentistIdAsync(int id);
        Task<IEnumerable<ProcedureScheduling>> ListByFranchiseIdAsync(int id);
        Task<ProcedureSchedulingResponse> SaveAsync(ProcedureScheduling category);
        Task<ProcedureSchedulingResponse> UpdateStatus(int id, SchedulingStatus status);
        Task<ProcedureSchedulingResponse> UpdateAsync(int id, ProcedureScheduling category);
        Task<ProcedureSchedulingResponse> DeleteAsync(int id);
    }
}
