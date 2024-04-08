using CarBook.Application.Features.MediatR.Results.RentACarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.RentACarQueries
{
    public class GetRentACarQuery:IRequest<List<GetRentACarQueryResult>>
    {
        //public GetRentACarQuery(int locationId, bool available)
        //{
        //    this.locationId = locationId;
        //    Available = available;
        //}

        public int locationId { get; set; }
        public bool Available { get; set; }
    }
}
