using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IFranchiseRepository
    {
        Task<IEnumerable<Franchise>> ListAsync();
        Task AddAsync(Franchise product);
        Task<Franchise> FindByIdAsync(int id);
        void Update(Franchise product);
        void Remove(Franchise product);
    }
}
