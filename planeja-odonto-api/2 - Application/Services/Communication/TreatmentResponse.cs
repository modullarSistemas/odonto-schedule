using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class TreatmentResponse : BaseResponse<Treatment>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="treatment">Saved treatment.</param>
        /// <returns>Response.</returns>
        public TreatmentResponse(Treatment treatment) : base(treatment)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TreatmentResponse(string message) : base(message)
        { }
    }
}
