using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface ISchedulingRepository
    {
        Task<IEnumerable<Scheduling>> ListAsync();
        Task<IEnumerable<Scheduling>> ListByDentistIdAsync(int id);
        Task<IEnumerable<Scheduling>> ListByFranchiseIdAsync(int id);
        Task<Scheduling> CheckDateAvailability(Scheduling newScheduling);
        Task AddAsync(Scheduling product);
        Task<Scheduling> FindByIdAsync(int id);
        void Update(Scheduling product);


        void Remove(Scheduling product);

    }
}
