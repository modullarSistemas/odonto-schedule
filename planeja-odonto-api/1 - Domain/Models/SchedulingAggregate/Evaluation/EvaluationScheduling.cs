using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.FranchiseeAggregate;
using System;

namespace PlanejaOdonto.Api.Domain.Models.SchedulingAggregate.Evaluation
{
    public class EvaluationScheduling : BaseModel
    {
        public int ScheduledBy { get; set; }

        public int FranchiseId { get; set; }

        public Franchise Franchise { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SchedulingStatus Status { get; set; }

    }
}
