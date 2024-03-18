using CarBook.Application.Features.MediatR.Commands.ServiceCommands;
using CarBook.Application.Features.MediatR.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController:ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Service Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send( new RemoveServiceCommand(id));
            return Ok("Service Bilgisi Silindi");
        }
    }
}
