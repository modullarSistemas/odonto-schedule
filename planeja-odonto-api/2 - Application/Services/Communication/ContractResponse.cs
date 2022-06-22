using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ContractResponse : BaseResponse<Contract>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="contract">Saved contract.</param>
        /// <returns>Response.</returns>
        public ContractResponse(Contract contract) : base(contract)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ContractResponse(string message) : base(message)
        { }
    }
}
