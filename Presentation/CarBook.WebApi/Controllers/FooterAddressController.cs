using CarBook.Application.Features.MediatR.Commands.FooterAddressCommands;
using CarBook.Application.Features.MediatR.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController:ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetFooterAddresses()
        {
            var values = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("FooterAddress Bilgisi Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("FooterAddress Bilgisi Güncellendi");
        }
    }
}
