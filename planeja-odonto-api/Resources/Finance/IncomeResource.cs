using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.Finance
{
    public class IncomeResource
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }


        public int FranchiseId { get; set; }
    }
}
