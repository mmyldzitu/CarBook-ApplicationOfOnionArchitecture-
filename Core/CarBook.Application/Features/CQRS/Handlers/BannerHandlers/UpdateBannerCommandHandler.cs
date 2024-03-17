using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.BannerId);
            if(entity!=null) {
                entity.Title = command.Title;
                entity.Description=command.Description;
                entity.VideoDescription= command.VideoDescription;
                entity.VideUrl=command.VideUrl;
                
            await _repository.UpdateAsync(entity);
            
            }
        }
    }
}
