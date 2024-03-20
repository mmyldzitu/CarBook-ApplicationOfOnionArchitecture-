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
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testiomanial> _repository;

        public RemoveTestimonialCommandHandler(IRepository<Testiomanial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.testimonialId);
            if (entity != null)
            {
                await _repository.DeleteAsync(entity);
            }
        }
    }
}
