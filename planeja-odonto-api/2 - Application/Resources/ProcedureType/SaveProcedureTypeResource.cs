using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.ProcedureType
{
    public class SaveProcedureTypeResource
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public int TreatmentType { get; set; }
    }
}
