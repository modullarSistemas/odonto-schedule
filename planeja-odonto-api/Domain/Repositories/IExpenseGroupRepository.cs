using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Repositories
{
    interface IExpenseGroupGroupRepository
    {
        Task<IEnumerable<ExpenseGroup>> ListAsync();
        Task AddAsync(ExpenseGroup expenseGroup);
        Task<ExpenseGroup> FindByIdAsync(int id);
        void Update(ExpenseGroup expenseGroup);
        void Remove(ExpenseGroup expenseGroup);
    }
}
