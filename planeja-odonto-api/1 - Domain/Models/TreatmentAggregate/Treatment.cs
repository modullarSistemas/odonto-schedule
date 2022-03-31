using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Treatment : BaseModel
    {
        public int PacientId { get; set; }

        [JsonIgnore]
        public Pacient Pacient { get; set; }

        [JsonIgnore]
        public List<Procedure> Procedures { get; set; }

        [JsonIgnore]
        public List<Installment> Installments { get; set; }

        public string Description { get; set; }

        public double TotalCost { get; set; }

        public double ProthesisCost { get; set; }

        public string Anamnesis { get; set; }

        public TreatmentStatusEnum Status { get; set; }

    }
}
