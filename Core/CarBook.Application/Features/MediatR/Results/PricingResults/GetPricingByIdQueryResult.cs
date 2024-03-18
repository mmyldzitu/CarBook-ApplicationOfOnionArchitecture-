﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.PricingResults
{
    public class GetPricingByIdQueryResult
    {
        public int PricingId { get; set; }
        public string? PricingName { get; set; }
    }
}
