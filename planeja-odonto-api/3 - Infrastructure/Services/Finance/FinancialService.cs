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

            AddDiscount(DateTime.Now,installment);

            installment.PaymentMethod = paymentMethod;
            installment.Payday = DateTime.Now;
            installment.UpdatedAt = DateTime.Now;

            _installmentRepository.Update(installment);
            await _unitOfWork.CompleteAsync();

            return new InstallmentResponse(installment);

        }

        private void AddDiscount(DateTime now, Installment installment)
        {
            if(now <= installment.Payday)
            {
                installment.Cost = installment.Cost * 0.95;
            }
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

            if(existingTreatment.Status == TreatmentStatusEnum.EmProgresso)
                return new TreatmentResponse("Parcelas ja foram geradas.");


            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, resource.InstallmentDueDay);
            try
            {
                IncludeInstallments(resource, existingTreatment, date);

                await _unitOfWork.CompleteAsync();

                return new TreatmentResponse(existingTreatment);
            }
            catch (Exception ex)
            {
                return new TreatmentResponse($"Ocorreu um erro ao gerar o parcelas: {ex.Message}");
            }
        }

        private void IncludeInstallments(GenerateInstallmentsResource resource, Treatment existingTreatment, DateTime date)
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
        }

        public Task<IEnumerable<Installment>> GetLateInstallmentsByFranchiseId(int id)
        {
            throw new NotImplementedException();
        }




    }
}
