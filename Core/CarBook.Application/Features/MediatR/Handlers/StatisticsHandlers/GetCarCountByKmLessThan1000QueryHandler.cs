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
    public class GetCarCountByKmLessThan1000QueryHandler : IRequestHandler<GetCarCountByKmLessThan1000Query, GetCarCountByKmLessThan1000QueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByKmLessThan1000QueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByKmLessThan1000QueryResult> Handle(GetCarCountByKmLessThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetCarCountByKmLessThan1000();
            return new GetCarCountByKmLessThan1000QueryResult { CarCount = value };
        }
    }
}
