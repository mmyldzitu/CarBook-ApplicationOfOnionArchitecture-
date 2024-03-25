using CarBook.Application.Features.MediatR.Queries.BlogQueries;
using CarBook.Application.Features.MediatR.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _BlogRepository;

        public GetBlogByIdQueryHandler(IRepository<Blog> BlogRepository)
        {
            _BlogRepository = BlogRepository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _BlogRepository.GetByIdAsync(request.BlogId);
            if (entity != null)
            {

                return new GetBlogByIdQueryResult { BlogId = entity.BlogId, Title = entity.Title, CategoryId = entity.CategoryId, CreateDate = entity.CreateDate , CoverImg=entity.CoverImg, AuthorId=entity.AuthorId,Description=entity.Description };
            }
            return new GetBlogByIdQueryResult();
        }
    }
}
