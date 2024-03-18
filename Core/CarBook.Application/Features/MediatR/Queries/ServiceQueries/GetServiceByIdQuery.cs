using CarBook.Application.Features.MediatR.Results.ServiceResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.ServiceQueries
{
    public class GetServiceByIdQuery:IRequest<GetServiceByIdQueryResult>
    {
        public int ServiceId { get; set; }

        public GetServiceByIdQuery(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}
