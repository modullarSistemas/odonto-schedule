using System;
using System.Collections.Generic;
using System.Text;

namespace PlanejaOdonto.Finance.ApiClient.Resource
{
    public class ComissionResource
    {
        public int Id { get; set; }

        public int DentistId { get; set; }

        public double Value { get; set; }

        public DateTime CreationDate { get; set; }

        public int InstallmentId { get; set; }

        public bool Paid { get; set; }
    }
}
