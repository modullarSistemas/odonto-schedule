using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources.Prothesis;
using PlanejaOdonto.Api.Application.Resources;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class ProthesisController : ControllerBase
    {
        private readonly IProthesisService _procedureTypeService;
        private readonly IMapper _mapper;

        public ProthesisController(IProthesisService procedureTypeService, IMapper mapper)
        {
            _procedureTypeService = procedureTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all procedureTypes.
        /// </summary>
        /// <returns>List os procedureTypes.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProthesisResource>), 200)]
        public async Task<IEnumerable<ProthesisResource>> ListAsync()
        {
             var procedureTypes = await _procedureTypeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Prothesis>, IEnumerable<ProthesisResource>>(procedureTypes);

            return resources;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(ProthesisResource), 200)]
        public async Task<ProthesisResource> GetById(int id)
        {
            var procedureType = await _procedureTypeService.GetById(id);
            var resource = _mapper.Map<Prothesis, ProthesisResource>(procedureType);

            return resource;
        }

        /// <summary>
        /// Saves a new procedureType.
        /// </summary>
        /// <param name="resource">Prothesis data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProthesisResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProthesisResource resource)
        {
            var procedureType = _mapper.Map<SaveProthesisResource, Prothesis>(resource);
            var result = await _procedureTypeService.SaveAsync(procedureType);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<Prothesis, ProthesisResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

        /// <summary>
        /// Updates an existing procedureType according to an identifier.
        /// </summary>
        /// <param name="id">Prothesis identifier.</param>
        /// <param name="resource">Updated procedureType data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProthesisResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProthesisResource resource)
        {
            var procedureType = _mapper.Map<SaveProthesisResource, Prothesis>(resource);
            var result = await _procedureTypeService.UpdateAsync(id, procedureType);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<Prothesis, ProthesisResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

        /// <summary>
        /// Deletes a given procedureType according to an identifier.
        /// </summary>
        /// <param name="id">Prothesis identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProthesisResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _procedureTypeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<Prothesis, ProthesisResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

    }
}
