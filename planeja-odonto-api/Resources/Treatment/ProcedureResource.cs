using System;

namespace PlanejaOdonto.Api.Resources.Treatment
{
    public class ProcedureResource
    {
        public int Id { get; set; }

        public int Tooth { get; set; }

        public int TreatmentId { get; set; }

        public int ProcedureTypeId { get; set; }
 

    }
}
