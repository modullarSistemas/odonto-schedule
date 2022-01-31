using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;
using System.Collections.Generic;

namespace PlanejaOdonto.Api.Domain.Models.PacientAggregate
{
    public class Pacient  
    {
        public int Id { get; set; }

        public int FranchiseId { get; set; }

        public Franchise Franchise{ get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string  CPF { get; set; } // tinytipe\

        public string Rg { get; set; }

        public string Gender { get; set; } 

        public Address Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Profession { get; set; }

        public string CivilState { get; set; }

        public IList<Dependent> Dependants { get; set; } = new List<Dependent>();

    }
}
