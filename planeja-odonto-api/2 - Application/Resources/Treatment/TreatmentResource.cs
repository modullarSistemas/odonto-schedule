using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.Pacient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class TreatmentResource
    {
        public int Id { get; set; }

        public DentistResource Dentist { get; set; }

        public PacientResource Pacient { get; set; }

        public List<ProcedureResource> Procedures { get; set; }

        public List<InstallmentResource> Installments { get; set; }

        public string TreatmentType { get; set; }

        public string Description { get; set; }

        public double TotalCost { get; set; }

        public double ProthesisCost { get; set; }

        public string Anamnesis { get; set; }

        public string Status { get; set; }
    }
}
