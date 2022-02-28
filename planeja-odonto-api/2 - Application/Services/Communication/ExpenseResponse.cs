using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ExpenseResponse : BaseResponse<Expense>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="expense">Saved expense.</param>
        /// <returns>Response.</returns>
        public ExpenseResponse(Expense expense) : base(expense)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ExpenseResponse(string message) : base(message)
        { }
    }
}
