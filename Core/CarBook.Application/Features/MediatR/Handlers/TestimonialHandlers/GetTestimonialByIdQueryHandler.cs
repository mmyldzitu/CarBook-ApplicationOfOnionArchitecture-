using CarBook.Application.Features.MediatR.Queries.TestimonialQueries;
using CarBook.Application.Features.MediatR.Results.TestiomonialResults;
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
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testiomanial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testiomanial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.testimonialId);
            if (entity != null)
            {
                return new GetTestimonialByIdQueryResult { Comment = entity.Comment, Id = entity.Id, ImageUrl = entity.ImageUrl, Name = entity.Name, Title = entity.Title };
            }
            return new GetTestimonialByIdQueryResult();
        }
    }
}
