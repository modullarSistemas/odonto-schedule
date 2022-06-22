using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRespository;
        private readonly IProcedureTypeRepository _procedureTypeRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IPacientRepository _pacientRespository;
        private readonly IProthesisRepository _prothesisRepository;
        private readonly IUnitOfWork _unitOfWork;



        public TreatmentService(
              ITreatmentRepository treatmentRespository
            , IProcedureTypeRepository procedureTypeRepository
            , IProcedureRepository procedureRepository
            , IPacientRepository pacientRespository
            , IProthesisRepository prothesisRepository
            , IUnitOfWork unitOfWork)
        {
            _treatmentRespository = treatmentRespository;
            _procedureTypeRepository = procedureTypeRepository;
            _procedureRepository = procedureRepository;
            _pacientRespository = pacientRespository;
            _prothesisRepository = prothesisRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Treatment> GetByIdAsync(int id)
        {
            var treatment = await _treatmentRespository.FindByIdAsync(id);
            return treatment;
        }

        public async Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListByFranchiseIdAsync(id);
            return treatments;
        }


        public async Task<IEnumerable<Procedure>> ListProcedureByTreatmentIdAsync(int id)
        {
            var procedures = await _procedureRepository.ListByTreatmentIdAsync(id);
            return procedures;
        }

        public async Task<TreatmentResponse> SaveAsync(Treatment treatment)
        {
            try
            {
                var existingPacient = await _pacientRespository.FindByIdAsync(treatment.PacientId);
                if (existingPacient == null)
                    return new TreatmentResponse("Paciente não está cadastrado no sistema.");

                
                await _treatmentRespository.AddAsync(treatment);
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(treatment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TreatmentResponse($"An error occurred when saving the treatment: {ex.Message}");
            }
        }

        public async Task<TreatmentResponse> UpdateAsync(int id, Treatment treatment)
        {
            var existingTreatment = await _treatmentRespository.FindByIdTrackingAsync(id);

            try
            {
                existingTreatment.UpdatedAt = DateTime.Now;
                existingTreatment.Description = treatment.Description;
                existingTreatment.Anamnesis = treatment.Anamnesis;
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TreatmentResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
            }
        }


        public async Task<TreatmentResponse> UpdateStatusAsync(int id, TreatmentStatusEnum status)
        {
            var existingTreatment = await _treatmentRespository.FindByIdTrackingAsync(id);

            try
            {
                existingTreatment.Status = status;
                existingTreatment.UpdatedAt = DateTime.Now;
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TreatmentResponse($"Ocorreu um erro ao atualizar o Tratamento: {ex.Message}");
            }
        }



        public async Task<TreatmentResponse> DeleteAsync(int id)
        {
            var existingTreatment = await _treatmentRespository.FindByIdAsync(id);

            if (existingTreatment == null)
                return new TreatmentResponse("Tratamento não encontrado.");

            try
            {
                _treatmentRespository.Remove(existingTreatment);
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TreatmentResponse($"Ocorreu um erro ao deletar o Tratamento: {ex.Message}");
            }
        }



        public async Task<List<Procedure>> GenerateProcedures(int treatmentId, List<Procedure> procedures)
        {
            var treatment = await _treatmentRespository.FindByIdTrackingAsync(treatmentId);

            if (treatment == null)
                throw new Exception("Tratamento não cadastrado");

            foreach (var procedure in procedures)
            {
                var existingProcedure = await _procedureTypeRepository.FindByIdAsync(procedure.ProcedureTypeId);
                if (existingProcedure == null)
                    throw new Exception("Procedimento não está cadastrado no sistema.");

                if (procedure.NeedProthesis)
                {
                    var prothesis = await _prothesisRepository.FindByIdAsync((int)procedure.ProthesisId);
                    treatment.ProthesisCost += prothesis.Cost;
                }

                treatment.TotalCost += existingProcedure.Cost;
                procedure.TreatmentId = treatmentId;
                await _procedureRepository.AddAsync(procedure);
                await _unitOfWork.CompleteAsync();
            }

            await UpdateAsync(treatmentId, treatment);

            return procedures;
        }

        public async Task<ProcedureResponse> UpdateProcedureStatus(int procedureId,ProcedureStatusEnum status)
        {
            var procedure = await _procedureRepository.FindByIdAsync(procedureId);
            if (procedure == null)
                throw new Exception("Procedimento não está cadastrado no sistema.");

            procedure.Status = status;
            _procedureRepository.Update(procedure);
            await _unitOfWork.CompleteAsync();

            return new ProcedureResponse(procedure);

        }

        public async Task<IEnumerable<Treatment>> ListOrthodonticsByPacientIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListOrthodonticsByPacientIdAsync(id);
            return treatments;
        }

        public async Task<IEnumerable<Treatment>> ListGeneralClinicByPacientIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListGeneralClinicByPacientIdAsync(id);
            return treatments;
        }

        public async Task<IEnumerable<Treatment>> ListImplantologyByPacientIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListImplantologyByPacientIdAsync(id);
            return treatments;
        }

        public async Task<IEnumerable<Treatment>> ListFacialHarmonizationByPacientIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListFacialHarmonizationByPacientIdAsync(id);
            return treatments;
        }
    }
}

