using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IProthesisService
    {
        Task<IEnumerable<Prothesis>> ListAsync();
        Task<Prothesis> GetById(int id);

        Task<ProthesisResponse> SaveAsync(Prothesis pacient);
        Task<ProthesisResponse> UpdateAsync(int id, Prothesis pacient);
        Task<ProthesisResponse> DeleteAsync(int id);
    }
}
