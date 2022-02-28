using PlanejaOdonto.Api.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class SaveSchedulingResource
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PacientId { get; set; }

        public int DentistId { get; set; }

        public int SchedulingType { get; set; }

        public int ScheduledBy { get; set; }

    }
}
