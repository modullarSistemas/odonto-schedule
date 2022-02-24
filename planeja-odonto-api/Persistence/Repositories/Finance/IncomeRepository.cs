using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class IncomeRepository : BaseRepository, IIncomeRepository
    {
        public IncomeRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<Income>> ListAsync()
        {
            return await _context.Income
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Income income)
        {
            await _context.Income.AddAsync(income);
        }

        public async Task<Income> FindByIdAsync(int id)
        {
            return await _context.Income
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Income income)
        {
            _context.Income.Update(income);
        }

        public void Remove(Income income)
        {
            _context.Income.Remove(income);
        }
    }
}
