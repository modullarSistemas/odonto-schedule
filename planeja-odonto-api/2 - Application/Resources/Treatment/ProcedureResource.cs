﻿using PlanejaOdonto.Api.Application.Resources.Dentist;
using PlanejaOdonto.Api.Application.Resources.ProcedureType;
using PlanejaOdonto.Api.Application.Resources.Prothesis;
using System;

namespace PlanejaOdonto.Api.Application.Resources.Treatment
{
    public class ProcedureResource
    {
        public int Id { get; set; }

        public int TreatmentId { get; set; }

        public int Tooth { get; set; }

        public bool NeedProthesis { get; set; }

        public bool Completed { get; set; }

        public ProthesisResource Prothesis { get; set; }

        public ProcedureTypeResource ProcedureType { get; set; }

        public DentistResource Dentist { get; set; }



    }
}
