using AutoMapper;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseGroupRepository _expenseGroupRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FinancialService(IExpenseRepository expenseRepository, IExpenseGroupRepository expenseGroupRepository, IIncomeRepository incomeRepository, IUnitOfWork unitOfWork)
        {
            _expenseRepository = expenseRepository;
            _expenseGroupRepository = expenseGroupRepository;
            _incomeRepository = incomeRepository;
            _unitOfWork = unitOfWork;
        }

        #region Expenses

        public async Task<ExpenseGroupResponse> SaveExpenseAsync(ExpenseGroup expenseGroup)
        {
            try
            {
                await _expenseGroupRepository.AddAsync(expenseGroup);
                await _unitOfWork.CompleteAsync();

                return new ExpenseGroupResponse(expenseGroup);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseGroupResponse($"An error occurred when saving the expense: {ex.Message}");
            }
        }




        public async Task<IEnumerable<Expense>> ListExpensesAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var expenses = await _expenseRepository.ListAsync();
            return expenses;
        }


        public Task<Expense> GetExpenseById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ExpenseResponse> SaveExpenseAsync(Expense expense)
        {
            try
            {
                await _expenseRepository.AddAsync(expense);
                await _unitOfWork.CompleteAsync();

                return new ExpenseResponse(expense);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseResponse($"An error occurred when saving the expense: {ex.Message}");
            }
        }

        public async Task<ExpenseResponse> UpdateExpenseAsync(int id, Expense expense)
        {
            var existingExpense = await _expenseRepository.FindByIdAsync(id);

            if (existingExpense == null)
                return new ExpenseResponse("Expense not found.");

            //existingExpense.Name = expense.Name;
            //existingExpense.Email = expense.Email;
            //existingExpense.Phone = expense.Phone;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ExpenseResponse(existingExpense);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseResponse($"An error occurred when updating the expense: {ex.Message}");
            }
        }


        public async Task<ExpenseResponse> DeleteExpenseAsync(int id)
        {
            var existingExpense = await _expenseRepository.FindByIdAsync(id);

            if (existingExpense == null)
                return new ExpenseResponse("Expense not found.");

            try
            {
                _expenseRepository.Remove(existingExpense);
                await _unitOfWork.CompleteAsync();

                return new ExpenseResponse(existingExpense);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseResponse($"An error occurred when deleting the expense: {ex.Message}");
            }
        }

        #endregion



        #region ExpenseGroup
        public async Task<IEnumerable<ExpenseGroup>> ListExpenseGroupsAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var expenseGroups = await _expenseGroupRepository.ListAsync();
            return expenseGroups;
        }

        public Task<ExpenseGroup> GetExpenseGroupById(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ExpenseGroupResponse> SaveExpenseGroupAsync(ExpenseGroup expenseGroup)
        {
            try
            {
                await _expenseGroupRepository.AddAsync(expenseGroup);
                await _unitOfWork.CompleteAsync();

                return new ExpenseGroupResponse(expenseGroup);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseGroupResponse($"An error occurred when saving the expenseGroup: {ex.Message}");
            }
        }

        public async Task<ExpenseGroupResponse> UpdateExpenseGroupAsync(int id, ExpenseGroup expenseGroup)
        {
            var existingExpenseGroup = await _expenseGroupRepository.FindByIdAsync(id);

            if (existingExpenseGroup == null)
                return new ExpenseGroupResponse("ExpenseGroup not found.");

            existingExpenseGroup.Name = expenseGroup.Name;
            existingExpenseGroup.UpdatedAt = DateTime.Now;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ExpenseGroupResponse(existingExpenseGroup);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseGroupResponse($"An error occurred when updating the expenseGroup: {ex.Message}");
            }
        }


        public async Task<ExpenseGroupResponse> DeleteExpenseGroupAsync(int id)
        {
            var existingExpenseGroup = await _expenseGroupRepository.FindByIdAsync(id);

            if (existingExpenseGroup == null)
                return new ExpenseGroupResponse("ExpenseGroup not found.");

            try
            {
                _expenseGroupRepository.Remove(existingExpenseGroup);
                await _unitOfWork.CompleteAsync();

                return new ExpenseGroupResponse(existingExpenseGroup);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ExpenseGroupResponse($"An error occurred when deleting the expenseGroup: {ex.Message}");
            }
        }

        #endregion


        #region Income

        public async Task<IEnumerable<Income>> ListIncomesAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var expenses = await _incomeRepository.ListAsync();
            return expenses;
        }

        public async Task<IncomeResponse> SaveIncomeAsync(Income expense)
        {
            try
            {
                await _incomeRepository.AddAsync(expense);
                await _unitOfWork.CompleteAsync();

                return new IncomeResponse(expense);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IncomeResponse($"An error occurred when saving the expense: {ex.Message}");
            }
        }

        public async Task<IncomeResponse> UpdateIncomeAsync(int id, Income income)
        {
            var existingIncome = await _incomeRepository.FindByIdAsync(id);

            if (existingIncome == null)
                return new IncomeResponse("Income not found.");

            existingIncome.Value = income.Value;
            existingIncome.Description = income.Description;
            existingIncome.Date = income.Date;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new IncomeResponse(existingIncome);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IncomeResponse($"An error occurred when updating the expense: {ex.Message}");
            }
        }


        public async Task<IncomeResponse> DeleteIncomeAsync(int id)
        {
            var existingIncome = await _incomeRepository.FindByIdAsync(id);

            if (existingIncome == null)
                return new IncomeResponse("Income not found.");

            try
            {
                _incomeRepository.Remove(existingIncome);
                await _unitOfWork.CompleteAsync();

                return new IncomeResponse(existingIncome);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new IncomeResponse($"An error occurred when deleting the expense: {ex.Message}");
            }
        }


        public Task<Income> GetIncomeById(int id)
        {
            throw new NotImplementedException();
        }



        #endregion



    }
}
