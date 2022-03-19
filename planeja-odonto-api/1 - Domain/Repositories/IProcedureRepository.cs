using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IProcedureRepository
    {
        Task<IEnumerable<Procedure>> ListAsync();

        Task<IEnumerable<Procedure>> ListByTreatmentIdAsync(int treatmentId);

        Task AddAsync(Procedure Procedure);
        Task<Procedure> FindByIdAsync(int id);
        void Update(Procedure Procedure);
        void Remove(Procedure Procedure);
    }
}

