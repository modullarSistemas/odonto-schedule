using AutoMapper;
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
    public class FinancialService : IFinancialService
    {
        private readonly IInstallmentRepository _installmentRepository;
        private readonly ITreatmentRepository _treatmentRespository;
        private readonly IUnitOfWork _unitOfWork;


        public FinancialService( IInstallmentRepository installmentRepository, ITreatmentRepository treatmentRespository, IUnitOfWork unitOfWork)
        {
            _installmentRepository = installmentRepository;
            _treatmentRespository = treatmentRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InstallmentResponse> PayInstallment(int installmentId, PaymentMethod paymentMethod)
        {
            var installment = await _installmentRepository.FindByIdAsync(installmentId);

            if (installment == null)
                return new InstallmentResponse("Parcela não encontrada");

            installment.PaymentMethod = paymentMethod;
            installment.Payday = DateTime.Now;
            installment.UpdatedAt = DateTime.Now;

            _installmentRepository.Update(installment);
            await _unitOfWork.CompleteAsync();

            return new InstallmentResponse(installment);

        }



        public async Task<TreatmentResponse> GenerateInstallments(int treatmentId, GenerateInstallmentsResource resource)
        {
            if (resource.InstallmentDueDay > 25)
                return new TreatmentResponse("Dia de vencimento não pode passar do dia 25");

            if (resource.InstallmentQuantity > 36)
                return new TreatmentResponse("Numero máximo de parcelas não pode ser maior que 36");

            var existingTreatment = await _treatmentRespository.FindByIdTrackingAsync(treatmentId);

            if (existingTreatment == null)
                return new TreatmentResponse("Tratamento não encontrado.");

            if(existingTreatment.Status != TreatmentStatusEnum.AvaliacaoCompleta)
                return new TreatmentResponse("Parcelas ja foram geradas.");


            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, resource.InstallmentDueDay);
            try
            {

                double installmentCost = Math.Truncate(100 * ((existingTreatment.TotalCost + existingTreatment.ProthesisCost) / resource.InstallmentQuantity)) / 100;
                for (int i = 1; i <= resource.InstallmentQuantity; i++)
                {

                    existingTreatment.Installments.Add(
                        new Installment
                        {
                            Cost = installmentCost,
                            Due = date.AddMonths(i),

                        });

                }
                _treatmentRespository.Update(existingTreatment);

                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                return new TreatmentResponse($"Ocorreu um erro ao gerar o parcelas: {ex.Message}");
            }
        }

        public Task<IEnumerable<Installment>> GetLateInstallmentsByFranchiseId(int id)
        {
            throw new NotImplementedException();
        }




    }
}
