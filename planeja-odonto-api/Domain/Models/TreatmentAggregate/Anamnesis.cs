using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using PlanejaOdonto.Api.Domain.Models.TreatmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Anamnesis
    {
        public int Id { get; set; }

        public int TreatmentId { get; set; }

        [JsonIgnore]
        public Treatment Treatment { get; set; }

    }
}
