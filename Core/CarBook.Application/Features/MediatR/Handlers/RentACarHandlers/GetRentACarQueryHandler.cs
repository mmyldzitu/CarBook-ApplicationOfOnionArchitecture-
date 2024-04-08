using CarBook.Application.Features.MediatR.Queries.RentACarQueries;
using CarBook.Application.Features.MediatR.Results.RentACarResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.RentACarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;
        private readonly ICarPricingRespository _carPricingRepository;

        public GetRentACarQueryHandler(IRentACarRepository repository, ICarPricingRespository carPricingRepository)
        {
            _repository = repository;
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            decimal amount = 0;
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.locationId && x.Available == request.Available);
            List<GetRentACarQueryResult> results = new();
            List<decimal> amounts = new List<decimal>();
            foreach( var value in values)
            {
                amount += await _carPricingRepository.GetCarDailyPricing(value.CarId);
                amounts.Add(amount);
                amount = 0;
            }
            for (int i= 0; i < values.Count; i++){
                GetRentACarQueryResult result = new();
                result.Amount = amounts[i];
                result.CoverImgUrl = values[i].Car?.CoverImgUrl;
                result.Brand = values[i].Car?.Brand?.BrandName;
                result.Model = values[i].Car?.Model;
                result.CarId = values[i].CarId;
                results.Add(result);
            }
            return results;
        }
    }
}
