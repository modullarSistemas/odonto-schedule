using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.Contract;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Presentation.Controllers
{
    [Route("/api/[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(Contract), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GenerateContract([FromBody] SaveContractResource resources)
        {
            var contract = _mapper.Map<SaveContractResource, Contract>(resources);

            var result = await _contractService.SaveAsync(contract);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var contractResource = _mapper.Map<Contract, ContractResource>(result.Resource);

            return Ok(contractResource);
        }

        [HttpPut("[action]")]
        [Produces("application/pdf")]
        public async Task<IActionResult> GetContractPdfByTreatmentId(int treatmentId)
        {
            var result = await _contractService.GetByTreatmentId(treatmentId);

            var stream = new MemoryStream(result.Resource.DocumentFile);

            return  new FileStreamResult(stream, "application/pdf");
        }

    }
}
