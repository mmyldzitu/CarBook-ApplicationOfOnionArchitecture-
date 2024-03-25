using CarBook.Application.Features.MediatR.Commands.TagCloudCommands;
using CarBook.Application.Features.MediatR.Queries.TagCloudQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagCloudController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetTagClouds()
        {
            var values = await _mediator.Send( new GetTagCloudQuery() );
            return Ok( values );
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloud(int id)
        {
            var value= await _mediator.Send( new GetTagCloudByIdQuery(id) );
            return Ok( value );
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetTagCloudByBlogId(int id)
        {
            var value = await _mediator.Send(new GetTagCloudByBlogIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTagCloudCommand command)
        {
            await _mediator.Send(command);
            return Ok("TagCloud Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send( new RemoveTagCloudCommand(id) );
            return Ok("TagCloud Bilgisi Silindi");
        }
    }
}
