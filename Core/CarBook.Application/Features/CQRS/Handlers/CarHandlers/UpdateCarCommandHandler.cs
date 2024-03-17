using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand command)
        {

            var entity = await _repository.GetByIdAsync (command.CarId);
            if(entity!=null)
            {
                entity.Model = command.Model;
                entity.BigImgUrl = command.BigImgUrl;
                entity.BrandId = command.BrandId;
                entity.Seat = command.Seat;
                entity.Km = command.Km;
                entity.Luggage = command.Luggage;
                entity.Fuel = command.Fuel;
                entity.Transmission = command.Transmission;
                entity.CoverImgUrl = command.CoverImgUrl;
                await _repository.UpdateAsync (entity);

            }

        }
    }
}
