using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ExpenseGroupResponse : BaseResponse<ExpenseGroup>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="expense">Saved expense group.</param>
        /// <returns>Response.</returns>
        public ExpenseGroupResponse(ExpenseGroup expense) : base(expense)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ExpenseGroupResponse(string message) : base(message)
        { }
    }
}
