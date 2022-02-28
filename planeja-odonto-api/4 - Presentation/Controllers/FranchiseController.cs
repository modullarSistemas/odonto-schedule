using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources.Franchisee;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService franchiseService, IMapper mapper)
        {
            _franchiseService = franchiseService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all franchises.
        /// </summary>
        /// <returns>List os franchises.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FranchiseResource>), 200)]
        public async Task<IEnumerable<FranchiseResource>> ListAsync()
        {
            var franchises = await _franchiseService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Franchise>, IEnumerable<FranchiseResource>>(franchises);

            return resources;
        }

        /// <summary>
        /// Saves a new Franchise.
        /// </summary>
        /// <param name="resource">Franchise data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FranchiseResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveFranchiseResource resource)
        {
            var franchise = _mapper.Map<SaveFranchiseResource, Franchise>(resource);
            var result = await _franchiseService.SaveAsync(franchise);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Franchise, FranchiseResource>(result.Resource);
            return Ok(categoryResource);
        }

        /// <summary>
        /// Updates an existing Franchise according to an identifier.
        /// </summary>
        /// <param name="id">Franchise identifier.</param>
        /// <param name="resource">Updated Franchise data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FranchiseResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFranchiseResource resource)
        {
            var Franchise = _mapper.Map<SaveFranchiseResource, Franchise>(resource);
            var result = await _franchiseService.UpdateAsync(id, Franchise);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Franchise, FranchiseResource>(result.Resource);
            return Ok(categoryResource);
        }

        /// <summary>
        /// Deletes a given Franchise according to an identifier.
        /// </summary>
        /// <param name="id">Franchise identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FranchiseResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _franchiseService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Franchise, FranchiseResource>(result.Resource);
            return Ok(categoryResource);
        }

    }
}
