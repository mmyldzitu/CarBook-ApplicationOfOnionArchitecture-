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
    public class GetMostCountBrandQueryHandler : IRequestHandler<GetMostCountBrandQuery, GetMostCountBrandQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetMostCountBrandQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetMostCountBrandQueryResult> Handle(GetMostCountBrandQuery request, CancellationToken cancellationToken)
        {
            var brandName = await _statisticsRepository.GetMostCountBrand();
            return new GetMostCountBrandQueryResult { brandName = brandName };
        }
    }
}
