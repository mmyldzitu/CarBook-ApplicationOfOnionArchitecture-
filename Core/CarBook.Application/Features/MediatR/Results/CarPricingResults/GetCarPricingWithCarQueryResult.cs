using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.MediatR.Results.PricingResults;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarPricingId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal Amount { get; set; }
        public string? CoverImgUrl { get; set; }

    }
}
