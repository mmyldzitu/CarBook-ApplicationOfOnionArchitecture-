using CarBook.Application.Features.MediatR.Queries.PricingQueries;
using CarBook.Application.Features.MediatR.Results.PricingResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _pricingRepository;

        public GetPricingQueryHandler(IRepository<Pricing> pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            return values.Select(x=> new GetPricingQueryResult
            {
                PricingId=x.PricingId, PricingName=x.PricingName,
            }).ToList();
        }
    }
}
