using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            var entity = new Car
            {
                Model = command.Model,
                BigImgUrl = command.BigImgUrl,
                BrandId = command.BrandId,
                Seat = command.Seat,
                Km = command.Km,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                Transmission = command.Transmission,
                CoverImgUrl = command.CoverImgUrl,



            };
            await _repository.CreateAsync(entity);

        }
    }
}
