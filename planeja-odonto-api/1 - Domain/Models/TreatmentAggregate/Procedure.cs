using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Procedure : BaseModel
    {
        public Treatment Treatment { get; set; }

        public int TreatmentId { get; set; }

        public Dentist Dentist{ get; set; }

        public int DentistId { get; set; }

        public int Tooth { get; set; }

        public int ProcedureTypeId { get; set; }

        public bool NeedProthesis { get; set; }

        public Prothesis Prothesis { get; set; }

        public ProcedureType ProcedureType { get; set; }

        public bool Completed { get; set; }
    }
}
