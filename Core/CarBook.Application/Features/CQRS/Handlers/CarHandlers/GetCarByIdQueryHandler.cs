using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {

            var value = await _repository.GetByIdAsync(query.Id);
            if (value != null)
            {

                return new GetCarByIdQueryResult
                {
                    CarId = value.CarId,
                    Model = value.Model,
                    BigImgUrl = value.BigImgUrl,
                    BrandId = value.BrandId,
                    Seat = value.Seat,
                    Km = value.Km,
                    Luggage = value.Luggage,
                    Fuel = value.Fuel,
                    Transmission = value.Transmission,
                    CoverImgUrl = value.CoverImgUrl,


                };



            }
            return new GetCarByIdQueryResult();

        }
    }
}
