using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class FranchiseResponse : BaseResponse<Franchise>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="franchise">Saved franchise.</param>
        /// <returns>Response.</returns>
        public FranchiseResponse(Franchise franchise) : base(franchise)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public FranchiseResponse(string message) : base(message)
        { }
    }
}
