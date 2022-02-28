using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public SchedulingController(ISchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all schedulings.
        /// </summary>
        /// <returns>List os schedulings.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchedulingResource>), 200)]
        public async Task<IEnumerable<SchedulingResource>> ListAsync()
        {
            var schedulings = await _schedulingService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Scheduling>, IEnumerable<SchedulingResource>>(schedulings);

            return resources;
        }

        /// <summary>
        /// Saves a new Scheduling.
        /// </summary>
        /// <param name="resource">Scheduling data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(SchedulingResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveSchedulingResource resource)
        {

            var scheduling = _mapper.Map<SaveSchedulingResource, Scheduling>(resource);
            var result = await _schedulingService.SaveAsync(scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<Scheduling, SchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

        /// <summary>
        /// Updates an existing Scheduling according to an identifier.
        /// </summary>
        /// <param name="id">Scheduling identifier.</param>
        /// <param name="resource">Updated Scheduling data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSchedulingResource resource)
        {
            var scheduling = _mapper.Map<SaveSchedulingResource, Scheduling>(resource);
            var result = await _schedulingService.UpdateAsync(id, scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<Scheduling, SchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

        /// <summary>
        /// Deletes a given Scheduling according to an identifier.
        /// </summary>
        /// <param name="id">Scheduling identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _schedulingService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<Scheduling, SchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

    }
}
