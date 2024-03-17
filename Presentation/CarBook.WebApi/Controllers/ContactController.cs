using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController:ControllerBase
    {

        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        public ContactController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle( new Application.Features.CQRS.Queries.ContactQueries.GetContactByIdQuery(id) );
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return  Ok("Contact Bilgisi Eklendi"); ;
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi Güncellendi");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact Bilgisi Silindi");
        }
    }
}
