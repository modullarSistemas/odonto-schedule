using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class SchedulingResponse : BaseResponse<Scheduling>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="scheduling">Saved scheduling.</param>
        /// <returns>Response.</returns>
        public SchedulingResponse(Scheduling scheduling) : base(scheduling)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SchedulingResponse(string message) : base(message)
        { }
    }
}
