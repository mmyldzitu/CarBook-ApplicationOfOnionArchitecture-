using CarBook.Application.Features.MediatR.Queries.LocationQueries;
using CarBook.Application.Features.MediatR.Results.LocationResults;
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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _locationRepository;

        public GetLocationByIdQueryHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _locationRepository.GetByIdAsync(request.LocationId);
            if (entity != null)
            {
                return new GetLocationByIdQueryResult { LocationId = entity.LocationId, LocationName = entity.LocationName };
            }
            return new GetLocationByIdQueryResult();
        }
    }
}
