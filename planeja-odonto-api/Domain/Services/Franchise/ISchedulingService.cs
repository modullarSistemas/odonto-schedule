using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface ISchedulingService
    {
        Task<IEnumerable<Scheduling>> ListAsync();
        Task<SchedulingResponse> SaveAsync(Scheduling category);
        Task<SchedulingResponse> UpdateAsync(int id, Scheduling category);
        Task<SchedulingResponse> DeleteAsync(int id);
    }
}
