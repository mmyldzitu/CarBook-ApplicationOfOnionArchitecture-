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
    public class GetCarCountByGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByGasolineOrDieselQuery, GetCarCountByGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetCarCountByGasolineOrDieselQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetCarCountByGasolineOrDieselQueryResult> Handle(GetCarCountByGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value =  _statisticsRepository.GetCarCountByGasolineOrDiesel();
            return new GetCarCountByGasolineOrDieselQueryResult { CarCount = value };
        }
    }
}
