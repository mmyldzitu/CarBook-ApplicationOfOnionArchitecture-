using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.LocationResults
{
    public class GetLocationByIdQueryResult
    {
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
    }
}
