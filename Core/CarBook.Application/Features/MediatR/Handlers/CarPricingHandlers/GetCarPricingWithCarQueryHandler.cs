using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.MediatR.Queries.CarPricingQueries;
using CarBook.Application.Features.MediatR.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRespository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRespository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carPricingRepository.GetCarPricings(request.PricingId);
            return values.Select(x => new GetCarPricingWithCarQueryResult
            {
                CarPricingId = x.CarPricingId,
                Brand = x.Car?.Brand?.BrandName,
                Amount = x.Amount,
                CoverImgUrl = x.Car?.CoverImgUrl,
                Model = x.Car?.Model,




            }).ToList();
        }
    }
}
