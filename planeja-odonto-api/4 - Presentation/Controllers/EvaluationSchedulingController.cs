using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;
using PlanejaOdonto.Api.Application.Services.Scheduling;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class EvaluationSchedulingController : ControllerBase
    {
        private readonly IEvaluationSchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public EvaluationSchedulingController(IEvaluationSchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }


        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(IEnumerable<EvaluationSchedulingResource>), 200)]
        public async Task<IEnumerable<EvaluationSchedulingResource>> ListByFranchiseIdAsync(int id)
        {
            var schedulings = await _schedulingService.ListByFranchiseIdAsync(id);
            var resources = _mapper.Map<IEnumerable<EvaluationScheduling>, IEnumerable<EvaluationSchedulingResource>>(schedulings);

            return resources;
        }



        [HttpPost]
        [ProducesResponseType(typeof(EvaluationSchedulingResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveEvaluationSchedulingResource resource)
        {

            var scheduling = _mapper.Map<SaveEvaluationSchedulingResource, EvaluationScheduling>(resource);
            var result = await _schedulingService.SaveAsync(scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<EvaluationScheduling, EvaluationSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EvaluationSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEvaluationSchedulingResource resource)
        {
            var scheduling = _mapper.Map<SaveEvaluationSchedulingResource, EvaluationScheduling>(resource);
            var result = await _schedulingService.UpdateAsync(id, scheduling);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<EvaluationScheduling, EvaluationSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EvaluationSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _schedulingService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<EvaluationScheduling, EvaluationSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }



        [HttpPost("{id}")]
        [ProducesResponseType(typeof(EvaluationSchedulingResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateStatus(int id,SchedulingStatus schedulingStatus)
        {
            var result = await _schedulingService.UpdateStatus(id,schedulingStatus);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var schedulingResource = _mapper.Map<EvaluationScheduling, EvaluationSchedulingResource>(result.Resource);
            return Ok(schedulingResource);
        }

    }
}
