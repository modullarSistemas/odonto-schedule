using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.Treatment
{
    public class TreatmentResource
    {
        public int Id { get; set; }

        public int PacientId { get; set; }

        public List<InstallmentResource> Installments { get; set; }

        public List<ProcedureResource> Procedures { get; set; }

    }
}
