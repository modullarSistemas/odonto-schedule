﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Domain.Enums;

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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SchedulingResource>), 200)]
        public async Task<IEnumerable<SchedulingResource>> ListAsync()
        {
            var schedulings = await _schedulingService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Scheduling>, IEnumerable<SchedulingResource>>(schedulings);

            return resources;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<SchedulingResource>), 200)]
        public async Task<IEnumerable<SchedulingResource>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingService.ListByFranchiseIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Scheduling>, IEnumerable<SchedulingResource>>(schedulings);

            return resources;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<SchedulingResource>), 200)]
        public async Task<IEnumerable<SchedulingResource>> ListByDentistIdAsync(int id)
        {
            var schedulings = await _schedulingService.ListByDentistIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Scheduling>, IEnumerable<SchedulingResource>>(schedulings);

            return resources;
        }


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



        [HttpPost("{id}")]
        [ProducesResponseType(typeof(SchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateStatus(int id,SchedulingStatus schedulingStatus)
        {
            var result = await _schedulingService.UpdateStatus(id,schedulingStatus);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<Scheduling, SchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

    }
}
