using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Resources.ProcedureType
{
    public class SaveProcedureTypeResource
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public bool NeedProthesis { get; set; }
    }
}
