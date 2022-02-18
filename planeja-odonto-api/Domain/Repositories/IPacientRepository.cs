using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IPacientRepository
    {
        Task<IEnumerable<Pacient>> ListPacientByFranchiseIdAsync(int id);
        Task AddAsync(Pacient product);
        Task<Pacient> FindByIdAsync(int id);
        void Update(Pacient product);
        void Remove(Pacient product);
    }
}
