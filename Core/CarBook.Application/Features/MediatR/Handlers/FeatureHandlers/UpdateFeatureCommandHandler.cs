using CarBook.Application.Features.MediatR.Commands.FeatureCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.FeatureId);
            if(entity!=null)
            {
                entity.FeatureName= request.FeatureName;
                await _repository.UpdateAsync   (entity);
            }
        }
    }
}
