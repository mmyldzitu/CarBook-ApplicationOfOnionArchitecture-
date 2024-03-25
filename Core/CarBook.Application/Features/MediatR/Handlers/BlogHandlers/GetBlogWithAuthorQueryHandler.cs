using CarBook.Application.Features.MediatR.Queries.BlogQueries;
using CarBook.Application.Features.MediatR.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.BlogHandlers
{
    public class GetBlogWithAuthorQueryHandler : IRequestHandler<GetBlogWithAuthorQuery, GetBlogWithAuthorQueryResult>
    {
        private readonly IBlogRespository _blogRepository;

        public GetBlogWithAuthorQueryHandler(IBlogRespository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<GetBlogWithAuthorQueryResult> Handle(GetBlogWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _blogRepository.GetBlogWithAuthor(request.BlogId);
            if (entity != null)
            {
                return new GetBlogWithAuthorQueryResult
                {

                    AuthorDescription = entity.Author?.Description,
                    AuthorId = entity.AuthorId,
                    AuthorImg = entity.Author?.ImageUrl,
                    AuthorName = entity.Author?.AuthorName,
                    CategoryId = entity.CategoryId,


                    BlogId = entity.BlogId,
                    CoverImg = entity.CoverImg,
                    CreateDate = entity.CreateDate,
                    Title = entity.Title,


                    CategoryName = entity.Category?.Name,
                    Description = entity.Description

                };
            }
            return new GetBlogWithAuthorQueryResult();
        }
    }
}
