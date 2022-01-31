using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<User> FindByUserAndPassword(User user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password );
            return existingUser;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            return existingUser;
        }
    }
}
