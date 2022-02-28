using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IDentistService
    {
        Task<IEnumerable<Dentist>> ListAsync();
        Task<IEnumerable<Dentist>> ListByFranchiseIdAsync(int id);
        Task<Dentist> GetById(int id);
        Task<DentistResponse> SaveAsync(Dentist category);
        Task<DentistResponse> UpdateAsync(int id, Dentist category);
        Task<DentistResponse> DeleteAsync(int id);
    }
}
