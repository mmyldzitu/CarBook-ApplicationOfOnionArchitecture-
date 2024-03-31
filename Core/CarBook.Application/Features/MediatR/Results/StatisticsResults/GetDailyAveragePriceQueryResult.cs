using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.StatisticsResults
{
    public class GetDailyAveragePriceQueryResult
    {
        public decimal price { get; set; }
    }
}
