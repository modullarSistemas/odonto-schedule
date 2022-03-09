using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;

namespace PlanejaOdonto.Api.Services
{
    public class ProthesisService : IProthesisService
    {
        private readonly IProthesisRepository _procedureTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProthesisService(IProthesisRepository procedureTypeRepository, IUnitOfWork unitOfWork)
        {
            _procedureTypeRepository = procedureTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Prothesis>> ListAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListAsync();

            return procedureTypes;
        }

        public async Task<Prothesis> GetById(int id)
        {
            var procedureType = await _procedureTypeRepository.FindByIdAsync(id);

            return procedureType;
        }

        public async Task<ProthesisResponse> SaveAsync(Prothesis procedureType)
        {
            try
            {
                await _procedureTypeRepository.AddAsync(procedureType);
                await _unitOfWork.CompleteAsync();

                return new ProthesisResponse(procedureType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProthesisResponse($"Ocorreu um erro ao salvar o Procedimento: {ex.Message}");
            }
        }

        public async Task<ProthesisResponse> UpdateAsync(int id, Prothesis updatedProthesis)
        {
            var existingProthesis = await _procedureTypeRepository.FindByIdAsync(id);

            if (existingProthesis == null)
                return new ProthesisResponse("Prótese não encontrado.");

            existingProthesis.Name = updatedProthesis.Name;
            existingProthesis.Cost = updatedProthesis.Cost;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ProthesisResponse(existingProthesis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProthesisResponse($"Ocorreu um erro ao atualizar o Procedimento: {ex.Message}");
            }
        }

        public async Task<ProthesisResponse> DeleteAsync(int id)
        {
            var existingProthesis = await _procedureTypeRepository.FindByIdAsync(id);

            if (existingProthesis == null)
                return new ProthesisResponse("Procedimento não encontrado.");

            try
            {
                _procedureTypeRepository.Remove(existingProthesis);
                await _unitOfWork.CompleteAsync();

                return new ProthesisResponse(existingProthesis);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProthesisResponse($"Ocorreu um erro ao deletar o procedimento: {ex.Message}");
            }
        }
    }
}
