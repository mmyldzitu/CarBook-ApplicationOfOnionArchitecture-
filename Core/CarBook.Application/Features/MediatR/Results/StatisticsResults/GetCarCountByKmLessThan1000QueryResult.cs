using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.StatisticsResults
{
    public class GetCarCountByKmLessThan1000QueryResult
    {
        public int CarCount { get; set; }
    }
}
