using PlanejaOdonto.Api.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Dentist
{
    public class SaveDentistResource
    {
        public string Name { get; set; }

        public int FranchiseId { get; set; }

        public int Category { get; set; }
    }
}
