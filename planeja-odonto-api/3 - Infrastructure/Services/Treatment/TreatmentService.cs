using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
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

        public async Task<IEnumerable<Treatment>> ListByFranchiseIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListByFranchiseIdAsync(id);
            return treatments;
        }

        public async Task<IEnumerable<Treatment>> ListByPacientIdAsync(int id)
        {
            var treatments = await _treatmentRespository.ListByPacientIdAsync(id);
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
            var existingTreatment = await _treatmentRespository.FindByIdAsync(id);

            try
            {
                existingTreatment.Status = treatment.Status;
                existingTreatment.UpdatedAt = DateTime.Now;
                existingTreatment.Description = treatment.Description;
                existingTreatment.InstallmentDueDay = treatment.InstallmentDueDay;
                existingTreatment.InstallmentQuantity = treatment.InstallmentQuantity;
                existingTreatment.TotalCost =  treatment.TotalCost;
                
                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new TreatmentResponse($"Ocorreu um erro ao atualizar o agendamento: {ex.Message}");
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
                return new TreatmentResponse($"Ocorreu um erro ao deletar o agendamento: {ex.Message}");
            }
        }

        //private void GenerateInstallments(Treatment treatment)
        //{
        //    double installmentCost = Math.Truncate(100 * (treatment.TotalCost / treatment.InstallmentQuantity)) / 100;
        //    var date = DateTime.Now;
        //    for (int i = 0; i <= treatment.InstallmentQuantity; i++)
        //    {
        //        date.AddMonths(i + 1);
        //        treatment.Installments.Add(
        //            new Installment
        //            {
        //                Cost = installmentCost,
        //                Due = new DateTime(date.Year,date.Month , treatment.InstallmentDueDay),

        //            });

        //    }
        //}

        public async Task<List<Procedure>> GenerateProcedures(int treatmentId, List<Procedure> procedures)
        {
            var treatment = await _treatmentRespository.FindByIdAsync(treatmentId);

            foreach (var procedure in procedures)
            {
                var existingProcedure = await _procedureTypeRepository.FindByIdAsync(procedure.ProcedureTypeId);
                if (existingProcedure == null)
                    throw new Exception("Procedimento não está cadastrado no sistema.");

                if (procedure.NeedProthesis)
                {
                    var prothesis = await _prothesisRepository.FindByIdAsync(procedure.ProthesisId);
                    treatment.ProthesisCost += prothesis.Cost;
                }

                treatment.TotalCost += existingProcedure.Cost;
                procedure.TreatmentId = treatmentId;
                procedure.CreatedAt = DateTime.Now;
                await _procedureRepository.AddAsync(procedure);
                await _unitOfWork.CompleteAsync();
            }

            await UpdateAsync(treatmentId, treatment);

            return procedures;
        }

        public async Task<ProcedureResponse> FinalizeProcedure(int procedureId)
        {
            var procedure = await _procedureRepository.FindByIdAsync(procedureId);
            if (procedure == null)
                throw new Exception("Procedimento não está cadastrado no sistema.");

            procedure.Completed = true;
             _procedureRepository.Update(procedure);
            await _unitOfWork.CompleteAsync();

            return new ProcedureResponse(procedure);

        }



    }
}

