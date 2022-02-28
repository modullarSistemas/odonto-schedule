﻿using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Application.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> ListAsync();

        Task<IEnumerable<Expense>> ListByFranchiseIdAsync(int franchiseId);

        Task<Expense> GetById(int id);
        Task<ExpenseResponse> SaveAsync(Expense expense);
        Task<ExpenseResponse> UpdateAsync(int id, Expense expense);
        Task<ExpenseResponse> DeleteAsync(int id);
    }
}