using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class FranchiseeResponse : BaseResponse<Franchisee>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="franchisee">Saved franchisee.</param>
        /// <returns>Response.</returns>
        public FranchiseeResponse(Franchisee franchisee) : base(franchisee)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public FranchiseeResponse(string message) : base(message)
        { }
    }
}
