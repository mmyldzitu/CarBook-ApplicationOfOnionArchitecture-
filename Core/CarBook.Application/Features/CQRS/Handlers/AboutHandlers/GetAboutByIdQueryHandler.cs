using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutQueryResult> Handle(GetAboutByIdQuery query)
        {
            var entity = await _repository.GetByIdAsync(query.Id);
            if (entity != null)
            {
                return new GetAboutQueryResult
                {
                    AboutId = entity.AboutId,
                    Description = entity.Description,
                    ImageUrl = entity.ImageUrl,
                    Title = entity.Title,
                };

            }
            return new GetAboutQueryResult();
         

        }
    }
}
