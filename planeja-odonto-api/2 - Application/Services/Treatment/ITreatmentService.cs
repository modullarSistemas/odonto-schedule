using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface ITreatmentService
    {
        Task<Treatment> GetByIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id);
        Task<IEnumerable<Procedure>> ListProcedureByTreatmentIdAsync(int id);
        Task<TreatmentResponse> SaveAsync(Treatment treatment);
        Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment);
        Task<TreatmentResponse> DeleteAsync(int id);
        Task<List<Procedure>> GenerateProcedures(int treatmentId, List<Procedure> procedures);
        Task<ProcedureResponse> FinalizeProcedure(int procedureId);


    }
}
