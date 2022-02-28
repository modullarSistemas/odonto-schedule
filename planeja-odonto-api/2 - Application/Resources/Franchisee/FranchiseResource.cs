using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Franchisee
{
    public class FranchiseResource
    {
        public int Id { get; set; }

        public int FranchiseeId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string District { get; set; }
    }
}
