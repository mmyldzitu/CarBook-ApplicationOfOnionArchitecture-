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
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _serviceRepository;

        public GetServiceQueryHandler(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _serviceRepository.GetAllAsync();
            return values.Select(x=> new GetServiceQueryResult { ServiceId=x.ServiceId,Description=x.Description,IconUrl=x.IconUrl, Title=x.Title} ).ToList();
        }
    }
}
