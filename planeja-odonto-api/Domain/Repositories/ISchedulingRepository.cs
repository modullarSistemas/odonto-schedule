using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Scheduling>> ListAsync();
        Task AddAsync(Scheduling product);
        Task<Scheduling> FindByIdAsync(int id);
        void Update(Scheduling product);
        void Remove(Scheduling product);

    }
}
