using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class SaveTreatmentResource
    {
        public int PacientId { get; set; }

        public int InstallmentQuantity { get; set; }

        public int InstallmentDueDay { get; set; }

        public int Status { get; set; }
    }
}
