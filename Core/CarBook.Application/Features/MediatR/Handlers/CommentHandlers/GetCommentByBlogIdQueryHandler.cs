using CarBook.Application.Features.MediatR.Queries.CommentQueries;
using CarBook.Application.Features.MediatR.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.CommentHandlers
{
    public class GetCommentByBlogIdQueryHandler : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
    {
       private readonly ICommentRepository _commentRepository;

        public GetCommentByBlogIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _commentRepository.GetCommentsByBlogId(request.blogId);
            return values.Select(x => new GetCommentByBlogIdQueryResult { BlogId = x.BlogId, CommentId = x.CommentId, CreateDate = x.CreateDate, Description = x.Description, Name = x.Name, blogName=x.Blog?.Title }).ToList();
        }
    }
}
