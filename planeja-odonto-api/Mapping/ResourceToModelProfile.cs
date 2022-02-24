using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.Enums;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Resources.Dentist;
using PlanejaOdonto.Api.Resources.Finance;
using PlanejaOdonto.Api.Resources.Franchisee;
using PlanejaOdonto.Api.Resources.Login;
using PlanejaOdonto.Api.Resources.Pacient;
using PlanejaOdonto.Api.Resources.ProcedureType;
using PlanejaOdonto.Api.Resources.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Mapping
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
                            .ForMember(src => src.SchedulingType, opt => opt.MapFrom(src => src.SchedulingType));

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
