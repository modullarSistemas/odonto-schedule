using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface ITreatmentRepository
    {

        Task<Treatment> FindByIdTrackingAsync(int id);

        Task<Treatment> FindByIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id);
        Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListOrthodonticsByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListGeneralClinicByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListImplantologyByPacientIdAsync(int id);
        Task<IEnumerable<Treatment>> ListFacialHarmonizationByPacientIdAsync(int id);

        Task AddAsync(Treatment treatment);
        void Update(Treatment treatment);
        void Remove(Treatment treatment);
    }
}
