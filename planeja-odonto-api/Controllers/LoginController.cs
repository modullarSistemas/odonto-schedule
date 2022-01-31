﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Persistence.Contexts;
using PlanejaOdonto.Api.Domain.Services;
using AutoMapper;
using PlanejaOdonto.Api.Resources.Login;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Authentication;

namespace PlanejaOdonto.Api.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(UserResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginResource resource)
        {
            var user = _mapper.Map<LoginResource, User>(resource);

            var result = await _loginService.Authenticate(user);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var token = TokenService.GenerateToken(result.Resource);
            return new
            {
                user = user.Username,
                franchiseId = result.Resource.FranchiseId,
                token = token
            };
        }





        /// <summary>
        /// Saves a new User.
        /// </summary>
        /// <param name="resource">User data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(UserResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUserResource resource)
        {
            var user = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _loginService.SaveAsync(user);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        /// <summary>
        /// Updates an existing User according to an identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <param name="resource">Updated User data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUserResource resource)
        {
            var User = _mapper.Map<SaveUserResource, User>(resource);
            var result = await _loginService.UpdateAsync(id, User);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

        /// <summary>
        /// Deletes a given User according to an identifier.
        /// </summary>
        /// <param name="id">User identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _loginService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var userResource = _mapper.Map<User, UserResource>(result.Resource);
            return Ok(userResource);
        }

    }
}
