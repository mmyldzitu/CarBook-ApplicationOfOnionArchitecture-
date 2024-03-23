using CarBook.Application.Features.MediatR.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.BlogQueries
{
    public class GetBlogByIdQuery:IRequest<GetBlogByIdQueryResult>
    {
        public int BlogId { get; set; }

        public GetBlogByIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
