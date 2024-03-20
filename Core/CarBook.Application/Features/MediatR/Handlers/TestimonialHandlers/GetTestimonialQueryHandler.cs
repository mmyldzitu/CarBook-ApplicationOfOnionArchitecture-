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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testiomanial> repository;

        public GetTestimonialQueryHandler(IRepository<Testiomanial> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult { Comment = x.Comment, Id = x.Id, ImageUrl = x.ImageUrl, Name = x.Name, Title = x.Title }).ToList();
        }
    }
}
