using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IPacientService
    {
        
        Task<IEnumerable<Pacient>> ListPacientByFranchiseIdAsync(int id);

        Task<IEnumerable<Pacient>> ListAsync();


        Task<Pacient> GetById(int id);

        Task<PacientResponse> SaveAsync(Pacient pacient);
        Task<PacientResponse> UpdateAsync(int id, Pacient pacient);
        Task<PacientResponse> DeleteAsync(int id);
    }
}
