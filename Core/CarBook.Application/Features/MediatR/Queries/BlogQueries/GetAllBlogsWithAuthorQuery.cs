using CarBook.Application.Features.MediatR.Results.BlogResults;
using MediatR;


namespace CarBook.Application.Features.MediatR.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery:IRequest<List<GetAllBlogsWithAuthorQueryResult>>
    {
    }
}
