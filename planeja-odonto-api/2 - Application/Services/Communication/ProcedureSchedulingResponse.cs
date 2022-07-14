using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ProcedureSchedulingResponse : BaseResponse<ProcedureScheduling>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="scheduling">Saved scheduling.</param>
        /// <returns>Response.</returns>
        public ProcedureSchedulingResponse(ProcedureScheduling scheduling) : base(scheduling)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProcedureSchedulingResponse(string message) : base(message)
        { }
    }
}
