using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.FinancialAggregate
{
    public class Expense
    {
        public int Id { get; set; }

        public int FranchiseId { get; set; }

        public Franchise Franchise { get; set; }

        public double Value { get; set; }

        public int ExpenseGroupId { get; set; }

        public ExpenseGroup ExpenseGroup { get; set; }

    }
}
 