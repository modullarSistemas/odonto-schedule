using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Services;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Resources.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Controllers
{
    [Route("/api/[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IMapper _mapper;

        public TreatmentController(ITreatmentService treatmentService, IMapper mapper)
        {
            _treatmentService = treatmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all treatments.
        /// </summary>
        /// <returns>List os treatments.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TreatmentResource>), 200)]
        public async Task<IEnumerable<TreatmentResource>> ListAsync()
        {
            var treatments = await _treatmentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Treatment>, IEnumerable<TreatmentResource>>(treatments);

            return resources;
        }

        /// <summary>
        /// Lists all treatments.
        /// </summary>
        /// <returns>List os treatments.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<TreatmentResource>), 200)]
        public async Task<IEnumerable<TreatmentResource>> ListByPacientIdAsync(int pacientId)
        {
            var treatments = await _treatmentService.ListByPacientIdAsync(pacientId);
            var resources = _mapper.Map<IEnumerable<Treatment>, IEnumerable<TreatmentResource>>(treatments);

            return resources;
        }


        /// <summary>
        /// Saves a new Treatment.
        /// </summary>
        /// <param name="resource">Treatment data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(TreatmentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTreatmentResource resource)
        {
                var treatment = _mapper.Map<SaveTreatmentResource, Treatment>(resource);
                var result = await _treatmentService.SaveAsync(treatment);

                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }

                var categoryResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);
                return Ok(categoryResource);      
        }

        /// <summary>
        /// Updates an existing Treatment according to an identifier.
        /// </summary>
        /// <param name="id">Treatment identifier.</param>
        /// <param name="resource">Updated Treatment data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TreatmentResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTreatmentResource resource)
        {
            var Treatment = _mapper.Map<SaveTreatmentResource, Treatment>(resource);
            var result = await _treatmentService.UpdateAsync(id, Treatment);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);
            return Ok(categoryResource);
        }

        /// <summary>
        /// Deletes a given Treatment according to an identifier.
        /// </summary>
        /// <param name="id">Treatment identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TreatmentResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _treatmentService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Treatment, TreatmentResource>(result.Resource);
            return Ok(categoryResource);
        }

    }
}
