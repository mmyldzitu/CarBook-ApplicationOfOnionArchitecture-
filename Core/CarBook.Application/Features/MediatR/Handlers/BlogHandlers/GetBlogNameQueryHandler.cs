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
    public class GetBlogNameQueryHandler : IRequestHandler<GetBlogNameQuery, GetBlogNameQueryResult>
    {
        private readonly IBlogRespository _blogRespository;

        public GetBlogNameQueryHandler(IBlogRespository blogRespository)
        {
            _blogRespository = blogRespository;
        }

        public async Task<GetBlogNameQueryResult> Handle(GetBlogNameQuery request, CancellationToken cancellationToken)
        {
            var blogName = await _blogRespository.ReturnBlogName(request.blogId);
            return new GetBlogNameQueryResult { blogName = blogName };
        }
    }
}
