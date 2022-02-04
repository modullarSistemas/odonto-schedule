using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.Finance
{
    public class ExpenseResource
    {
        public int Id { get; set; }

        public int FranchiseId { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public int ExpenseGroupId { get; set; }

    }
}
