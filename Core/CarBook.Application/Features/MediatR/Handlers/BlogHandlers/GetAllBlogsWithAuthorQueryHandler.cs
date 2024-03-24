using CarBook.Application.Features.MediatR.Queries.BlogQueries;
using CarBook.Application.Features.MediatR.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;


namespace CarBook.Application.Features.MediatR.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRespository _blogRepository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRespository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _blogRepository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResult
            {
                CategoryId = x.CategoryId,
                AuthorId = x.AuthorId,
                AuthorName = x.Author?.AuthorName,
                BlogId = x.BlogId,
                CoverImg = x.CoverImg,
                CreateDate = x.CreateDate,
                Title = x.Title,
                CategoryName=x.Category?.Name,





            }).ToList();
        }
    }
}
