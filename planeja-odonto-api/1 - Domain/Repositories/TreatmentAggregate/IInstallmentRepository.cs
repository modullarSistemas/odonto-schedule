using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IInstallmentRepository
    {
        Task<IEnumerable<Installment>> ListAsync();

        Task<IEnumerable<Installment>> ListByTreatmentIdAsync(int treatmentId);

        Task AddAsync(Installment Installment);
        Task<Installment> FindByIdAsync(int id);
        void Update(Installment Installment);
        void Remove(Installment Installment);
    }
}

