using CarBook.Application.Features.MediatR.Results.TestiomonialResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public int testimonialId { get; set; }

        public GetTestimonialByIdQuery(int testimonialId)
        {
            this.testimonialId = testimonialId;
        }
    }
}
