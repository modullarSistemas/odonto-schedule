using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface IDentistService
    {
        Task<IEnumerable<Dentist>> ListAsync();

        Task<Dentist> GetById(int id);

        Task<DentistResponse> SaveAsync(Dentist category);
        Task<DentistResponse> UpdateAsync(int id, Dentist category);
        Task<DentistResponse> DeleteAsync(int id);
    }
}
