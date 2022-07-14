using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.Finance;
using PlanejaOdonto.Api.Application.Resources.Franchisee;
using PlanejaOdonto.Api.Application.Resources.Login;
using PlanejaOdonto.Api.Application.Resources.Pacient;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Application.Resources.Prothesis;
using PlanejaOdonto.Api.Application.Resources.Contract;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Procedure;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation;

namespace PlanejaOdonto.Api.Application.Mapping
{
    public class ResourceToModelProfile : Profile
    {

        public ResourceToModelProfile()
        {
            MapScheduling();
            MapFranchisee();
            MapPacient();
            MapDentist();
            MapTreatment();
            MapLogin();
            MapFinancial();
            MapContract();

        }

        private void MapLogin()
        {
            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
            CreateMap<LoginResource, User>();
        }

        private void MapFinancial()
        {
            CreateMap<ExpenseResource, Expense>();
            CreateMap<ExpenseGroupResource, ExpenseGroup>();
            CreateMap<IncomeResource, Income>();

            CreateMap<SaveIncomeResource, Income>();
            CreateMap<SaveExpenseGroupResource, ExpenseGroup>();
            CreateMap<SaveExpenseResource, Expense>();

        }

        private void MapFranchisee()
        {
            CreateMap<FranchiseeResource, Franchisee>();
            CreateMap<FranchiseResource, Franchise>();


            CreateMap<SaveFranchiseeResource, Franchisee>();
            CreateMap<SaveFranchiseResource, Franchise>();
        }

        private void MapScheduling()
        {
            CreateMap<ProcedureSchedulingResource, ProcedureScheduling>()
                            .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SaveProcedureSchedulingResource, ProcedureScheduling>();


            CreateMap<EvaluationSchedulingResource, EvaluationScheduling>()
                            .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SaveEvaluationSchedulingResource, EvaluationScheduling>();
        }

        private void MapTreatment()
        {
            CreateMap<ProcedureTypeResource, ProcedureType>();
            CreateMap<ProcedureResource, Procedure>();
            CreateMap<GenerateInstallmentsResource, Treatment>();
            CreateMap<ProthesisResource, Prothesis>();
            CreateMap<InstallmentResource, Installment>()
                .ForMember(src => src.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod));
            CreateMap<TreatmentResource, Treatment>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType));


            CreateMap<SaveProthesisResource, Prothesis>();
            CreateMap<SaveProcedureResource, Treatment>();
            CreateMap<SaveProcedureResource, Procedure>();
            CreateMap<SaveProcedureTypeResource, ProcedureType>()
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => (TreatmentTypeEnum)src.TreatmentType));
            CreateMap<SaveTreatmentResource, Treatment>()
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => (TreatmentTypeEnum)src.TreatmentType));

        }

        private void MapDentist()
        {
            CreateMap<DentistResource, Dentist>()
                .ForMember(src => src.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<SaveDentistResource, Dentist>()
                .ForMember(src => src.Category, opt => opt.MapFrom(src => (SchedulingType)src.Category));
        }

        private void MapPacient()
        {
            CreateMap<PacientResource, Pacient>();
            CreateMap<SavePacientResource, Pacient>();
            CreateMap<SaveAddressResource, Pacient>();
            CreateMap<SaveDependentResource, Pacient>();
            CreateMap<SaveAddressResource, Address>();
            CreateMap<SaveDependentResource, Dependent>();
        }

        private void MapContract()
        {

            CreateMap<ContractResource,Contract>();
            CreateMap<SaveContractResource, Contract>();
        }
    }
}
