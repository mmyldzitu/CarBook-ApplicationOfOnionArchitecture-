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
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
    {private readonly IRepository<Location> _locationRepository;

        public RemoveLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _locationRepository.GetByIdAsync(request.LocationId);
            if (entity != null)
            {
                await _locationRepository.DeleteAsync   (entity);
            }
        }
    }
}
