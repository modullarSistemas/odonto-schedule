using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;

namespace PlanejaOdonto.Api.Domain.Models.FinancialAggregate
{
    public class Income : BaseModel
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int FranchiseId { get; set; }

        public Franchise Franchise { get; set; }

    }
}
