using AutoMapper;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Mapping
{
    public class UpdateProfile:Profile
    {
        public UpdateProfile()
        {

            CreateMap<Pacient, Pacient>()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Pacient, Address>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.PacientId, opt => opt.Ignore());

            CreateMap<Pacient, Dependent>()
                .ForMember(x => x.PacientId, opt => opt.Ignore());


        }
    }
}
