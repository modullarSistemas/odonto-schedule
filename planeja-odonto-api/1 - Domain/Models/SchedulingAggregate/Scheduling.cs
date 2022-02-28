using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using PlanejaOdonto.Api.Domain.Models.Enums;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System;
using System.Text.Json.Serialization;

namespace PlanejaOdonto.Api.Domain.Models.SchedulingAggregate
{
    public class Scheduling : BaseModel
    {
        public DateTime StartDate{ get; set; }

        public DateTime EndDate{ get; set; }

        public int PacientId { get; set; }

        [JsonIgnore]
        public Pacient Pacient { get; set; }

        public int DentistId { get; set; }

        [JsonIgnore]
        public Dentist Dentist { get; set; }

        public int ScheduledBy { get; set; }

        public SchedulingType SchedulingType { get; set; }
    }
}
