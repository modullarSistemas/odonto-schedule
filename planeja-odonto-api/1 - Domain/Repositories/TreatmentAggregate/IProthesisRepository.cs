using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IProthesisRepository
    {
        Task<IEnumerable<Prothesis>> ListAsync();
        Task AddAsync(Prothesis procedureType);
        Task<Prothesis> FindByIdAsync(int id);
        void Update(Prothesis procedureType);
        void Remove(Prothesis procedureType);
    }
}

