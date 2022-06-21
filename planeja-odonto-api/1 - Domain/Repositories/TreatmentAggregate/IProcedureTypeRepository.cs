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

        Task<IEnumerable<ProcedureType>> ListOrthodonticsAsync();
        Task<IEnumerable<ProcedureType>> ListGeneralClinictAsync();
        Task<IEnumerable<ProcedureType>> ListImplantologyAsync();
        Task<IEnumerable<ProcedureType>> ListFacialHarmonizationAsync();

        void Update(ProcedureType procedureType);
        void Remove(ProcedureType procedureType);
    }
}

