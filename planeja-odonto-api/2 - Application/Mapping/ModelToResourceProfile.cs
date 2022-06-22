using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.FinancialAggregate;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using PlanejaOdonto.Api.Domain.Models.LoginAggregate;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.SchedulingAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using PlanejaOdonto.Api.Extensions;
using PlanejaOdonto.Api.Application.Resources;
using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.Finance;
using PlanejaOdonto.Api.Application.Resources.Franchisee;
using PlanejaOdonto.Api.Application.Resources.Login;
using PlanejaOdonto.Api.Application.Resources.Pacient;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using PlanejaOdonto.Api.Application.Resources.Treatment;
using PlanejaOdonto.Api.Application.Resources.Prothesis;
using PlanejaOdonto.Api.Application.Resources.Contract;

namespace PlanejaOdonto.Api.Application.Mapping
{

    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Scheduling, SchedulingResource>()
                .ForMember(src => src.SchedulingType, opt => opt.MapFrom(src => src.SchedulingType.ToDescriptionString()))
                .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status.ToDescriptionString()));


            CreateMap<Scheduling, SaveSchedulingResource>()
                 .ForMember(src => src.SchedulingType, opt => opt.MapFrom(src => src.SchedulingType.ToDescriptionString()));

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


            CreateMap<ProcedureType, ProcedureTypeResource>()
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType.ToDescriptionString()));


            CreateMap<ProcedureType, SaveProcedureTypeResource>()
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType.ToDescriptionString()));

            CreateMap<Prothesis, ProthesisResource>();
            CreateMap<Prothesis, SaveProthesisResource>();


            CreateMap<Treatment, TreatmentResource>()
                .ForMember(src => src.Status, opt => opt.MapFrom(src => src.Status.ToDescriptionString()))
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType.ToDescriptionString()));


            CreateMap<Treatment, SaveTreatmentResource>()
                .ForMember(src => src.TreatmentType, opt => opt.MapFrom(src => src.TreatmentType.ToDescriptionString()));





            CreateMap<Installment, InstallmentResource>()
                .ForMember(src => src.PaymentMethod,
                           opt => opt.MapFrom(src => src.PaymentMethod.ToDescriptionString()));

            CreateMap<Procedure, ProcedureResource>();
            CreateMap<Procedure, SaveProcedureResource>();


            CreateMap<User, UserResource>();
            CreateMap<User, SaveUserResource>();


            CreateMap<Expense, ExpenseResource>();
            CreateMap<Expense, SaveExpenseResource>();


            CreateMap<ExpenseGroup, ExpenseGroupResource>();
            CreateMap<ExpenseGroup, SaveExpenseGroupResource>();

            CreateMap<Income, IncomeResource>();
            CreateMap<Income, SaveIncomeResource>();

            CreateMap<Contract, ContractResource>();
            CreateMap<Contract, SaveContractResource>();


        }
    }

}
