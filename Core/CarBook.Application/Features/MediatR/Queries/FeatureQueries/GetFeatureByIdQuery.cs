using CarBook.Application.Features.MediatR.Results.FeatureResults;

using MediatR;


namespace CarBook.Application.Features.MediatR.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
