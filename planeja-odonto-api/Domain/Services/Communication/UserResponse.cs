using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Services.Communication
{
    public class UserResponse : BaseResponse<User>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="user"> User.</param>
        /// <returns>Response.</returns>
        public UserResponse(User user) : base(user)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : base(message)
        { }
    }
}
