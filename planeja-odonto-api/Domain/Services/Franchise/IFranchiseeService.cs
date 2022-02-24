using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Services.Communication;
using PlanejaOdonto.Api.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services
{
    public interface IFranchiseeService
    {
        Task<IEnumerable<Franchisee>> ListAsync();
        Task<FranchiseeResponse> SaveAsync(Franchisee franchisee);
        Task<FranchiseeResponse> UpdateAsync(int id, Franchisee franchisee);
        Task<FranchiseeResponse> DeleteAsync(int id);

    }
}
