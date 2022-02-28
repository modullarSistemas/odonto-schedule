using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IFranchiseeService
    {
        Task<IEnumerable<Franchisee>> ListAsync();
        Task<FranchiseeResponse> SaveAsync(Franchisee franchisee);
        Task<FranchiseeResponse> UpdateAsync(int id, Franchisee franchisee);
        Task<FranchiseeResponse> DeleteAsync(int id);

    }
}
