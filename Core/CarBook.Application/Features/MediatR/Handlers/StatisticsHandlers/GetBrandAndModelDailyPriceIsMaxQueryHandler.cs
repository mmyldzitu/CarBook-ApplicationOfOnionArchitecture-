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
    public class GetBrandAndModelDailyPriceIsMaxQueryHandler : IRequestHandler<GetBrandAndModelDailyPriceIsMaxQuery, GetBrandAndModelDailyPriceIsMaxQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBrandAndModelDailyPriceIsMaxQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandAndModelDailyPriceIsMaxQueryResult> Handle(GetBrandAndModelDailyPriceIsMaxQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBrandAndModelDailyPriceIsMax();
            return new GetBrandAndModelDailyPriceIsMaxQueryResult { BrandAndModelName = value };
        }
    }
}
