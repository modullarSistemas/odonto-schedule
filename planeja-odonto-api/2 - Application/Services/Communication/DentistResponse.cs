using PlanejaOdonto.Api.Domain.Models.DentistAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class DentistResponse : BaseResponse<Dentist>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="dentist">Saved dentist.</param>
        /// <returns>Response.</returns>
        public DentistResponse(Dentist dentist) : base(dentist)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public DentistResponse(string message) : base(message)
        { }
    }
}
