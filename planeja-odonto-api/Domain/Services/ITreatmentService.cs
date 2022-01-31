using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface ITreatmentService
    {
        Task<IEnumerable<Treatment>> ListAsync();
        Task<TreatmentResponse> SaveAsync(Treatment treatment);
        Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment);
        Task<TreatmentResponse> DeleteAsync(int id);
    }
}
