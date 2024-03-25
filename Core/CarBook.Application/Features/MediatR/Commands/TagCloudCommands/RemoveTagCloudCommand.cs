using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Commands.TagCloudCommands
{
    public class RemoveTagCloudCommand:IRequest
    {
        public int TagCloudId { get; set; }

        public RemoveTagCloudCommand(int tagCloudId)
        {
            TagCloudId = tagCloudId;
        }
    }
}
