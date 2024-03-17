using CarBook.Application.Features.MediatR.Queries.FeatureQueries;
using CarBook.Application.Features.MediatR.Results.FeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _featureRepository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _featureRepository.GetByIdAsync(request.Id);
            if (entity != null)
            {

                return new GetFeatureByIdQueryResult { FeatureId = entity.FeatureId, FeatureName = entity.FeatureName };
            }
            return new GetFeatureByIdQueryResult();
        }
    }
}
