using Microsoft.EntityFrameworkCore;
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
    public class FranchiseRepository : BaseRepository, IFranchiseRepository
    {
        public FranchiseRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Franchise>> ListAsync()
        {
            return await _context.Franchises
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Franchise franchisee)
        {
            await _context.Franchises.AddAsync(franchisee);
        }

        public async Task<Franchise> FindByIdAsync(int id)
        {
            return await _context.Franchises.FindAsync(id);
        }

        public void Update(Franchise franchisee)
        {
            _context.Franchises.Update(franchisee);
        }

        public void Remove(Franchise franchisee)
        {
            _context.Franchises.Remove(franchisee);
        }
    }
}
