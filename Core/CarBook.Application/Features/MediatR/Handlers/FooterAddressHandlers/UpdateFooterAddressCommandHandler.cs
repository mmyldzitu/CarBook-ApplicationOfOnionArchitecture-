using CarBook.Application.Features.MediatR.Commands.FooterAddressCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.FooterAddressId);
            if (entity != null)
            {
                entity.Address = request.Address;
                entity.PhoneNumber=request.PhoneNumber;
                entity.Description=request.Description;
                entity.Email=request.Email;
                await _repository.UpdateAsync(entity);

            }
        }
    }
}
