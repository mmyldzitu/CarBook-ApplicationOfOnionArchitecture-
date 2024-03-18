using CarBook.Application.Features.MediatR.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler:IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = new SocialMedia { IconUrl = request.IconUrl,Name=request.Name, Url=request.Url };
            await _socialMediaRepository.CreateAsync(entity);
        }
    }
}
