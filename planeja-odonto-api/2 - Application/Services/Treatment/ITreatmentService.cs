using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Enums;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface ITreatmentService
    {
        Task<Treatment> GetByIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id);
        Task<IEnumerable<Procedure>> ListProcedureByTreatmentIdAsync(int id);

        Task<IEnumerable<Treatment>> ListOrthodonticsByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListGeneralClinicByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListImplantologyByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListFacilHarmonizationByPacientIdAsync(int id);

        Task<TreatmentResponse> UpdateStatusAsync(int id, TreatmentStatusEnum status);
        Task<TreatmentResponse> SaveAsync(Treatment treatment);
        Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment);
        Task<TreatmentResponse> DeleteAsync(int id);
        Task<List<Procedure>> GenerateProcedures(int treatmentId, List<Procedure> procedures);
        Task<ProcedureResponse> UpdateProcedureStatus(int procedureId,ProcedureStatusEnum status);



    }
}
