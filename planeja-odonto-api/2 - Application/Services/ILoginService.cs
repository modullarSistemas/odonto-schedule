using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface ILoginService
    {
        Task<UserResponse> Authenticate(User Franchise);
        Task<UserResponse> SaveAsync(User Franchise);
        Task<UserResponse> UpdateAsync(int id, User Franchise);
        Task<UserResponse> DeleteAsync(int id);
    }
}
