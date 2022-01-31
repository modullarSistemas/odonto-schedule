using PlanejaOdonto.Api.Domain.Models.PacientAggregate;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class PacientResponse : BaseResponse<Pacient>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="pacient">Saved pacient.</param>
        /// <returns>Response.</returns>
        public PacientResponse(Pacient category) : base(category)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PacientResponse(string message) : base(message)
        { }
    }
}
