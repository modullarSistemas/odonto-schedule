using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Domain.Services;
using AutoMapper;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Resources.Pacient;

namespace PlanejaOdonto.Api.Controllers
{
    [Route("/api/[controller]")]
    public class PacientController : ControllerBase
    {
        private readonly IPacientService _pacientService;
        private readonly IMapper _mapper;

        public PacientController(IPacientService pacientService, IMapper mapper)
        {
            _pacientService = pacientService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all pacients.
        /// </summary>
        /// <returns>List os pacients.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PacientResource>), 200)]
        public async Task<IEnumerable<PacientResource>> ListAsync()
        {
            var pacients = await _pacientService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Pacient>, IEnumerable<PacientResource>>(pacients);

            return resources;
        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PacientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pacientService.GetById(id);
            if (result == null)
                return BadRequest(new ErrorResource("Paciente nao encontrado"));

            var pacient = _mapper.Map<Pacient, PacientResource>(result);

            return Ok(pacient);
        }


        /// <summary>
        /// Saves a new Pacient.
        /// </summary>
        /// <param name="resource">Pacient data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PacientResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SavePacientResource resource)
        {


            var pacient = _mapper.Map<SavePacientResource, Pacient>(resource);
            var result = await _pacientService.SaveAsync(pacient);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var pacientResource = _mapper.Map<Pacient, PacientResource>(result.Resource);
            return Ok(pacientResource);


        }

        /// <summary>
        /// Updates an existing Pacient according to an identifier.
        /// </summary>
        /// <param name="id">Pacient identifier.</param>
        /// <param name="resource">Updated Pacient data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PacientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePacientResource resource)
        {
            var Pacient = _mapper.Map<SavePacientResource, Pacient>(resource);
            var result = await _pacientService.UpdateAsync(id, Pacient);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var pacientResource = _mapper.Map<Pacient, PacientResource>(result.Resource);
            return Ok(pacientResource);
        }


        /// <summary>
        /// Deletes a given Pacient according to an identifier.
        /// </summary>
        /// <param name="id">Pacient identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PacientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _pacientService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var pacientResource = _mapper.Map<Pacient, PacientResource>(result.Resource);
            return Ok(pacientResource);
        }

    }
}
