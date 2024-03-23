using CarBook.Application.Features.MediatR.Commands.AuthorCommands;

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
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.AuthorId);
            if (entity != null)
            {
                entity.AuthorName= request.AuthorName;
                entity.ImageUrl= request.ImageUrl;
                entity.Description= request.Description;
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
