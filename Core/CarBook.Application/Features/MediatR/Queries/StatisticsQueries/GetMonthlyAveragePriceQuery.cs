using CarBook.Application.Features.MediatR.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.StatisticsQueries
{
    public class GetMonthlyAveragePriceQuery:IRequest<GetMonthlyAveragePriceQueryResult>
    {
    }
}
