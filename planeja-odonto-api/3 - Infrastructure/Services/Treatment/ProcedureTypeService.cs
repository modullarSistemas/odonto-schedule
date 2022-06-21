using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;

namespace PlanejaOdonto.Api.Services
{
    public class ProcedureTypeService : IProcedureTypeService
    {
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureTypeService(IProcedureTypeRepository procedureTypeRepository, IUnitOfWork unitOfWork)
        {
            _procedureTypeRepository = procedureTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProcedureType>> ListAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListAsync();

            return procedureTypes;
        }

        public async Task<ProcedureType> GetById(int id)
        {
            var procedureType = await _procedureTypeRepository.FindByIdAsync(id);

            return procedureType;
        }

        public async Task<ProcedureTypeResponse> SaveAsync(ProcedureType procedureType)
        {
            try
            {
                await _procedureTypeRepository.AddAsync(procedureType);
                await _unitOfWork.CompleteAsync();

                return new ProcedureTypeResponse(procedureType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureTypeResponse($"Ocorreu um erro ao salvar o Procedimento: {ex.Message}");
            }
        }

        public async Task<ProcedureTypeResponse> UpdateAsync(int id, ProcedureType updatedProcedureType)
        {
            var existingProcedureType = await _procedureTypeRepository.FindByIdAsync(id);

            if (existingProcedureType == null)
                return new ProcedureTypeResponse("Procedimento não encontrado.");

            existingProcedureType.Name = updatedProcedureType.Name;
            existingProcedureType.Cost = updatedProcedureType.Cost;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new ProcedureTypeResponse(existingProcedureType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureTypeResponse($"Ocorreu um erro ao atualizar o Procedimento: {ex.Message}");
            }
        }

        public async Task<ProcedureTypeResponse> DeleteAsync(int id)
        {
            var existingProcedureType = await _procedureTypeRepository.FindByIdAsync(id);

            if (existingProcedureType == null)
                return new ProcedureTypeResponse("Procedimento não encontrado.");

            try
            {
                _procedureTypeRepository.Remove(existingProcedureType);
                await _unitOfWork.CompleteAsync();

                return new ProcedureTypeResponse(existingProcedureType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ProcedureTypeResponse($"Ocorreu um erro ao deletar o procedimento: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ProcedureType>> ListOrthodonticsAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListOrthodonticsAsync();

            return procedureTypes;
        }

        public async Task<IEnumerable<ProcedureType>> ListGeneralClinictAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListGeneralClinictAsync();

            return procedureTypes;
        }

        public async Task<IEnumerable<ProcedureType>> ListImplantologyAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListImplantologyAsync();

            return procedureTypes;
        }

        public async Task<IEnumerable<ProcedureType>> ListFacialHarmonizationAsync()
        {
            var procedureTypes = await _procedureTypeRepository.ListFacialHarmonizationAsync();

            return procedureTypes;
        }
    }
}
