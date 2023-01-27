using System;

namespace PlanejaOdonto.Finance.ApiClient.Resource
{
    public class SaveComissionResource
    {
        public int DentistId { get; set; }

        public int FranchiseId { get; set; }

        public double Value { get; set; }

        public DateTime CreationDate { get; set; }

        public int InstallmentId { get; set; }
    }
}
