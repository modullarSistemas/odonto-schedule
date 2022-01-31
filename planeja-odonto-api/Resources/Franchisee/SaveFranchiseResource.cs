using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.Franchisee
{
    public class SaveFranchiseResource
    {
        public int FranchiseeId { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string District { get; set; }
    }
}
