using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class SaveInstallmentResource
    {

        public double Cost { get; set; }

        public DateTime Due { get; set; }

        public DateTime Payday { get; set; }

        public int PaymentMethod { get; set; }
    }
}
