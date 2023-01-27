using AutoMapper;
using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Application.Services;
using PlanejaOdonto.Api.Application.Services.Communication;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Domain.Repositories;
using PlanejaOdonto.Finance.ApiClient.Resource;
using PlanejaOdonto.Finance.ApiClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Infrastructure.Services
{
    public class FinancialService : IFinancialService
    {
        private readonly IInstallmentRepository _installmentRepository;
        private readonly ITreatmentRepository _treatmentRespository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDentistService _dentistService;
        private ComissionService _commissionService;
        public FinancialService(IInstallmentRepository installmentRepository, ITreatmentRepository treatmentRespository, IUnitOfWork unitOfWork, IDentistService dentistService)
        {
            _installmentRepository = installmentRepository;
            _treatmentRespository = treatmentRespository;
            _unitOfWork = unitOfWork;
            _dentistService = dentistService;
            _commissionService = new ComissionService("https://localhost:7138/api");
        }

        public async Task<InstallmentResponse> PayInstallment(int installmentId, PaymentMethod paymentMethod)
        {
            var installment = await _installmentRepository.FindByIdAsync(installmentId);

            if (installment == null)
                return new InstallmentResponse("Parcela não encontrada");

            //multiplicar valor acima pela comissao e adicionar a tabela de comissao(pensar em talvez outra maneira)
            //AddDiscount(DateTime.Now,installment);

            installment.PaymentMethod = paymentMethod;
            installment.Payday = DateTime.Now;
            installment.UpdatedAt = DateTime.Now;

            bool result = await CalculateComission(installment);

            if (!result)
                return new InstallmentResponse("Não foi possível realizar o pagamento da parcela");

            _installmentRepository.Update(installment);
            await _unitOfWork.CompleteAsync();

            return new InstallmentResponse(installment);

        }

        private async Task<bool> CalculateComission(Installment installment)
        {
            var percentageDictionary = GetDentistComissionPercentageComparedToTreatmentTotalValue(installment);

            foreach (var percentage in percentageDictionary)
            {
                var dentistComission = await _dentistService.GetById(percentage.Key);
                var comissionValue = (installment.Cost * (percentage.Value / 100)) * (dentistComission.Comission / 100);

                var response  = await _commissionService.AddComission(
                new SaveComissionResource { 
                     CreationDate = DateTime.UtcNow.AddHours(-3)
                    ,DentistId = percentage.Key
                    ,InstallmentId = installment.Id
                    ,Value = comissionValue 
                    ,FranchiseId = dentistComission.FranchiseId
                });
                if (response == null)
                    return false;
            }

            return true;
        }

        private Dictionary<int, double> GetDentistComissionPercentageComparedToTreatmentTotalValue(Installment installment)
        {
            var perDentistValueDictionary = installment.Treatment
                                                    .Procedures
                                                         .GroupBy(x => x.DentistId)
                                                         .ToDictionary(g => g.Key,
                                                                       g => g.Sum(v => v.ProcedureType.Cost));


            Dictionary<int, double> percentageDictionary = new Dictionary<int, double>();

            foreach (var item in perDentistValueDictionary)
            {
                var percentage = (int)Math.Round((double)(100 * item.Value) / installment.Treatment.TotalCost);

                percentageDictionary.Add(item.Key, percentage);
            }

            return percentageDictionary;
        }


        private void AddDiscount(DateTime now, Installment installment)
        {
            if (now <= installment.Payday)
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

            if (existingTreatment.Status == TreatmentStatusEnum.EmProgresso)
                return new TreatmentResponse("Parcelas ja foram geradas.");


            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, resource.InstallmentDueDay);
            try
            {
                IncludeInstallments(resource, existingTreatment, date);
                IncludeProthesisInstallments(resource, existingTreatment, date);


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
            double installmentCost = Math.Truncate(100 * ((existingTreatment.TotalCost) / resource.InstallmentQuantity)) / 100;
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



        private void IncludeProthesisInstallments(GenerateInstallmentsResource resource, Treatment existingTreatment, DateTime date)
        {
            if (existingTreatment.ProthesisCost == 0)
                return;

            double installmentCost = Math.Truncate(100 * ((existingTreatment.ProthesisCost) / resource.InstallmentQuantity)) / 100;
            for (int i = 1; i <= resource.InstallmentQuantity; i++)
            {

                existingTreatment.ProthesisInstallments.Add(
                    new ProthesisInstallment
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
