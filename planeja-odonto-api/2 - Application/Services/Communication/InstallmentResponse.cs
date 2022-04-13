using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;

namespace PlanejaOdonto.Api.Application.Services.Communication
{
    public class InstallmentResponse : BaseResponse<Installment>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="installment">Saved treatment.</param>
        /// <returns>Response.</returns>
        public InstallmentResponse(Installment installment) : base(installment)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public InstallmentResponse(string message) : base(message)
        { }
    }
}
