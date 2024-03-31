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
    public class GetCarCountByElectricQueryHandler : IRequestHandler<GetCarCountByElectricQuery, GetCarCountByElectricQueryResult>
    {
        private readonly IStatisticsRepository  _statisticsRepository;

        public GetCarCountByElectricQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByElectricQueryResult> Handle(GetCarCountByElectricQuery request, CancellationToken cancellationToken)
        {
            var value =  _statisticsRepository.GetCarCountByElectric();
            return new GetCarCountByElectricQueryResult { CarCount = value };
        }
    }
}
