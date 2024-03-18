using CarBook.Application.Features.MediatR.Commands.ServiceCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IRepository<Service> _serviceRepository;

        public CreateServiceCommandHandler(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Service { Description = request.Description ,  IconUrl= request.IconUrl, Title=request.Title};
            await _serviceRepository.CreateAsync    (entity);
        }
    }
}
