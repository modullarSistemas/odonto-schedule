using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> ListAsync();
        Task AddAsync(Expense expense);
        Task<Expense> FindByIdAsync(int id);
        void Update(Expense expense);
        void Remove(Expense expense);
    }
}
