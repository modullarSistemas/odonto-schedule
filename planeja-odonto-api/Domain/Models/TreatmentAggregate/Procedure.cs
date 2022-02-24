using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Procedure : BaseModel
    {
        public int TreatmentId { get; set; }

        public int DentistId { get; set; }

        public int Tooth { get; set; }

        public Treatment Treatment { get; set; }

        public int ProcedureTypeId { get; set; }

        public ProcedureType ProcedureType { get; set; }



    }
}
