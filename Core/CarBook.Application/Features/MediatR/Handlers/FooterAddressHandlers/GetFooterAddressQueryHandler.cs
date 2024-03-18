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
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values=await _footerAddressRepository.GetAllAsync();
            return values.Select(x=> new GetFooterAddressQueryResult { Address=x.Address, Description=x.Description , Email=x.Email,FooterAddressId=x.FooterAddressId,PhoneNumber=x.PhoneNumber}).ToList();
        }
    }
}
