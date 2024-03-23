using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarsWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetLast5CarsWithBrandQueryResult>> Handle()
        {
            var values = await _carRepository.GetCarsTop5WithBrand();
            if (values.Count != 0)
            {
                return values.Select(x=> new GetLast5CarsWithBrandQueryResult {

                    CarId = x.CarId,
                    Brand = x.Brand?.BrandName,
                    Model = x.Model,
                    BigImgUrl = x.BigImgUrl,
                    BrandId = x.BrandId,
                    Seat = x.Seat,
                    Km = x.Km,
                    Luggage = x.Luggage,
                    Fuel = x.Fuel,
                    Transmission = x.Transmission,
                    CoverImgUrl = x.CoverImgUrl,

                }).ToList();
            }
            return new List<GetLast5CarsWithBrandQueryResult>();
        }
    }
}
