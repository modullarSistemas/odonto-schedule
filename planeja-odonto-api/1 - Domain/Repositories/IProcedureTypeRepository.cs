using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IProcedureTypeRepository
    {
        Task<IEnumerable<ProcedureType>> ListAsync();
        Task AddAsync(ProcedureType procedureType);
        Task<ProcedureType> FindByIdAsync(int id);
        void Update(ProcedureType procedureType);
        void Remove(ProcedureType procedureType);
    }
}

