using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using PlanejaOdonto.Api.Application.Resources;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class ProcedureTypeController : ControllerBase
    {
        private readonly IProcedureTypeService _procedureTypeService;
        private readonly IMapper _mapper;

        public ProcedureTypeController(IProcedureTypeService procedureTypeService, IMapper mapper)
        {
            _procedureTypeService = procedureTypeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all procedureTypes.
        /// </summary>
        /// <returns>List os procedureTypes.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListAsync()
        {
             var procedureTypes = await _procedureTypeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }

        /// <summary>
        /// Saves a new procedureType.
        /// </summary>
        /// <param name="resource">ProcedureType data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProcedureTypeResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProcedureTypeResource resource)
        {
            var procedureType = _mapper.Map<SaveProcedureTypeResource, ProcedureType>(resource);
            var result = await _procedureTypeService.SaveAsync(procedureType);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<ProcedureType, ProcedureTypeResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

        /// <summary>
        /// Updates an existing procedureType according to an identifier.
        /// </summary>
        /// <param name="id">ProcedureType identifier.</param>
        /// <param name="resource">Updated procedureType data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProcedureTypeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProcedureTypeResource resource)
        {
            var procedureType = _mapper.Map<SaveProcedureTypeResource, ProcedureType>(resource);
            var result = await _procedureTypeService.UpdateAsync(id, procedureType);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<ProcedureType, ProcedureTypeResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

        /// <summary>
        /// Deletes a given procedureType according to an identifier.
        /// </summary>
        /// <param name="id">ProcedureType identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProcedureTypeResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _procedureTypeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var procedureTypeResource = _mapper.Map<ProcedureType, ProcedureTypeResource>(result.Resource);
            return Ok(procedureTypeResource);
        }

    }
}
