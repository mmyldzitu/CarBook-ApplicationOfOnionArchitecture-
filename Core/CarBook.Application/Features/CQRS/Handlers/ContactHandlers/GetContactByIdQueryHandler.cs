using CarBook.Application.Features.CQRS.Queries.ContactQueries;
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
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactByIdQueryHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var entity = await _contactRepository.GetByIdAsync(query.Id);
            if (entity != null)
            {
                return new GetContactByIdQueryResult { Email = entity.Email, ContactId = entity.ContactId, Subject = entity.Subject, Message = entity.Message, SendDate = entity.SendDate, Name = entity.Name };
            }
            return new GetContactByIdQueryResult();
        }
        }
}
