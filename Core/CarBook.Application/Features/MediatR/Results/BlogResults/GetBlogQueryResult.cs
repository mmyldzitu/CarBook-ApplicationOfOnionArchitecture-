﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.MediatR.Results.BlogResults
{
    public class GetBlogQueryResult
    {
        public int BlogId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }

        public string? CoverImg { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
    }
}
