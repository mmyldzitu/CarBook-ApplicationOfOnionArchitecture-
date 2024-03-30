using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentDtos
{
    public class ResultCommentDto
    {



        public int commentId { get; set; }
        public string? name { get; set; }
        public DateTime createDate { get; set; }
        public string? description { get; set; }
        public string? blogName { get; set; }
        public int blogId { get; set; }


    }
}
