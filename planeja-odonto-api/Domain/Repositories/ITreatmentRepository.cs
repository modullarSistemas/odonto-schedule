using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> ListAsync();
        Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id);

        Task AddAsync(Treatment treatment);
        Task<Treatment> FindByIdAsync(int id);
        void Update(Treatment treatment);
        void Remove(Treatment treatment);
    }
}
