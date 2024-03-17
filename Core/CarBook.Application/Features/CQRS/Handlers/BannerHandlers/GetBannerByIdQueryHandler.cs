using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerQueryResult> Handle(GetBannerByIdQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity != null)
            {
                return new GetBannerQueryResult
                {
                    BannerId = entity.BannerId,
                    Description = entity.Description,
                    Title = entity.Title,
                    VideoDescription = entity.VideoDescription,
                    VideUrl = entity.VideUrl,


                };
            }
            return new GetBannerQueryResult();
        }
    }
}
