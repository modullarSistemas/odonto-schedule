using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public enum TreatmentStatusEnum
    {
        Pending = 1,
        EvaluationComplete = 2,
        InProgress = 3,
        Finished = 4
    }
}
