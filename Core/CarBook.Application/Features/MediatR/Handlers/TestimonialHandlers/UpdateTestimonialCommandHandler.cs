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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testiomanial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testiomanial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if(entity!=null)
            {
                entity.Title = request.Title;
                entity.Comment  = request.Comment;
                entity.Name = request.Name;
                entity.ImageUrl= request.ImageUrl;
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
