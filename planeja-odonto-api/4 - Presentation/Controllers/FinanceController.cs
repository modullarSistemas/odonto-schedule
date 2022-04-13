using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.Finance;
using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinancialService _financialService;
        private readonly IMapper _mapper;

        public FinanceController(IFinancialService financialService, IMapper mapper)
        {
            _financialService = financialService;
            _mapper = mapper;
        }


        #region Income

        /// <summary>
        /// Lists all incomes.
        /// </summary>
        /// <returns>List os expenses.</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(IEnumerable<InstallmentResponse>), 200)]
        public async Task<IActionResult> PayInstallment(int installmentId, PaymentMethod paymentMethod)
        {
            var result = await _financialService.PayInstallment(installmentId, paymentMethod);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpPost("[action]/{treatmentId}")]
        [ProducesResponseType(typeof(IEnumerable<InstallmentResponse>), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GenerateInstalments(int treatmentId, [FromBody] GenerateInstallmentsResource resource)
        {
            var result = await _financialService.GenerateInstallments(treatmentId, resource);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        ///// <summary>
        ///// Saves a new expense.
        ///// </summary>
        ///// <param name="resource">Income data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPost("[action]")]
        //[ProducesResponseType(typeof(IncomeResource), 201)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> InsertIncomeAsync([FromBody] SaveIncomeResource resource)
        //{
        //    var income = _mapper.Map<SaveIncomeResource, Income>(resource);
        //    var result = await _financialService.SaveIncomeAsync(income);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var incomeResource = _mapper.Map<Income, IncomeResource>(result.Resource);
        //    return Ok(incomeResource);
        //}

        ///// <summary>
        ///// Updates an existing expense according to an identifier.
        ///// </summary>
        ///// <param name="id">Income identifier.</param>
        ///// <param name="resource">Updated expense data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPut("[action]/{id}")]
        //[ProducesResponseType(typeof(IncomeResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> UpdateIncomeAsync(int id, [FromBody] SaveIncomeResource resource)
        //{
        //    var income = _mapper.Map<SaveIncomeResource, Income>(resource);
        //    var result = await _financialService.UpdateIncomeAsync(id, income);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var incomeResource = _mapper.Map<Income, IncomeResource>(result.Resource);
        //    return Ok(incomeResource);
        //}

        ///// <summary>
        ///// Deletes a given expense according to an identifier.
        ///// </summary>
        ///// <param name="id">Income identifier.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpDelete("[action]/{id}")]
        //[ProducesResponseType(typeof(IncomeResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> DeleteIncomeAsync(int id)
        //{
        //    var result = await _financialService.DeleteIncomeAsync(id);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var incomeResource = _mapper.Map<Income, IncomeResource>(result.Resource);
        //    return Ok(incomeResource);
        //}


        #endregion



        #region Expenses



        ///// <summary>
        ///// Lists all expenses.
        ///// </summary>
        ///// <returns>List os expenses.</returns>
        //[HttpGet("[action]")]
        //[ProducesResponseType(typeof(IEnumerable<IncomeResource>), 200)]
        //public async Task<IEnumerable<ExpenseGroupResource>> ListExpenseGroupsAsync()
        //{
        //    var expenseGroups = await _financialService.ListExpenseGroupsAsync();
        //    var resources = _mapper.Map<IEnumerable<ExpenseGroup>, IEnumerable<ExpenseGroupResource>>(expenseGroups);

        //    return resources;
        //}




        ///// <summary>
        ///// Lists all expenses.
        ///// </summary>
        ///// <returns>List os expenses.</returns>
        //[HttpGet("[action]")]
        //[ProducesResponseType(typeof(IEnumerable<IncomeResource>), 200)]
        //public async Task<IEnumerable<ExpenseResource>> ListExpensesAsync()
        //{
        //    var expenses = await _financialService.ListExpensesAsync();
        //    var resources = _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseResource>>(expenses);

        //    return resources;
        //}


        ///// <summary>
        ///// Saves a new expense.
        ///// </summary>
        ///// <param name="resource">Expense data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPost("[action]")]
        //[ProducesResponseType(typeof(ExpenseResource), 201)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> InsertExpenseAsync([FromBody] SaveExpenseResource resource)
        //{
        //    var expense = _mapper.Map<SaveExpenseResource, Expense>(resource);
        //    var result = await _financialService.SaveExpenseAsync(expense);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
        //    return Ok(expenseResource);
        //}

        ///// <summary>
        ///// Updates an existing expense according to an identifier.
        ///// </summary>
        ///// <param name="id">Expense identifier.</param>
        ///// <param name="resource">Updated expense data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPut("[action]/{id}")]
        //[ProducesResponseType(typeof(ExpenseResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> UpdateExpenseAsync(int id, [FromBody] SaveExpenseResource resource)
        //{
        //    var expense = _mapper.Map<SaveExpenseResource, Expense>(resource);
        //    var result = await _financialService.UpdateExpenseAsync(id, expense);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
        //    return Ok(expenseResource);
        //}

        ///// <summary>
        ///// Deletes a given expense according to an identifier.
        ///// </summary>
        ///// <param name="id">Expense identifier.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpDelete("[action]/{id}")]
        //[ProducesResponseType(typeof(ExpenseResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> DeleteExpenseAsync(int id)
        //{
        //    var result = await _financialService.DeleteExpenseAsync(id);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
        //    return Ok(expenseResource);
        //}
        #endregion



    }
}
