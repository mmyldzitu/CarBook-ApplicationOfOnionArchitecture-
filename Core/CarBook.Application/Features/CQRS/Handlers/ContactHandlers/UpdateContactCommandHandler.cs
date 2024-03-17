using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var entity = await _contactRepository.GetByIdAsync(command.ContactId);
            if (entity != null)
            {

                entity.Subject = command.Subject;
                entity.SendDate = command.SendDate;
                entity.Name = command.Name;
                entity.Message = command.Message;
                entity.Email = command.Email;
                await _contactRepository.UpdateAsync(entity);
            }
        }
    }
}
