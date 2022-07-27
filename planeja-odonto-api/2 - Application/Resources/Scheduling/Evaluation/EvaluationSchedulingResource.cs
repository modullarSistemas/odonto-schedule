using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.Pacient;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using System;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class EvaluationSchedulingResource
    {
        public int Id { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }

        public string Description { get; set; }


        public int ScheduledBy { get; set; }

        public int FranchiseId { get; set; }

    }
}
