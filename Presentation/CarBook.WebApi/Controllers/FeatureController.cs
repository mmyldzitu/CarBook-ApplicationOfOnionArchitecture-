using CarBook.Application.Features.MediatR.Commands.FeatureCommands;
using CarBook.Application.Features.MediatR.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController:ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFeatures()
        {
            var values = await _mediator.Send(new GetFeatureQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(int id)
        {
            var value = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Feature Bilgisi Güncellendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok("Feature Bilgisi Silindi");
        }
    }
}
