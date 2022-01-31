using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IFranchiseeRepository
    {
        Task<IEnumerable<Franchisee>> ListAsync();
        Task AddAsync(Franchisee product);
        Task<Franchisee> FindByIdAsync(int id);
        void Update(Franchisee product);
        void Remove(Franchisee product);
    }
}
