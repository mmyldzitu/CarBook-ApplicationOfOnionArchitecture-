using CarBook.Application.Features.MediatR.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.BlogHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = new Blog { Title  = request.Title, CreateDate = request.CreateDate, AuthorId = request.AuthorId,CategoryId=request.CategoryId, CoverImg=request.CoverImg };
            await _repository.CreateAsync(entity);
        }
    }
}
