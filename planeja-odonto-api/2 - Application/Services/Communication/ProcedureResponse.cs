using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ProcedureResponse : BaseResponse<Procedure>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Procedure">Saved Procedure.</param>
        /// <returns>Response.</returns>
        public ProcedureResponse(Procedure Procedure) : base(Procedure)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProcedureResponse(string message) : base(message)
        { }
    }
}
