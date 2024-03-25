using CarBook.Application.Features.MediatR.Queries.TagCloudQueries;
using CarBook.Application.Features.MediatR.Results.TagCloudResults;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudInterface _tagCloudInterface;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudInterface tagCloudInterface)
        {
            _tagCloudInterface = tagCloudInterface;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _tagCloudInterface.GetTagCloudsByBlogId(request.BlogId);
            return values.Select(x => new GetTagCloudByBlogIdQueryResult { BlogId = x.BlogId, TagCloudId = x.TagCloudId, Title = x.Title }).ToList();
        }
    }
}
