using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejaOdonto.Finance.ApiClient.Resource.Income
{
    public class AddIncomeResource
    {
        public DateTime PaymentDate { get; set; }

        public double Value { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public int FranchiseId { get; set; }

    }
}
