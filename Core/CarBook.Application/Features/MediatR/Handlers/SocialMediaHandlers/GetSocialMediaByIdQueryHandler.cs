using CarBook.Application.Features.MediatR.Queries.SocialMediaQueries;
using CarBook.Application.Features.MediatR.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _socialMediaRepository.GetByIdAsync(request.SocialMediaId);
            if (entity != null)
            {
                return new GetSocialMediaByIdQueryResult { IconUrl = entity.IconUrl, Id = entity.Id, Name = entity.Name, Url = entity.Url };
            }
            return new GetSocialMediaByIdQueryResult();
        }

    }
}
