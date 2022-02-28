using PlanejaOdonto.Api.Domain.Models.Enums;
using System;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class SchedulingResource
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PacientId { get; set; }

        public int DentistId { get; set; }

        public string SchedulingType { get; set; }

        public int ScheduledBy { get; set; }

    }
}
