﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class ProcedureType : BaseModel
    {
        public string Name { get; set; }

        public double Cost { get; set; }

        public bool NeedProthesis { get; set; }

    }
}