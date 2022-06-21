using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IProcedureTypeService
    {
        Task<IEnumerable<ProcedureType>> ListAsync();
        Task<ProcedureType> GetById(int id);

        Task<IEnumerable<ProcedureType>> ListOrthodonticsAsync();
        Task<IEnumerable<ProcedureType>> ListGeneralClinictAsync();
        Task<IEnumerable<ProcedureType>> ListImplantologyAsync();
        Task<IEnumerable<ProcedureType>> ListFacialHarmonizationAsync();

        Task<ProcedureTypeResponse> SaveAsync(ProcedureType pacient);
        Task<ProcedureTypeResponse> UpdateAsync(int id, ProcedureType pacient);
        Task<ProcedureTypeResponse> DeleteAsync(int id);
    }
}
