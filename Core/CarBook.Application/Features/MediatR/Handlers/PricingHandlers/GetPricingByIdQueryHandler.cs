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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            if (value!=null)
            {
                return new GetPricingByIdQueryResult { PricingId = value.PricingId, PricingName = value.PricingName };
            }
            return new GetPricingByIdQueryResult();
        }
    }
}
