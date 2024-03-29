using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
        
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public string? Description { get; set; }
        public int BlogId { get; set; }
    }
}
