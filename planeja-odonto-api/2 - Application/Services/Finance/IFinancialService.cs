using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IFinancialService
    {
        Task<IEnumerable<Expense>> ListExpensesAsync();

        Task<IEnumerable<ExpenseGroup>> ListExpenseGroupsAsync();
        Task<Expense> GetExpenseById(int id);
        Task<ExpenseResponse> SaveExpenseAsync(Expense expense);
        Task<ExpenseResponse> UpdateExpenseAsync(int id, Expense expense);
        Task<ExpenseResponse> DeleteExpenseAsync(int id);
        Task<IEnumerable<Income>> ListIncomesAsync();
        Task<Income> GetIncomeById(int id);
        Task<IncomeResponse> SaveIncomeAsync(Income income);
        Task<IncomeResponse> UpdateIncomeAsync(int id, Income income);
        Task<IncomeResponse> DeleteIncomeAsync(int id);
    }
}
