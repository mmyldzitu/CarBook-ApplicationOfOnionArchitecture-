using CarBook.Application.Features.MediatR.Results.CommentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.CommentQueries
{
    public class GetCommentByIdQuery:IRequest<GetCommentByIdQueryResult>
    {
        public int CommentId { get; set; }

        public GetCommentByIdQuery(int commentId)
        {
            CommentId = commentId;
        }
    }
}
