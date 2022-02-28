using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.Enums
{
    public enum DentistCategory : byte
    {
        [Description("ClínicoGeral")]
        GeneralPractitioner = 1

    }
}
