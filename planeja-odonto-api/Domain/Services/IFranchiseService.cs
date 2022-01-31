using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> ListAsync();
        Task<FranchiseResponse> SaveAsync(Franchise Franchise);
        Task<FranchiseResponse> UpdateAsync(int id, Franchise Franchise);
        Task<FranchiseResponse> DeleteAsync(int id);
    }
}
