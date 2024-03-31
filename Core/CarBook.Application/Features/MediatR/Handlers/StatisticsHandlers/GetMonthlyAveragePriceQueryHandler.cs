using CarBook.Application.Features.MediatR.Queries.StatisticsQueries;
using CarBook.Application.Features.MediatR.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.StatisticsHandlers
{
    public class GetMonthlyAveragePriceQueryHandler : IRequestHandler<GetMonthlyAveragePriceQuery, GetMonthlyAveragePriceQueryResult>
    {
        private readonly IStatisticsRepository  _statisticsRepository;

        public GetMonthlyAveragePriceQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetMonthlyAveragePriceQueryResult> Handle(GetMonthlyAveragePriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetMonthlyAveragePrice();
            return new GetMonthlyAveragePriceQueryResult { price = value };
        }
    }
}
