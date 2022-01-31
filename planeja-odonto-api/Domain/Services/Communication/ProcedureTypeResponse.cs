using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class ProcedureTypeResponse : BaseResponse<ProcedureType>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="procedureType">Saved procedureType.</param>
        /// <returns>Response.</returns>
        public ProcedureTypeResponse(ProcedureType category) : base(category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProcedureTypeResponse(string message) : base(message)
        { }
    }
}
