using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class FranchiseeRepository : BaseRepository, IFranchiseeRepository
    {
        public FranchiseeRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Franchisee>> ListAsync()
        {
            return await _context.Franchisees
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Franchisee franchisee)
        {
            await _context.Franchisees.AddAsync(franchisee);
        }

        public async Task<Franchisee> FindByIdAsync(int id)
        {
            return await _context.Franchisees.FindAsync(id);
        }

        public void Update(Franchisee franchisee)
        {
            _context.Franchisees.Update(franchisee);
        }

        public void Remove(Franchisee franchisee)
        {
            _context.Franchisees.Remove(franchisee);
        }
    }
}
