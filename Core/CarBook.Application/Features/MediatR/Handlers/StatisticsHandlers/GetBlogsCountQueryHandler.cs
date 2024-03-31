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
    public class GetBlogsCountQueryHandler : IRequestHandler<GetBlogsCountQuery, GetBlogsCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetBlogsCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async  Task<GetBlogsCountQueryResult> Handle(GetBlogsCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetBlogsCount();
            return new GetBlogsCountQueryResult { BlogCount = value };
        }
    }
}
