using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Pacient
{
    public class SavePacientResource
    {
        public string Name { get; set; }

        public int FranchiseId { get; set; }

        public DateTime BirthDate { get; set; }

        public string CPF { get; set; } // tinytipe\

        public string Rg { get; set; }

        public string Gender { get; set; }

        public SaveAddressResource Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Profession { get; set; }

        public string CivilState { get; set; }

        public IList<SaveDependentResource> Dependants { get; set; } = new List<SaveDependentResource>();
    }
}
