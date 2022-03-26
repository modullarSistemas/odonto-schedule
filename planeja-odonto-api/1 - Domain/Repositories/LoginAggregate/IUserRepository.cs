using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindByUserAndPassword(User user);
        void Update(User user);
        void Remove(User user);
        Task<User> FindByIdAsync(int id);
    }
}
