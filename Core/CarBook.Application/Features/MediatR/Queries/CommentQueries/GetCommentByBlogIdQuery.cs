using CarBook.Application.Features.MediatR.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.CommentQueries
{
    public class GetCommentByBlogIdQuery:IRequest<List<GetCommentByBlogIdQueryResult>>
    {
        public int blogId { get; set; }

        public GetCommentByBlogIdQuery(int blogId)
        {
            this.blogId = blogId;
        }
    }
}
