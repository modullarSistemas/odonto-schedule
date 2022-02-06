using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Extensions;
using PlanejaOdonto.Api.Resources;
using PlanejaOdonto.Api.Resources.Dentist;
using PlanejaOdonto.Api.Resources.Finance;
using PlanejaOdonto.Api.Resources.Franchisee;
using PlanejaOdonto.Api.Resources.Login;
using PlanejaOdonto.Api.Resources.Pacient;
using PlanejaOdonto.Api.Resources.ProcedureType;
using PlanejaOdonto.Api.Resources.Treatment;

namespace PlanejaOdonto.Api.Mapping
{

    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Scheduling, SchedulingResource>()
                .ForMember(src => src.SchedulingType,
                           opt => opt.MapFrom(src => src.SchedulingType.ToDescriptionString()));


            CreateMap<Scheduling, SaveSchedulingResource>()
                 .ForMember(src => src.SchedulingType,
                           opt => opt.MapFrom(src => src.SchedulingType.ToDescriptionString()));


            CreateMap<Franchisee, FranchiseeResource>();
            CreateMap<Franchisee, SaveFranchiseeResource>();


            CreateMap<Franchise, FranchiseResource>();
            CreateMap<Franchise, SaveFranchiseResource>();


            CreateMap<Pacient, PacientResource>();
            CreateMap<Pacient, SavePacientResource>();
            CreateMap<Pacient, SaveAddressResource>();
            CreateMap<Pacient, SaveDependentResource>();
            CreateMap<Address, SaveAddressResource>();
            CreateMap<Dependent, SaveDependentResource>();


            CreateMap<Dentist, DentistResource>()
                .ForMember(src => src.Category,
                           opt => opt.MapFrom(src => src.Category.ToDescriptionString()));

            CreateMap<Dentist, SaveDentistResource>()
                .ForMember(src => src.Category,
                           opt => opt.MapFrom(src => src.Category.ToDescriptionString()));


            CreateMap<ProcedureType, ProcedureTypeResource>();
            CreateMap<ProcedureType, SaveProcedureTypeResource>();


            CreateMap<Treatment, TreatmentResource>();
            CreateMap<Treatment, SaveTreatmentResource>();
            CreateMap<Treatment, SaveProcedureResource>();
            CreateMap<Treatment, SaveInstallmentResource>();


            CreateMap<Installment, InstallmentResource>()
                .ForMember(src => src.PaymentMethod,
                           opt => opt.MapFrom(src => src.PaymentMethod.ToDescriptionString()));

            CreateMap<Installment, SaveInstallmentResource>()
                .ForMember(src => src.PaymentMethod,
                           opt => opt.MapFrom(src => src.PaymentMethod.ToDescriptionString()));

            CreateMap<Procedure, ProcedureResource>();
            CreateMap<Installment, SaveProcedureResource>();


            CreateMap<User, UserResource>();
            CreateMap<User, SaveUserResource>();


            CreateMap<Expense, ExpenseResource>();
            CreateMap<Expense, SaveExpenseResource>();


            CreateMap<ExpenseGroup, ExpenseGroupResource>();
            CreateMap<ExpenseGroup, SaveExpenseGroupResource>();

            CreateMap<Income, IncomeResource>();
            CreateMap<Income, SaveIncomeResource>();



        }
    }

}
