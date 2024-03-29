using CarBook.Application.Features.MediatR.Commands.CommentCommands;
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
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CommentId);
            if (entity != null)
            {
                entity.CreateDate = request.CreateDate;
                entity.Description=request.Description;
                entity.BlogId=request.BlogId;
                entity.Name=request.Name;
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
