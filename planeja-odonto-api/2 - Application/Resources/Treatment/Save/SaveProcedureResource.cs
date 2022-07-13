using PlanejaOdonto.Api.Application.Resources.Prothesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class SaveProcedureResource
    {
        public int DentistId { get; set; } 
        public int ProcedureTypeId { get; set; }
        public int? ProthesisId { get; set; }
        public int Tooth { get; set; }
        public bool NeedProthesis { get; set; }
        public bool Completed { get; set; }
    }
}
