﻿using Microsoft.EntityFrameworkCore;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Persistence.Repositories
{
    public class ExpenseGroupRepository : BaseRepository, IExpenseGroupRepository
    {
        public ExpenseGroupRepository(PlanejaOdontoDbContext context) : base(context) { }

        public async Task<IEnumerable<ExpenseGroup>> ListAsync()
        {
            return await _context.ExpenseGroups
                                 .ToListAsync();
        }

        public async Task AddAsync(ExpenseGroup category)
        {
            await _context.ExpenseGroups.AddAsync(category);
        }

        public async Task<ExpenseGroup> FindByIdAsync(int id)
        {
            return await _context.ExpenseGroups
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(ExpenseGroup category)
        {
            _context.ExpenseGroups.Update(category);
        }

        public void Remove(ExpenseGroup category)
        {
            _context.ExpenseGroups.Remove(category);
        }
    }
}