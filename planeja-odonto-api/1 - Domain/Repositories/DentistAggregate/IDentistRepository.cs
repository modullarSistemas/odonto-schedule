using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IDentistRepository
    {
        Task<IEnumerable<Dentist>> ListAsync();
        Task<IEnumerable<Dentist>> ListByFranchiseIdAsync(int id);
        Task AddAsync(Dentist dentist);
        Task<Dentist> FindByIdAsync(int id);

        Task<Dentist> FindByUserIdAsync(int id);

        void Update(Dentist dentist);
        void Remove(Dentist dentist);
    }
}
