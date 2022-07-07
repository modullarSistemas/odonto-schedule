using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class SaveTreatmentResource
    {
        public int PacientId { get; set; }
        public int DentistId { get; set; }
        public int TreatmentType { get; set; }
        public string Anamnesis { get; set; }
        public string Description { get; set; }
    }
}
