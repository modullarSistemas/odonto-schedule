using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services.Communication
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
