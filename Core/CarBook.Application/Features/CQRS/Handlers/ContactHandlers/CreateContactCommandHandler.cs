﻿using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public CreateContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Handle(CreateContactCommand command)
        {
            var entity = new Contact
            {
                Email = command.Email,
                SendDate = command.SendDate,
                Subject = command.Subject,
                Message = command.Message,
                Name = command.Name,
            };
            await _contactRepository.CreateAsync(entity);

        }
    }
}
