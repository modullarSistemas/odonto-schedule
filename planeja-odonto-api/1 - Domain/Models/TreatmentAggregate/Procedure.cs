﻿using PlanejaOdonto.Api.Domain.Enums;
using PlanejaOdonto.Api.Domain.Models.DentistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class Procedure : BaseModel
    {
        [JsonIgnore]
        public Treatment Treatment { get; set; }

        public int TreatmentId { get; set; }

        [JsonIgnore]
        public Dentist Dentist { get; set; }

        public int DentistId { get; set; }

        public int Tooth { get; set; }

        public string Description { get; set; }

        public bool NeedProthesis { get; set; }

        public int? ProthesisId { get; set; }

        public Prothesis? Prothesis { get; set; }

        public int ProcedureTypeId { get; set; }

        public ProcedureType ProcedureType { get; set; }

        public ProcedureStatusEnum Status { get; set; }
    }
}
