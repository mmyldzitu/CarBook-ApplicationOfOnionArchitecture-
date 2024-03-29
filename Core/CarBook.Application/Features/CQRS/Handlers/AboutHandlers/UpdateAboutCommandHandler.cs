﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.AboutId);
            if(entity!=null)
            {
                entity.Title = command.Title;
                entity.Description = command.Description;
                entity.ImageUrl=command.ImageUrl;
                await _repository.UpdateAsync(entity);

            }
        }
    }
}
