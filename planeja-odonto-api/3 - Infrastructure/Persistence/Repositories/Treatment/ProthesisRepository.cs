using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using PlanejaOdonto.Api.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class ProthesisRepository : BaseRepository, IProthesisRepository
    {
        public ProthesisRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Prothesis>> ListAsync()
        {
            return await _context.Prothesis
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Prothesis franchisee)
        {
            await _context.Prothesis.AddAsync(franchisee);
        }

        public async Task<Prothesis> FindByIdAsync(int id)
        {
            return await _context.Prothesis.FindAsync(id);
        }

        public void Update(Prothesis franchisee)
        {
            _context.Prothesis.Update(franchisee);
        }

        public void Remove(Prothesis franchisee)
        {
            _context.Prothesis.Remove(franchisee);
        }
    }
}
