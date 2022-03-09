using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System.Collections.Generic;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Treatment : BaseModel
    {
        public int PacientId { get; set; }

        public Pacient Pacient { get; set; }

        public string Description { get; set; }

        public int InstallmentQuantity { get; set; }

        public double TotalCost { get; set; }

        public int InstallmentDueDay { get; set; }

        public TreatmentStatusEnum Status { get; set; }

    }
}
