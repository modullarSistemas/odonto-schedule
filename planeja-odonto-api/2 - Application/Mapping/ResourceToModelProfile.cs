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
            CreateMap<SaveExpenseResource, Expense>();

            CreateMap<IncomeResource, Income>();
            CreateMap<SaveIncomeResource, Income>();

            CreateMap<ExpenseGroupResource, ExpenseGroup>();
            CreateMap<SaveExpenseGroupResource, ExpenseGroup>();
        }

        private void MapFranchisee()
        {
            CreateMap<FranchiseeResource, Franchisee>();
            CreateMap<SaveFranchiseeResource, Franchisee>();


            CreateMap<FranchiseResource, Franchise>();
            CreateMap<SaveFranchiseResource, Franchise>();
        }

        private void MapScheduling()
        {
            CreateMap<SchedulingResource, Scheduling>()
                            .ForMember(src => src.SchedulingType, opt => opt.MapFrom(src => src.SchedulingType))
                            .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SaveSchedulingResource, Scheduling>()
                .ForMember(src => src.SchedulingType, opt => opt.MapFrom(src => (SchedulingType)src.SchedulingType));
        }

        private void MapTreatment()
        {
            CreateMap<ProcedureTypeResource, ProcedureType>();
            CreateMap<SaveProcedureTypeResource, ProcedureType>();

            CreateMap<SaveProcedureResource, Treatment>();
            CreateMap<SaveInstallmentResource, Treatment>();



            CreateMap<TreatmentResource, Treatment>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SaveTreatmentResource, Treatment>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => (SchedulingType)src.Status));

            CreateMap<InstallmentResource, Installment>()
                .ForMember(src => src.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod));

            CreateMap<SaveInstallmentResource, Installment>()
                .ForMember(src => src.PaymentMethod, opt => opt.MapFrom(src => (PaymentMethod)src.PaymentMethod));


            CreateMap<ProcedureResource, Procedure>();
            CreateMap<SaveProcedureResource, Procedure>();
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
    }
}
