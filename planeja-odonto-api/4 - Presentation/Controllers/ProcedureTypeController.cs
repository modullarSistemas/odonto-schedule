using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using System.Linq;

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


        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListAsync()
        {
            var procedureTypes = await _procedureTypeService.ListAsync();
            procedureTypes = procedureTypes.OrderBy(procedure => procedure.Name);
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }


        /// <summary>
        /// Lists all procedureTypes.
        /// </summary>
        /// <returns>List os procedureTypes.</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListGeneralClincAsync()
        {
            var procedureTypes = await _procedureTypeService.ListGeneralClinictAsync();
            procedureTypes = procedureTypes.OrderBy(procedure => procedure.Name);
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListOrthodonticsAsync()
        {
            var procedureTypes = await _procedureTypeService.ListOrthodonticsAsync();
            procedureTypes = procedureTypes.OrderBy(procedure => procedure.Name);
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListImplantologyAsync()
        {
            var procedureTypes = await _procedureTypeService.ListImplantologyAsync();
            procedureTypes = procedureTypes.OrderBy(procedure => procedure.Name);
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ProcedureTypeResource>), 200)]
        public async Task<IEnumerable<ProcedureTypeResource>> ListFacialHarmonizationAsync()
        {
            var procedureTypes = await _procedureTypeService.ListFacialHarmonizationAsync();
            procedureTypes = procedureTypes.OrderBy(procedure => procedure.Name);
            var resources = _mapper.Map<IEnumerable<ProcedureType>, IEnumerable<ProcedureTypeResource>>(procedureTypes);

            return resources;
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(ProcedureTypeResource), 200)]
        public async Task<ProcedureTypeResource> GetById(int id)
        {
            var procedureType = await _procedureTypeService.GetById(id);
            var resource = _mapper.Map<ProcedureType, ProcedureTypeResource>(procedureType);

            return resource;
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
