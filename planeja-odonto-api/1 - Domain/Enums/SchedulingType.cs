using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Enums
{
    public enum SchedulingType : byte
    {
        [Description("Avaliação")]

        Avaliacao = 1,

        [Description("Procedimento")]

        Procedimento = 2
    }
}
