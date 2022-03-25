﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class TreatmentResource
    {
        public int Id { get; set; }

        public int PacientId { get; set; }

        public int InstallmentQuantity { get; set; }

        public List<ProcedureResource> Procedures { get; set; }

        public List<InstallmentResource> Installments { get; set; }

        public double TotalCost { get; set; }

        public double ProthesisCost { get; set; }

        public int InstallmentDueDay { get; set; }

        public string Anamnesis { get; set; }

        public string Status { get; set; }
    }
}
