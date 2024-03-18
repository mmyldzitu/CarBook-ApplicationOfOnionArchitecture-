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
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var entity= await _footerAddressRepository.GetByIdAsync(request.FooterAddressId);
            if(entity!=null)
            {
                await _footerAddressRepository.DeleteAsync(entity); 
            }
        }
    }
}
