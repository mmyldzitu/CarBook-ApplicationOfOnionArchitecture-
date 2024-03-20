using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand:IRequest
    {
        public int testimonialId { get; set; }

        public RemoveTestimonialCommand(int testimonialId)
        {
            this.testimonialId = testimonialId;
        }
    }
}
