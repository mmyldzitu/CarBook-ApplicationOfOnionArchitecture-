using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactQueryHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _contactRepository.GetAllAsync();
            return values.Select(x=> new GetContactQueryResult { ContactId=x.ContactId, Email=x.Email,Message=x.Message,Subject=x.Subject,SendDate=x.SendDate,Name=x.Name}).ToList();   
        }
    }
}
