using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITreatmentRepository _treatmentRepository;

        public ContractService(IContractRepository contractRepository, IUnitOfWork unitOfWork, ITreatmentRepository treatmentRepository)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
            _treatmentRepository = treatmentRepository;
        }

        public async Task<ContractResponse> GetByTreatmentId(int id)
        {
            var contract = await _contractRepository.FindByTreatmentIdAsync(id);

            if (contract==null)
                return new ContractResponse("Contrato não encontrado.");

            return new ContractResponse(contract);
        }

        public async Task<ContractResponse> SaveAsync(Contract contract)
        {
            try
            {
                var existingTreatment = await _treatmentRepository.FindByIdAsync(contract.TreatmentId);

                if (existingTreatment == null)
                    return new ContractResponse("Tratamento não existe");

                var existingContract = await _contractRepository.FindByTreatmentIdAsync(contract.TreatmentId);

                if (existingContract != null)
                    return new ContractResponse("Contrato ja foi gerado para o tratamento.");

                GenerateContractPdf(contract);

                await _contractRepository.AddAsync(contract);
                await _unitOfWork.CompleteAsync();

                return new ContractResponse(contract);
            }
            catch (Exception ex)
            {
                return new ContractResponse($"Ocorreu um erro ao salvar o Contrato: {ex.Message}");
            }
        }

        private static void GenerateContractPdf(Contract contract)
        {
            var uri = "http://localhost:3000/api/";
            var client = new RestClient(uri);
            var request = new RestRequest("GenerateGeneralPracticionerContract", Method.Get);

            byte[] byteArray = client.DownloadData(request);

            contract.DocumentFile = byteArray;
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
