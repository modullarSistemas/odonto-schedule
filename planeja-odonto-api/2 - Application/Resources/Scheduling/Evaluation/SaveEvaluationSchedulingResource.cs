using System;

namespace PlanejaOdonto.Api.Application.Resources
{
    public class SaveEvaluationSchedulingResource
    {
        public int FranchiseId { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int ScheduledBy { get; set; }

    }
}
