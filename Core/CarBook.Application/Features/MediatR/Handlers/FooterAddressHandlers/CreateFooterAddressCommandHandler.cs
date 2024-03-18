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
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public CreateFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new FooterAddress { 
            Address = request.Address,
            Description = request.Description,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            
            
            };
            await _footerAddressRepository.CreateAsync  (entity);
        }
    }
}
