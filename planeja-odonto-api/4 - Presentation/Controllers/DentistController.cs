using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources;

namespace PlanejaOdonto.Api.Presentation.Controllers
{
    [Route("/api/[controller]")]
    public class DentistController : ControllerBase
    {
        private readonly IDentistService _dentistService;
        private readonly IMapper _mapper;

        public DentistController(IDentistService dentistService, IMapper mapper)
        {
            _dentistService = dentistService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all dentists.
        /// </summary>
        /// <returns>List os dentists.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DentistResource>), 200)]
        public async Task<IEnumerable<DentistResource>> ListAsync()
        {
            var dentists = await _dentistService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Dentist>, IEnumerable<DentistResource>>(dentists);

            return resources;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DentistResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _dentistService.GetById(id);

            if (result == null)
                return BadRequest(new ErrorResource("Paciente nao encontrado"));

            var dentist = _mapper.Map<Dentist, DentistResource>(result);

            return Ok(dentist);
        }

        /// <summary>
        /// Saves a new Dentist.
        /// </summary>
        /// <param name="resource">Dentist data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(DentistResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveDentistResource resource)
        {

                var dentist = _mapper.Map<SaveDentistResource, Dentist>(resource);
                var result = await _dentistService.SaveAsync(dentist);

                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }

                var dentistResource = _mapper.Map<Dentist, DentistResource>(result.Resource);
                return Ok(dentistResource);

        }

        /// <summary>
        /// Updates an existing Dentist according to an identifier.
        /// </summary>
        /// <param name="id">Dentist identifier.</param>
        /// <param name="resource">Updated Dentist data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DentistResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDentistResource resource)
        {
            var Dentist = _mapper.Map<SaveDentistResource, Dentist>(resource);
            var result = await _dentistService.UpdateAsync(id, Dentist);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var dentistResource = _mapper.Map<Dentist, DentistResource>(result.Resource);
            return Ok(dentistResource);
        }

        /// <summary>
        /// Deletes a given Dentist according to an identifier.
        /// </summary>
        /// <param name="id">Dentist identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DentistResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _dentistService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var dentistResource = _mapper.Map<Dentist, DentistResource>(result.Resource);
            return Ok(dentistResource);
        }

    }
}
