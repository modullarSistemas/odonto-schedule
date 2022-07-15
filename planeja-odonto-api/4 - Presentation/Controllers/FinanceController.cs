using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Controllers
{
    [Route("/api/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IFinancialService _financialService;
        private readonly IMapper _mapper;

        public FinanceController(IFinancialService financialService, IMapper mapper)
        {
            _financialService = financialService;
            _mapper = mapper;
        }


        /// <summary>
        /// Lists all incomes.
        /// </summary>
        /// <returns>List os expenses.</returns>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(IEnumerable<InstallmentResponse>), 200)]
        public async Task<IActionResult> PayInstallment(int installmentId, PaymentMethod paymentMethod)
        {
            var result = await _financialService.PayInstallment(installmentId, paymentMethod);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpPost("[action]/{treatmentId}")]
        [ProducesResponseType(typeof(IEnumerable<InstallmentResponse>), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GenerateInstalments(int treatmentId, [FromBody] GenerateInstallmentsResource resource)
        {
            var result = await _financialService.GenerateInstallments(treatmentId, resource);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


    }
}
