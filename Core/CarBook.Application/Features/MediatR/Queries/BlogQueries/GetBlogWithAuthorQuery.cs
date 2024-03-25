using CarBook.Application.Features.MediatR.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.BlogQueries
{
    public class GetBlogWithAuthorQuery:IRequest<GetBlogWithAuthorQueryResult>
    {
        public int BlogId { get; set; }

        public GetBlogWithAuthorQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
