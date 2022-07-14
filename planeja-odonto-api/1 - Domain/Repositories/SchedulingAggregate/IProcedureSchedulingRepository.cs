using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories.SchedulingAggregate
{
    public interface IProcedureSchedulingRepository
    {
        Task<IEnumerable<ProcedureScheduling>> ListAsync();
        Task<IEnumerable<ProcedureScheduling>> ListByDentistIdAsync(int id);
        Task<IEnumerable<ProcedureScheduling>> ListByFranchiseIdAsync(int id);
        Task<ProcedureScheduling> CheckDateAvailability(ProcedureScheduling newScheduling);
        Task AddAsync(ProcedureScheduling product);
        Task<ProcedureScheduling> FindByIdAsync(int id);
        void Update(ProcedureScheduling product);
        void Remove(ProcedureScheduling product);

    }
}
