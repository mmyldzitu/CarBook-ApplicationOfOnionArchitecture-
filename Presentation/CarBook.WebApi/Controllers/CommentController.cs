using CarBook.Application.Features.MediatR.Commands.CommentCommands;
using CarBook.Application.Features.MediatR.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var values= await _mediator.Send( new GetCommentQuery() );  
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Comment Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Commment Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Comment Bilgisi Silindi");
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCommentByBlogId(int id)
        {
            var values=await _mediator.Send(new GetCommentByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
