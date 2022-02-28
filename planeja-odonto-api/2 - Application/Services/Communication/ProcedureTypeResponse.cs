using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
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
