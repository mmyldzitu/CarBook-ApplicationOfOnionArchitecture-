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
    public class GetWeeklyAveragePriceQueryHandler : IRequestHandler<GetWeeklyAveragePriceQuery, GetWeeklyAveragePriceQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetWeeklyAveragePriceQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetWeeklyAveragePriceQueryResult> Handle(GetWeeklyAveragePriceQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetWeeklyAveragePrice();
            return new GetWeeklyAveragePriceQueryResult { price = value };
        }
    }
}
