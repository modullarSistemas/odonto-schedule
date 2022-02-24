using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface ITreatmentService
    {
        Task<IEnumerable<Treatment>> ListAsync();
        Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id);
        Task<TreatmentResponse> SaveAsync(Treatment treatment);
        Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment);
        Task<TreatmentResponse> DeleteAsync(int id);
    }
}
