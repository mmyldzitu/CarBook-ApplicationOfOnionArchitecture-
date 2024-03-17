using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public UpdateBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task Handle(UpdateBrandCommand command)
        {
            var entity = await _brandRepository.GetByIdAsync(command.BrandId);
            if(entity != null) {
            
            entity.BrandName = command.BrandName;
                await _brandRepository.UpdateAsync(entity);
            }
        }
    }
}
