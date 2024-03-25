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
    public class GetLast3BlogsWiithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRespository _blogRepository;

        public GetLast3BlogsWiithAuthorsQueryHandler(IBlogRespository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetLast3BlogsWithAuthors();
            return values.Select(x=> new GetLast3BlogsWithAuthorsQueryResult {
            CategoryId = x.CategoryId,
            AuthorId = x.AuthorId,
            AuthorName=x.Author?.AuthorName,
            BlogId = x.BlogId,
            CoverImg= x.CoverImg,
            CreateDate = x.CreateDate,
            Title= x.Title,
            Description=x.Description,
            

            
            
            
            }).ToList();
        }
    }
}
