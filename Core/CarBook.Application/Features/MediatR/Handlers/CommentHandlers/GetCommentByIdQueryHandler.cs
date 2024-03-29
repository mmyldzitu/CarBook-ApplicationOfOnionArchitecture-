using CarBook.Application.Features.MediatR.Queries.CommentQueries;
using CarBook.Application.Features.MediatR.Results.CommentResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.CommentHandlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CommentId);
            if (entity != null)
            {
                return new GetCommentByIdQueryResult { BlogId = entity.BlogId, CommentId = entity.CommentId, CreateDate = entity.CreateDate, Description = entity.Description, Name = entity.Name };
            }
            return new GetCommentByIdQueryResult();
        }
    }
}
