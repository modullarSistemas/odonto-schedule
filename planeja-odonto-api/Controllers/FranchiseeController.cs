using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Services;
using AutoMapper;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;

namespace PlanejaOdonto.Api.Controllers
{
    [Route("/api/[controller]")]
    public class FranchiseeController : ControllerBase
    {
        private readonly IFranchiseeService _franchiseeService;
        private readonly IMapper _mapper;

        public FranchiseeController(IFranchiseeService franchiseeService, IMapper mapper)
        {
            _franchiseeService = franchiseeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all categories.
        /// </summary>
        /// <returns>List os categories.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FranchiseeResource>), 200)]
        public async Task<IEnumerable<FranchiseeResource>> ListAsync()
        {
            var categories = await _franchiseeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Franchisee>, IEnumerable<FranchiseeResource>>(categories);

            return resources;
        }

        /// <summary>
        /// Saves a new franchisee.
        /// </summary>
        /// <param name="resource">Franchisee data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FranchiseeResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveFranchiseeResource resource)
        {
            var franchisee = _mapper.Map<SaveFranchiseeResource, Franchisee>(resource);
            var result = await _franchiseeService.SaveAsync(franchisee);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var franchiseeResource = _mapper.Map<Franchisee, FranchiseeResource>(result.Resource);
            return Ok(franchiseeResource);
        }

        /// <summary>
        /// Updates an existing franchisee according to an identifier.
        /// </summary>
        /// <param name="id">Franchisee identifier.</param>
        /// <param name="resource">Updated franchisee data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FranchiseeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFranchiseeResource resource)
        {
            var franchisee = _mapper.Map<SaveFranchiseeResource, Franchisee>(resource);
            var result = await _franchiseeService.UpdateAsync(id, franchisee);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var franchiseeResource = _mapper.Map<Franchisee, FranchiseeResource>(result.Resource);
            return Ok(franchiseeResource);
        }

        /// <summary>
        /// Deletes a given franchisee according to an identifier.
        /// </summary>
        /// <param name="id">Franchisee identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FranchiseeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _franchiseeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var franchiseeResource = _mapper.Map<Franchisee, FranchiseeResource>(result.Resource);
            return Ok(franchiseeResource);
        }

    }
}
