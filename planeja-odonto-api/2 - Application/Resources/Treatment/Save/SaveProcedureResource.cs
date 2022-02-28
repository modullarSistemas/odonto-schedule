using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class SaveProcedureResource
    {
        public int Tooth { get; set; }

        public int ProcedureTypeId { get; set; }
    }
}
