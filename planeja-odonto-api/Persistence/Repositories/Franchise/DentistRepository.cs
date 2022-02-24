using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class DentistRepository : BaseRepository, IDentistRepository
    {
        public DentistRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Dentist>> ListAsync()
        {
            return await _context.Dentists
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task<IEnumerable<Dentist>> ListByFranchiseIdAsync(int id)
        {
            return await _context.Dentists
                                 .Where(x=>x.FranchiseId == id)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
        public async Task AddAsync(Dentist franchisee)
        {
            await _context.Dentists.AddAsync(franchisee);
        }

        public async Task<Dentist> FindByIdAsync(int id)
        {
            return await _context.Dentists.FindAsync(id);
        }

        public void Update(Dentist franchisee)
        {
            _context.Dentists.Update(franchisee);
        }

        public void Remove(Dentist franchisee)
        {
            _context.Dentists.Remove(franchisee);
        }
    }
}
