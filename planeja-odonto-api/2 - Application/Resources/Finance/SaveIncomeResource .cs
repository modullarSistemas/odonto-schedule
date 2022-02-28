﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanejaOdonto.Api.Application.Resources.Finance
{
    public class SaveIncomeResource
    {
        public double Value { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int FranchiseId { get; set; }
    }
}