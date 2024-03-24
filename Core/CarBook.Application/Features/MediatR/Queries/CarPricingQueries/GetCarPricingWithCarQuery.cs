using CarBook.Application.Features.MediatR.Results.CarPricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.CarPricingQueries
{
    public class GetCarPricingWithCarQuery:IRequest<List<GetCarPricingWithCarQueryResult>>
    {
        public int PricingId { get; set; }

        public GetCarPricingWithCarQuery(int pricingId)
        {
            PricingId = pricingId;
        }
    }
}
