using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class IncomeResponse : BaseResponse<Income>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="expense">Saved income.</param>
        /// <returns>Response.</returns>
        public IncomeResponse(Income income) : base(income)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public IncomeResponse(string message) : base(message)
        { }
    }
}
