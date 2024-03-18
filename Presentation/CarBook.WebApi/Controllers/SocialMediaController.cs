using CarBook.Application.Features.MediatR.Commands.SocialMediaCommands;
using CarBook.Application.Features.MediatR.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController:ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialMedias()
        {
            var values = await _mediator.Send( new GetSocialMediaQuery() );
            return Ok( values );
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _mediator.Send( new GetSocialMediaByIdQuery(id) );
            return Ok( value ); 
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("SocialMedia Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("socialMedia Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send( new RemoveSocialMediaCommand(id) );
            return Ok("SocialMedia Bilgisi Silindi");
        }
    }
}
