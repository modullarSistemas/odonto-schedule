using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using PlanejaOdonto.Api.Application.Services.Scheduling;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class ProcedureSchedulingController : ControllerBase
    {
        private readonly IProcedureSchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public ProcedureSchedulingController(IProcedureSchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureSchedulingResource>), 200)]
        public async Task<IEnumerable<ProcedureSchedulingResource>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingService.ListByFranchiseIdAsync(id);
            var resources = _mapper.Map<IEnumerable<ProcedureScheduling>, IEnumerable<ProcedureSchedulingResource>>(schedulings);

            return resources;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureSchedulingResource>), 200)]
        public async Task<IEnumerable<ProcedureSchedulingResource>> ListByDentistIdAsync(int id)
        {
            var schedulings = await _schedulingService.ListByDentistIdAsync(id);
            var resources = _mapper.Map<IEnumerable<ProcedureScheduling>, IEnumerable<ProcedureSchedulingResource>>(schedulings);

            return resources;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ProcedureSchedulingResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProcedureSchedulingResource resource)
        {

            var scheduling = _mapper.Map<SaveProcedureSchedulingResource, ProcedureScheduling>(resource);
            var result = await _schedulingService.SaveAsync(scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<ProcedureScheduling, ProcedureSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProcedureSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProcedureSchedulingResource resource)
        {
            var scheduling = _mapper.Map<SaveProcedureSchedulingResource, ProcedureScheduling>(resource);
            var result = await _schedulingService.UpdateAsync(id, scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<ProcedureScheduling, ProcedureSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProcedureSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _schedulingService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<ProcedureScheduling, ProcedureSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }



        [HttpPost("{id}")]
        [ProducesResponseType(typeof(ProcedureSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateStatus(int id,SchedulingStatus schedulingStatus)
        {
            var result = await _schedulingService.UpdateStatus(id,schedulingStatus);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<ProcedureScheduling, ProcedureSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

    }
}
