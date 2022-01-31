using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class PacientRepository : BaseRepository, IPacientRepository
    {
        public PacientRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Pacient>> ListAsync()
        {
            return await _context.Pacients
                                 .Include(x=>x.Address)
                                 .Include(x=>x.Dependants)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Pacient category)
        {
            await _context.Pacients.AddAsync(category);
        }

        public async Task<Pacient> FindByIdAsync(int id)
        {
            return await _context.Pacients
                .Include(x => x.Address)
                .Include(x => x.Dependants)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Pacient category)
        {
            _context.Pacients.Update(category);
        }

        public void Remove(Pacient category)
        {
            _context.Pacients.Remove(category);
        }
    }
}
