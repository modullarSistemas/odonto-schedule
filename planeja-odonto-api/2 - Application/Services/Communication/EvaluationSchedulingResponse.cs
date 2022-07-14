using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class EvaluationSchedulingResponse : BaseResponse<EvaluationScheduling>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="scheduling">Saved scheduling.</param>
        /// <returns>Response.</returns>
        public EvaluationSchedulingResponse(EvaluationScheduling scheduling) : base(scheduling)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public EvaluationSchedulingResponse(string message) : base(message)
        { }
    }
}
