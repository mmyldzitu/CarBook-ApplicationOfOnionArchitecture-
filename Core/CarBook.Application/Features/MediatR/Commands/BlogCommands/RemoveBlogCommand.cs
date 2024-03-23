using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Commands.BlogCommands
{
    public class RemoveBlogCommand:IRequest
    {
        public int BlogId { get; set; }

        public RemoveBlogCommand(int blogId)
        {
            BlogId = blogId;
        }
    }
}
