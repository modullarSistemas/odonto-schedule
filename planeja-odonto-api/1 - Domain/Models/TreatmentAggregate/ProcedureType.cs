using PlanejaOdonto.Api.Domain.Enums;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class ProcedureType : BaseModel
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public TreatmentTypeEnum TreatmentType { get; set; }

    }
}
