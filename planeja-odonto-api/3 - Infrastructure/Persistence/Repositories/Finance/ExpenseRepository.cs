using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Persistence.Repositories
{
    public class ExpenseRepository : BaseRepository, IExpenseRepository
    {
        public ExpenseRepository(PlanejaOdontoDbContext context,IConfiguration configuration) : base(context, configuration) { }

        public async Task<IEnumerable<Expense>> ListAsync()
        {
            return await _context.Expense
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Expense category)
        {
            await _context.Expense.AddAsync(category);
        }

        public async Task<Expense> FindByIdAsync(int id)
        {
            return await _context.Expense
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Expense category)
        {
            _context.Expense.Update(category);
        }

        public void Remove(Expense category)
        {
            _context.Expense.Remove(category);
        }
    }
}
