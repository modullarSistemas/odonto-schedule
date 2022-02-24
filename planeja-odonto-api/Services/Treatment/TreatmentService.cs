using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Api.Domain.Services;
using PlanejaOdonto.Api.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly ITreatmentRepository _treatmentRespository;
        private readonly IPacientRepository _pacientRespository;
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentService(ITreatmentRepository treatmentRespository, IPacientRepository pacientRespository, IUnitOfWork unitOfWork)
        {
            _treatmentRespository = treatmentRespository;
            _pacientRespository = pacientRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Treatment>> ListAsync()
        {
            var treatments = await _treatmentRespository.ListAsync();
            return treatments;
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

        //private async Task SetTreatmentTotalCost(Treatment treatment)
        //{
        //    foreach (var procedure in treatment.Procedures)
        //    {
        //        var existingProcedure = await _procedureTypeRepository.FindByIdAsync(procedure.ProcedureTypeId);
        //        if (existingProcedure == null)
        //            throw new Exception("Procedimento não está cadastrado no sistema.");

        //        treatment.TotalCost += existingProcedure.Cost;
        //    }

        //}

        //private void SetTreatmentInstallmentValue(Treatment treatment)
        //{
        //    double installmentCost = Math.Truncate(100 * (treatment.TotalCost / treatment.InstallmentQuantity)) / 100;
        //    int year = DateTime.Now.Year;
        //    int month = DateTime.Now.Month;
        //    for (int i = 1; i <= treatment.InstallmentQuantity; i++)
        //    {
        //        month++;
        //        treatment.Installments.Add(
        //            new Installment
        //            {
        //                Cost = installmentCost,
        //                Due = new DateTime(year, month, treatment.InstallmentDueDay),

        //            });

        //        if (month == 12)
        //        {
        //            year++;
        //            month = 0;
        //        }
        //    }
        //}
    }
}

