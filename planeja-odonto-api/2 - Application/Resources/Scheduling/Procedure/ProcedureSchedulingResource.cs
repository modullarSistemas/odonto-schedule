using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.Pacient;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using System;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class ProcedureSchedulingResource
    {
        public int Id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public PacientResource Pacient{ get; set; }

        public DentistResource Dentist { get; set; }

        public ProcedureTypeResource ProcedureType { get; set; }

        public string SchedulingType { get; set; }

        public string Status { get; set; }

        public int ScheduledBy { get; set; }

    }
}
