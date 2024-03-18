using CarBook.Application.Features.MediatR.Results.LocationResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.LocationQueries
{
    public class GetLocationByIdQuery:IRequest<GetLocationByIdQueryResult>
    {
        public int LocationId { get; set; }

        public GetLocationByIdQuery(int locationId)
        {
            LocationId = locationId;
        }
    }
}
