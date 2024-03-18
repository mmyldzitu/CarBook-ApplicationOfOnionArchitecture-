using CarBook.Application.Features.MediatR.Queries.FooterAddressQueries;
using CarBook.Application.Features.MediatR.Results.FooterAddressResults;
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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.FooterAddressId);
            if(entity!=null)
            {
                return new GetFooterAddressByIdQueryResult
                {
                    Address = entity.Address,
                    Description = entity.Description,
                    Email = entity.Email,
                    FooterAddressId = request.FooterAddressId,
                    PhoneNumber = entity.PhoneNumber
                };
            }
            return new GetFooterAddressByIdQueryResult();
        }
    }
}
