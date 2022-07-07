using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Services
{
    public interface IContractService
    {
        Task<ContractResponse> GetByTreatmentId(int id);
        Task<ContractResponse> SaveAsync(Contract contract);
        Task<ContractResponse> UpdateAsync(int id, Contract contract);
        Task<ContractResponse> DeleteAsync(int id);
    }
}
