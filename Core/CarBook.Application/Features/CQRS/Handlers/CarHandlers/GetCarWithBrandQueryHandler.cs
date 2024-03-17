using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarsWithBrandQueryResult>> Handle()
        {
            var list = await _carRepository.GetCarsWithBrand();
            return list.Select(x => new GetCarsWithBrandQueryResult
            {
                CarId = x.CarId,
                Brand=x.Brand?.BrandName,
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
        
    }
}
