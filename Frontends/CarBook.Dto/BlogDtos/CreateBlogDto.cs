using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.BlogDtos
{
    public class CreateBlogDto
    {
        
        public string? title { get; set; }
        public int authorId { get; set; }
        public string? authorName { get; set; }
        public string? coverImg { get; set; }
        public DateTime createDate { get; set; }
        public int categoryId { get; set; }
        public string? categoryName { get; set; }
        public string? Description { get; set; }
        public string? AuthorImg { get; set; }
        public string? AuthorDescription { get; set; }
    }
}
