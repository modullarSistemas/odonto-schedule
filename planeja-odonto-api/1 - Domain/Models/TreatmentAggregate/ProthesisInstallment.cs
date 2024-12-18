﻿using PlanejaOdonto.Api.Domain.Enums;
using System;

namespace PlanejaOdonto.Api.Domain.Models.TreatmentAggregate
{
    public class ProthesisInstallment : BaseModel
    {

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }

        public double Cost { get; set; }

        public DateTime Due { get; set; }

        public DateTime Payday { get; set; }

        public PaymentMethod PaymentMethod{ get; set; }
        

    }
}