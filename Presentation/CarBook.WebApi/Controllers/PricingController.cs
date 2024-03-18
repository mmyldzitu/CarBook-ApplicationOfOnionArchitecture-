using CarBook.Application.Features.MediatR.Commands.PricingCommands;
using CarBook.Application.Features.MediatR.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController:ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPricings()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send( new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create( CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Pricing Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Pricing Bilgisi Silindi");
        }
    }
}
