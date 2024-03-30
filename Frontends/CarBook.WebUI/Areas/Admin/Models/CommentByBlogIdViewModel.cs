using CarBook.Dto.BlogDtos;
using CarBook.Dto.CommentDtos;

namespace CarBook.WebUI.Areas.Admin.Models
{
    public class CommentByBlogIdViewModel
    {
        public List<ResultCommentDto>? Comments { get; set; }
        public string? blogName { get; set; }
    }
}
