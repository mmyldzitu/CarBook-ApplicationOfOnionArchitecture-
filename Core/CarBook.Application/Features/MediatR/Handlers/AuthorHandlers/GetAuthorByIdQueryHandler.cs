using CarBook.Application.Features.MediatR.Queries.AuthorQueries;

using CarBook.Application.Features.MediatR.Results.AuthorResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Authors.MediatR.Handlers.AuthorHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _AuthorRepository;

        public GetAuthorByIdQueryHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _AuthorRepository.GetByIdAsync(request.AuthorId);
            if (entity != null)
            {

                return new GetAuthorByIdQueryResult { AuthorId = entity.AuthorId, AuthorName = entity.AuthorName, Description=entity.Description, ImageUrl=entity.ImageUrl };
            }
            return new GetAuthorByIdQueryResult();
        }
    }
}
