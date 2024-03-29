using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Commands.CommentCommands
{
    public class RemoveCommentCommand:IRequest
    {
        public int CommentId { get; set; }

        public RemoveCommentCommand(int commentId)
        {
            CommentId = commentId;
        }
    }
}
