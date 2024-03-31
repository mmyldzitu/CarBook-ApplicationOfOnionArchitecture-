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
    public class GetDailyAveragePriceQueryHandler : IRequestHandler<GetDailyAveragePriceQuery, GetDailyAveragePriceQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetDailyAveragePriceQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetDailyAveragePriceQueryResult> Handle(GetDailyAveragePriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetDailyAveragePrice();
            return new GetDailyAveragePriceQueryResult { price = value };
        }
    }
}
