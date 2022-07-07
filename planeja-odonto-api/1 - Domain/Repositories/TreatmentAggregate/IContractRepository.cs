using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IContractRepository
    {
        Task AddAsync(Contract contract);
        Task<Contract> FindByTreatmentIdAsync(int id);
        Task<Contract> FindByIdAsync(int id);
        void Update(Contract contract);
        void Remove(Contract contract);
    }
}
