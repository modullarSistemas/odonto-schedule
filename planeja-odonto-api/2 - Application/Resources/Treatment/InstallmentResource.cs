using System;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class InstallmentResource
    {

        public int Id { get; set; }

        public int TreatmentId { get; set; }

        public double Cost { get; set; }

        public DateTime Due { get; set; }

        public DateTime Payday { get; set; }

        public string PaymentMethod { get; set; }

    }
}
