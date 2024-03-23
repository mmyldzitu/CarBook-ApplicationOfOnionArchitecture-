using CarBook.Application.Features.MediatR.Commands.AuthorCommands;
using CarBook.Application.Features.MediatR.Queries.AuthorQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var values = await _mediator.Send(new GetAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorCommand command)
        {
            await _mediator.Send(command);
            return Ok("Author Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveAuthorCommand(id));
            return Ok("Author Bilgisi Silindi");
        }
    }
}
