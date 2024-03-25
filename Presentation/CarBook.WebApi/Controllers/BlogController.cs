using CarBook.Application.Features.MediatR.Commands.BlogCommands;
using CarBook.Application.Features.MediatR.Queries.BlogQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var values = await _mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLast3BlogsWithAuthor()
        {
            var values = await _mediator.Send(new GetLast3BlogsWithAuthorsQuery());
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllBlogsWithAuthor()
        {
            var values = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetBlogWithAuthor(int id)
        {
            var value = await _mediator.Send(new GetBlogWithAuthorQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand command)
        {
            await _mediator.Send(command);
            return Ok("Blog Bilgisi Güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog Bilgisi Silindi");
        }
    }
}
