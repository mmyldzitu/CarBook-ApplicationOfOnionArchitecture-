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
    public class GetBrandAndModelDailyPriceIsMinQueryHandler : IRequestHandler<GetBrandAndModelDailyPriceIsMinQuery, GetBrandAndModelDailyPriceIsMinQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBrandAndModelDailyPriceIsMinQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandAndModelDailyPriceIsMinQueryResult> Handle(GetBrandAndModelDailyPriceIsMinQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetBrandAndModelDailyPriceIsMin();
            return new GetBrandAndModelDailyPriceIsMinQueryResult { BrandAndModelName = value };
        }
    }
}
