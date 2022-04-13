using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Application.Resources.Treatment;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IFinancialService
    {
        Task<InstallmentResponse> PayInstallment(int installmentId, PaymentMethod paymentMethod);

        Task<TreatmentResponse> GenerateInstallments(int treatmentId, GenerateInstallmentsResource resource);


        //Task<IEnumerable<Expense>> ListExpensesAsync();

        //Task<IEnumerable<ExpenseGroup>> ListExpenseGroupsAsync();
        //Task<Expense> GetExpenseById(int id);
        //Task<ExpenseResponse> SaveExpenseAsync(Expense expense);
        //Task<ExpenseResponse> UpdateExpenseAsync(int id, Expense expense);
        //Task<ExpenseResponse> DeleteExpenseAsync(int id);
        //Task<IEnumerable<Income>> ListIncomesAsync();
        //Task<Income> GetIncomeById(int id);
        //Task<IncomeResponse> SaveIncomeAsync(Income income);
        //Task<IncomeResponse> UpdateIncomeAsync(int id, Income income);
        //Task<IncomeResponse> DeleteIncomeAsync(int id);
    }
}
