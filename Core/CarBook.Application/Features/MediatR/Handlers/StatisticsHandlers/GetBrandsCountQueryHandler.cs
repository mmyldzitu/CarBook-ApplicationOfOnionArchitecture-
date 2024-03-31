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
    public class GetBrandsCountQueryHandler : IRequestHandler<GetBrandsCountQuery, GetBrandsCountQueryResult>
    {
        private readonly IStatisticsRepository  _statisticsRepository;

        public GetBrandsCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetBrandsCountQueryResult> Handle(GetBrandsCountQuery request, CancellationToken cancellationToken)
        {
            var value = _statisticsRepository.GetBrandsCount();
            return new GetBrandsCountQueryResult { BrandCount = value };
        }
    }
}
