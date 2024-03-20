using CarBook.Application.Features.MediatR.Commands.TestimonialCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testiomanial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testiomanial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = new Testiomanial { Comment = request.Comment, ImageUrl = request.ImageUrl, Name = request.Name, Title = request.Title };
            await _repository.CreateAsync(entity);
        }
    }
}
