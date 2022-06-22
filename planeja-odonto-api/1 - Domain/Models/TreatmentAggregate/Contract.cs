using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Contract : BaseModel
    {
        public Treatment Treatment { get; set; }

        public int TreatmentId { get; set; }
    }
}
