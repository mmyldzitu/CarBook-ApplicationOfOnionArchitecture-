using CarBook.Application.Features.MediatR.Queries.ServiceQueries;
using CarBook.Application.Features.MediatR.Results.ServiceResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _serviceRepository;

        public GetServiceByIdQueryHandler(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _serviceRepository.GetByIdAsync(request.ServiceId);
            if (value!=null)
            {
            return  new GetServiceByIdQueryResult { Description=value.Description,Title=value.Title,IconUrl=value.IconUrl,ServiceId=value.ServiceId};

            }
            return new GetServiceByIdQueryResult();
        }
    }
}
