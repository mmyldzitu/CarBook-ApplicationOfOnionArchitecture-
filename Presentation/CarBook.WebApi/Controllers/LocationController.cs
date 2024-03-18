using CarBook.Application.Features.MediatR.Commands.LocationCommands;
using CarBook.Application.Features.MediatR.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController:ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Location Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveLocationCommand(id));
            return Ok("Location Bilgisi Silindi");
        }
    }
}
