using CarBook.Application.Features.MediatR.Commands.LocationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public UpdateLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _locationRepository.GetByIdAsync(request.LocationId);
            if (entity != null)
            {
                entity.LocationName = request.LocationName;
                await _locationRepository.UpdateAsync(entity);  
            }
        }
    }
}
