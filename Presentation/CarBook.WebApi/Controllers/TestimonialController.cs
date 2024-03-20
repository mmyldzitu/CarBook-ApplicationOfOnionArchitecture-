using CarBook.Application.Features.MediatR.Commands.TestimonialCommands;
using CarBook.Application.Features.MediatR.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTestimonials()
        {
            var values = await _mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonial(int id)
        {
            var value = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Testimonial Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send( new RemoveTestimonialCommand(id));
            return Ok("Testimonial Bilgisi Silindi");
        }
    }
}
