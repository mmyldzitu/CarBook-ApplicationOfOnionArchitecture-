using CarBook.Application.Features.MediatR.Commands.BlogCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.MediatR.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.BlogId);
            if (entity != null)
            {
                entity.Title   = request.Title;
                entity.CoverImg = request.CoverImg;
                entity.CategoryId = request.CategoryId;
                entity.CreateDate = request.CreateDate;
                entity.AuthorId = request.AuthorId;
                entity.Description=request.Description;
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
