using PlanejaOdonto.Api.Domain.Models.PacientAggregate;
using System.Collections.Generic;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Treatment
    {
        public int Id { get; set; }

        public int PacientId { get; set; }

        public Pacient Pacient { get; set; }

        public Anamnesis Anamnesis { get; set; }

        public int InstallmentQuantity { get; set; }

        public double TotalCost { get; set; }

        public int InstallmentDueDay { get; set; }

        public TreatmentStatusEnum Status { get; set; }

        public IList<Installment> Installments { get; set; } = new List<Installment>();

        public IList<Procedure> Procedures { get; set; } = new List<Procedure>();
    }
}
