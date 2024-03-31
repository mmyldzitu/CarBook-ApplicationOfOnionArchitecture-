using CarBook.Application.Features.MediatR.Queries.StatisticsQueries;
using CarBook.Application.Features.MediatR.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.StatisticsHandlers
{
    public class GetMostCommentBlogQueryHandler : IRequestHandler<GetMostCommentBlogQuery, GetMostCommentBlogQueryResult>
    {
        private readonly IStatisticsRepository  _statisticsRepository;

        public GetMostCommentBlogQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetMostCommentBlogQueryResult> Handle(GetMostCommentBlogQuery request, CancellationToken cancellationToken)
        {
            var value = await _statisticsRepository.GetMostCommentBlog();
            return new GetMostCommentBlogQueryResult { blogName = value };
        }
    }
}
