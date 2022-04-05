using System;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class SaveSchedulingResource
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PacientId { get; set; }

        public int DentistId { get; set; }

        public int? ProcedureTypeId { get; set; }

        public int SchedulingType { get; set; }

        public int ScheduledBy { get; set; }

    }
}
