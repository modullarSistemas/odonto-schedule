using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class ProthesisResponse : BaseResponse<Prothesis>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="prothesis">Saved procedureType.</param>
        /// <returns>Response.</returns>
        public ProthesisResponse(Prothesis prothesis) : base(prothesis)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ProthesisResponse(string message) : base(message)
        { }
    }
}
