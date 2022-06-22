using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractService(IContractRepository contractRepository, IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Contract> GetById(int id)
        {
            var contract = await _contractRepository.FindByIdAsync(id);

            return contract;
        }

        public async Task<ContractResponse> SaveAsync(Contract contract)
        {
            try
            {
                await _contractRepository.AddAsync(contract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(contract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"Ocorreu um erro ao salvar o Contrato: {ex.Message}");
            }
        }

        public async Task<ContractResponse> UpdateAsync(int id, Contract updatedContract)
        {
            var existingContract = await _contractRepository.FindByIdAsync(id);

            if (existingContract == null)
                return new ContractResponse("Contrato não encontrado.");


            try
            {
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(existingContract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"Ocorreu um erro ao atualizar o Contrato: {ex.Message}");
            }
        }

        public async Task<ContractResponse> DeleteAsync(int id)
        {
            var existingContract = await _contractRepository.FindByIdAsync(id);

            if (existingContract == null)
                return new ContractResponse("Contrato não encontrado.");

            try
            {
                _contractRepository.Remove(existingContract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(existingContract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"Ocorreu um erro ao deletar o procedimento: {ex.Message}");
            }
        }

    }
}
