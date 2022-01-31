using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.Treatment
{
    public class SaveTreatmentResource
    {
        public int PacientId { get; set; }

        public int InstallmentQuantity { get; set; }

        public int InstallmentDueDay { get; set; }
        //public List<SaveInstallmentResource> Installments { get; set; }
        //public double TotalValue { get; set; }

        public List<SaveProcedureResource> Procedures { get; set; }
    }
}
