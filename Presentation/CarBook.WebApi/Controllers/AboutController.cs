using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _removeAboutCommandHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdHandler;

        public AboutController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutByIdQueryHandler getAboutByIdHandler, GetAboutQueryHandler getAboutQueryHandler, RemoveAboutCommandHandler removeAboutCommandHandler, UpdateAboutCommandHandler updateAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutByIdHandler = getAboutByIdHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _removeAboutCommandHandler = removeAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetAbout()
        {
            var values=await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await _getAboutByIdHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _removeAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("About Bilgisi Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand command)
        {
            await _createAboutCommandHandler.Handle(command);
            return Ok("About Bilgisi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update( UpdateAboutCommand command)
        {
            await _updateAboutCommandHandler.Handle(command);
            return Ok("About Bilgisi Güncellendi");
        }
    }
}
