using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Services;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Resources.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Controllers
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

        /// <summary>
        /// Lists all expenses.
        /// </summary>
        /// <returns>List os expenses.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ExpenseResource>), 200)]
        public async Task<IEnumerable<ExpenseResource>> ListExpensesAsync()
        {
            var expenses = await _financialService.ListExpensesAsync();
            var resources = _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseResource>>(expenses);

            return resources;
        }

        /// <summary>
        /// Saves a new expense.
        /// </summary>
        /// <param name="resource">Expense data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(ExpenseResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> InsertExpenseAsync([FromBody] SaveExpenseResource resource)
        {
            var expense = _mapper.Map<SaveExpenseResource, Expense>(resource);
            var result = await _financialService.SaveExpenseAsync(expense);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
            return Ok(expenseResource);
        }

        /// <summary>
        /// Updates an existing expense according to an identifier.
        /// </summary>
        /// <param name="id">Expense identifier.</param>
        /// <param name="resource">Updated expense data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("[action]/{id}")]
        [ProducesResponseType(typeof(ExpenseResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateExpenseAsync(int id, [FromBody] SaveExpenseResource resource)
        {
            var expense = _mapper.Map<SaveExpenseResource, Expense>(resource);
            var result = await _financialService.UpdateExpenseAsync(id, expense);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
            return Ok(expenseResource);
        }

        /// <summary>
        /// Deletes a given expense according to an identifier.
        /// </summary>
        /// <param name="id">Expense identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(typeof(ExpenseResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteExpenseAsync(int id)
        {
            var result = await _financialService.DeleteExpenseAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var expenseResource = _mapper.Map<Expense, ExpenseResource>(result.Resource);
            return Ok(expenseResource);
        }
    }
}
